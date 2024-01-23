using Microsoft.AspNetCore.Identity;

namespace WPeCommerceAPI.DataLayer.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
