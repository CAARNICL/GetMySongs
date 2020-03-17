using GetMySongs.Interface;
using GetMySongs.Model;
using SmuleLib;
using SmuleLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GetMySongs.ViewModel
{
    public class SongsViewModel : ViewModelBase
    {
        private int _count;
        private string _userName;
        public string userName { get { return _userName; } set { _userName = value; RaisePropertyChanged("userName"); } }
        public ObservableCollection<SongListItem> userList { get; set; }

        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged("IsBusy"); } }
        public async Task Download(SongListItem obj)
        {
            SmuleClient client = new SmuleClient();
            if (Device.RuntimePlatform == Device.Android)
            {
                DependencyService.Get<ISaveFile>().SaveFile();
                //string thePath = Environment..GetExternalStoragePublicDirectory(Environment.DirectoryDocuments).AbsolutePath Environment.GetFolderPath(Environment.SpecialFolder.);
                await client.DownloadSong(obj.DownloadUri, obj.Title, "/storage/emulated/0/Music/");
            }
            if(Device.RuntimePlatform == Device.iOS)
            {
                string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                downloadPath = Path.Combine(downloadPath, "Music");
                if (!Directory.Exists(downloadPath))
                    Directory.CreateDirectory(downloadPath);
                //ToDo
                //There is some trouble with file.exists
               // if(!File.Exists(Path.Combine(downloadPath,obj.Title + ".mp4")))
                    await client.DownloadSong(obj.DownloadUri, ReplaceIllegal(obj.Title, "_"), downloadPath); 
            }
        }

        private string ReplaceIllegal(String input, String Replacer)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(input, Replacer);
        }

        public async Task DonmwloadAll()
        {
            List<SongListItem> downloadList = new List<SongListItem>();
            if (Device.RuntimePlatform == Device.iOS)
            {
                string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                downloadPath = Path.Combine(downloadPath, "Music");
                if (!Directory.Exists(downloadPath))
                    Directory.CreateDirectory(downloadPath);
                foreach (SongListItem song in this.userList)
                {
                    //ToDo
                    //There is some trouble with file.exists
                    if (!File.Exists(Path.Combine(downloadPath, ReplaceIllegal(song.Title, "_") + ".mp4")))
                    {
                        downloadList.Add(song);
                    }
                    else
                    {
                        song.Title = "Downloaded: " + ReplaceIllegal(song.Title, "_");
                    }
                }
                int i = 0;
                foreach (SongListItem song in downloadList)
                {
                    i++;
                    await Download(song);
                    song.Title = "Downloaded: " + ReplaceIllegal(song.Title, "_");
                    userName = "Download " + i + " von " + downloadList.Count;
                }
            }


            
        }

        public SongsViewModel(string theUsername, int theCount = -1)
        {
            _count = theCount;
            userName = theUsername;
            userList = new ObservableCollection<SongListItem>();
            GetFavorites();
        }

        private async void GetFavorites()
        {
            SmuleClient client = new SmuleClient();
            IsBusy = true;
            List<SmuleLib.Model.List> favSongs = await client.GetFavoritesAsync(userName, _count);
            IsBusy = false;
            foreach(SmuleLib.Model.List song in favSongs)
            {
                SongListItem item = new SongListItem();
                item.Title = song.title;
                item.Performare = song.other_performers.Length > 0 ? (song.other_performers[0].handle + " - " + song.owner.handle) : song.owner.handle;
                item.PerformanceDate = song.created_at.ToString();
                item.PerformareGroup = song.owner.handle;
                item.DownloadUri = song.web_url;
                userList.Add(item);
            }
        }
    }
}
