using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   
    public class OrderItem
    {
        [DataSource.Column(NickName="纸张编号")]
        public int PaperId { set; get; }
        [DataSource.Column(NickName = "纸张名称")]
        public string PaperName { set; get; }
        [DataSource.Column(NickName = "客户自带")]
        public bool IsUserPaper { set; get; }

        [DataSource.Column(NickName = "成品长度")]
        public int Length { set; get; }
        [DataSource.Column(NickName = "成品宽度")]
        public int Width { set; get; }
        [DataSource.Column(NickName = "上机长度")]
        public int PreLen { set; get; }
        [DataSource.Column(NickName = "上机宽度")]
        public int PreWidth { set; get; }
        [DataSource.Column(NickName = "上机开度")]
        public int PreKaidu { set; get; }
        [DataSource.Column(NickName = "大张数量")]
        public int FullPaperNum { set; get; }
        [DataSource.Column(NickName = "损耗数量")]
        public int LostNum { set; get; }
        [DataSource.Column(NickName = "出货数量")]
        public int UseNum { set; get; }
        [DataSource.Column(NickName = "版纸套数")]
        public int PsNum { set; get; }

        [DataSource.Column(NickName = "颜色数")]
        public int PsColorNum { set; get; }

        [DataSource.Column(NickName = "制版方式")]
        public PsMode Psmode { set; get; }
        
        public List<Model.NameType> AllProcess;

        public static List<string> GetColName()
        {
            return DataSource.ORMHelper.GetColumnsName(typeof(OrderItem));
        }
    }
}
