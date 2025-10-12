using System.ComponentModel.DataAnnotations;

namespace Tekever_Challenge.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? BirthDate { get; set; }

        public ICollection<TvShowActor> TvShowActors { get; set; } = new List<TvShowActor>();
    }
}
