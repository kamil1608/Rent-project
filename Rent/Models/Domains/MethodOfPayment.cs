using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Rent.Models.Domains
{
    public class MethodOfPayment
    {
        public MethodOfPayment()
        {
            Orders = new Collection<Order>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }




        public ICollection<Order> Orders { get; set; }
    }
}