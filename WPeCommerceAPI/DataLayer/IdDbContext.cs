using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WPeCommerceAPI.DataLayer
{
    public class IdDbContext : IdentityDbContext<IdentityUser>
    {
        public IdDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
