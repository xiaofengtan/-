using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Model
{
    public class OrderRequest
    {
        public string OrderCode;
        public string PPLCode;
        public string UserName;
        public string ProductName;
        public string ProductType;
        public string SizeName;
        public string ProductNum;
        public string Request;
        public string SendStyle;
        public string SendAddress;
        public string Price;
        public string TelPhone;
        public string OverTime;
        public string BindType;
        public string b2;
         public static List<UserProduct> UserRequest;

    }
}
