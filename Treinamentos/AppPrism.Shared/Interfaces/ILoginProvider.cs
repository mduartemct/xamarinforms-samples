using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPrism.Shared.Interfaces
{
    public interface ILoginProvider
    {
        Task LoginAsync(MobileServiceClient client);
    }
}
