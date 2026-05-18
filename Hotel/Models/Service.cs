using Hotel.Data;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Hotel.Models
{
    public class Service
    {
        private HotelContext context;
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите id сотрудника")]
        public int Id_st { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите id клиента")]
        public int Id_c { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите дату")]
        public DateTime Date_of_registration { get; set; }
    }
}
