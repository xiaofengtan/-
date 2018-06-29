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
    public partial class PaperIn : Form
    {
        //private DataTable PaperData;
        DataTable inputdata = null;
        DataTable Canin = null;
        DataTable dtin = null;
        DataTable allpaper = null;
        //List<Model.Paper_Stand> Allstand;
        //List<Model.Product> AllProduct;
        public PaperIn()
        {
            InitializeComponent();
            splitContainer2.SplitterDistance = 100;

            List<Model.NameType> typelist = Model.Paper_Type.GetDataNameList();
            BindData();
        }

        private void BindData()
        {
            //DataTable dt=Model.Paper_Store.GetDataTable("TypeId= '11'");
            allpaper = Model.Paper_Store.GetAllPaperTable();
            //PaperData = allpaper.Clone();
           
        }
       

      
        #region 批量写入库存段
        private void button3_Click_1(object sender, EventArgs e)
        {
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
                textBox1.Text = of.FileName;
            }
            else
            {
                inputdata = null;
                Canin = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Canin = null;
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
                try
                {
                    if (isincol(NameColIndex) && isincol(NumColIndex) && isincol(MoneyColIndex) && isincol(DateColIndex))
                    {
                        if (inputdata.Columns.Count > 0)
                        {
                            NameColIndex = NameColIndex - 1;
                            NumColIndex = NumColIndex - 1;
                            MoneyColIndex = MoneyColIndex - 1;
                            DateColIndex = DateColIndex - 1;


                            allpaper.PrimaryKey = new DataColumn[] { allpaper.Columns["PaperId"] };
                            List<Model.Paper_In> allin = new List<Model.Paper_In>();
                            Canin = inputdata.Clone();

                            foreach (DataRow dr in inputdata.Rows)
                            {
                                string papername = dr[NameColIndex].ToString();
                                Model.Paper_In pi = new Model.Paper_In();
                                pi.PaperName = papername;
                                pi.PaperId = -1;
                                DataRow dr1 = null;
                                foreach (DataRow dr2 in allpaper.Rows)
                                {
                                    if (dr2["PaperName"].ToString() == papername)
                                    {
                                        dr1 = dr2;
                                        break;
                                    }
                                }
                                if (dr1 != null)
                                {
                                    pi.PaperId = int.Parse(dr1["PaperId"].ToString());
                                    pi.Num = int.Parse(dr[NumColIndex].ToString());
                                    pi.Money = decimal.Parse(dr[MoneyColIndex].ToString());
                                    if (pi.Num == 0)
                                        continue;
                                    pi.Price = Math.Abs(pi.Money / pi.Num);
                                    pi.Price = decimal.Round(pi.Price, 2);
                                    pi.RealTime = DateTime.Now;
                                    pi.InTime = DateTime.Parse(dr[DateColIndex].ToString());
                                    pi.FactorName = "系统自动";
                                    allin.Add(pi);
                                }
                                else
                                {
                                    Canin.ImportRow(dr);
                                }
                            }
                            if (allin.Count > 0)
                            {
                                dtin = DataSource.ORMHelper.ModelListToTb<Model.Paper_In>(allin);
                                if (dtin != null)
                                {
                                    dataGridView1.DataSource = dtin;
                                    List<string> title = Model.Paper_In.GetColumNikeName();
                                    for (int i = 0; i < title.Count; i++)
                                        dataGridView1.Columns[i].HeaderText = title[i];
                                }
                            }
                            else
                            {
                                dtin = null;
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

        private bool isincol(int input)
        {
            int MaxCol = inputdata.Columns.Count;
            return input >= 0 && input <= MaxCol;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Canin != null)
            {
                dataGridView1.DataSource = Canin;
                List<string> title = Model.Paper_In.GetColumNikeName();
                for (int i = 0; i < title.Count; i++)
                    dataGridView1.Columns[i].HeaderText = title[i];
            }
        }
       

        private void button5_Click(object sender, EventArgs e)
        {
            if (dtin != null)
            {
                DialogResult dr = MessageBox.Show("确认全部入库？不确认将清除所有输入！", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    int resutlt = Model.Paper_In.Paper_StroeIn(dtin,true,true);
                    if (resutlt == dtin.Rows.Count)
                    {
                        MessageBox.Show(resutlt.ToString() + " 种纸张已经入库！,全部入库成功！");
                    }
                    else
                    {
                        MessageBox.Show(resutlt.ToString() + " 种纸张已经入库！检查入库明细，有" + (dtin.Rows.Count - resutlt).ToString() + "项目未入库！");
                    }
                }
            }
            dtin = null;
        }
      
        #endregion

        
    }
}
