using Hotel.Data;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Hotel.Models
{
    public class Booking
    {
        private HotelContext context;
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите id клиента")]
        public int Id_c { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите номер")]
        public int Id_r { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите дату въезда")]
        public DateTime Begin_date { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите дату выезда")]
        public DateTime End_date { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите количество гостей")]
        public int Count_c { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите конечную сумму")]
        public int Final_price { get; set; }
    }
}
