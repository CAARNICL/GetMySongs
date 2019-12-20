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
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ProfileListItem> userList { get; set; }

        public ObservableCollection<PerformListItem> performList { get; set; }
        public ICommand SearchCommand => new Command(Search);

        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged("IsBusy"); } }

        private PerformListItem _selectedItem;
        public PerformListItem SelectedItem
        {
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
  
                    Songs(_selectedItem);

                }
            }
        }

        private void Songs(PerformListItem obj)
        {
            if(obj!= null)
                switch(obj.Title)
                {
                    case "Favorites":
                        {
                            Navigation.PushAsync(new SongsView(userName));
                        }break;
                }
        }

        public string userName { get; set; }

        public Uri userImage { get; set; }
        private async void Search(object obj)
        {
            IsBusy = true;
            SmuleLib.SmuleClient client = new SmuleLib.SmuleClient();
            Profile profile = await client.GetProfileAsync(userName);
            /*ProfileListItem pli = new ProfileListItem();
            pli.title = profile.user.handle;
            userImage = new Uri(profile.user.pic_url);
            userList.Add(pli);*/
            PerformListItem pfli = new PerformListItem();
            pfli.Count = profile.num_performances;
            pfli.Title = "Performances";
            performList.Add(pfli);

            pfli.Count = profile.num_favorites;
            pfli.Title = "Favorites";
            performList.Add(pfli);
            IsBusy = false;
        }
        private INavigation Navigation;
        public MainViewModel(INavigation theNavigation)
        {
            Navigation = theNavigation;
            userList = new ObservableCollection<ProfileListItem>();
            performList = new ObservableCollection<PerformListItem>();
            userImage = new Uri("https://c-ash.smule.com/sf/z5/account/picture/39/5d/cb69ac87-1e52-4de3-a386-8f64d89c081e.jpg");
        }
    }
}
