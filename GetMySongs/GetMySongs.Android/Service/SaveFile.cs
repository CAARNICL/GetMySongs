using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;

using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using GetMySongs.Droid.Service;
using GetMySongs.Interface;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;


[assembly: Dependency(typeof(SaveFile))]
namespace GetMySongs.Droid.Service
{

    public class SaveFile : Activity, ISaveFile
    {
        async void ISaveFile.SaveFile()
        {

            //var status = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
            
             var status = CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage);

            var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic);

            if (!File.Exists(path.Path))
            {
                Directory.CreateDirectory(path.Path);
            }

            string absPath = path.Path + "tempfile.mpf";
            File.WriteAllText(absPath, "test");
            //return Task.FromResult(0); 
        }
    }
}