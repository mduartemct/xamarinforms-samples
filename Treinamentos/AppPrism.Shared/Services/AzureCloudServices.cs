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
        List<AppServiceIdentity> identities = null;

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

        
        public async Task<AppServiceIdentity> GetIdentityAsync()
        {
            if (_client.CurrentUser == null || _client.CurrentUser?.MobileServiceAuthenticationToken == null)
            {
                throw new InvalidOperationException("Not Authenticated");
            }
            if (identities == null)
            {
                identities = await _client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");
            }

            if (identities.Count > 0)
                return identities[0];
            return null;
        }
    }
}
