using CustomerCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCRUD.Models;

namespace CustomerCRUD.API.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int customerID)
        {
            return await appDbContext.Customers
                .Include(s => s.Store)
                //.ThenInclude(d => d.Department)
                .FirstOrDefaultAsync(e => e.CustomerID == customerID);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var result = await appDbContext.Customers.AddAsync(customer);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
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
        public async Task<Customer> DeleteCustomer(int customerID)
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

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await appDbContext.Customers
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Customer>> Search(string name, MemberType? memberType)
        {
            IQueryable<Customer> query = appDbContext.Customers;

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
