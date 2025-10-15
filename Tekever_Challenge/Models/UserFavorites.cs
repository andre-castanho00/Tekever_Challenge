using System.ComponentModel.DataAnnotations.Schema;

namespace Tekever_Challenge.Models
{
    public class UserFavorites
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        //public User User { get; set; }

        [ForeignKey("TvShow")]
        public int TvShowId { get; set; }
        public TvShow TvShow { get; set; }
    }
}
