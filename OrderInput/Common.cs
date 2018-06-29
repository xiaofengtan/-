using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Data;



namespace OrderInput
{
    public class Common
    {
        public static OrderPart Order = null;
        public static void BindCombox(ComboBox cbx, List<Model.NameType> list)
        {
            if (list != null)
            {
                Model.NameType[] mylist = new Model.NameType[list.Count];
                list.CopyTo(mylist);
                cbx.DataSource = mylist;
                cbx.DisplayMember = "Name";
                cbx.ValueMember = "Id";
                return;
            }
            cbx.DataSource = null;
        }

        public static void BindCombox(ComboBox cbx, Type enumType)
        {
            List<Model.NameType> list = Model.EnumHelper.EnumToList(enumType);
            BindCombox(cbx, list);
        }
    }
}