using GetMySongs.Model;
using GetMySongs.View;
using SmuleLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GetMySongs.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<ProfileListItem> userList { get; set; }
        public ICommand SearchCommand => new Command(Search);
        public ICommand FavCommand => new Command(Fav);

        private void Fav(Object obj)
        {
            Navigation.PushAsync(new FavoritesView(userName));
        }

        public string userName { get; set; }

        public Uri userImage { get; set; }
        private async void Search(object obj)
        {
            SmuleLib.SmuleClient client = new SmuleLib.SmuleClient();
            Profile profile = await client.GetProfileAsync(userName);
            ProfileListItem pli = new ProfileListItem();
            pli.title = profile.user.handle;
            userImage = new Uri(profile.user.pic_url);
            userList.Add(pli);
        }
        private INavigation Navigation;
        public MainViewModel(INavigation theNavigation)
        {
            Navigation = theNavigation;
            userList = new ObservableCollection<ProfileListItem>();
            userImage = new Uri("https://c-ash.smule.com/sf/z5/account/picture/39/5d/cb69ac87-1e52-4de3-a386-8f64d89c081e.jpg");
        }
    }
}
