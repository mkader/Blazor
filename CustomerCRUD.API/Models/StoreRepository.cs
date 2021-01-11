using CustomerCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCRUD.API.Models
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext appDbContext;

        public StoreRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Store> GetStore(int storeID)
        {
            return await appDbContext.Stores
                .FirstOrDefaultAsync(d => d.StoreID == storeID);
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await appDbContext.Stores.ToListAsync();
        }
    }
}