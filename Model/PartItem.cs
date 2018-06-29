using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PartItem
    {
        private int _partType;
        private string _partName;
        private int _id;
        private string name;
        private decimal _price;
        private int _num;
        private decimal _money;
        private string _remark;
        [DataSource.Column(NickName = "类型编号")]
        public int PartType
        {
            get
            {
                return _partType;
            }

            set
            {
                _partType = value;
            }
        }
        [DataSource.Column(NickName = "类型名称")]
        public string PartName
        {
            get
            {
                return _partName;
            }

            set
            {
                _partName = value;
            }
        }
        [DataSource.Column(NickName = "编号")]
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        [DataSource.Column(NickName = "名称")]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        [DataSource.Column(NickName = "单价")]
        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }
        [DataSource.Column(NickName = "数量")]
        public int Num
        {
            get
            {
                return _num;
            }

            set
            {
                _num = value;
            }
        }
        [DataSource.Column(NickName = "金额")]
        public decimal Money
        {
            get
            {
                return _money;
            }

            set
            {
                _money = value;
            }
        }
        [DataSource.Column(NickName = "说明")]
        public string Remark
        {
            get
            {
                return _remark;
            }

            set
            {
                _remark = value;
            }
        }

        public static List<string> GetColumNikeName()
        {
            return DataSource.ORMHelper.GetColumnsName(typeof(PartItem));
        }
    }

}
