using System.ComponentModel.DataAnnotations;

namespace Hotel.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите ФИО!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите Email!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль!")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Пароль должен быть от 8 до 40 символов!")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Пароли не совпадают!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
