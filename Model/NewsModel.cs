using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
   public  class NewsModel
    {
        public int Id { set; get; }
        public string title { set; get; }
        public string author { set; get; }
        public string time { set; get; }
        public int click { set; get; }
        public string Source { set; get; }
        public string image { set; get; }
    }
}
