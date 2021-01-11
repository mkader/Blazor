using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerCRUD.Models;
using Microsoft.AspNetCore.Components;

namespace CustomerCRUD.Server.Services
{
    public class StoreService : IStoreService
    {
        private readonly HttpClient httpClient;

        public StoreService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            return await httpClient.GetJsonAsync<Store[]>("api/stores");
        }

        public async Task<Store> GetStores(int id)
        {
            return await httpClient.GetJsonAsync<Store>($"api/stores/{id}");
        }
    }
}
