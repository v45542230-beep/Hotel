using Hotel.Data;
namespace Hotel.Models
{
    public class Income
    {
        private HotelContext context;
        public decimal Final_price { get; set; }
        public int Begin_date { get; set; }
    }
}
