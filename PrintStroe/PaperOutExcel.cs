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
    public partial class PaperOutExcel : Form
    {
        public PaperOutExcel()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 90;
        }
        


        private void button3_Click(object sender, EventArgs e)
        {
            DataTable inputdata = null;
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
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DataTable inputdata = (DataTable)dataGridView1.DataSource;
            if (inputdata != null)
            {
                int NameColIndex = -1;
                int NumColIndex = -1;
                int DateColIndex = -1;

                int.TryParse(name_col.Text, out NameColIndex);
                int.TryParse(num_col.Text, out NumColIndex);
                int.TryParse(datecol.Text, out DateColIndex);
                try
                {
                    if (isincol(NameColIndex) && isincol(NumColIndex) && isincol(DateColIndex))
                    {
                        if (inputdata.Columns.Count > 0)
                        {
                            NameColIndex = NameColIndex - 1;
                            NumColIndex = NumColIndex - 1;
                            DateColIndex = DateColIndex - 1;
                          
                            List<Model.Paper_Out> AllOut = new List<Model.Paper_Out>();

                            List<Model.Paper_Store> AllPaperList = Model.Paper_Store.GetAllPaperList();

                            List<Model.Paper_Store> NeedUpdateList = new List<Model.Paper_Store>();

                            foreach (DataRow dr in inputdata.Rows)
                            {
                                string papername = dr[NameColIndex].ToString();
                                Model.Paper_Out pi = new Model.Paper_Out();
                                pi.PaperName = papername;
                                pi.PaperId = -1;

                                foreach (Model.Paper_Store paper  in AllPaperList)
                                {
                                    if (paper.PaperName == pi.PaperName)
                                    {
                                        pi.PaperId = paper.PaperId;
                                        pi.Num = int.Parse(dr[NumColIndex].ToString());
                                        if (pi.Num == 0)
                                            continue;
                                        pi.Price = paper.TaxiPrice;
                                        pi.Money = Math.Round(pi.Num * pi.Price, 2);
                                        pi.RealTime = DateTime.Now;
                                        pi.OutTime = DateTime.Parse(dr[DateColIndex].ToString());
                                        pi.SourceCode = "批量出库";
                                        AllOut.Add(pi);
                                        break;
                                    }
                                }
                              
                            }
                            if (AllOut.Count>0)
                            {
                                DataTable PaperOut = DataSource.ORMHelper.ModelListToTb<Model.Paper_Out>(AllOut);
                                if (PaperOut != null)
                                {
                                    dataGridView1.DataSource = PaperOut;
                                    List<string> title = Model.Paper_Out.GetColumNikeName();
                                    for (int i = 0; i < title.Count; i++)
                                        dataGridView1.Columns[i].HeaderText = title[i];
                                }
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
            if (dataGridView1.DataSource != null)
            {
                int MaxCol = ((DataTable)dataGridView1.DataSource).Columns.Count;
                return input >= 0 && input <= MaxCol;
            }
            return false;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable OutData = (DataTable)dataGridView1.DataSource;
            if (OutData != null)
            {
                DialogResult dr = MessageBox.Show("确认全部出库？不确认将清除所有输入！", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {

                    int resutlt = Model.Paper_Out.paperout(OutData,true,true,false);
                    if (resutlt == OutData.Rows.Count)
                    {
                        MessageBox.Show(resutlt.ToString() + " 种纸张已经入库！,全部入库成功！");
                    }
                }
            }
        }
    }
}
