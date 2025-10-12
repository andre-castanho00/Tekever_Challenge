using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using Tekever_Challenge.Models;

namespace Tekever_Challenge.Data
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonEpisode> SeasonEpisodes { get; set; }
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

            // --- Many-to-many: TvShow <-> Genre
            builder.Entity<TvShowGenre>()
                .HasKey(x => new { x.TvShowId, x.GenreId });

            // --- Many-to-many: User <-> TvShow (Favorites)
            builder.Entity<UserFavorites>()
                .HasKey(x => new { x.UserId, x.TvShowId });

            builder.Entity<Season>()
                .HasOne(s => s.TvShow)
                .WithMany(t => t.Seasons)
                .HasForeignKey(s => s.TvShowId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SeasonEpisode>()
                .HasOne(e => e.Season)
                .WithMany(s => s.Episodes)
                .HasForeignKey(e => e.SeasonId)
                .OnDelete(DeleteBehavior.Cascade);

            PopulateDatabase(builder);
        }

        private void PopulateDatabase(ModelBuilder modelBuilder)
        {
            // === Genres ===
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Drama" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Action" },
                new Genre { Id = 4, Name = "Sci-Fi" }
            );

            // === Actors ===
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Cillian Murphy" },
                new Actor { Id = 2, Name = "Bryan Cranston" },
                new Actor { Id = 3, Name = "Jennifer Aniston" },
                new Actor { Id = 4, Name = "Pedro Pascal" }
            );

            // === TV Shows ===
            modelBuilder.Entity<TvShow>().HasData(
                new TvShow { Id = 1, Title = "Peaky Blinders", Description = "British crime drama", ReleaseDate = new DateTime(2013, 9, 12), Rating = 9.1 },
                new TvShow { Id = 2, Title = "Breaking Bad", Description = "Chemistry teacher turns to crime", ReleaseDate = new DateTime(2008, 1, 20), Rating = 9.5 },
                new TvShow { Id = 3, Title = "Friends", Description = "Six friends navigate life in NYC", ReleaseDate = new DateTime(1994, 9, 22), Rating = 8.9 },
                new TvShow { Id = 4, Title = "The Mandalorian", Description = "Star Wars bounty hunter saga", ReleaseDate = new DateTime(2019, 11, 12), Rating = 8.7 }
            );

            // === TvShowGenres ===
            modelBuilder.Entity<TvShowGenre>().HasData(
                new TvShowGenre { TvShowId = 1, GenreId = 1 },
                new TvShowGenre { TvShowId = 2, GenreId = 3 },
                new TvShowGenre { TvShowId = 3, GenreId = 2 },
                new TvShowGenre { TvShowId = 4, GenreId = 4 }
            );

            // === TvShowActors ===
            modelBuilder.Entity<TvShowActor>().HasData(
                new TvShowActor { TvShowId = 1, ActorId = 1 },
                new TvShowActor { TvShowId = 2, ActorId = 2 },
                new TvShowActor { TvShowId = 3, ActorId = 3 },
                new TvShowActor { TvShowId = 4, ActorId = 4 }
            );

            // === Seasons ===
            modelBuilder.Entity<Season>().HasData(
                new Season { Id = 1, TvShowId = 1, SeasonNumber = 1, ReleaseDate = new DateTime(2013, 9, 12) },
                new Season { Id = 2, TvShowId = 1, SeasonNumber = 2, ReleaseDate = new DateTime(2014, 10, 2) },
                new Season { Id = 3, TvShowId = 2, SeasonNumber = 1, ReleaseDate = new DateTime(2008, 1, 20) },
                new Season { Id = 4, TvShowId = 3, SeasonNumber = 1, ReleaseDate = new DateTime(1994, 9, 22) },
                new Season { Id = 5, TvShowId = 4, SeasonNumber = 1, ReleaseDate = new DateTime(2019, 11, 12) }
            );

            // === SeasonEpisodes ===
            modelBuilder.Entity<SeasonEpisode>().HasData(
                // Peaky Blinders - Season 1
                new SeasonEpisode { Id = 1, SeasonId = 1, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2013, 9, 12), Rating = 8.6 },
                new SeasonEpisode { Id = 2, SeasonId = 1, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2013, 9, 19), Rating = 8.7 },
                new SeasonEpisode { Id = 3, SeasonId = 2, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2014, 10, 2), Rating = 8.9 },

                // Breaking Bad - Season 1
                new SeasonEpisode { Id = 4, SeasonId = 3, EpisodeNumber = 1, Title = "Pilot", AirDate = new DateTime(2008, 1, 20), Rating = 9.0 },
                new SeasonEpisode { Id = 5, SeasonId = 3, EpisodeNumber = 2, Title = "Cat's in the Bag...", AirDate = new DateTime(2008, 1, 27), Rating = 8.7 },

                // Friends - Season 1
                new SeasonEpisode { Id = 6, SeasonId = 4, EpisodeNumber = 1, Title = "The One Where It All Began", AirDate = new DateTime(1994, 9, 22), Rating = 8.3 },

                // Mandalorian - Season 1
                new SeasonEpisode { Id = 7, SeasonId = 5, EpisodeNumber = 1, Title = "Chapter 1: The Mandalorian", AirDate = new DateTime(2019, 11, 12), Rating = 8.9 },
                new SeasonEpisode { Id = 8, SeasonId = 5, EpisodeNumber = 2, Title = "Chapter 2: The Child", AirDate = new DateTime(2019, 11, 15), Rating = 8.8 }
            );
        }
    }
}
