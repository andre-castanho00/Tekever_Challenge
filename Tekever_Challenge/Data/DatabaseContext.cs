using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Data
{
    public class DatabaseContext: IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<TvShowActor> TvShowActors { get; set; }
        public DbSet<TvShowGenre> TvShowGenres { get; set; }
        public DbSet<UserFavorites> UserFavorites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // --- Many-to-many: TvShow <-> Actor
            builder.Entity<TvShowActor>()
                .HasKey(x => new { x.TvShowId, x.ActorId });

            // Optional: configure FK relationships
            //builder.Entity<TvShowActor>()
            //    .HasOne<TvShow>()
            //    .WithMany()
            //    .HasForeignKey(x => x.TvShowId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<TvShowActor>()
            //    .HasOne<Actor>()
            //    .WithMany()
            //    .HasForeignKey(x => x.ActorId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // --- Many-to-many: TvShow <-> Genre
            builder.Entity<TvShowGenre>()
                .HasKey(x => new { x.TvShowId, x.GenreId });

            //builder.Entity<TvShowGenre>()
            //    .HasOne<TvShow>()
            //    .WithMany()
            //    .HasForeignKey(x => x.TvShowId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<TvShowGenre>()
            //    .HasOne<Genre>()
            //    .WithMany()
            //    .HasForeignKey(x => x.GenreId)
            //    .OnDelete(DeleteBehavior.Cascade);

            // --- Many-to-many: User <-> TvShow (Favorites)
            builder.Entity<UserFavorites>()
                .HasKey(x => new { x.UserId, x.TvShowId });

            //builder.Entity<UserFavorites>()
            //    .HasOne<User>()
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<UserFavorites>()
            //    .HasOne<TvShow>()
            //    .WithMany()
            //    .HasForeignKey(x => x.TvShowId)
            //    .OnDelete(DeleteBehavior.Cascade);

            PopulateDatabase(builder);
        }

        private void PopulateDatabase(ModelBuilder modelBuilder)
        {
            var random = new Random();

            // Genres
            var genres = new[]
            {
                new Genre { Id = 101, Name = "Drama" },
                new Genre { Id = 102, Name = "Comedy" },
                new Genre { Id = 103, Name = "Action" },
                new Genre { Id = 104, Name = "Sci-Fi" },
                new Genre { Id = 105, Name = "Fantasy" }
            };
            modelBuilder.Entity<Genre>().HasData(genres);

            // TvShows
            var shows = new[]
            {
                new TvShow { Id = 2001, Title = "Peaky Blinders", ReleaseDate = new DateTime(2022, 5, 10), Rating = 9.0 },
                new TvShow { Id = 2002, Title = "Suits", ReleaseDate = new DateTime(2023, 2, 14), Rating = 8.8 },
                new TvShow { Id = 2003, Title = "Friends", ReleaseDate = new DateTime(2021, 9, 1), Rating = 5.2 },
                new TvShow { Id = 2004, Title = "Modern Family", ReleaseDate = new DateTime(2020, 12, 25), Rating = 9.5}
            };
            modelBuilder.Entity<TvShow>().HasData(shows);

            // Episodes
            var episodes = new List<Episode>();
            int episodeId = 30001;
            foreach (var show in shows)
            {
                for (int i = 1; i <= random.Next(3, 6); i++)
                {
                    episodes.Add(new Episode
                    {
                        Id = episodeId++,
                        TvShowId = show.Id,
                        Title = $"{show.Title} - Episode {i}",
                        SeasonNumber = i,
                        EpisodeNumber = i+4,
                        ReleaseDate = show.ReleaseDate.AddDays(i * 7)
                    });
                }
            }
            modelBuilder.Entity<Episode>().HasData(episodes);

            // Actors
            var actors = new[]
            {
                new Actor { Id = 1, Name = "John Carter" },
                new Actor { Id = 2, Name = "Emma Wilson" },
                new Actor { Id = 3, Name = "Carlos Vega" },
                new Actor { Id = 4, Name = "Mia Chen" },
                new Actor { Id = 5, Name = "Tom Novak" }
            };
            modelBuilder.Entity<Actor>().HasData(actors);

            // TvShowGenre
            var showGenres = new List<TvShowGenre>();
            foreach (var show in shows)
            {
                var genreCount = random.Next(1, 3);
                var randomGenres = genres.OrderBy(x => random.Next()).Take(genreCount);
                foreach (var g in randomGenres)
                {
                    showGenres.Add(new TvShowGenre { TvShowId = show.Id, GenreId = g.Id });
                }
            }
            modelBuilder.Entity<TvShowGenre>().HasData(showGenres);

            // TvShowActor
            var showActors = new List<TvShowActor>();
            foreach (var show in shows)
            {
                var actorCount = random.Next(2, 4);
                var randomActors = actors.OrderBy(x => random.Next()).Take(actorCount);
                foreach (var a in randomActors)
                {
                    showActors.Add(new TvShowActor { TvShowId = show.Id, ActorId = a.Id });
                }
            }
            modelBuilder.Entity<TvShowActor>().HasData(showActors);
        }
    }
}
