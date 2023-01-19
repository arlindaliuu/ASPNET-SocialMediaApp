namespace SocialMediaApp.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string context { get; set; }
        public DateTime date_created { get; set; } = DateTime.Now;  
        public DateTime date_updated { get; set; }
        //public int duplicateId { get; set; }

                public User user { get; set; }
        
    }
}
