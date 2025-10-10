using System.ComponentModel.DataAnnotations;

namespace Tekever_Challenge.Models
{
    public class TvShow
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double? Rating { get; set; }

        // Relationships
        public ICollection<Episode> Episodes { get; set; } = new List<Episode>();
        public ICollection<TvShowGenre> TvShowGenres { get; set; } = new List<TvShowGenre>();
        public ICollection<TvShowActor> TvShowActors { get; set; } = new List<TvShowActor>();
        public ICollection<UserFavorites> UserFavorites { get; set; } = new List<UserFavorites>();
    }
}
