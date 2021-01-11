using CustomerCRUD.Server.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCRUD.Models;

namespace CustomerCRUD.Server.Pages
{
    public class CustomerDetailsBase :ComponentBase
    {
        public Customer Customer { get; set; } = new Customer();
        
        [Inject]
        ICustomerService CustomerService { get; set; }

        [Parameter]
        public string ID { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ID = ID ??  "100";
            Customer = await CustomerService.GetCustomers(int.Parse(ID));
        }

        protected string Coordinates { get; set; }

        protected void Mouse_Move(MouseEventArgs e)
        {
            Coordinates = $"X = {e.ClientX } Y = {e.ClientY}";
        }

        protected string ButtonText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = null;

        protected void Button_Click()
        {
            if (ButtonText == "Hide Footer")
            {
                ButtonText = "Show Footer";
                CssClass = "HideFooter";
            }
            else
            {
                CssClass = null;
                ButtonText = "Hide Footer";
            }
        }
    }
}
