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
    public partial class InputOrder : AutoSizeFrm
    {
        Model.P_Order MyOrder;
        List<OrderPart> AllPart;
        public InputOrder()
        {
            InitializeComponent();
            MyOrder = new Model.P_Order();
            AllPart = new List<OrderPart>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyOrder.OrderTime = dateTimePicker1.Value;
            MyOrder.Receiver = text_user.Text;
            MyOrder.b2 = text_No.Text;
            MyOrder.TelPhone = text_tel.Text;
            MyOrder.b1 = 0;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            OrderPartInput op = new OrderPartInput();
            op.Show();
        }
      
        private void BindView()
        {
            if (AllPart != null)
            {
                for (int j = 0; j < AllPart.Count; j++)
                {
                    OrderPart op = AllPart[j];
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
        }
    }
}
