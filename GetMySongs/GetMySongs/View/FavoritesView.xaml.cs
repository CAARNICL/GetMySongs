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
    public partial class FavoritesView : ContentPage
    {
        private FavoritesViewModel favModel;
        public FavoritesView(string theUsername)
        {
            InitializeComponent();
            favModel = new FavoritesViewModel(theUsername);
            BindingContext = favModel;
        }

        private void Download_Clicked(object sender, EventArgs e)
        {
            favModel.Download((sender as MenuItem).CommandParameter as GetMySongs.Model.SongListItem);
        }
    }
}