using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Customer.Server.Services
{
    public class CustomerService :ICustomerService
    {
        private readonly HttpClient httpClient;

        public CustomerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Customer.Models.Customer>> GetCustomers()
        {
            return await httpClient.GetJsonAsync<Customer.Models.Customer[]>("api/customers");
        }

        public async Task<Customer.Models.Customer> GetCustomers(int id)
        {
            return await httpClient.GetJsonAsync<Customer.Models.Customer>($"api/customers/{id}");
        }
    }
}
