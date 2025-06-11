using Microsoft.AspNetCore.Identity;

namespace BeanSceneApp.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public string? FirstName;
        public string? LastName;
    }
}
