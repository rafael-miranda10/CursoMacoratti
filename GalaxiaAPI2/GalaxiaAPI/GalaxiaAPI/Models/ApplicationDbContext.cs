using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GalaxiaAPI.Models
{
    public class ApplicationDbContext : IdentityDbContext<MeuUserIdentity,MeuRoleIdentity,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
       
    }
}
