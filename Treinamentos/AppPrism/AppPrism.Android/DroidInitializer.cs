using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppPrism.Droid
{
     public class DroidInitializer : Prism.IPlatformInitializer
    {
        public void RegisterTypes(Prism.Ioc.IContainerRegistry containerRegistry)
        {
            //containerRegistry.Register<IAuthenticationService, AuthenticationService>();
        }
    }
}