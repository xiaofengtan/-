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
    public partial class ReOut : Form
    {
        DataTable AllOutPaper;
        public ReOut()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 100;
            button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dt1.AddDays(1);
            string dt1str = dt1.ToShortDateString();
            string dt2str = dt2.ToShortDateString();
            string whe = "RealTime >'" + dt1str + "' and RealTime<'" + dt2str + "'";
            AllOutPaper = Model.Paper_Out.GetDataTable(whe);
            if (AllOutPaper != null && AllOutPaper.Rows.Count > 0)
            {
                List<string> titile = Model.Paper_Out.GetColumNikeName();
              
                dataGridView1.DataSource = AllOutPaper;
                for (int i = 0; i < titile.Count; i++)
                {
                    dataGridView1.Columns[i].HeaderText = titile[i];

                }
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                MessageBox.Show(dt1str+"没有出库纸张，请重新选择或退出！", "提示");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AllOutPaper == null)
                return;
            DataTable upddata = AllOutPaper.Clone();
            DialogResult dr = MessageBox.Show("确认选中的项目？", "提示", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
                //取得选中的行
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool IsSelect = false;
                    if (dataGridView1.Rows[i].Cells[10].Value != null)
                    {
                        string tt = dataGridView1.Rows[i].Cells[10].Value.ToString();
                        if (tt == "False")
                            IsSelect = true;
                    }
                    if (IsSelect)
                    {
                        upddata.NewRow();
                        upddata.ImportRow(AllOutPaper.Rows[i]);
                    }
                }
                dataGridView1.DataSource = upddata;
                if (upddata.Rows.Count > 0)
                {
                    button3.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable upddata = AllOutPaper.Clone();
            DialogResult dr = MessageBox.Show("确认将以下纸张全部撤销出库？", "提示", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes&&dataGridView1.Rows.Count>0)
            {
                DataTable OutPaper =(DataTable) dataGridView1.DataSource;
                List<Model.Paper_Out> OutPaperList = DataSource.ORMHelper.TbToModelList<Model.Paper_Out>(OutPaper);
                List<Model.Paper_Store> WaitOutPaer = new List<Model.Paper_Store>();
                List<string> RemoveList = new List<string>();
                int count = 0;
                for (int i = 0; i < OutPaperList.Count; i++)
                {
                    Model.Paper_Store ps = Model.Paper_Store.GetPaperById(OutPaperList[i].PaperId);
                    if (ps != null)
                    {
                        bool HadInsert = false;
                        for (int k = 0; k < WaitOutPaer.Count; k++)
                        {
                            if (ps.PaperId == WaitOutPaer[k].PaperId)
                            {
                                WaitOutPaer[k].Num = WaitOutPaer[k].Num + OutPaperList[i].Num;
                                WaitOutPaer[k].TaxiMoney += OutPaperList[i].Money;
                                HadInsert = true;
                                break;
                            }
                        }
                        if (!HadInsert)
                        {
                            ps.Num = ps.Num + OutPaperList[i].Num;
                            //减去库存总金额；
                            ps.TaxiMoney = ps.TaxiMoney +OutPaperList[i].Money;
                            WaitOutPaer.Add(ps);
                        }
                        RemoveList.Add(OutPaperList[i].Id.ToString());
                        count++;
                    }
                }
                //添加出库记录
                int result=Model.Paper_Out.RemoveOut(RemoveList);
                //修改库存数量。PAPERSTROE里的数量更新；

                foreach (Model.Paper_Store p1 in WaitOutPaer)
                {
                    Model.Paper_Store.Update(p1);
                }
                button3.Enabled = false;
                if (result == count)
                {
                    MessageBox.Show("您选择的" + count.ToString() + "已经全部撤销了出库！", "提示");
                }
            }
        }
    }
}
