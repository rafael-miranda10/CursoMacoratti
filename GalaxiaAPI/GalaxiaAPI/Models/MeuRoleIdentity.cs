using Microsoft.AspNetCore.Identity;

namespace GalaxiaAPI.Models
{
    public class MeuRoleIdentity : IdentityRole
    {
        public string Descricao { get; set; }
    }
}
