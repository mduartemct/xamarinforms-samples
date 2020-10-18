using AppPrism.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppPrism.Shared.Interfaces
{
    public interface ICloudService
    {
        ICloudTable<T> GetTable<T>() where T : TableData;
    }
}
