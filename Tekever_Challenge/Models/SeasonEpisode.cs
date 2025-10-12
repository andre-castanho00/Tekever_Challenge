using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tekever_Challenge.Models
{
    public class SeasonEpisode
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public DateTime AirDate { get; set; }
        public double? Rating { get; set; }

        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public Season Season { get; set; } = null!;
    }
}
