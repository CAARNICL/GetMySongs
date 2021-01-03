using GetMySongs.Model;
using GetMySongs.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetMySongs.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SongsView : ContentPage
    {
        private SongsViewModel SongsModel;

        public SongsView(string theUsername, int count = -1)
        {
            SongsModel = new SongsViewModel(theUsername, count);
            BindingContext = SongsModel;
            InitializeComponent();
        }

        private async void Download_Clicked(object sender, EventArgs e)
        {
            await SongsModel.Download((sender as MenuItem).CommandParameter as GetMySongs.Model.SongListItem);
        }

        private async void Download_ALL(object sender, EventArgs e)
        {
            int i = 0;
            await SongsModel.DonmwloadAll();
            /*foreach(SongListItem song in SongsModel.userList)
            {
                i++;
                await SongsModel.Download(song);
                this.Title = "Download " + i + " von " + SongsModel.userList.Count;
            }*/
            //SongsModel.Download((sender as MenuItem).CommandParameter as GetMySongs.Model.SongListItem);
        }

        public void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            SongListItem sli = SongsModel.userList[e.ItemIndex];
            string uri = "https://www.smule.com" + sli.DownloadUri;
            Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}