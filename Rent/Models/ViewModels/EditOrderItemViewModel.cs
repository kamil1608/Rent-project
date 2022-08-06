using Rent.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent.Models.ViewModels
{
    public class EditOrderItemViewModel
    {
        public OrderItem OrderItem { get; set; }
        public string Heading { get; set; }
        public List<Product> Products { get; set; }
    }
}