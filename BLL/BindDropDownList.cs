using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace JxPrint.BLL
{
    public class BindDropDownList
    {
        /// <summary>
        /// 绑定尺寸
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="productid"></param>
        public static void BindSize(DropDownList ddl,int productid) 
        {
            ddl.DataSource = DAL.ShowRectList.GetSize(productid);
            BindName(ddl);

            ddl.Items.Add(new System.Web.UI.WebControls.ListItem("自定义", "-1"));
        }

        /// <summary>
        /// 绑定纸张类型
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="productid"></param>
        public static void BindPaper(DropDownList ddl, int productid)
        {
            ddl.DataSource = DAL.ShowRectList.GetPaperType(productid);
            BindName(ddl);
        }

        /// <summary>
        /// 克重绑定
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="productid"></param>
        /// <param name="typeid"></param>
        public static void BindKG(DropDownList ddl, int productid,int typeid)
        {
            ddl.DataSource = DAL.ShowRectList.GetPaperKG(productid,typeid);
            BindName(ddl);

            ddl.Items.Insert(0, new ListItem("-请选择-", "-1"));
        }

        /// <summary>
        /// 颜色绑定
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindColor(DropDownList ddl)
        {
            var ss = Enum.GetNames(typeof(ConstantValue.Paper.PaperColor));
            foreach (var t in ss)
            {
                var j = (int)Enum.Parse(typeof(ConstantValue.Paper.PaperColor), t);
                ddl.Items.Add(new ListItem(t, j.ToString()));
            }
            ddl.SelectedValue = "4";
        }
        /// <summary>
        /// 来源绑定
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindSource(DropDownList ddl)
        {
            var ss = Enum.GetNames(typeof(ConstantValue.Paper.PaperSource));
            foreach (var t in ss)
            {
                var j = (int)Enum.Parse(typeof(ConstantValue.Paper.PaperSource), t);
                ddl.Items.Add(new ListItem(t, j.ToString()));
            }
            ddl.SelectedValue = "1";
        }

        #region 辅助

        /// <summary>
        /// 数值绑定
        /// </summary>
        /// <param name="ddl"></param>
        private static void BindName(DropDownList ddl)
        {
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Id";
            ddl.DataBind();
        } 

        #endregion
    }
}
