using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCRUD.Server.Pages
{
    public class DataBindingBase :ComponentBase
    {
        protected string Name { get; set; } = "Mickey";
        protected string MemberType { get; set; } = "Gold";

        protected string Color { get; set; } = "background-color:white";

        public string Message { get; set; } = string.Empty;
    }
}
