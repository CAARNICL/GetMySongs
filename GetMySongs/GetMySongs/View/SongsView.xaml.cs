using GetMySongs.Model;
using GetMySongs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}