using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tekever_Challenge.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SeasonNumber { get; set; }
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("TvShow")]
        public int TvShowId { get; set; }
        public TvShow TvShow { get; set; } = null!;

        public ICollection<SeasonEpisode> Episodes { get; set; } = new List<SeasonEpisode>();
    }
}
