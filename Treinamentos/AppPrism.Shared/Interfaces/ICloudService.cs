using AppPrism.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPrism.Shared.Interfaces
{
    public interface ICloudService
    {
        //Tabelas Online == Síncronas
        ICloudTable<T> GetTable<T>() where T : TableData;

        //Tabelas Offline == Assíncronas
        Task<ICloudTable<T>> GetTableAsync<T>() where T : TableData;

        Task LoginAsync();

        /// <summary>
        /// This matches the JSON format from the /.auth/me
        /// </summary>
        /// <returns></returns>
        Task<AppServiceIdentity> GetIdentityAsync();
    }
}
