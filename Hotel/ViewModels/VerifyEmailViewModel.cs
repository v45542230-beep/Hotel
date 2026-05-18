using System.ComponentModel.DataAnnotations;

namespace Hotel.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Введите Email!")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
