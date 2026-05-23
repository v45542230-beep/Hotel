using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class CheckClient
    {
        public int Id_r { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите ФИО")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "Минимальное количество символов: 20")]
        public string Fio { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите номер телефона")]
        [RegularExpression(@"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$", ErrorMessage = "Вы ввели некорректный номер телефона")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Минимальное количество символов: 16")]
        public string Phone { get; set; }
    }
}
