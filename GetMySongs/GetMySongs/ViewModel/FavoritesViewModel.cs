using GetMySongs.Model;
using SmuleLib;
using SmuleLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GetMySongs.ViewModel
{
    public class FavoritesViewModel : ViewModelBase
    {
        public string userName { get; set; }
        public ObservableCollection<SongListItem> userList { get; set; }

        public ICommand DownloadCommand => new Command(Download);

        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged("IsBusy"); } }
        private void Download(object obj)
        {

        }

        public FavoritesViewModel(string theUsername)
        {
            userName = theUsername;
            userList = new ObservableCollection<SongListItem>();
            GetFavorites();
        }

        private async void GetFavorites()
        {
            SmuleClient client = new SmuleClient();
            IsBusy = true;
            List<SmuleLib.Model.List> favSongs = await client.GetFavoritesAsync(userName);
            IsBusy = false;
            foreach(SmuleLib.Model.List song in favSongs)
            {
                SongListItem item = new SongListItem();
                item.Title = song.title;
                userList.Add(item);
            }
        }
    }
}
