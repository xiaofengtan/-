using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PrintStroe
{
    public partial class InputPaper : AutoSizeFrm
    {

        private DataTable SaveTable;

        private DataTable AllPaper;

        List<Model.Paper_In> In = new List<Model.Paper_In>();


        public InputPaper()
        {
            InitializeComponent();
            splitContainer1.SplitterDistance = 100;
            Loaddata();
            SaveTable = null;
            
           
        }
        private void Loaddata()
        {
            AllPaper = Model.Paper_Store.GetAllPaperTable();

            List<Model.NameType> typelist = Model.Paper_Type.GetDataNameList();
            Common.BindCombox(cbx_type, typelist);
            cbx_type.SelectedIndex = 0;

        }

        private void SetInTitle()
        {
          
            List<string> title = Model.Paper_In.GetColumNikeName();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].HeaderText = title[i];
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            int type = 0;
            type = int.Parse(comboBox1.SelectedValue.ToString());
            Model.Paper_Store paper = Model.Paper_Store.GetPaperById(type);

            if (!(comboBox1.Items.Count > 0 && comboBox1.SelectedIndex >= 0))
            {
                MessageBox.Show("通过拼音简写选择要入库的纸张！", "提示");
                return;
            }

            if (In == null)
            {
                In = new List<Model.Paper_In>();
            }
          
            int num = 0;
            decimal price = 0, money = 0;

            bool inputok = true;
            
            inputok = inputok && int.TryParse(txt_num.Text, out num);
            inputok = inputok && decimal.TryParse(txt_money.Text, out money);
            if (!inputok)
            {
                MessageBox.Show("检查纸数量和金额！");
                return;
            }
           
            price=decimal.Round(money/(decimal)num,2);
            label12.Text = "纸张单价：" + price.ToString() + " 元";

            Model.Paper_In pi = new Model.Paper_In()
            {
                Id = 0,
                Num=num,
                PaperId = paper.PaperId,
                PaperName = paper.PaperName,
                Price = price,
                Money=money,
                InTime = dateTimePicker1.Value,
                InCode="手动单笔入库",
                FactorName="系统"
            };
            In.Add(pi);
            if (SaveTable == null)
            {
                DataTable InData = DataSource.ORMHelper.ModelListToTb<Model.Paper_In>(In);
                SaveTable = InData;
            }
            else
            {
                DataRow dr = DataSource.ORMHelper.ModelToRow<Model.Paper_In>(pi);
                SaveTable.ImportRow(dr);
            }
            dataGridView1.DataSource = SaveTable;
            SetInTitle();
            txt_money.Text = "";
            txt_num.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SaveTable != null)
            {
                DialogResult dr = MessageBox.Show("确认全部入库？不确认将清除所有输入！", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SaveTable.AcceptChanges();
                    int result = Model.Paper_In.Paper_StroeIn(SaveTable, true, true);
                    if (result == SaveTable.Rows.Count)
                    {
                        MessageBox.Show(result.ToString() + " 种纸张已经入库！");
                    }
                }
            }
            dataGridView1.DataSource = null;
            SaveTable = null;
            In.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string code = textBox1.Text;
            if (code.Length > 0&&AllPaper!=null)
            {
                DataRow[] drs = AllPaper.Select("PaperCode like '%" + code + "%'");
                if (drs.Length > 0)
                {
                    comboBox1.DataSource = null;
                    List<Model.NameType> paperlist = new List<Model.NameType>();
                    for (int i = 0; i < drs.Length; i++)
                    {
                        Model.NameType nt = new Model.NameType() { Id =int.Parse( drs[i]["PaperId"].ToString()), Name = drs[i]["PaperName"].ToString() };
                        paperlist.Add(nt);
                    }
                    Common.BindCombox(comboBox1, paperlist);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
           
            dataGridView1.DataSource = dt;
            SetInTitle();

        }

        private void cbx_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Model.Paper_Store> Allp = Model.Paper_Store.GetAllPaperList();
            List<Model.NameType> allpaper = new List<Model.NameType>();
            for(int i=0;i<Allp.Count;i++)
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
        }

        private void cbxkg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataRow[] drs=AllPaper.Select(" TypeId= ' "+(cbx_type.SelectedIndex+1).ToString()+"'");
            //List<Model.NameType> allpaper = new List<Model.NameType>();
            List<Model.Paper_Store> Allp = Model.Paper_Store.GetAllPaperList();
            List<Model.NameType> allpaper = new List<Model.NameType>();
            Model.NameType nt = (Model.NameType)cbxkg.SelectedItem;
            if (nt!=null)
            {
                for (int i = 0; i < Allp.Count; i++)
                {
                    if (nt.Name == Allp[i].Kg.ToString())
                    {
                        Model.NameType nt1 = new Model.NameType { Id = Allp[i].PaperId, Name = Allp[i].PaperName };
                        allpaper.Add(nt1);
                    }
                }
                Common.BindCombox(comboBox1, allpaper);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                int index=0;
                if (dataGridView1.CurrentRow != null)
                {
                    index = dataGridView1.CurrentRow.Index;
                    SaveTable.Rows.RemoveAt(index);
                    SaveTable.AcceptChanges();
                }
            }
        }
      
    }
}