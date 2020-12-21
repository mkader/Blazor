using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Server.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer.Models.Customer>> GetCustomers();
    }
}
