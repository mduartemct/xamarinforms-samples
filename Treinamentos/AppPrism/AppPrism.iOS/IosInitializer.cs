using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Prism.Ioc;
using UIKit;

namespace AppPrism.iOS
{
     public class IosInitializer : Prism.IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Registre algo especifico para o IoS
            //containerRegistry.Register<IAuthenticationService, AuthenticationService>();
        }
    }
}