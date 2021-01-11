using CustomerCRUD.Models;
using CustomerCRUD.Server.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCRUD.Server.Pages
{
    public class CustomerEditBase :ComponentBase
    {
        [Inject]
        public ICustomerService CustomerService { get; set; }
        private Customer Customer { get; set; } = new Customer();

        public CustomerEditModel CustomerEditModel { get; set; } = new CustomerEditModel();


        [Inject]
        public IStoreService StoreService { get; set; }
        public List<Store> Stores { get; set; } = new List<Store>();


        [Parameter]
        public string ID { get; set; }

        public string StoreID { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Customer = await CustomerService.GetCustomers(int.Parse(ID));
            Stores = (await StoreService.GetStores()).ToList();
            StoreID = Customer.StoreID.ToString();

            CustomerEditModel.CustomerID = Customer.CustomerID;
            CustomerEditModel.FirstName = Customer.FirstName;
            CustomerEditModel.LastName = Customer.LastName;
            CustomerEditModel.Email = Customer.Email;
            CustomerEditModel.ConfirmEmail = Customer.Email;
            CustomerEditModel.DateOfJoin = Customer.DateOfJoin;
            CustomerEditModel.MemberType = Customer.MemberType;
            CustomerEditModel.Store = Customer.Store;
            CustomerEditModel.StoreID = Customer.StoreID;
            CustomerEditModel.Image = Customer.Image;
        }
    }
}
