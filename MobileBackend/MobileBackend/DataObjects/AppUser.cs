using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileBackend.DataObjects
{
    public class AppUser : EntityData
    {
        public string Name { get; set; }

        public string AuthenticationMethod { get; set; }

        public string Email { get; set; }

        public byte[] Salt { get; set; }

        public byte[] SaltedAndHashedPassword { get; set; }

        public string PhotoUrl { get; set; }

    }
}