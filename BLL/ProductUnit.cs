using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace JxPrint.BLL
{
   [Serializable]
    //public delegate void ChangePaperNum(ProductUnit Sender,int num);
    public class ProductUnit
   {
       public rectang Size;//存放展开尺寸，其中RECTANGLE里的ID,存放SIZEID，MID存放纸张ID；NUM存放页码数量；双面单页为2，单面单页为1；
 
       public Paper UserPaper;
       public string UnitName;
       public int PaperSource;
       public int Color;
       public int ContentRepeat;
       public int GroupId;
       public decimal PaperUserRatio;

       public int NeedNum;
       public int PrintNum;
       public int PaperNum;
       public int PageNum;

       public int weight;
       public decimal  thick; //一个产品的厚度；

       public rectang PrintPaper;  //存储了该产品单元的开纸方式等信息；
       public PrintSheet PrintPs;   //记录了该产品的印刷信息，如各种版需要多少等信息；

       public int PsKaidu;
       public int ProductKaidu;

       int paperid;

       //public  event ChangePaperNum PaperNumChange;
      
       private  decimal _extendratio;
       public decimal ExtendRatio
       {
           set 
           {
               _extendratio += value;
               if (_extendratio > 1)
               {
                   ExtendNum += Convert.ToInt32((PaperNum + ExtendNum) * (_extendratio - 1));
               }
               else
               {
                   ExtendNum += Convert.ToInt32((PaperNum + ExtendNum) * _extendratio);
               }
           }
           get
           {
               return _extendratio;
           }
       }
       private int _extendnum;
       public int ExtendNum
       {
           set 
           {    
               _extendnum = value;
           }
           get
           {
               return _extendnum;
           }
       }
       
       
      
     /// <summary>
     /// 初始化一个标准产品
     /// </summary>
     /// <param name="size">SIZE.NUM=PAGENUM  Size.Mid=PaperId</param>
     /// <param name="color">颜色</param>
     /// <param name="ProNum">数量</param>
       public ProductUnit(rectang size,int color,int ProNum)
       {
           PageNum = size.Num;
           Size = new rectang();
           Size = size;
           Color = color;
           PaperSource = 0;
           paperid = size.MId;
           ContentRepeat = 0;
           NeedNum = ProNum;
           ExtendRatio = 1;
           ReCaculation();
           
       }
    /// <summary>
    /// 输入所有参数初始化一个产品基类；封面尺寸为不规范是，输入页码2，尺寸为展开尺寸，
    /// 标准的封面页码为4，尺寸为折叠尺寸
    /// </summary>
    /// <param name="sizeid">尺寸ID</param>
    /// <param name="Length">尺寸长</param>
    /// <param name="Height">尺寸高</param>
    /// <param name="paperId">纸张的类型</param>
    /// <param name="color">印刷颜色</param>
    /// <param name="type">产品类型，1为单页，2为折页</param>
    /// <param name="pageNum">折页的页码数必须大于2，,否则为单页</param>
    /// <param name="paperSource">纸张来源0 为我厂，1为客户自带</param>
    /// <param name="contentRepeat">印刷内容是否重复，0为正常，不重复，1为重复，2为无内容</param>
    /// <param name="pronum">产品数量</param>
       public ProductUnit(int sizeid, int Length, int Height, int paperId, int color,  int pageNum, int paperSource, int contentRepeat, int pronum)
       {
           PageNum = pageNum;
           Size = new rectang();
           if (sizeid > 0)
           {
               Size.Id = sizeid;
           }
           else
           {
               Size.Length = Length;
               Size.Height = Height;
           }
           Color = color;
           PaperSource = paperSource;
           ContentRepeat = contentRepeat;
           NeedNum = pronum;
           paperid = paperId;
           ExtendRatio = 0;
           ReCaculation();
           
       }
       private void SetSize(BLL.rectang NewSize)
       {
           PrintPaper = NewSize;
           ProductKaidu = Size.Kaidu;
           PsKaidu = PrintPaper.Kaidu;
       }
       private void GetSize()
       {
            FoldSheet fd;
           if (Size.Id > 0)
           {
               fd = new FoldSheet(Size.Id);
           }
           else
           {
               fd = new FoldSheet(Size.Length, Size.Height);
           }
           Size = fd.OldSize;
           PrintPaper = new rectang();
           PrintPaper = fd.NewSize;
           ProductKaidu = Size.Kaidu;
           PsKaidu = PrintPaper.Kaidu;
       }
        /// <summary>
        /// 初始化画册以后进行计算，一般不需要外部调用；
        /// 重新计算开版方式、纸张数量等，重量等
        /// </summary>
       public void ReCaculation()
       {
           GetSize();
           if (PrintPaper.Name.IndexOf("正") >= 0)
           {
               UserPaper = new Paper(paperid, 1);
           }
           else
           {
               UserPaper = new Paper(paperid, 2);
           }
           CalculationPaper();
           GetWeight();
           GetThcik();
       }

       public void ReCaculation(BLL.rectang NewSize)
       {
           SetSize(NewSize);
           CalculationPaper();
           GetWeight();
           GetThcik();
       }
       private void CalculationPaper()
       {
           int page = PageNum;
           Size.Num = PageNum;
           if (page == 1)
               page = 2;
           PaperNum = NeedNum * (page / 2) / Size.Kaidu;
           PrintPs = new PrintSheet(Color, Size.Kaidu, PrintPaper.Kaidu, NeedNum, Size.Num, PrintPaper.Name);
           PrintNum = PrintPs.TotalPrintNum;

           int UserArea = Size.Height * Size.Length * Size.Kaidu;
           int PaperArea = PrintPaper.Height * PrintPaper.Length * PrintPaper.Kaidu;
           PaperUserRatio = (decimal)UserArea / (decimal)PaperArea;
 
       }

       public bool SaveUnit(string ProductCode)
       {
           Model.ProductPaperUnit ppu = new Model.ProductPaperUnit();
           ppu.Id = ProductCode + GroupId.ToString();
           ppu.ProdcutCode = ProductCode;
           ppu.Color = Color;
           ppu.ContextReapet = ContentRepeat;
           ppu.GroupId = GroupId;
           ppu.UnitName = UnitName;
           ppu.PaperName = UserPaper.PaperName;
           ppu.PaperId = UserPaper.Id;
           ppu.PageNum = PageNum;
           ppu.SizeId = Size.Id;
           ppu.SizeName = Size.Name;
           ppu.PaperSource = PaperSource;
           ppu.ProductNum = NeedNum;
           if (DAL.ProductPaperUnit.Add(ppu))
               return true;
           else
               return false;

       }
       private void GetWeight()
       {
           double s = (double)Size.Length * Size.Height;
           s = s * UserPaper.kg;
           s = s * NeedNum;
           if (Size.Num > 3)
               s = s * Size.Num / 2;
           double xishu = (double)(1000 * 1000 * 1000);
           double r = s / xishu;
           weight = Convert.ToInt32(r);
       }

       private void GetThcik()
       {
           int xishu=UserPaper.ThickXishu ;
           xishu = Size.Num * xishu;
           thick = (decimal)xishu / (decimal)100;
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
