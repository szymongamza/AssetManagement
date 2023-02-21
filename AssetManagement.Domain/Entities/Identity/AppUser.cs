using Microsoft.AspNetCore.Identity;

namespace AssetManagement.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; } = null!;
    }
}
