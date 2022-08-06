using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace Rent.Models.Domains
{
    public class Address
    {
        public Address()
        {
            Clients = new Collection<Client>();
            Users = new Collection<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Pole miejscowość jest wymagane")]
        [Display(Name = "Miejscowość")]        
        public string City { get; set; }


        [Required(ErrorMessage = "Pole ulica jest wymagane")]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Pole numer jest wymagane")]
        [Display(Name = "Numer")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Pole kod pocztowy jest wymagane")]
        [Display(Name = "Kod pocztowy")]
        public string Code { get; set; }



        public ICollection<Client> Clients { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}