using GetMySongs.Interface;
using GetMySongs.Model;
using SmuleLib;
using SmuleLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GetMySongs.ViewModel
{
    public class SongsViewModel : ViewModelBase
    {
        public string userName { get; set; }
        public ObservableCollection<SongListItem> userList { get; set; }

        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged("IsBusy"); } }
        public void Download(SongListItem obj)
        {
            SmuleClient client = new SmuleClient();
            DependencyService.Get<ISaveFile>().SaveFile();
            //string thePath = Environment..GetExternalStoragePublicDirectory(Environment.DirectoryDocuments).AbsolutePath Environment.GetFolderPath(Environment.SpecialFolder.);
            client.DownloadSong(obj.DownloadUri, obj.Title, "/storage/emulated/0/Music/");
        }

        public SongsViewModel(string theUsername)
        {
            userName = theUsername;
            userList = new ObservableCollection<SongListItem>();
            GetFavorites();
        }

        private async void GetFavorites()
        {
            SmuleClient client = new SmuleClient();
            IsBusy = true;
            List<SmuleLib.Model.List> favSongs = await client.GetFavoritesAsync(userName, 200);
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
