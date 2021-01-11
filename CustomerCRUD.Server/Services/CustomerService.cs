using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using CustomerCRUD.Models;

namespace CustomerCRUD.Server.Services
{
    public class CustomerService :ICustomerService
    {
        private readonly HttpClient httpClient;

        public CustomerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await httpClient.GetJsonAsync<Customer[]>("api/customers");
        }

        public async Task<Customer> GetCustomers(int id)
        {
            return await httpClient.GetJsonAsync<Customer>($"api/customers/{id}");
        }
    }
}
