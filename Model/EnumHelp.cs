using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public enum PsMode { 大翻, 自翻, 双拼自翻, 四拼自翻,其他 }

    public enum CutModeMenu { 无, 左右对开, 上下对开, 左右三开, 上下三开 }

    public enum BookBindType { 无,骑马钉,无线胶装,有线胶装}

    //public enum NumName { 产品数量,纸张数量,对开张,八开张数量,颜色数,版数,总表面积,印张数,总折数}
    public enum ProcessNumMode {成品数量,长度,宽度,页数, 颜色数, 纸张数量,版套数,版纸数,对开张数,印张数,八开纸张数量,八开张面数,纸张面积, 工艺面积, 固定面积, 帖数, 厚度}

    public static class EnumHelper
    {
        /// <summary>
        /// 根据枚举的值获取枚举名称
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <param name="status">枚举的值</param>
        /// <returns></returns>
        public static string GetEnumName<T>(this int status)
        {
            return Enum.GetName(typeof(T), status);
        }
        /// <summary>
        /// 获取枚举名称集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string[] GetNamesArr<T>()
        {
            return Enum.GetNames(typeof(T));
        }
        public static string GetName(int id, System.Type enumType)
        {
            var ss = Enum.GetNames(enumType);
            foreach (var t in ss)
            {
                var j = (int)Enum.Parse(enumType, t);
                if (id == j)
                    return t;
            }
            return "";
        }

        public static int GetId(string name, System.Type enumType)
        {
            var ss = Enum.GetNames(enumType);
            foreach (var t in ss)
            {
                var j = (int)Enum.Parse(enumType, t);
                if (name.Trim() == t.Trim())
                    return j;
            }
            return -1;
        }
        public static List<NameType> EnumToList(System.Type enumType)
        {
            List<NameType> list = new List<NameType>();
            var ss = Enum.GetNames(enumType);
            foreach (var t in ss)
            {
                NameType nt = new NameType();
                var j = (int)Enum.Parse(enumType, t);
                nt.Id = j;
                nt.Name = t;
                list.Add(nt);
            }
            return list;
        }
        /// <summary>
        /// 将枚举转换成字典集合
        /// </summary>
        /// <typeparam name="T">枚举类型</typeparam>
        /// <returns></returns>
        public static Dictionary<string, int> getEnumDic<T>()
        {
            Dictionary<string, int> resultList = new Dictionary<string, int>();
            Type type = typeof(T);
            var strList = GetNamesArr<T>().ToList();
            foreach (string key in strList)
            {
                string val = Enum.Format(type, Enum.Parse(type, key), "d");
                resultList.Add(key, int.Parse(val));
            }
            return resultList;
        }
        /// <summary>
        /// 将枚举转换成字典
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, int> GetDic<TEnum>()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            Type t = typeof(TEnum);
            var arr = Enum.GetValues(t);
            foreach (var item in arr)
            {
                dic.Add(item.ToString(), (int)item);
            }
            return dic;
        }
    }
}
