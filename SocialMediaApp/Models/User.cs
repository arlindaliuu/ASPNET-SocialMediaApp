using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SocialMediaApp.Models
{
    public class User: IdentityUser
    {
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        /*public string? role { get; set; }*/
        public char? gender { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string? profile_picture_url { get; set; }
        public DateTime? birth_date { get; set; }
        public DateTime date_created { get; set; } = DateTime.Now;
        public DateTime? date_updated { get; set; }
        public string? active { get; set; }
        public string? activation_key { get; set; }
        public List<Followings>? followings { get; set; }
    }

    public class UserViewModel
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string role { get; set; }
        public char gender { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageData { get; set; }
        public string profile_picture_url { get; set; }
        public DateTime birth_date { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_updated { get; set; }
        public string active { get; set; }
        public string activation_key { get; set; }

    }
}
