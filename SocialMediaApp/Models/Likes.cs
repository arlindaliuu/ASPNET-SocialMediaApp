namespace SocialMediaApp.Models
{
    public class Likes
    {
        public int ID { get; set; }
        public DateTime date_created { get; set; }
        //public int duplicateId { get; set; }
        public User User { get; set; }
        public List<Posts>? Posts { get; set; }

    }
}
