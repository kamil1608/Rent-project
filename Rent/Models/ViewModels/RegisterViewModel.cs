using Rent.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace Rent.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Pole e-mail jest wymagane")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pole hasło jest wymagane")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pole potwierdź hasło jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Błąd przy powtórnym wpisywaniu hasła")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Pole nazwa jest wymagane")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
