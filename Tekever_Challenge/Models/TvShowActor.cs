using System.ComponentModel.DataAnnotations.Schema;

namespace Tekever_Challenge.Models
{
    public class TvShowActor
    {
        [ForeignKey("TvShow")]
        public int TvShowId { get; set; }
        public TvShow TvShow { get; set; }

        [ForeignKey("Actor")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
