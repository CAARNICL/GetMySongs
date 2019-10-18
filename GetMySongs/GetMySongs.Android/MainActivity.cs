using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.IO;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android;
using Android.Util;
using Android.Support.Design.Widget;


namespace GetMySongs.Droid
{
    [Activity(Label = "GetMySongs", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if(ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.WriteExternalStorage))
{
                // Provide an additional rationale to the user if the permission was not granted
                // and the user would benefit from additional context for the use of the permission.
                // For example if the user has previously denied the permission.
                //Log.Info(TAG, "Displaying camera permission rationale to provide additional context.");

                var requiredPermissions = new string[] { Manifest.Permission.WriteExternalStorage };
                /*Snackbar.Make(,
                               "Need write access",
                               Snackbar.LengthIndefinite)
                        .SetAction(Resource.String.ok,
                                   new Action<View>(delegate (View obj) {
                                       ActivityCompat.RequestPermissions(this, requiredPermissions, REQUEST_LOCATION);
                                   }
                        )
                ).Show();*/
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, 32);
            }
else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, 32);
            }

            LoadApplication(new App());

            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}