

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;
using GetMySongs.Model;
using Xamarin.Forms;

namespace GetMySongs.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        private ObservableCollection<SongListItem> testListe = new ObservableCollection<SongListItem>();
        public ObservableCollection<SongListItem> TestListe { get { return testListe; }
            set { testListe = value; } }

        // ICommand implementations
        public ICommand TestCommand { protected set; get; }

        public ICommand Download_Clicked { protected set; get; }

        public TestViewModel()
        {
            TestCommand = new Command((key) =>
            {
                // Add the key to the input string.
                /*Random generator = new Random();
                setProgress(0, Double.Parse(generator.Next(0,100).ToString()));*/
                setProgress(0, 100);


            });
            Download_Clicked = new Command((key) =>
            {
            });
            SongListItem sli = new SongListItem();
            {
                sli.DownloadUri = "http://www.testdownload.de";
                sli.IsDownloaded = false;
                sli.MediaUri = "http://www.testmediadownload.de";
                sli.PerformanceDate = "10.10.2010";
                sli.Performare = "Niclani";
                sli.Progress = 0;
                sli.Title = "Sing with me";
                sli.IsDownloading = false;
            }
            SongListItem sli2 = new SongListItem();
            {
                sli2.DownloadUri = "http://www.testdownload.de";
                sli2.IsDownloaded = true;
                sli2.MediaUri = "http://www.testmediadownload.de";
                sli2.PerformanceDate = "19.10.2010";
                sli2.Performare = "Niclani";
                sli2.Progress = 100;
                sli2.Title = "Sing with me again";
                sli2.IsDownloading = false;
            }
            SongListItem sli3 = new SongListItem();
            {
                sli3.DownloadUri = "http://www.testdownload.de";
                sli3.IsDownloaded = false;
                sli3.MediaUri = "http://www.testmediadownload.de";
                sli3.PerformanceDate = "19.10.2010";
                sli3.Performare = "Niclani";
                sli3.Progress = 50;
                sli3.Title = "Half way done";
                sli3.IsDownloading = true;
            }

            testListe.Add(sli);
            testListe.Add(sli2);
            testListe.Add(sli3);
        }

        private void setProgress(int theItem, int theProgress)
        {
            TestListe[theItem].Progress = theProgress;
            if (theProgress == 100.0)
                TestListe[theItem].IsDownloaded = true;
        }


    }
}