using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent.Models.Domains
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole lp jest wymagane")]
        public int Lp { get; set; }

        [Required(ErrorMessage = "Pole koszt jest wymagane")]
        [Display(Name = "Koszt")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Pole ilość jest wymagane")]
        [Display(Name = "Ilość")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Pole produkt jest wymagane")]
        [Display(Name = "Produkt")]
        public int ProductId { get; set; }
        public int OrderId { get; set; }



        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}