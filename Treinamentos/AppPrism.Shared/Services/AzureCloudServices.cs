using AppPrism.Shared.Interfaces;
using AppPrism.Shared.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppPrism.Shared.Services
{
    public class AzureCloudServices : ICloudService
    {
        Microsoft.WindowsAzure.MobileServices.MobileServiceClient _client;
        private readonly ILoginProvider _loginProvider;

        public AzureCloudServices(ILoginProvider loginProvider)
        {
            _client = new MobileServiceClient("https://xamarinmobilebackend.azurewebsites.net");
            _loginProvider = loginProvider;
        }

        public ICloudTable<T> GetTable<T>() where T : TableData
        {
            return new AzureCloudTable<T>(_client);
        }

        public Task LoginAsync()
        {
            //var loginProvider = DependencyService.Get<ILoginProvider>();
            return _loginProvider.LoginAsync(_client);
        }
    }
}
