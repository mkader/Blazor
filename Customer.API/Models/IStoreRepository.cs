using Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Models
{
    public interface IStoreRepository
    {
        IEnumerable<Store> GetStores();
        Store GetStore(int storeID);
    }
}
