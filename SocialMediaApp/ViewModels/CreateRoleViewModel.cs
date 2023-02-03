using System.ComponentModel.DataAnnotations;

namespace SocialMediaApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
