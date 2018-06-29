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
    public partial class Form1:AutoSizeFrm
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

        private void toolbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

     

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            InputOrder neworder = new InputOrder();
            AddWindow(neworder);

        }
    }
}
