using Rent.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rent.Models.ViewModels
{
    public class EditOrderViewModel
    {
        public Order Order { get; set; }
        public List<Client> Clients { get; set; }
        public List<MethodOfPayment> MethodOfPayments { get; set; }
        public string Heading { get; set; }
    }
}