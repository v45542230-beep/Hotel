using Microsoft.AspNetCore.Identity;

namespace Hotel.Models
{
    public class Users: IdentityUser
    {
        public string Name { get; set; }
    }
}
