using System.ComponentModel.DataAnnotations;

namespace Rent.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
