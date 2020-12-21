using Customer.API.Models;
using Customer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Customer.API.Models
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext appDbContext;

        public StoreRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Store GetStore(int storeID)
        {
            return appDbContext.Stores
                .FirstOrDefault(d => d.StoreID == storeID);
        }

        public IEnumerable<Store> GetStores()
        {
            return appDbContext.Stores;
        }
    }
}