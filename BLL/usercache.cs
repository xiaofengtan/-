using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public static class BookPaperType
    {
        public static List<Model.recttange> typelist;
        public static DateTime PreTime;

        public static List<Model.recttange> GetList()
        {
            if (typelist == null)
            {
                typelist=DAL.ShowRectList.GetPaperType(2);
                PreTime = DateTime.Now;
                return typelist;
            }
            DateTime AccessTime=PreTime;
            if ( AccessTime.AddMinutes(10)>DateTime.Now)
            {
                 DAL.ShowRectList.GetPaperType(1);
                PreTime = DateTime.Now;
                return typelist;

            }
            return typelist;
 
            }
        }
    
}
