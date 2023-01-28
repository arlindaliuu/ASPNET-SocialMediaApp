using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaApp.Models
{
    public class Followings
    {
        [Key]
        public int followingId { get; set; }
  
        public DateTime date_created { get; set; } = DateTime.Now;
        //public int duplicateId { get; set; }


        public List<User>? Users { get; set; }

    }
}
