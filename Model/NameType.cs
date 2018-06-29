using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Model
{
    public class NameType
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int CodeId { set; get; }
        public string Code { set; get; }

        public NameType(int id, string name)
        {
            Id = id;
            Name = name; 
        }
        public NameType()
        {
            Id = 0;
            Name = "";
        }

      
        /// <summary>
        /// 获取名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string GetName(int id, List<NameType> list)
        {
            foreach (NameType nn in list)
            {
                if (id == nn.Id)
                    return nn.Name;
            }
            return "";
        }

     

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="name"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int GetId(string name, List<NameType> list)
        {
            foreach (NameType nn in list)
            {
                if (name.Trim() == nn.Name.Trim())
                    return nn.Id;
            }
            return -1;
        }



        public static List<NameType> GetNameTypeListDataTable(DataTable dt, int IdIndex, int NameIndex)
        {
            if (dt == null)
                return null;
            if (IdIndex >= 0 && IdIndex < dt.Columns.Count)
                if (NameIndex >= 0 && NameIndex < dt.Columns.Count)
                {
                    List<NameType> result = new List<NameType>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        NameType nt = new NameType() { Id = int.Parse(dt.Rows[i][IdIndex].ToString()), Name = dt.Rows[i][NameIndex].ToString() };
                        result.Add(nt);
                    }
                    return result;
                }
            return null;
        }
    }
}
