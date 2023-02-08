using SocialMediaApp.Models;

namespace SocialMediaApp.ViewModels
{
    public class LikePostUserViewModel
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public DateTime date_created { get; set; } = DateTime.Now;
        public List<User>? Users { get; set; }
        public int PostId { get; set; }
        public List<Posts>? Posts { get; set; }
    
    }
}
