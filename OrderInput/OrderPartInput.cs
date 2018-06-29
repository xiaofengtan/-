using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrderInput
{
    public partial class OrderPartInput : AutoSizeFrm
    {
        OrderPart op;
        int PLen, PWidth, num, PageNum, ColorNum,ProductTypeId;
        Model.Rectange BigPaperSize;
        public OrderPartInput()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            Common.BindCombox(cbx_producter_type, Model.Common.ProductType);
            
            checkBox_c1.Checked = true;
            checkBox_k1.Checked = true;
            checkBox_m1.Checked = true;
            checkBox_y1.Checked = true;
        }

        private void text_papercode_TextChanged(object sender, EventArgs e)
        {
            DataTable AllPaper = Model.Paper_Store.GetAllPaperTable();
            string code = text_papercode.Text;
            if (code.Length > 0 && AllPaper != null)
            {
                DataRow[] drs = AllPaper.Select("PaperCode like '%" + code + "%'");
                if (drs.Length > 0)
                {
                    comb_Paper.DataSource = null;
                    List<Model.NameType> paperlist = new List<Model.NameType>();
                    for (int i = 0; i < drs.Length; i++)
                    {
                        Model.NameType nt = new Model.NameType() { Id = int.Parse(drs[i]["PaperId"].ToString()), Name = drs[i]["PaperName"].ToString() };
                        paperlist.Add(nt);
                    }
                    Common.BindCombox(comb_Paper, paperlist);
                }
            }
        }

        private void comb_ProcessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comb_ProcessType.SelectedIndex >= 0)
            {
                Model.NameType nt = (Model.NameType)comb_ProcessType.SelectedItem;
                Common.BindCombox(comb_Process, Model.Process.GetNameListByTypeId(nt.Id));
            }
        }

        private void cbx_producter_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_producter_type.SelectedIndex >=0)
            {
                Model.NameType nt = (Model.NameType)cbx_producter_type.SelectedItem;
                int page = 2;
                if (nt.Id <= 1)
                    page = 4;
                if (nt.Id == 2)
                    page = 8;
                if (nt.Id >=5)
                    page = 1;
                text_Page_Num.Text = page.ToString();
                ProductTypeId = nt.Id-1;
                Common.BindCombox(comb_ProcessType, Model.ProcessType.GetNameList(ProductTypeId));
            }
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if ((ActiveControl is TextBox || ActiveControl is ComboBox|| ActiveControl is CheckBox) &&
                keyData == Keys.Enter)
            {
                keyData = Keys.Tab;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Model.NameType nt = (Model.NameType)comb_Process.SelectedItem;
            int pnum = 0;
            if (op == null)
            {
                MessageBox.Show("请先添加产品！");
                return;
            }
            if (nt != null && int.TryParse(text_processnum.Text, out pnum))
            {
                if (!op.AddProcess(nt.Id, pnum))
                {
                    MessageBox.Show("添加工艺失败！");
                    return;
                }
                else
                {
                    BindView();
                }
            }
        }

        private void BindView()
        {
            if (op != null)
            {
                if (op.AllItem != null && op.AllItem.Count > 0)
                {
                    dataGridView1.DataSource = null;
                    List<string> title = Model.PartItem.GetColumNikeName();
                    dataGridView1.DataSource = new BindingList<Model.PartItem>(op.AllItem);
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        dataGridView1.Columns[i].HeaderText = title[i];
                        if (i == 5)
                        {
                            dataGridView1.Columns[i].ReadOnly = false;
                        }
                        else
                        {
                            dataGridView1.Columns[i].ReadOnly = true;
                        }
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (op != null)
            {
                if (dataGridView1.DataSource != null)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    if (op.AllItem.Count > index)
                    {
                        dataGridView1.DataSource = null;
                        op.AllItem.RemoveAt(index);
                        BindView();
                    }
                }
            }
        }

        private void checkBox2_Enter(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            cbx.ForeColor = Color.Red;
        }

        private void checkBox2_Leave(object sender, EventArgs e)
        {
            CheckBox cbx = (CheckBox)sender;
            cbx.ForeColor = Color.Black;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (op != null)
            {
                op.ReCalPaper();
                op.ReCalPrint();
                Common.Order = op;
                BindView();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            op = null;
            text_len.Text = "";
            text_width.Text = "";
            text_kaidu.Text = "";
            text_needPaperNum1.Text = "";
            textBox_PsNum1.Text = "";
            textBox1.Text = "";
            text_lostnum.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = null;
        }

        private void comb_Process_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (op != null)
            {
                Model.NameType nt = (Model.NameType)comb_Process.SelectedItem;
                text_processnum.Text = op.GetProcessNum(nt.Id).ToString();
                label_Unit .Text= op.GetProcessNumUnit(nt.Id);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox_c1.Checked = false;
                checkBox_k1.Checked = false;
                checkBox_m1.Checked = false;
                checkBox_y1.Checked = false;
            }
            else
            {
                checkBox_c1.Checked = true;
                checkBox_k1.Checked = true;
                checkBox_m1.Checked = true;
                checkBox_y1.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ptype = cbx_producter_type.SelectedIndex + 1; ;
                PLen = int.Parse(text_Product_Len.Text);
                PWidth = int.Parse(text_Product_width.Text);
                num = int.Parse(text_producter_Num.Text);
                PageNum = int.Parse(text_Page_Num.Text);
                ColorNum = 0;

                if (checkBox2.Checked)
                    ColorNum = 0;
                else
                {
                    if (checkBox_c1.Checked)
                        ColorNum++;
                    if (checkBox_y1.Checked)
                        ColorNum++;
                    if (checkBox_k1.Checked)
                        ColorNum++;
                    if (checkBox_m1.Checked)
                        ColorNum++;
                }

                op = new OrderPart(ptype, PLen, PWidth, num);
                op.PaperSource = checkBox_PaperSource.Checked;
                op.ColorNum = ColorNum;
                op.PageNum = PageNum;
                Model.NameType nt = (Model.NameType)comb_Paper.SelectedItem;
                op.PaperName = nt;
                if (op.MakePart())
                {
                    //检查页面数量的合法性；尤其是书本的开本和页数的关系；避免后面的计算出错

                    //checkPageNum()
                    Model.Paper_Store paper = Model.Paper_Store.GetPaperById(nt.Id);
                    Model.Rectange bp = new Model.Rectange(paper.Length, paper.Height);
                    if (op.ProductType < 0)
                    {
                        MessageBox.Show("录入有错误，请重新检查输入项！");
                        return;
                    }
                    else
                    {
                        List<Model.NameType> needproces = Model.Process.GetProductProcess(ProductTypeId);
                        if (needproces != null)
                        {
                            foreach (Model.NameType nt1 in needproces)
                            {
                                Model.PartItem pi = new Model.PartItem();
                                pi.PartType = 8;
                                pi.PartName = "必选工艺";
                                pi.Name = nt1.Name;
                                pi.Id = nt1.Id;
                                pi.Num = num;
                                pi.Price = 0;
                                pi.Money = Model.C_ProcessPrice.GetProcessPrice(nt1.Id, num);
                                op.AllItem.Add(pi);
                                //op.AddProcess(nt1.Id);
                            }
                        }
                        text_len.Text = op.Ps.Length.ToString();
                        text_width.Text = op.Ps.Width.ToString();
                        text_kaidu.Text = op.Ps.Kaidu.ToString();
                        text_needPaperNum1.Text = op.Part.PaperNum.ToString();
                        textBox_PsNum1.Text = op.AllPSnum.ToString();
                        textBox1.Text = op.AllPsSet.ToString();
                        text_lostnum.Text = op.Part.PaperExtend.ToString();
                        textBox2.Text = op.AllPrintNum.ToString();
                        BindView();
                    }
                }
            }
            catch
            {
                MessageBox.Show("录入有错误，请重新检查输入项！");
                return;
            }
        }

        private void textBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void text_producter_Num_Leave(object sender, EventArgs e)
        {
            PLen = int.Parse(text_Product_Len.Text);
            PWidth = int.Parse(text_Product_width.Text);
            num = int.Parse(text_producter_Num.Text);
            if (PLen > 0 && Width > 0 && num > 0)
            {
               // Model.Rectange ProductRect = new Model.Rectange(PLen, PWidth);
                Model.Tree CutTree = Model.Common.PaperCut;
                BigPaperSize = CutTree.GetPaper(PLen, PWidth);
                if (BigPaperSize == Model.Common.BigPaper)
                {
                    text_papercode.Text = "dg";
                }
                if (BigPaperSize == Model.Common.SmallPaper)
                {
                    text_papercode.Text = "zg";
                }
            }
            else
            {
                MessageBox.Show("录入错误");
            }
        }
    }
}
