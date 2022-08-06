using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Rent.Models.Domains
{
    public class Product
    {
        public Product()
        {
            OrderItems = new Collection<OrderItem>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public decimal Value { get; set; }




        public ICollection<OrderItem> OrderItems { get; set; }
    }
}