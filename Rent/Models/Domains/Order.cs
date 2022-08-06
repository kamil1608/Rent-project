using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rent.Models.Domains
{
    public class Order
    {
        public Order()
        {
            OrderItems = new Collection<OrderItem>();
        }

        public int Id { get; set; }
        
        [Required(ErrorMessage = "Pole tytuł jest wymagane")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Pole koszt jest wymagane")]
        [Display(Name = "Koszt")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Pole data utworzenia jest wymagane")]
        [Display(Name = "Data utworzenia")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Pole termin realizacji zamówienia jest wymagane")]
        [Display(Name = "Termin realizacji zamówienia")]
        public DateTime PaymentDeadline { get; set; }

        [Display(Name = "Uwagi")]
        public string Comments { get; set; }

        [Required(ErrorMessage = "Pole metoda płatności jest wymagane")]
        [Display(Name = "Metoda płatności")]
        public int MethodOfPaymentId { get; set; }

        [Required(ErrorMessage = "Pole klient jest wymagane")]
        [Display(Name = "Klient")]
        public int ClientId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }



        public MethodOfPayment MethodOfPayment { get; set; }
        public Client Client { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}