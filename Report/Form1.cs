using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Report
{
   

    public partial class Reports : Form
    {
        int CurrentMonth;
        int CurrentYear;
        //string[] Title = { "订单号", "客户名称", "印品名称", "销售价格", "计算价格", "不含CTP印工", "产品数量", "纸张价格", "CTP价格", "后道价格", "成本合计", "材料清单" };
       
        public Reports()
        {
            InitializeComponent();
            CurrentMonth = dateTimePicker1.Value.Month;
            comboBox1.Items.Add("自接业务");
            comboBox1.Items.Add("业务部");
            //comboBox1.Items.Add("全部");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Select = 0;
            Select = comboBox1.SelectedIndex;
            if (Select == 0)
            {
                Calzijie();
            }
            if (Select == 1)
            {
                Calyewubu();
            }
        }
        void Calzijie()
        {
            this.Cursor = Cursors.WaitCursor;
            CurrentMonth = dateTimePicker1.Value.Month;
            CurrentYear = dateTimePicker1.Value.Year;
            List<Model.P_Order> order = Model.P_Order.GetMonthOrder(dateTimePicker1.Value);
            if (order != null)
            {
                string pubno1 = order[0].OrderOn.Replace("O", "PUB");
                string pubno2 = order[order.Count - 1].OrderOn.Replace("O", "PUB");
                List<Model.P_MaterialList2> paper = Model.P_MaterialList2.GetDataList(" OrderOn>='" + pubno1 + "' and OrderOn<='" + pubno2 + "'");
                List<Model.P_ProcessList2> process = Model.P_ProcessList2.GetDataList(" OrderOn>='" + pubno1 + "' and OrderOn<='" + pubno2 + "'");
                List<Model.P_ProductList> product = Model.P_ProductList.GetDataList(" ListCode>='" + pubno1 + "' and ListCode<='" + pubno2 + "'");
                List<string> Title = DataSource.ORMHelper.GetColumnsName(typeof(Model.reportitem));
                dataGridView1.Columns.Clear();
              

                List<Model.reportitem> report = new List<Model.reportitem>();
                List<Model.reportitem> Over30 = new List<Model.reportitem>();
                List<Model.reportitem> Low = new List<Model.reportitem>();

                decimal AllSale = 0;
                decimal AllCal = 0;
                decimal AllPaper = 0;
                decimal AllCtp = 0;
                decimal AllNoCtp = 0;
                decimal AllProcess = 0;
                decimal AllDouble = 0;
                decimal AllPrint = 0;
                //decimal AllMoney = 0;
                decimal AllColor = 0;
                decimal AllBlack = 0;
                int index = 0;

                for (int j = 0; j < order.Count; j++)
                {
                    index++;
                    Model.reportitem rp = new Model.reportitem();
                    rp.P_order = order[j].b2;
                    rp.No = index;
                    rp.Num = 0;
                    rp.Customer = order[j].Receiver;
                    if (rp.Customer.LastIndexOf("业务部")>=0)
                    {
                        continue;
                    }
                    rp.SalePrice = order[j].Price;
                    rp.Days = order[j].OrderTime.Day;
                    decimal paperprice = 0;
                    decimal ctpprice = 0;
                    decimal calprice = 0;
                    decimal printprice = 0;
                    decimal processprice = 0;
                    int lailiaocount = 0;
                    string remark = "";
                    string pubno = order[j].OrderOn.Replace("O", "PUB");
                    for (int k3 = 0; k3 < product.Count; k3++)
                    {
                        if (product[k3].ListCode == pubno)
                        {
                            rp.Num = product[k3].ProductNum;
                            rp.ProductName = product[k3].ProductName;
                        }
                    }
                    decimal PaperNum = 0;
                    for (int k1 = 0; k1 < paper.Count; k1++)
                    {
                        if (paper[k1].OrderOn == pubno)
                        {
                            if (paper[k1].b1 > 0)
                            {
                                remark += paper[k1].b2 + ":" + (paper[k1].Num + paper[k1].ExtendNum).ToString() + "*" + paper[k1].UnitPrice.ToString() + "= " + paper[k1].Price.ToString() + " ";
                                paperprice += paper[k1].Price;
                                PaperNum += paper[k1].Num;
                            }
                            if (paper[k1].b1 == 0)
                            {
                                remark += paper[k1].StandName + paper[k1].Num.ToString() + "*" + paper[k1].UnitPrice.ToString() + "= " + paper[k1].Price.ToString() + " ";
                                ctpprice += paper[k1].Price;
                                if (paper[k1].StandId == 53)
                                    rp.ColorCtp += paper[k1].Num;
                                if (paper[k1].StandId == 52)
                                    rp.BlackCtp += paper[k1].Num;
                            }
                            if (paper[k1].b1 < 0)
                            {
                                remark += paper[k1].b2 + " ";
                                lailiaocount += paper[k1].Num;
                            }
                        }
                    }
                    for (int k2 = 0; k2 < process.Count; k2++)
                    {
                        if (process[k2].OrderOn == pubno)
                        {
                            if (process[k2].ProcessId == 3 || process[k2].ProcessId == 4 || process[k2].ProcessId == 33 || process[k2].ProcessId == 34)
                            {
                                printprice += process[k2].Price;
                            }
                            else
                            {
                                processprice += process[k2].Price;
                            }
                            remark += process[k2].ProcessName + " 数量：" + process[k2].Num.ToString() + " 价：" + process[k2].Price.ToString() + " ";
                        }
                    }
                    calprice = processprice + paperprice + ctpprice + printprice;
                    rp.ProcessPrice = processprice;
                    rp.PaperPrice = paperprice;
                    //rp.CostPrice = processprice + paperprice  + ctpprice;
                    rp.Remark = remark;
                    rp.CaltPrice = calprice;
                    rp.CtpPrice = ctpprice;

                    rp.NoCtp = rp.SalePrice - rp.PaperPrice - rp.CtpPrice;
                    rp.PrintPrcie = printprice;

                    if (rp.CaltPrice > 0)
                    {
                        decimal r = (rp.SalePrice - rp.CaltPrice) / rp.CaltPrice;
                        r = r * 100;
                        rp.Ratio = Math.Round(r, 2).ToString() + "%";
                    }
                    else
                        rp.Ratio = "-";

                    rp.DoubleCount = PaperNum * 2 + lailiaocount;
                    AllSale += rp.SalePrice;
                    AllPaper += rp.PaperPrice;
                    AllCtp += rp.CtpPrice;
                    AllCal += rp.CaltPrice;
                    //AllNoCtp += rp.NoCtp;
                    AllProcess += rp.ProcessPrice;
                    AllDouble += rp.DoubleCount;
                    //AllMoney += rp.GetMoney;
                    AllPrint += rp.PrintPrcie;
                    AllNoCtp += rp.NoCtp;
                    AllBlack += rp.BlackCtp;
                    AllColor += rp.ColorCtp;
                    report.Add(rp);
                }
                DataTable DataReport = DataSource.ORMHelper.ModelListToTb<Model.reportitem>(report);

                DataRow dr = DataReport.NewRow();
                dr[3] = "合计汇总";
                dr[5] = AllSale;
                dr[6] = AllCal;
                decimal r0 = (AllSale - AllCal) / AllCal;
                r0 = r0 * 100;
                dr[7] = Math.Round(r0, 2).ToString() + "%";
                dr[8] = AllNoCtp;
                dr[9] = AllPrint;
                dr[11] = AllPaper;
                dr[12] = AllCtp;
                dr[13] = AllProcess;
                dr[14] = AllDouble;
                dr[15] = AllColor;
                dr[16] = AllBlack;
                DataReport.Rows.Add(dr);
                dataGridView1.DataSource = DataReport;
                for (int i = 0; i < Title.Count; i++)
                {
                    dataGridView1.Columns[i].HeaderText = Title[i];
                }
            }
            else
            {
                MessageBox.Show("数据库连接错误或者没有录入数据！");
            }
            this.Cursor = Cursors.Default;
        }
        void Calyewubu()
        {
            this.Cursor = Cursors.WaitCursor;
            CurrentMonth = dateTimePicker1.Value.Month;
            CurrentYear = dateTimePicker1.Value.Year;
            List<Model.P_Order> order = Model.P_Order.GetMonthOrder(dateTimePicker1.Value);
            if (order != null)
            {
                string pubno1 = order[0].OrderOn.Replace("O", "PUB");
                string pubno2 = order[order.Count - 1].OrderOn.Replace("O", "PUB");
                List<Model.P_MaterialList2> paper = Model.P_MaterialList2.GetDataList(" OrderOn>='" + pubno1 + "' and OrderOn<='" + pubno2 + "'");
                List<Model.P_ProcessList2> process = Model.P_ProcessList2.GetDataList(" OrderOn>='" + pubno1 + "' and OrderOn<='" + pubno2 + "'");
                List<Model.P_ProductList> product = Model.P_ProductList.GetDataList(" ListCode>='" + pubno1 + "' and ListCode<='" + pubno2 + "'");
                List<string> Title = DataSource.ORMHelper.GetColumnsName(typeof(Model.reportitem2));
                dataGridView1.Columns.Clear();
              

                List<Model.reportitem2> report = new List<Model.reportitem2>();
                List<Model.reportitem2> Over30 = new List<Model.reportitem2>();
                List<Model.reportitem2> Low = new List<Model.reportitem2>();

                decimal AllSale = 0;
                decimal AllCal = 0;
                decimal AllPaper = 0;
                decimal AllCtp = 0;
                decimal AllNoCtp = 0;
                decimal AllProcess = 0;
                decimal AllDouble = 0;
                //decimal AllPrint = 0;
                decimal AllBlackPrint = 0;
                decimal AllColorPrint = 0;

                decimal AllMoney = 0;
                decimal AllColor = 0;
                decimal AllBlack = 0;
                int index = 0;

                for (int j = 0; j < order.Count; j++)
                {
                    index++;
                    Model.reportitem2 rp = new Model.reportitem2();
                    rp.P_order = order[j].b2;
                    rp.No = index;
                    rp.Num = 0;
                    rp.Customer = order[j].Receiver;
                    if (rp.Customer.LastIndexOf("业务部") ==-1)
                    {
                        continue;
                    }
                    rp.SalePrice = 0;
                    rp.Days = order[j].OrderTime.Day;
                    decimal paperprice = 0;
                    decimal ctpprice = 0;
                    decimal calprice = 0;
                    decimal printprice = 0;
                    decimal blackprint = 0;
                    decimal colorprint = 0;
                    decimal processprice = 0;
                    decimal ColorCtpprice = 0;
                    decimal BlackCtpPrice = 0;
                    int lailiaocount = 0;
                    string remark = "";
                    string pubno = order[j].OrderOn.Replace("O", "PUB");
                    for (int k3 = 0; k3 < product.Count; k3++)
                    {
                        if (product[k3].ListCode == pubno)
                        {
                            rp.Num = product[k3].ProductNum;
                            rp.ProductName = product[k3].ProductName;
                        }
                    }
                    decimal PaperNum = 0;
                    for (int k1 = 0; k1 < paper.Count; k1++)
                    {
                        if (paper[k1].OrderOn == pubno)
                        {
                            if (paper[k1].b1 > 0)
                            {
                                remark += paper[k1].b2 + ":" + (paper[k1].Num+paper[k1].ExtendNum).ToString() + "*" + paper[k1].UnitPrice.ToString() + "= " + paper[k1].Price.ToString() + " ";
                                paperprice += paper[k1].Price;
                                PaperNum += paper[k1].Num;
                            }
                            if (paper[k1].b1 == 0)
                            {
                                remark += paper[k1].StandName + paper[k1].Num.ToString() + "*" + paper[k1].UnitPrice.ToString() + "= " + paper[k1].Price.ToString() + " ";
                                //ctpprice += paper[k1].Price;
                                if (paper[k1].StandId == 53)
                                {
                                    rp.ColorCtp += paper[k1].Num;
                                    ColorCtpprice += paper[k1].Price;
                                }
                                if (paper[k1].StandId == 52)
                                {
                                    rp.BlackCtp += paper[k1].Num;
                                    BlackCtpPrice += paper[k1].Price;
                                }
                            }
                            if (paper[k1].b1 < 0)
                            {
                                remark += paper[k1].b2 + " ";
                                lailiaocount += paper[k1].Num;
                            }
                        }
                    }
                    for (int k2 = 0; k2 < process.Count; k2++)
                    {
                        if (process[k2].OrderOn == pubno)
                        {
                            if (process[k2].ProcessId == 3 || process[k2].ProcessId == 4 || process[k2].ProcessId == 33 || process[k2].ProcessId == 34)
                            {
                                if (process[k2].ProcessId == 3 || process[k2].ProcessId == 4)
                                {
                                    colorprint += process[k2].Price;
                                }
                                if (process[k2].ProcessId == 33 || process[k2].ProcessId == 34)
                                {
                                    blackprint += process[k2].Price;
                                }
                            }
                            else
                            {
                                processprice += process[k2].Price;
                            }
                            remark += process[k2].ProcessName + " 数量：" + process[k2].Num.ToString() + " 价：" + process[k2].Price.ToString() + " ";
                        }
                    }
                    //印工价合计；
                    printprice = blackprint + colorprint;
                    //计算基准价；
                    calprice = paperprice+ processprice + Math.Round((printprice+ctpprice) *(decimal)1.2,0);
                    ctpprice = ColorCtpprice + BlackCtpPrice;
                    rp.ProcessPrice = processprice;
                    rp.PaperPrice = paperprice;
                  
                    rp.Remark = remark;
                    rp.CaltPrice = calprice;
                    rp.CtpPrice = ctpprice;

                    rp.NoCtp = rp.ProcessPrice + printprice;
                    //rp.PrintPrcie = printprice;
                    rp.BlackPrint = blackprint;
                    rp.ColorPrint = colorprint;

                    rp.Money = rp.ColorPrint + rp.ProcessPrice + rp.CtpPrice;
                    rp.DoubleCount = PaperNum * 2 + lailiaocount;
                    AllBlackPrint += rp.BlackPrint;
                    AllColorPrint += rp.ColorPrint;
                    AllMoney += rp.Money;
                    AllSale += rp.SalePrice;
                    AllPaper += rp.PaperPrice;
                    AllCtp += rp.CtpPrice;
                    AllCal += rp.CaltPrice;
                    //AllNoCtp += rp.NoCtp;
                    AllProcess += rp.ProcessPrice;
                    AllDouble += rp.DoubleCount;
                    //AllMoney += rp.Money;
                    //AllPrint += rp.PrintPrcie;
                    AllNoCtp += rp.NoCtp;
                    AllBlack += rp.BlackCtp;
                    AllColor += rp.ColorCtp;
                    report.Add(rp);
                }
                DataTable DataReport = DataSource.ORMHelper.ModelListToTb<Model.reportitem2>(report);

                DataRow dr = DataReport.NewRow();
                dr[3] = "合计汇总";
                //dr[5] = AllSale;
                dr[6] = AllCal;
                dr[8] = AllNoCtp;
                //dr[8] = AllPrint;
            
                dr[10] = AllDouble;
                dr[11] = AllPaper;
                dr[12] = AllColor;
                dr[13] = AllBlack;
                dr[14] = AllCtp;
                dr[15] = AllBlackPrint;
                dr[16] = AllColorPrint;
                dr[17] = AllProcess;
                dr[18] = AllMoney;
                DataReport.Rows.Add(dr);
                dataGridView1.DataSource = DataReport;
                for (int i = 0; i < Title.Count; i++)
                {
                    dataGridView1.Columns[i].HeaderText = Title[i];
                }
            }
            else
            {
                MessageBox.Show("数据库连接错误或者没有录入数据！");
            }
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                int[] width1 = { 3, 3, 6, 9, 11, 7, 7, 7, 9, 7, 6, 6, 8, 6, 7, 7, 5,200,5};
                int[] width2= { 3, 3, 6, 9, 11, 7, 7, 7, 9, 7, 6, 6, 8, 6, 7, 7, 8,5, 7,100 ,5};
                int[] width=width1;
                bool color = true;
                string Title = CurrentYear.ToString() + "年" + CurrentMonth.ToString() + "月";
                if (comboBox1.SelectedIndex == 1)
                {
                    width = width2;
                    color = false;
                    Title += "彩印中心承接业务部业务统计表（含税）";
                }
                else
                {
                    Title += "彩印中心自接业务统计表（含税）";
                }
                this.Cursor = Cursors.WaitCursor;
                var NewBook  = Common.BuildWorkbook(dataGridView1, Title, width,color);
                this.Cursor = Cursors.Default;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = "d:\\";
                saveFileDialog1.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
                {
                    var fs = File.OpenWrite(saveFileDialog1.FileName);
                    NewBook.Write(fs);
                    MessageBox.Show("存储文件成功！", "保存文件");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认需要修改数据彩色CTP 13.3 元，黑白CTP 14.1元？", "确认", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                
                List<Model.P_MaterialList2> dt = Model.P_MaterialList2.GetDataList("b1='0' and StandId>'51' and StandId<'54'");
                if (dt != null)
                {
                    foreach (Model.P_MaterialList2 pm in dt)
                    {
                        bool NeedSave = false;
                       
                        if (pm.StandId == 53)
                        {
                            if (pm.UnitPrice != (decimal)13.3)
                            {
                                pm.UnitPrice = (decimal)13.3;
                                decimal Price = decimal.Round(pm.Num * pm.UnitPrice, 0);
                                pm.Price = (int)Price;
                                NeedSave = true;
                            }
                        }
                        if (pm.StandId == 52)
                        {
                            if (pm.UnitPrice != (decimal)14.1)
                            {
                                pm.UnitPrice = (decimal)14.1;
                                decimal Price = decimal.Round(pm.Num * pm.UnitPrice, 0);
                                pm.Price = (int)Price;
                                NeedSave = true;
                            }
                        }
                        if (NeedSave)
                        {
                            Model.P_MaterialList2.Update(pm);
                        }
                    }
                    MessageBox.Show("已经修改完成！");
                }
                else
                {
                    MessageBox.Show("没有发现要修改的数据！");
 
                }
                this.Cursor = Cursors.Default;
            }
        }
    }
}
