using Microsoft.AspNetCore.Identity;

namespace ISPlaning.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}
