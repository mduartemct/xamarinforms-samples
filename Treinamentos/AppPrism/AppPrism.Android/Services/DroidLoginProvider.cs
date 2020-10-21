using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppPrism.Droid.Services;
using AppPrism.Shared.Interfaces;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidLoginProvider))]
namespace AppPrism.Droid.Services
{
   
    public class DroidLoginProvider : ILoginProvider
    {
        //Context context;

        //public void Init(Context context)
        //{
        //    this.context = context;
        //}

        public Context RootView { get; private set; }
        public void Init(Context context)
        {
            RootView = context;
        }

        public async Task LoginAsync(MobileServiceClient client)
        {


            Android.App.Activity context = Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity;
            this.Init(context);
            var _return = await client.LoginAsync(context, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, "xamarinmobilebackend");

            if (_return != null)
            {
                var x = _return.UserId;
            }
            //return _return;

            //facebook", "google", "microsoftaccount", "twitter" or "aad" 
            // await client.LoginAsync(RootView, "aad", "xamarinmobilebackend");

            //await client.LoginAsync(context, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory, "xamarinmobilebackend");

            // Sign in with Facebook login using a server-managed flow.
            //var user = await client.LoginAsync(this, MobileServiceAuthenticationProvider.Facebook, "{url_scheme_of_your_app}");
        }
    }
}