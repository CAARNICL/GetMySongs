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
    public partial class MediaView : ContentPage
    {
        public MediaView(string thePath)
        {
            InitializeComponent();
            BindingContext = new MediaViewModel(thePath);
        }
    }
}