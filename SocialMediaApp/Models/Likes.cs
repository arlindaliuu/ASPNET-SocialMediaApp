namespace SocialMediaApp.Models
{
    public class Likes
    {
        public int ID { get; set; }
        public DateTime date_created { get; set; }
        public User User { get; set; }
    }
}
