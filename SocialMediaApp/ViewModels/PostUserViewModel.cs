using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using SocialMediaApp.Models;

namespace SocialMediaApp.ViewModels
{
    public class PostUserViewModel
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public string caption { get; set; }
        public float latitude { get; set; }
        public float longtitude { get; set; }
        public string post_url { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_update { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        public List<User> Users { get; set; }
    }
}
