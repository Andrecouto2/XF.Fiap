using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Security;

namespace XF.Atividade06.Droid
{
    [Activity(Label = "XF.Atividade06.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            PackageInfo info = this.PackageManager.GetPackageInfo("com.andrecouto.XF_Atividade06", PackageInfoFlags.Signatures);

    foreach (Android.Content.PM.Signature signature in info.Signatures)
    {
                
        MessageDigest md = MessageDigest.GetInstance("SHA");

        md.Update(signature.ToByteArray());

        string keyhash = Convert.ToBase64String(md.Digest());

        Console.WriteLine("KeyHash:", keyhash);

    }


            LoadApplication(new App());
        }
    }
}
