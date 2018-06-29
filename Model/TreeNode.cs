using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    
    public class PaperTreeNode
    {
        private int Cut;
        public int Kaidu;
        public CutModeMenu CutMode;
        public int Level;
        public int Len;
        public int Width;
        public PaperTreeNode L2Cut;
        public PaperTreeNode W2Cut;
        public PaperTreeNode L3Cut;
        public PaperTreeNode W3Cut;

        public PaperTreeNode Root;

        
        public PaperTreeNode(int level, int l, int w, PaperTreeNode root, int k)
        {
            Len = l;
            Width = w;
            Level = level - 1;
            Kaidu = k;
            Root = root;
            if ((Level <= 0 || Len < 50 || Width < 50))
            {
                Len = 0;
                Width = 0;
                CutMode = CutModeMenu.无;
                return;
            }
            if (FitRect())
            {
                Cut = 1;
                CutMode = CutModeMenu.无; ;
                L2Cut = new PaperTreeNode(Level, (Len - Cut) / 2, Width, this, Kaidu * 2);
                L2Cut.CutMode = CutModeMenu.左右对开;
                L3Cut = new PaperTreeNode(Level, (Len - Cut * 2) / 3, Width, this, Kaidu * 3);
                L3Cut.CutMode = CutModeMenu.左右三开;
                W2Cut = new PaperTreeNode(Level, Len, (Width - Cut) / 2, this, Kaidu * 2);
                W2Cut.CutMode = CutModeMenu.上下对开;
                W3Cut = new PaperTreeNode(Level, Len, (Width - 2 * Cut) / 3, this, Kaidu * 3);
                W3Cut.CutMode = CutModeMenu.上下三开;
            }
            else
            {
                return;
            }
        }

        public PaperTreeNode(Rectange paper) : this(7, paper.Length, paper.Width, null, 1)
        { }

        public Rectange Node2Rect()
        {
            Rectange result = new Rectange(Len, Width);
            result.Name = EnumHelper.GetEnumName<CutModeMenu>((int)(CutMode));
            if (result == Common.BigPaper)
            {
                result.Name = "大规纸";
            }
            if (result == Common.SmallPaper)
            {
                result.Name = "正规规纸";
            }
            result.Id = 0;
            result.Kaidu = Kaidu;
            return result;
        }
     
        public Rectange GetPsRect()
        {
            PaperTreeNode pt = this;
            PaperTreeNode pt1=this;
            while(pt.Root!=null)
            {
                pt1 = pt;
                pt = pt.Root;
            }
            Rectange result = new Rectange(pt1.Len, pt1.Width);
            result.Name = "上机尺寸：" + pt1.Kaidu.ToString() + "开";
            result.Id = 0;
            return result;
        }
        public Rectange GetPaperRect()
        {
            PaperTreeNode pt = this;
            PaperTreeNode pt1 = this;
            while (pt != null)
            {
                pt1 = pt;
                pt = pt.Root;
            }
            Rectange result = new Rectange(pt1.Len, pt1.Width);
            result.Name = EnumHelper.GetEnumName<CutModeMenu>((int)CutMode)+  pt1.Kaidu.ToString() + "开";
            result.Id = 0;
            return result;
        }
        private bool FitRect()
        {
            if (Kaidu < Common.PsBase.Kaidu)
                return true;
            int l, h;
            if (Len > Width)
            {
                l = Len;
                h = Width;
            }
            else
            {
                l = Width;
                h = Len;
            }
            return (l <= Common.PsBase.Length && h <=Common.PsBase.Width);
        }

        public List<PaperTreeNode> GetCutRouter()
        {
            List<PaperTreeNode> list = new List<PaperTreeNode>();
            PaperTreeNode pt = this;
            PaperTreeNode pt1 = this;
            while (pt != null)
            {
                pt1 = pt;
                list.Add(pt1);
                pt = pt.Root;
            }
            if (list.Count > 0)
                return list;
            else
                return null;

        }
    }

    public class Tree
    {
        PaperTreeNode BigRoot;
        PaperTreeNode SmallRoot;
        //PaperTreeNode PsRoot;
        public List<PaperTreeNode> AllBig;
        public List<PaperTreeNode> AllSmall;
        public List<PaperTreeNode> AllPs;
        public Tree()
        {

            BigRoot = new PaperTreeNode(Common.BigPaper);
            SmallRoot = new PaperTreeNode(Common.SmallPaper);
           

            AllBig = new List<PaperTreeNode>();
            AllSmall = new List<PaperTreeNode>();
            AllPs = new List<PaperTreeNode>();

            GetAllChild(BigRoot,AllBig);
            GetAllChild(SmallRoot, AllSmall);
        }

        private void GetAllChild(PaperTreeNode root, List<PaperTreeNode> list)
        {
            if (root != null)
            {
                if (root.Len != 0)
                {
                    list.Add(root);
                    GetAllChild(root.L2Cut,list);
                    GetAllChild(root.W2Cut, list);
                    GetAllChild(root.L3Cut, list);
                    GetAllChild(root.W3Cut, list);
                }
            }
        }

        public List<PaperTreeNode> GetCutList(int l, int h)
        {
            Rectange rect = new Rectange(l,h);
            PaperTreeNode big = GetFitSize(l, h, AllBig);
            PaperTreeNode small = GetFitSize(l, h, AllSmall);

            List<Model.PaperTreeNode> list = big.GetCutRouter();
            decimal r = GetPaperRation(l, h, list);

            List<Model.PaperTreeNode> list2= small.GetCutRouter();
            decimal r1 = GetPaperRation(l, h, list2);

            if (r > r1)
            {
                return list;
            }
            else
                return list2;
        }

        public decimal GetPaperRation(int l, int h, List<Model.PaperTreeNode> list)
        {
            Model.Rectange rect1 = new Model.Rectange(l, h);
            rect1.Kaidu = list[0].Kaidu;
            decimal r = rect1.GetRatio(list[list.Count - 1].Node2Rect());
            r = decimal.Round(r  * 100, 2);
            return r;
        }

        public Model.Rectange GetPaper(int l, int h)
        {
            List<PaperTreeNode> list = GetCutList(l, h);
            if (list.Count > 1)
            {
                return list[list.Count - 1].Node2Rect();
            }
            return null;
        }

        public Model.Rectange GetPs(int l, int h)
        {
            List<PaperTreeNode> list = GetCutList(l, h);
            if (list.Count > 2)
            {
                return list[list.Count - 2].Node2Rect();
            }
            return null;
        }

        public Model.Rectange GetCutSize(int l, int h)
        {
            List<PaperTreeNode> list = GetCutList(l, h);
            if (list.Count > 2)
            {
                return list[0].Node2Rect();
            }
            return null;
        }
        public PaperTreeNode GetFitSize(int l, int h,List<PaperTreeNode> list)
        {
            decimal ratio = 0;
            int x1, y1, x2, y2;
            if (l > h)
            {
                x1 = l;
                y1 = h;
            }
            else
            {
                x1 = h;
                y1 = l;
            }
            if (list.Count > 0)
            {
                int index = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    int x = list[i].Len;
                    int y = list[i].Width;
                    if (x > y)
                    {
                        x2 = x;
                        y2 = y;
                    }
                    else
                    {
                        x2 = y;
                        y2 = x;
                    }

                    if (x1 <=x2 && y1 <= y2)
                    {
                        decimal s1= (decimal)x1 * y1;
                        decimal s2 = (decimal)x2 * y2;
                        decimal r = s1 / s2;
                        if (r > ratio)
                        {
                            index = i;
                            ratio = r;
                        }
                    }
                }
                if (index > 0)
                    return list[index];
            }
            return null;
        }
    }
}
        
   

