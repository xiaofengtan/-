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
    public partial class Form1 : AutoSizeFrm
    {
        Form CurrentForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolbar.Height = this.Height;
            toolbar.Width = this.Width / 8;
          
        }

        private void AddWindow(Form frm)
        {
            if (CurrentForm != null)
                CurrentForm.Close();
            CurrentForm = frm;
            CurrentForm.TopLevel = false;
            panel1.Size = new Size() { Height = this.Height - toolbar.Size.Height - 50, Width = this.Width };
            CurrentForm.Parent = panel1;
            CurrentForm.Dock = DockStyle.Fill;
            CurrentForm.Size = panel1.Size;
            CurrentForm.FormBorderStyle = FormBorderStyle.None;
            CurrentForm.Show();
        }

        private void tssb01_Click(object sender, EventArgs e)
        {
            PaperOutAuto op = new PaperOutAuto();
            AddWindow(op);
        }

        private void tssb03_Click(object sender, EventArgs e)
        {
            InputPaper ip = new InputPaper();
            AddWindow(ip);

        }

        private void tssb04_Click(object sender, EventArgs e)
        {
            total cal = new total();
            AddWindow(cal);
        }

        private void tssb02_Click(object sender, EventArgs e)
        {
            PaperIn mo = new PaperIn();
            AddWindow(mo);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PaperManger pm = new PaperManger();
            AddWindow(pm);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ManOut mo11 = new ManOut();
            AddWindow(mo11);
        }

        private void 出库修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReOut re1 = new ReOut();
            AddWindow(re1);
        }

        private void 修改订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManRepair mpr1 = new ManRepair();
            AddWindow(mpr1);
        }

        private void 入库修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReInput ri1 = new ReInput();
            AddWindow(ri1);
        }

        private void 初始库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitStore init1 = new InitStore();
            AddWindow(init1);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            PaperOutExcel pe1 = new PaperOutExcel();
            AddWindow(pe1);
        }
    }
}
