using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace JxPrint.BLL
{
    public class asklist
    {
        Model.P_AskList Asker;
        Model.Requset UserRequest;
        Model.ResultPrice Price;

        public asklist()
        {
            Asker = new Model.P_AskList();
            UserRequest = new Model.Requset();
            Price = new Model.ResultPrice();
            Asker.AskTime = DateTime.Now;
        }

        
        public override string ToString()
        {
            string result = "";
            StringBuilder sb = new StringBuilder();
            JavaScriptSerializer jsson = new JavaScriptSerializer();
            jsson.Serialize(this, sb);
            result = sb.ToString();
            return result;

        }
    }
}
