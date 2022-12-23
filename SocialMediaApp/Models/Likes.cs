namespace SocialMediaApp.Models
{
    public class Likes
    {
        public int id { get; set; }
        public DateTime date_created { get; set; }
        public User user { get; set; }

    }
}
