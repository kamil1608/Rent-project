using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rent.Models.Domains
{
    public class Client
    {
        public Client()
        {
            Orders = new Collection<Order>();
        }

        public int Id { get; set; }


        [Required]
        
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public int AddressId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }




        public Address Address { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ApplicationUser User { get; set; }
    }
}