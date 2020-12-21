using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Models
{
    public interface ICustomerRepository
    { 
        Task<IEnumerable<Customer.Models.Customer>> GetCustomers();
        Task<Customer.Models.Customer> GetCustomer(int customerID);
        Task<Customer.Models.Customer> AddCustomer(Customer.Models.Customer custoemr);
        Task<Customer.Models.Customer> UpdateCustomer(Customer.Models.Customer custoemr);
        Task<Customer.Models.Customer> GetCustomerByEmail(string email);
        Task<Customer.Models.Customer> DeleteCustomer(int customerID);
        Task<IEnumerable<Customer.Models.Customer>> Search(string name, Customer.Models.MemberType? memberType);
    }
}
