using GetMySongs.Model;
using GetMySongs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GetMySongs.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestView : ContentPage
    {
        private TestViewModel testModel;

        public TestView()
        {
            InitializeComponent();
            testModel = new TestViewModel();
            BindingContext = testModel;  
        }
    }
}