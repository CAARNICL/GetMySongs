using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace GetMySongs.ViewModel
{
    public class FilesViewModel : ViewModelBase
    {
        public ObservableCollection<string> fileList { get; set; }

        public FilesViewModel()
        {
            fileList = new ObservableCollection<string>();
            string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            downloadPath = Path.Combine(downloadPath, "Music");
            if (!Directory.Exists(downloadPath))
                Directory.CreateDirectory(downloadPath);
            string[] list = Directory.GetFiles(downloadPath, "*.mp4");
            foreach (string song in list)
                fileList.Add(song);
        }
    }
}
