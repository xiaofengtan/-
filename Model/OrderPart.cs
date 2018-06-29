/**  版本信息模板在安装目录下，可自行修改。
* P_OrderDetail.cs
*
* 功 能： N/A
* 类 名： P_OrderDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017-05-02 16:31:09   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：山西四元信息科技有限公司　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
    /// <summary>
    /// P_OrderDetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [DataSource.Table(IsCahche = false, NickName = "产品分项表", TableName = "OrderPart")]
    public  class OrderPart
    {
        public OrderPart()
        { }
        public OrderPart(int orderId)
        {
            OrderId = orderId;
        }
        #region feild
        private int _partid;
        private string _partname;
        private int _orderid;
        private string _orderon;
        private int _paperid;
        private string _papername;
        private int _width;
        private int _length;
        private int _sizeid;
        private int _pswidth;
        private int _pslength;
        private int _paperwidth;
        private int _paperlength;
        private int _pagenum;
        private int _colornum;
        private int _num;
        private int _psnum;
        private int _papernum;
        private int _paperextend;
        private int _papersouce;
        private string _request;
        private string _remark;
        private int _b1;
        private string _b2;

        [DataSource.Column(IsIdentity = true, IsPrimary = true, NickName = "编号")]
        public int PartId
        {
            get
            {
                return _partid;
            }

            set
            {
                _partid = value;
            }
        }
        [DataSource.Column(NickName = "部件名称")]
        public string PartName
        {
            get
            {
                return _partname;
            }

            set
            {
                _partname = value;
            }
        }
        [DataSource.Column(NickName = "订单编号")]
        public int OrderId
        {
            get
            {
                return _orderid;
            }

            set
            {
                _orderid = value;
            }
        }
        [DataSource.Column(NickName = "订单序号")]
        public string OrderOn
        {
            get
            {
                return _orderon;
            }

            set
            {
                _orderon = value;
            }
        }
        [DataSource.Column(NickName = "纸张编号")]
        public int PaperId
        {
            get
            {
                return _paperid;
            }

            set
            {
                _paperid = value;
            }
        }
        [DataSource.Column(NickName = "纸张名称")]
        public string PaperName
        {
            get
            {
                return _papername;
            }

            set
            {
                _papername = value;
            }
        }
        [DataSource.Column(NickName = "成品宽")]
        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }
        [DataSource.Column(NickName = "成品长")]
        public int Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }
        [DataSource.Column(NickName = "尺寸编码")]
        public int SizeId
        {
            get
            {
                return _sizeid;
            }

            set
            {
                _sizeid = value;
            }
        }
        [DataSource.Column(NickName = "版面宽")]
        public int PSWidth
        {
            get
            {
                return _pswidth;
            }

            set
            {
                _pswidth = value;
            }
        }
        [DataSource.Column(NickName = "版面长")]
        public int PSLength
        {
            get
            {
                return _pslength;
            }

            set
            {
                _pslength = value;
            }
        }
        [DataSource.Column(NickName = "上机宽")]
        public int PaperWidth
        {
            get
            {
                return _paperwidth;
            }

            set
            {
                _paperwidth = value;
            }
        }
        [DataSource.Column(NickName = "上机长")]
        public int PaperLength
        {
            get
            {
                return _paperlength;
            }

            set
            {
                _paperlength = value;
            }
        }
        [DataSource.Column(NickName = "内容页数")]
        public int PageNum
        {
            get
            {
                return _pagenum;
            }

            set
            {
                _pagenum = value;
            }
        }
        [DataSource.Column(NickName = "颜色数")]
        public int ColorNum
        {
            get
            {
                return _colornum;
            }

            set
            {
                _colornum = value;
            }
        }
        [DataSource.Column(NickName = "产品数量")]
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
        [DataSource.Column(NickName = "版纸数量")]
        public int PSNum
        {
            get
            {
                return _psnum;
            }

            set
            {
                _psnum = value;
            }
        }
        [DataSource.Column(NickName = "大张数")]
        public int PaperNum
        {
            get
            {
                return _papernum;
            }

            set
            {
                _papernum = value;
            }
        }
        [DataSource.Column(NickName = "放张数")]
        public int PaperExtend
        {
            get
            {
                return _paperextend;
            }

            set
            {
                _paperextend = value;
            }
        }
        [DataSource.Column(NickName = "纸张来源")]
        public int PaperSource
        {
            get
            {
                return _papersouce;
            }

            set
            {
                _papersouce = value;
            }
        }
        [DataSource.Column(NickName = "印刷要求")]
        public string Request
        {
            get
            {
                return _request;
            }

            set
            {
                _request = value;
            }
        }
        [DataSource.Column(NickName = "备注")]
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
        [DataSource.Column(NickName = "备注1")]
        public int b1
        {
            get
            {
                return _b1;
            }

            set
            {
                _b1 = value;
            }
        }
        [DataSource.Column(NickName = "备注2")]
        public string b2
        {
            get
            {
                return _b2;
            }

            set
            {
                _b2 = value;
            }
        }

        #endregion
    }
}

