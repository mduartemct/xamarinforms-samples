using AppPrism.Shared.Interfaces;
using AppPrism.Shared.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPrism.Shared.Services
{
    public class AzureCloudServices : ICloudService
    {
        Microsoft.WindowsAzure.MobileServices.MobileServiceClient client;

        public AzureCloudServices()
        {
            client = new MobileServiceClient("https://xamarinmobilebackend.azurewebsites.net");
        }

        public ICloudTable<T> GetTable<T>() where T : TableData
        {
            return new AzureCloudTable<T>(client);
        }
    }
}
