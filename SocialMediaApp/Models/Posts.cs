using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApp.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string caption { get; set; }
        public float latitude { get; set; }
        public float longtitude { get; set; }
        public string post_url { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_update { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }   
        [ForeignKey("user_id")]
        public User User { get; set; }
        public List<Likes> likes { get; set; }
        public List<Comments> comments { get; set; }

    }
    public class PostsViewModel
    {
        public int Id { get; set; }
        public string caption { get; set; }
        public float latitude { get; set; }
        public float longtitude { get; set; }
        public string post_url { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_update { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
     
    }

}
