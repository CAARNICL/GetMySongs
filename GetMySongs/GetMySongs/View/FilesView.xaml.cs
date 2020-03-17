using GetMySongs.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetMySongs.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilesView : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public FilesView()
        {
            InitializeComponent();
            BindingContext = new FilesViewModel();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            string path = /*"file://" + */e.Item.ToString();
            //path = Path.Combine(path, e.Item.ToString());
            //Device.OpenUri(new Uri(path));
            await Navigation.PushAsync(new MediaView(path));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
