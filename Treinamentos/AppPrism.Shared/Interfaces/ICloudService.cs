using AppPrism.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPrism.Shared.Interfaces
{
    public interface ICloudService
    {
        ICloudTable<T> GetTable<T>() where T : TableData;

        Task LoginAsync();

        /// <summary>
        /// This matches the JSON format from the /.auth/me
        /// </summary>
        /// <returns></returns>
        Task<AppServiceIdentity> GetIdentityAsync();
    }
}
