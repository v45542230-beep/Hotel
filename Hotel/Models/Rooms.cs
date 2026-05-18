using Hotel.Data;
using System.ComponentModel.DataAnnotations;
namespace Hotel.Models
{
    public class Rooms
    {
        private HotelContext context;
        public int Id { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public int Floor { get; set; }
    }
}
