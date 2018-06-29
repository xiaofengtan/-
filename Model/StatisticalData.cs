using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class StatisticalData
    {
        #region 文字
        /// <summary>
        /// 日期
        /// </summary>
        public string Tim { get; set; }
        /// <summary>
        /// 凭单号
        /// </summary>
        public string OrderOn { get; set; }
        /// <summary>
        /// 委印单位
        /// </summary>
        public string Vender { get; set; }
        /// <summary>
        /// 印刷品名
        /// </summary>
        public string OrderName { get; set; }
        /// <summary>
        /// 业务来源
        /// </summary>
        public string Source { get; set; }
        #endregion

        #region 合计

        /// <summary>
        /// 总价
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 原始价格
        /// </summary>
        public int OldPrice { get; set; }
        /// <summary>
        /// 印工合计(不含CTP版)
        /// </summary>
        public int NoCtpVersion { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 理论对开张
        /// </summary>
        public int PrintNum { get; set; }
        /// <summary>
        /// 实际对开张
        /// </summary>
        public int RealPrintNum { get; set; }

        #endregion

        #region 成本
        /// <summary>
        /// 纸张
        /// </summary>
        public string Paper { get; set; }
        /// <summary>
        /// 纸张成本
        /// </summary>
        public int PaperCost { get; set; }
        /// <summary>
        /// CTP版成本
        /// </summary>
        public int CTPCost { get; set; }
        /// <summary>
        /// 彩版
        /// </summary>
        public int CTPNumBlack { get; set; }
        /// <summary>
        /// 黑版
        /// </summary>
        public int CTPNumColor { get; set; }
        /// <summary>
        /// 后道成本
        /// </summary>
        public int ProcessCost { get; set; }
        /// <summary>
        /// 成本合计
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// 纸张来源
        /// </summary>
        public string PaperSource { get; set; }

        public string OldOrderNo { get; set; }
        #endregion

    }
}