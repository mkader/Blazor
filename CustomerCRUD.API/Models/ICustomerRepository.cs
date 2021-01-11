using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCRUD.Models;

namespace CustomerCRUD.API.Models
{
    public interface ICustomerRepository
    { 
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int customerID);
        Task<Customer> AddCustomer(Customer custoemr);
        Task<Customer> UpdateCustomer(Customer custoemr);
        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> DeleteCustomer(int customerID);
        Task<IEnumerable<Customer>> Search(string name, MemberType? memberType);
    }
}
