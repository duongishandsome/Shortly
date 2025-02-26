using Microsoft.AspNetCore.Identity;

namespace Shortly.Data.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Urls = new List<Url>();
        }
        public string? FullName { get; set; }
        public List<Url> Urls { get; set; }
    }
}
