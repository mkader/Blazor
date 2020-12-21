using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Models;
using Customer.Server.Services;

namespace Customer.Server.Pages
{
    public class CustomerListBase :ComponentBase
    {
        [Inject]
        public ICustomerService CustomerService { get; set; }
        public IEnumerable<Customer.Models.Customer> Customers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Customers = (await CustomerService.GetCustomers()).ToList();
        }
        private void LoadCusotmerss()
        {
            System.Threading.Thread.Sleep(3000);
            Customer.Models.Customer c1 = new Customer.Models.Customer
            {
                CustomerID = 100,
                FirstName = "Bugs",
                LastName = "Bunny",
                Email = "Bugs.Bunny@dns.com",
                DateOfJoin = new DateTime(1980, 10, 5),
                MemberType = MemberType.Gold,
                StoreID = 1,
                //Store = new Store { StoreID = 1, StoreName = "TXIRV" },
                Image = "images/bugs.png"
            };

            Customer.Models.Customer c2 = new Customer.Models.Customer
            {
                CustomerID = 200,
                FirstName = "Winnie",
                LastName = "Pooh",
                Email = "Winnie.Pooh@dns.com",
                DateOfJoin = new DateTime(1981, 12, 22),
                MemberType = MemberType.Silver,
                //Store = new Store { StoreID = 2, StoreName = "WIMAD" },
                StoreID = 2,
                Image = "images/winnie.png"
            };

            Customer.Models.Customer c3 = new Customer.Models.Customer
            {
                CustomerID = 300,
                FirstName = "Mickey",
                LastName = "Mouse",
                Email = "Mickey.Mouse@dns.com",
                DateOfJoin = new DateTime(1979, 11, 11),
                MemberType = MemberType.Bronze,
                //Store = new Store { StoreID = 3, StoreName = "NEBEL" },
                StoreID = 3,
                Image = "images/mickey.png"
            };

            Customer.Models.Customer c4 = new Customer.Models.Customer
            {
                CustomerID = 400,
                FirstName = "Donald",
                LastName = "Duck",
                Email = "Donald.Duck@dns.com",
                DateOfJoin = new DateTime(1982, 9, 23),
                MemberType = MemberType.Gold,
                //Store = new Store { StoreID = 3, StoreName = "TXDFW" },
                StoreID = 4,
                Image = "images/donald.png"
            };

            Customers = new List<Customer.Models.Customer> { c1, c2, c3, c4 };
        }
    }
}
