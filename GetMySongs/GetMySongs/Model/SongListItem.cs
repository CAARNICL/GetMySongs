using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GetMySongs.Model
{
    public class SongListItem : INotifyPropertyChanged
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
        private bool _isDownloaded;
        public bool IsDownloaded { get { return _isDownloaded; } set { _isDownloaded = value; RaisePropertyChanged("IsDownloaded"); } }
        private bool _isDownloading = false;
        public bool IsDownloading { get { return _isDownloading; } set { _isDownloading = value; RaisePropertyChanged("IsDownloading"); } }
        private int _progress;
        public int Progress { get { return _progress; } set { _progress = value; RaisePropertyChanged("Progress"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Progress<float> progress = new Progress<float>();
        
        public SongListItem()
        {
            progress.ProgressChanged += Download_Progress_Changed;
        }

        private void Download_Progress_Changed(object sender, float e)
        {
            if(!this.IsDownloaded)
            { 
                this.IsDownloading = true;
                Progress = (int)e;
                if (e == 100)
                { 
                    this.IsDownloaded = true;
                    this.IsDownloading = false;
                }
            }
        }
    }
}
