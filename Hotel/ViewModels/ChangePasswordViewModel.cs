using System.ComponentModel.DataAnnotations;

namespace Hotel.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Введите Email!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль!")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Пароль должен быть от 8 до 40 символов!")]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Пароли не совпадают!")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль!")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }
    }
}
