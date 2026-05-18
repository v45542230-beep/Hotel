using Hotel.Data;
using System.ComponentModel.DataAnnotations;
namespace Hotel.Models
{
    public class Post
    {
        private HotelContext context;
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите должность")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Минимальное количество символов: 5")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, введите зарплату")]
        public int Pay { get; set; }
    }
}
