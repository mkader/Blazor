using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCRUD.Models;

namespace CustomerCRUD.Server.Pages
{
    public class CustomerListDisplayBase : ComponentBase
    {
        [Parameter]
        public Customer Customer { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        protected bool IsSelected { get; set; }

        [Parameter]
        public EventCallback<bool> OnCustomerSelection { get; set; }

        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            IsSelected = (bool)e.Value;
            await OnCustomerSelection.InvokeAsync(IsSelected);
        }
    }
}
