using System;
using System.Collections.Generic;
using System.Text;

namespace GetMySongs.Model
{
    public class SongListItem
    {
        public String Title { get; set; }
        public String Performare { get; set; }
        public String PerformanceDate { get; set; }
        public string PerformareGroup { set; get; }
        public string MediaUri { get; set; }
        public string DownloadUri
        {
            get;set;
        }
    }
}
