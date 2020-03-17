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
        public SongsView(string theUsername)
        {
            InitializeComponent();
            SongsModel = new SongsViewModel(theUsername);
            BindingContext = SongsModel;
        }

        private void Download_Clicked(object sender, EventArgs e)
        {
            SongsModel.Download((sender as MenuItem).CommandParameter as GetMySongs.Model.SongListItem);
        }
    }
}