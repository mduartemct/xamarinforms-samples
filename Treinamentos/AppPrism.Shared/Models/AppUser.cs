using System;
using System.Collections.Generic;
using System.Text;

namespace AppPrism.Shared.Models
{
    public class AppUser : TableData
    {
        public string Name { get; set; }

        public string AuthenticationMethod { get; set; }

        public string Email { get; set; }

        public byte[] Salt { get; set; }

        public byte[] SaltedAndHashedPassword { get; set; }

        public string PhotoUrl { get; set; }
    }
}
