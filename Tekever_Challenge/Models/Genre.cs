using System.ComponentModel.DataAnnotations;

namespace Tekever_Challenge.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<TvShowGenre> TvShowGenres { get; set; } = new List<TvShowGenre>();
    }
}
