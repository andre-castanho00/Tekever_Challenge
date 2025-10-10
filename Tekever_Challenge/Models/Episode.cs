using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tekever_Challenge.Models
{
    public class Episode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int SeasonNumber { get; set; }

        public int EpisodeNumber { get; set; }

        public DateTime ReleaseDate { get; set; }

        [ForeignKey("TvShow")]
        public int TvShowId { get; set; }

        //public TvShow TvShow { get; set; }
    }
}
