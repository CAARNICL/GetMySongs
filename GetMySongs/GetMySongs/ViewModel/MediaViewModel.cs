using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace GetMySongs.ViewModel
{
    class MediaViewModel : ViewModelBase
    {
        public MediaSource mediaSource;

        public MediaViewModel(string theFile)
        {
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            downloadPath = Path.Combine(downloadPath, "Music");
            downloadPath = Path.Combine(downloadPath, "Run.mp4");

            mediaSource = MediaSource.FromFile(downloadPath);
            
        }
    }
}
