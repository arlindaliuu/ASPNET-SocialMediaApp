using SocialMediaApp.Models;

namespace SocialMediaApp.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RegisteredUserViewModel
    {
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public char? gender { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public string? profile_picture_url { get; set; }
        public DateTime? birth_date { get; set; }
        public DateTime date_created { get; set; } = DateTime.Now;
        public DateTime? date_updated { get; set; }

    }
    public class RegisterViewModel
    {
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; } 
        public char? gender { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? profile_picture_url { get; set; }
        public DateTime? birth_date { get; set; }
        public DateTime date_created { get; set; } = DateTime.Now;
        public DateTime? date_updated { get; set; }
        public string? active { get; set; }
        public string? activation_key { get; set; }
        
    }
}
