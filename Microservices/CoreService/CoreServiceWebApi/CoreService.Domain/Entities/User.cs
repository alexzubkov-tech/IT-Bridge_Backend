
using Microsoft.AspNetCore.Identity;

namespace CoreService.Domain.Entities
{
    public class User : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
        
    }
}
