using System.ComponentModel.DataAnnotations.Schema;

namespace Tekever_Challenge.Models
{
    public class TvShowGenre
    {
        [ForeignKey("TvShow")]
        public int TvShowId { get; set; }
        public TvShow TvShow { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
