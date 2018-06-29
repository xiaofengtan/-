using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PrintStroe
{
    public partial class PaperOutAuto : Form
    {
        public PaperOutAuto()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            List<Model.P_Order> AllOrder = Model.P_Order.GetMonthOrder(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            DataTable WaitOutPaper = Model.Paper_Out.TransMaterListToDataTable(AllOrder);
            if (WaitOutPaper != null)
            {
                DataView dv1 = WaitOutPaper.DefaultView;
                dv1.Sort = "PaperId desc";
                WaitOutPaper = dv1.ToTable();
                decimal totalmoney = 0;
                //decimal taxim=0;
                for (int i = 0; i < WaitOutPaper.Rows.Count; i++)
                {
                    decimal m = 0;
                    decimal.TryParse(WaitOutPaper.Rows[i]["Money"].ToString(), out m);
                    totalmoney += m;
                }
                DataRow dr = WaitOutPaper.NewRow();
                dr["PaperName"] = "合计";
              
                dr["Money"] = totalmoney;
                WaitOutPaper.Rows.Add(dr);

                if (WaitOutPaper != null)
                {
                    dataGridView1.DataSource = WaitOutPaper;
                    List<string> title = Model.Paper_Out.GetColumNikeName();
                    for (int i = 0; i < title.Count; i++)
                        dataGridView1.Columns[i].HeaderText = title[i];
                    dataGridView1.AutoSize = true;
                    button3.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("提示！", "该月份纸张已经全部出库！");
            }
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable WaitOutPaper =(DataTable)dataGridView1.DataSource;
            if (WaitOutPaper != null)
            {
                DialogResult dr = MessageBox.Show("确认全部出库？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    int  count = WaitOutPaper.Rows.Count;
                    WaitOutPaper.Rows.RemoveAt(count-1);
                    count = Model.Paper_Out.paperout(WaitOutPaper, true, true, false);
                    if (count == WaitOutPaper.Rows.Count)
                    {
                        MessageBox.Show("共计出库：" + count.ToString() + "条记录", "提示");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable WaitOutPaper = (DataTable)dataGridView1.DataSource;
            if (WaitOutPaper != null)
            {
                var newBook = Common.BuildWorkbook(WaitOutPaper, "待出库清单");

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = "d:\\";
                saveFileDialog1.Filter = "Excel文件(*.xls,xlsx)|*.xls;*.xlsx";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
                {
                    var fs = File.OpenWrite(saveFileDialog1.FileName);
                    newBook.Write(fs);
                    MessageBox.Show("存储文件成功！", "保存文件");
                }
            }
        }
    }
}
