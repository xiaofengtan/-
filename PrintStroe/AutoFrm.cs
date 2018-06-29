using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace PrintStroe
{
    public class AutoSizeFrm : System.Windows.Forms.Form
    {
        //(1).声明结构,只记录窗体和其控件的初始位置和大小。
        public struct controlRect
        {
            public string Name;
            public int Left;
            public int Top;
            public int Width;
            public int Height;
        }
        //(2).声明 1个对象
        //注意这里不能使用控件列表记录 List nCtrl;，因为控件的关联性，记录的始终是当前的大小。
        //      public List oldCtrl= new List();//这里将西文的大于小于号都过滤掉了，只能改为中文的，使用中要改回西文
        public List<controlRect> oldCtrl;
        int ctrlNo = 0;
        //1;
        //(3). 创建两个函数
        //(3.1)记录窗体和其控件的初始位置和大小,
        public AutoSizeFrm()
        {
            //窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用

            //this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化
            //0 - Normalize , 1 - Minimize,2- Maximize
            this.Shown += LoadCtrol;

            this.Layout += sizechange;
        }

        private void LoadCtrol(object sender, EventArgs e)
        {
            ctrlNo = 0;
            oldCtrl = new List<controlRect>();
            InserControl(this);
            AddControl(this);
        }

        private void InserControl(Control ctl)
        {
            ctrlNo++;
            controlRect cR;
            cR.Left = ctl.Location.X; cR.Top = ctl.Location.Y;
            cR.Width = ctl.Size.Width; cR.Height = ctl.Size.Height;
            cR.Name = ctl.Name;
            oldCtrl.Add(cR);
        }
        private void AddControl(Control ctl)
        {
            //第一个为"窗体本身",只加入一次即可
            foreach (Control c in ctl.Controls)
            {
                InserControl(c);
                if (c.Controls.Count > 0)
                    AddControl(c);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
            }
        }
        private void sizechange(object sender, EventArgs e)
        {
            controlAutoSize(this);
        }

        //(3.2)控件自适应大小,
        private void controlAutoSize(Control mForm)
        {
            if (ctrlNo > 0)
            {
                float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;//新旧窗体之间的比例，与最早的旧窗体
                float hScale = (float)mForm.Height / (float)oldCtrl[0].Height;//.Height;
                AutoScaleControl(mForm, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用
            }
        }
        private int SearchRect(string Name)
        {
            int index = 0;
            foreach (controlRect cr in oldCtrl)
            {
                if (cr.Name == Name)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        private void AutoScaleControl(Control ctl, float wScale, float hScale)
        {
            int ctrLeft0, ctrTop0, ctrWidth0, ctrHeight0;

            foreach (Control c in ctl.Controls)
            {
                int index = SearchRect(c.Name);
                if (index > 0 && index <= ctrlNo)
                {
                    ctrLeft0 = oldCtrl[index].Left;
                    ctrTop0 = oldCtrl[index].Top;
                    ctrWidth0 = oldCtrl[index].Width;
                    ctrHeight0 = oldCtrl[index].Height;
                    //c.Left = (int)((ctrLeft0 - wLeft0) * wScale) + wLeft1;//新旧控件之间的线性比例
                    //c.Top = (int)((ctrTop0 - wTop0) * h) + wTop1;
                    c.Left = (int)((ctrLeft0) * wScale);//新旧控件之间的线性比例。控件位置只相对于窗体，所以不能加 + wLeft1
                    c.Top = (int)((ctrTop0) * hScale);//
                    c.Width = (int)(ctrWidth0 * wScale);//只与最初的大小相关，所以不能与现在的宽度相乘 (int)(c.Width * w);
                    c.Height = (int)(ctrHeight0 * hScale);//

                    //**放在这里，是先缩放控件本身，后缩放控件的子控件
                    if (c.Controls.Count > 0)
                        AutoScaleControl(c, wScale, hScale);//窗体内其余控件还可能嵌套控件(比如panel),要单独抽出,因为要递归调用

                    if (ctl is DataGridView)
                    {
                        DataGridView dgv = ctl as DataGridView;
                        Cursor.Current = Cursors.WaitCursor;

                        int widths = 0;
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            dgv.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);  // 自动调整列宽  
                            widths += dgv.Columns[i].Width;   // 计算调整列后单元列的宽度和                       
                        }
                        if (widths >= ctl.Size.Width)  // 如果调整列的宽度大于设定列宽  
                            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;  // 调整列的模式 自动  
                        else
                            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  // 如果小于 则填充  

                        Cursor.Current = Cursors.Default;
                    }
                }

            }


        }
    }
}
