using CustomerCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCRUD.Server.Services
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetStores();
        Task<Store> GetStores(int id);
    }
}
