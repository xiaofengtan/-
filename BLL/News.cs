using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JxPrint.BLL
{
    public class News
    {
        /// <summary>
        ///根据新闻类型 获得新闻列表
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public static List<Model.NewsModel> GetTitle(int typeid)
        {
            DataTable dt = DAL.News.GetList(" NewsType="+typeid.ToString()).Tables[0];
            List<Model.NewsModel> thlist =JxPrint.DAL.News.GetList(dt);
            return thlist;
        }

        /// <summary>
        /// 获得当月新闻列表
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public static List<Model.NewsModel> GetTitle(string datetime)
        {
            DataTable dt = DAL.News.GetList(" datediff(month,[NewsTime],'" + datetime + "')=0").Tables[0];
            List<Model.NewsModel> thlist = JxPrint.DAL.News.GetList(dt);
            return thlist;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public static List<Model.NewsModel> GetTitle(int typeid, string datetime)
        {
            DataTable dt = DAL.News.GetList(" NewsType=" + typeid.ToString() + " and datediff(month,[NewsTime],'" + datetime + "')=0").Tables[0];
            List<Model.NewsModel> thlist = JxPrint.DAL.News.GetList(dt);
            return thlist;
        }
    }
}
