using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintStroe
{
    public partial class ManRepair : Form
    {

        private bool NoOut;
        private List<Model.P_MaterialList2> MaterialList;
        public ManRepair()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 150;
            NoOut = false;
        }


        private void cbx_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Model.Paper_Store> Allp = Model.Paper_Store.GetAllPaperList();
            List<Model.NameType> allpaper = new List<Model.NameType>();
            for (int i = 0; i < Allp.Count; i++)
            {
                if (Allp[i].TypeId.ToString() == cbx_type.SelectedValue.ToString())
                {
                    bool exit = false;
                    Model.NameType nt = new Model.NameType { Id = Allp[i].PaperId, Name = Allp[i].Kg.ToString() };
                    for (int j = 0; j < allpaper.Count; j++)
                    {
                        if (nt.Name == allpaper[j].Name)
                        {
                            exit = true;
                            break;
                        }
                    }
                    if (!exit)
                    {
                        allpaper.Add(nt);
                    }
                }
            }
            Common.BindCombox(cbxkg, allpaper);
            cbxkg.SelectedItem = 0;

        }

        private void cbxkg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.NameType nt2 = (Model.NameType)cbx_type.SelectedItem;
            List<Model.NameType> Allp = Model.Paper_Store.GetListByType(nt2.Id);
            List<Model.NameType> allpaper = new List<Model.NameType>();
            Model.NameType nt = (Model.NameType)cbxkg.SelectedItem;

            if (nt != null)
            {
                for (int i = 0; i < Allp.Count; i++)
                {
                    if (nt.Name == Allp[i].CodeId.ToString())
                    {
                        Model.NameType nt1 = new Model.NameType { Id = Allp[i].Id, Name = Allp[i].Name };
                        allpaper.Add(nt1);
                    }
                }
                Common.BindCombox(comboBox2, allpaper);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable allpaper = Model.Paper_Store.GetAllPaperTable();
            string code = textBox2.Text;
            if (code.Length > 0 && allpaper != null)
            {
                DataRow[] drs = allpaper.Select("PaperCode like '%" + code + "%'");
                if (drs.Length > 0)
                {
                    comboBox2.DataSource = null;
                    List<Model.NameType> paperlist = new List<Model.NameType>();
                    for (int i = 0; i < drs.Length; i++)
                    {
                        Model.NameType nt = new Model.NameType() { Id = int.Parse(drs[i]["PaperId"].ToString()), Name = drs[i]["PaperName"].ToString() };
                        paperlist.Add(nt);
                    }
                    Common.BindCombox(comboBox2, paperlist);
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string OrderNo = text_oldpaper.Text.Trim();
            string OrderOn = "";
            NoOut = false;
            DataTable WaitOutPaper = null;

            Model.P_Order order = Model.P_Order.GetOrderByOrder(OrderNo);
            DataTable tempout = null;
            if (order != null)
            {
                string pubno1 = order.OrderOn.Replace("O", "PUB");
                OrderOn = pubno1;
                MaterialList = Model.P_MaterialList2.GetDataList("OrderOn='" + pubno1 + "' and Mtype='1'");
                if (MaterialList != null && MaterialList.Count > 0)
                {
                    List<Model.Paper_Out> OutList = new List<Model.Paper_Out>();
                    foreach (Model.P_MaterialList2 pm2 in MaterialList)
                    {
                        Model.Paper_Out po11 = new Model.Paper_Out();
                        po11.PaperName = pm2.b2;
                        po11.PaperId = pm2.b1;
                        po11.Num = pm2.Num;
                        OutList.Add(po11);
                    }
                    tempout = DataSource.ORMHelper.ModelListToTb<Model.Paper_Out>(OutList);
                }
                else
                {
                    MessageBox.Show("订单号错误或该订单没有纸张，请重新输入！");
                    return;
                }
            }

            //检查是否有出库；
            WaitOutPaper = Model.Paper_Out.GetDataTable(" b1='" + OrderNo + "'");
            if (WaitOutPaper != null && WaitOutPaper.Rows.Count > 0)
                NoOut = false;
            else
                WaitOutPaper = tempout;

            dataGridView1.DataSource = WaitOutPaper;
            List<string> title = Model.Paper_Out.GetColumNikeName();
            for (int i = 0; i < title.Count; i++)
                dataGridView1.Columns[i].HeaderText = title[i];
            dataGridView1.AutoSize = true;

            this.Cursor = Cursors.Default;
            List<Model.Paper_Out> wp = Model.Paper_Out.PaperoutTabletoList(WaitOutPaper);
            comboBox3.DataSource = wp;
            comboBox3.DisplayMember = "PaperName";
            comboBox3.SelectedIndex = 0;
            Model.Paper_Out po = wp[0];
            textBox1.Text = po.Num.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("请先选择目标纸张！");
                return;
            }
            if (comboBox3.SelectedItem == null)
            {
                MessageBox.Show("请先选择要修改的纸张！");
                return;
            }

            int num = 0;
            if (!int.TryParse(textBox1.Text, out num))
            {
                MessageBox.Show("请先输入要修改的纸张的数量！");
                return;
            }
            Model.NameType SelectedPaper = (Model.NameType)comboBox2.SelectedItem;
            Model.Paper_Out OutPaper = (Model.Paper_Out)comboBox3.SelectedItem;

            Model.Paper_Store NewPaper = Model.Paper_Store.GetPaperById(SelectedPaper.Id);

            if (MaterialList != null)
            {
                Model.P_MaterialList2 pm2 = MaterialList[comboBox2.SelectedIndex];
                pm2.StandName = SelectedPaper.Name;
                pm2.StandId = SelectedPaper.Id;
                pm2.UnitPrice = NewPaper.UnitPrice;
                pm2.Price = (int)Math.Round(OutPaper.Money, 0);
                pm2.Num = OutPaper.Num;
                if (DataSource.ORMHelper.UpdateModelById<Model.P_MaterialList2>(pm2) ==0)
                {
                    DialogResult dr= MessageBox.Show("订单信息修改失败，确认是否继续修改出入库记录！","确认",MessageBoxButtons.YesNo);
                    if (dr != DialogResult.Yes)
                        return;
                }
            }
            //读出新的纸张和老的纸张；
            //如果已经出库，还要修改出库记录，及库存记录；
            if (!NoOut)
            {
                Model.Paper_Store OldPaper = Model.Paper_Store.GetPaperById(OutPaper.PaperId);
                //修改相关记录；
                OldPaper.Num += OutPaper.Num;
                OldPaper.Money += OutPaper.Money;
                NewPaper.Num -= num;
                OutPaper.Num = num;
                OutPaper.Money = NewPaper.TaxiPrice * num;
                NewPaper.TaxiMoney -= OutPaper.Money;
                OutPaper.PaperId = NewPaper.PaperId;
                OutPaper.PaperName = NewPaper.PaperName;
                OutPaper.Price = NewPaper.TaxiPrice;

                if (Model.Paper_Out.Update(OutPaper) < 1)
                {
                    MessageBox.Show("修改出库记录失败，确认后退出！");
                    return;
                }
                if (Model.Paper_Store.Update(OldPaper) + Model.Paper_Store.Update(NewPaper) == 2)
                {
                    MessageBox.Show("修改出库记录及库存数据成功，确认后退出！");
                }
            }
          
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable PaperOut = Model.Paper_Out.GetYearMonth(dateTimePicker1.Value);
            if (PaperOut != null)
            {
                if (PaperOut.Rows.Count > 0)
                {
                    List<string> OrderList = new List<string>();
                    List<Model.Paper_Out> PaperOutList = DataSource.ORMHelper.TbToModelList<Model.Paper_Out>(PaperOut);
                    foreach (Model.Paper_Out po in PaperOutList)
                    {
                        if (po.Num > 0&&po.Money==0)
                        {
                            OrderList.Add(po.b1);
                        }
                    }
                    if (OrderList.Count > 0)
                    {
                        comboBox1.DataSource = OrderList;
                        comboBox1.SelectedIndex = 0;
                    }
                    return;
                }
            }
            MessageBox.Show(dateTimePicker1.Value.ToLongDateString() + "的出库信息没有，可以先用系统自动出库，然后再查找！", "提示");


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            text_oldpaper.Text = comboBox1.SelectedValue.ToString();
            button7_Click(this, null);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Model.Paper_Out> wp = (List<Model.Paper_Out>)comboBox3.DataSource;
            Model.Paper_Out po = wp[comboBox3.SelectedIndex];
            textBox1.Text = po.Num.ToString();
        }

        private void ManRepair_Layout(object sender, LayoutEventArgs e)
        {
            
        }
    }
}

