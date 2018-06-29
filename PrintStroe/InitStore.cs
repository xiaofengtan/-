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
    public partial class InitStore : Form
    {
        public InitStore()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 100;
            button3.Enabled = false;
            button4.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable inputdata=null;
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = "d:\\";
            of.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
            of.FilterIndex = 2;
            of.RestoreDirectory = true;
            DialogResult dr = of.ShowDialog();
            if (dr == DialogResult.OK && of.FileName.Length > 0)
            {
                inputdata = Common.ExcelToDataTable(of.FileName, true);
            }
            if (inputdata != null)
            {
                dataGridView1.DataSource = inputdata;
                dataGridView1.AutoResizeColumns();
                button3.Enabled = true;
            }
            else
            {
                inputdata = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable inputdata =(DataTable)dataGridView1.DataSource;
            DataTable AllInput = null;
            if (inputdata != null)
            {
                int NameColIndex = -1;
                int NumColIndex = -1;
                int MoneyColIndex = -1;
                int DateColIndex = -1;

                int.TryParse(name_col.Text, out NameColIndex);
                int.TryParse(num_col.Text, out NumColIndex);
                int.TryParse(money_col.Text, out MoneyColIndex);
                int.TryParse(datecol.Text, out DateColIndex);

                int MaxCount = inputdata.Columns.Count;
                try
                {
                    if (isincol(NameColIndex, MaxCount) && isincol(NumColIndex, MaxCount) && isincol(MoneyColIndex, MaxCount) && isincol(DateColIndex, MaxCount))
                    {
                        if (inputdata.Columns.Count > 0)
                        {
                            NameColIndex = NameColIndex - 1;
                            NumColIndex = NumColIndex - 1;
                            MoneyColIndex = MoneyColIndex - 1;
                            DateColIndex = DateColIndex - 1;

                            List<Model.Paper_Store> allpaper = Model.Paper_Store.GetAllPaperList();

                            List<Model.Paper_In> allin = new List<Model.Paper_In>();
                            foreach (DataRow dr in inputdata.Rows)
                            {
                                string papername = dr[NameColIndex].ToString();
                                int index = -1;
                                for (int i = 0; i < allpaper.Count; i++)
                                {
                                    if (allpaper[i].PaperName == papername)
                                    {
                                        index = i;
                                        break;
                                    }
                                }
                                if(index>=0)
                                {
                                    Model.Paper_In pi = new Model.Paper_In();
                                    pi.PaperName = papername;
                                    pi.PaperId = allpaper[index].PaperId;
                                    pi.Num = int.Parse(dr[NumColIndex].ToString());
                                    pi.Money = decimal.Parse(dr[MoneyColIndex].ToString());
                                    if (pi.Num == 0)
                                        continue;
                                    pi.Price = Math.Abs(pi.Money / pi.Num);
                                    pi.Price = decimal.Round(pi.Price, 2);
                                    pi.RealTime = DateTime.Now;
                                    pi.InTime = dateTimePicker1.Value;
                                    pi.FactorName = "系统初始化";
                                    allin.Add(pi);
                                }
                            }
                            if (allin.Count > 0)
                            {
                                AllInput = DataSource.ORMHelper.ModelListToTb<Model.Paper_In>(allin);
                            }
                            if (AllInput != null)
                            {
                                dataGridView1.DataSource = AllInput;
                                List<string> title = Model.Paper_In.GetColumNikeName();
                                for (int i = 0; i < title.Count; i++)
                                    dataGridView1.Columns[i].HeaderText = title[i];
                                dataGridView1.AutoResizeColumns();
                                button2.Enabled = true;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("请检查输入文件的格式，或重新输入队列对应关系！");
                }
            }
        }

        private bool isincol(int input,int count)
        {
            return input >= 0 && input <= count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable Indata = (DataTable)dataGridView1.DataSource;
            DataTable store = Model.Store_month.InitStoreList(Indata, dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            if (store != null)
            {
                dataGridView1.DataSource = store;
                List<string> title = Model.Store_month.GetColumNikeName();
                for (int i = 0; i < title.Count; i++)
                    dataGridView1.Columns[i].HeaderText = title[i];
                dataGridView1.AutoResizeColumns();
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认清除所有历史库存数据，数据将按日期进行初始化操作！", "提示", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DataTable store = (DataTable)dataGridView1.DataSource;
                if (store == null)
                {
                    MessageBox.Show("请先处理好初始化数据的原始数据！再进行初始化操作！", "提示");
                    return;
                }
                List<Model.Store_month> storelist = DataSource.ORMHelper.TbToModelList<Model.Store_month>(store);
                List<Model.Paper_Store> AllPaper = Model.Paper_Store.GetAllPaperList();
                List<Model.Paper_Store> NeedUpdaePaper = new List<Model.Paper_Store>();
                for (int i =0;i< AllPaper.Count; i++)
                {
                    if (AllPaper[i].PaperId == storelist[i].PaperId)
                    {
                        int oldnum = AllPaper[i].Num;
                        AllPaper[i].Num = storelist[i].LastNum;
                        AllPaper[i].TaxiMoney = storelist[i].LastMoney;
                      
                        if (!(AllPaper[i].Num == 0 && oldnum == 0))
                        {
                            AllPaper[i].TaxiPrice = storelist[i].CurrentPrice;
                            NeedUpdaePaper.Add(AllPaper[i]);
                        }
                    }
                }
                bool sucess = true;
                try
                {
                    if (Model.Store_month.InsertData(store) != store.Rows.Count)
                    {
                        sucess = false;
                    }
                    int count = 0;
                    for (int j = 0; j < NeedUpdaePaper.Count; j++)
                    {
                        if (Model.Paper_Store.Update(NeedUpdaePaper[j]) > 0)
                            count++;
                    }
                    if (count != NeedUpdaePaper.Count)
                    {
                        sucess = false;
                    }
                }
                catch
                {
                    MessageBox.Show("初始化操作失败！", "提示");
                    sucess = false;
                }
                if (sucess)
                {
                    MessageBox.Show("初始化操作成功！", "提示");
                }
            }
        }
    }
}
