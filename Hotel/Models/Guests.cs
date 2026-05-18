using Hotel.Data;
namespace Hotel.Models
{
    public class Guests
    {
        private HotelContext context;
        public string Fio { get; set; }
        public int Id_r { get; set; }
        public DateTime Begin_date { get; set; }
        public DateTime End_date { get; set; }
    }
}
