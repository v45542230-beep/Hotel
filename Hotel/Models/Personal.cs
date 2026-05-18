using Hotel.Data;

namespace Hotel.Models
{
    public class Personal
    {
        private HotelContext context;
        public string Fio { get; set; }
        public string Name { get; set; }
        public DateTime Date_of_employment { get; set; }
        public int Pay { get; set; }
    }
}
