using Customer.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Customer.Models.Customer>> GetCustomers()
        {
            return await appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer.Models.Customer> GetCustomer(int customerID)
        {
            return await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.CustomerID == customerID);
        }

        public async Task<Customer.Models.Customer> AddCustomer(Customer.Models.Customer customer)
        {
            var result = await appDbContext.Customers.AddAsync(customer);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer.Models.Customer> UpdateCustomer(Customer.Models.Customer customer)
        {
            var result = await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.CustomerID == customer.CustomerID);

            if (result != null)
            {
                result.FirstName = customer.FirstName;
                result.LastName = customer.LastName;
                result.Email = customer.Email;
                result.DateOfJoin = customer.DateOfJoin;
                result.MemberType = customer.MemberType;
                result.StoreID = customer.StoreID;
                result.Image = customer.Image;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
        public async Task<Customer.Models.Customer> DeleteCustomer(int customerID)
        {
            var result = await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.CustomerID == customerID);
            if (result != null)
            {
                appDbContext.Customers.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Customer.Models.Customer> GetCustomerByEmail(string email)
        {
            return await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Customer.Models.Customer>> Search(string name, Customer.Models.MemberType? memberType)
        {
            IQueryable<Customer.Models.Customer> query = appDbContext.Customers;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }

            if (memberType != null)
            {
                query = query.Where(e => e.MemberType == memberType);
            }

            return await query.ToListAsync();
        }
    }
}
