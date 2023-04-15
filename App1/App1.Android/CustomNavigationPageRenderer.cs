using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.Droid;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;


[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationPageRenderer))]
namespace App1.Droid
{
    public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);




           

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var window = ((Activity)Context).Window;
                window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                window.SetStatusBarColor(Color.FromHex("#282828").ToAndroid()); // Use Color from the Xamarin.Forms namespace
            }
           






        }
    }
}