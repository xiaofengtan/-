using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PrintStroe
{
    public partial class PaperManger : Form
    {
        private DataTable PaperData;
        DataTable allpaper=null;
        List<Model.Paper_Stand> Allstand;
        List<Model.Product> AllProduct;

        public PaperManger()
        {
            InitializeComponent();

            splitContainer1.SplitterDistance = 100;
            comboBox1.SelectedIndex = 0;

            checkBox1.Checked = true;

            List<Model.NameType> typelist = Model.Paper_Type.GetDataNameList();
            Common.BindCombox(cbx_type, typelist);
            cbx_type.SelectedIndex = 0;
            Allstand = null;

            AllProduct = Model.Product.GetDataList("1=1");
            checkedListBox1.Items.Clear();
            for (int i = 0; i < AllProduct.Count; i++)
            {
                checkedListBox1.Items.Add(AllProduct[i].ProductName);
            }
            BindData();
        }

        private void BindData()
        {
            //DataTable dt=Model.Paper_Store.GetDataTable("TypeId= '11'");
            allpaper = Model.Paper_Store.GetAllPaperTable();
            PaperData = allpaper.Clone() ;
            DataRow[] drs = allpaper.Select("PaperId= '" + cbx_type.SelectedIndex.ToString() + "'");
            if (drs.Length > 0)
            {
                foreach (DataRow dr in drs)
                {
                    PaperData.ImportRow(dr);
                }
                dataGridView1.DataSource = PaperData;
                dataGridView1.ReadOnly = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            Allstand = Model.Paper_Stand.GetDataList("1=1");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                text_len.Text = "889";
                text_width.Text = "1194";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                text_len.Text = "787";
                text_width.Text = "1092";
            }
            if (comboBox1.SelectedIndex == 2)
            {
                text_len.Text = "0";
                text_width.Text = "0";
                text_len.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Paper_Store ps = new Model.Paper_Store();
            ps.TypeId = cbx_type.SelectedIndex;
            string PaperName = "";
            string StandName = "";
            decimal unitprice = 0;
            int tonprice = 0;
          
            //ps.StandId = 98;
         
            ps.PaperFactory = text_factor.Text.Trim();
            if (ps.PaperFactory.Length < 1)
            {
                MessageBox.Show("纸张品牌输入有误，检查输入！");
                return;
            }

            if (comboBox1.SelectedIndex == 2)
            {
                PaperName = "非标";
                int len = 0, width = 0;
                bool input = int.TryParse(text_len.Text, out len);
                input = input && int.TryParse(text_width.Text, out width);
                if (!input)
                {
                    MessageBox.Show("自定义尺寸输入有误，检查输入！");
                    return;
                }
                else
                {
                    ps.Length = len;
                    ps.Height = width;
                }
            }
            if (comboBox1.SelectedIndex == 0)
            {
                PaperName = "大规";
                ps.Length = 880;
                ps.Height = 1194;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                PaperName = "正规";
                ps.Length = 780;
                ps.Height = 1092;
            }

            int kg = 0;
            if (!int.TryParse(text_kg.Text, out kg))
            {
                MessageBox.Show("纸张克重输入有误，检查输入！");
                return;
            }
            ps.Kg = kg;
            PaperName += kg.ToString() + "g";

            decimal price = 0;
            if(!decimal.TryParse(text_unitprice.Text, out price))
            {
                MessageBox.Show("纸张销售价输入有误，检查输入！");
                return;
            }
            //ps.UnitPrice = unitprice;

            StandName=PaperName;
            PaperName += text_factor.Text;
            string typename = cbx_type.Text;
            PaperName += typename;
            StandName += typename;

            ps.PaperName = PaperName;
            ps.StandId = 0;
            foreach (DataRow dr in allpaper.Rows)
            {
                if (ps.PaperName == dr["PaperName"].ToString())
                {
                    ps.StandId = int.Parse(dr["StandId"].ToString());
                    break;
                }
            }
            if (ps.StandId > 0)
            {
                MessageBox.Show("该纸张已经存在，请确认和检查输入！");
                return;
            }
             
            foreach(Model.Paper_Stand psd in Allstand)
            {
                if(psd.StandName==StandName)
                {
                    ps.StandId=psd.Id;
                }
            }
            if(ps.StandId==0)
            {
                
                if (checkBox1.Checked)
                {
                    unitprice = price;
                    tonprice = decimal.ToInt32(Common.CalNumPreTon(ps.Length, ps.Height, ps.Kg) * unitprice);
                }
                else
                {
                    tonprice = decimal.ToInt32(price);
                    unitprice = Math.Round(price / Common.CalNumPreTon(ps.Length, ps.Height, ps.Kg), 2);
                }

                Model.Paper_Stand psd =new Model.Paper_Stand{StandName=StandName,KG=kg,SizeId=comboBox1.SelectedIndex+1,TypeId=int.Parse(cbx_type.SelectedValue.ToString())};
                psd.SalesUnitPrice = unitprice;
                psd.SalesTonPrice = tonprice;
               
                DataSource.ORMHelper.InsertModel<Model.Paper_Stand>(psd);
                Allstand = Model.Paper_Stand.GetDataList("1=1");
                foreach (Model.Paper_Stand psd1 in Allstand)
                {
                    if (psd1.StandName == StandName)
                    {
                        ps.StandId = psd1.Id;
                        break;
                    }
                }
            }
            if (ps.StandId > 0)
            {
                ps.TonPrice = tonprice;
                ps.TypeId = cbx_type.SelectedIndex;
                if (ps.PaperName != null)
                {
                    ps.PaperCode = Model.Common.GetChineseSpell(ps.PaperName);
                }
                if (Model.Paper_Store.InserData(ps) > 0)
                {
                    MessageBox.Show(ps.PaperName + " 纸张已经添加！");
                }
                else
                {
                    MessageBox.Show(ps.PaperName + " 纸张添加失败！");
                    return;
                }

                for (int i = 0; i < AllProduct.Count; i++)
                {
                    if (checkedListBox1.GetSelected(i))
                    {
                        int id = AllProduct[i].ProductId;
                        Model.R_ProductPaper rpp = new Model.R_ProductPaper() { ProductId = id, StandId = ps.StandId };
                        Model.R_ProductPaper.InserData(rpp);
                    }
                }
            }

            //BindData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.BeginEdit(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                int rowindex = -1;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Selected)
                    {
                        rowindex = i;
                        break;
                    }
                }
                if (rowindex >= 0)
                {
                    DialogResult dr = MessageBox.Show("确认删除！第" + rowindex.ToString() + "数据？", "确认", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Model.Paper_Store ps1 = DataSource.ORMHelper.RowToModel<Model.Paper_Store>(PaperData.Rows[rowindex]);
                        Model.Paper_Store.Delete(ps1);
                        PaperData.Rows.RemoveAt(rowindex);
                        BindData();
                    }
                }
            }
        }
      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "单价";
                label9.Text = "销售单价";
            }
            else
            {
                checkBox1.Text = "吨价";
                label9.Text = "销售吨价";
            }
        }
    }
}
