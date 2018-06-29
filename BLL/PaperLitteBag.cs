using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JxPrint.BLL
{
    public class PaperLitteBag : papersheet
    {
        /// <summary>
        /// 封套的初始化程序
        /// </summary>
        /// <param name="psize"></param>
        /// <param name="ProNum"></param>
        /// <param name="color"></param>
        /// <param name="AddHeight">封套增加部分的长度</param>
        public PaperLitteBag(Model.recttange psize, int ProNum, int color,int AddHeight)
            : base(psize, ProNum, color)
        {
            ProductName = "封套";
            ProductId = 10;
            InsertSingleProcess(26, ProNum);
            InsertSingleProcess(27, ProNum);
            Cover.UnitName = "封套";
        }
    }
}
