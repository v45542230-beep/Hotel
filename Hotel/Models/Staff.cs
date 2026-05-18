using Hotel.Data;
using System.ComponentModel.DataAnnotations;
namespace Hotel.Models
{
    public class Staff
    {
        private HotelContext context;
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите ФИО")]
        [StringLength(100, MinimumLength = 15, ErrorMessage = "Минимальное количество символов: 15")]
        public string Fio { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите дату рождения")]
        public DateTime Birth { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите серию паспорта")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Вы ввели некорректную серию паспорта")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Минимальное количество символов: 4")]
        public string Series { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите номер паспорта")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Вы ввели некорректный номер паспорта")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Минимальное количество символов: 6")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите дату выдачи паспорта")]
        public DateTime Date_of_issue { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите кем выдан паспорт")]
        [StringLength(50, MinimumLength = 20, ErrorMessage = "Минимальное количество символов: 20")]
        public string Issued_by_whom { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите номер телефона")]
        [RegularExpression(@"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$", ErrorMessage = "Вы ввели некорректный номер телефона")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Минимальное количество символов: 16")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите адрес электронной почты")]
        [RegularExpression(@".+@.+\..+", ErrorMessage = "Вы ввели некорректную почту")]
        [StringLength(50, MinimumLength = 20, ErrorMessage = "Минимальное количество символов: 20")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите id должности")]
        public int Id_p { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите дату найма")]
        public DateTime Date_of_employment { get; set; }
    }
}
