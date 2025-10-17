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
            PopulateGenres(modelBuilder);

            PopulateActors(modelBuilder);

            PopulateTvShows(modelBuilder);

            PopulateTvShowsGenres(modelBuilder);

            PopulateTvShowsActors(modelBuilder);

            PopulateSeasons(modelBuilder);

            PopulateEpisodes(modelBuilder);
        }

        private void PopulateGenres(ModelBuilder modelBuilder)
        {
            // === Genres ===
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Drama" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Action" },
                new Genre { Id = 4, Name = "Sci-Fi" },
                new Genre { Id = 5, Name = "Thriller" },
                new Genre { Id = 6, Name = "Fantasy" },
                new Genre { Id = 7, Name = "Crime" },
                new Genre { Id = 8, Name = "Adventure" }
            );
        }

        private void PopulateActors(ModelBuilder modelBuilder)
        {
            // === Actors ===
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, Name = "Cillian Murphy" },
                new Actor { Id = 2, Name = "Bryan Cranston" },
                new Actor { Id = 3, Name = "Jennifer Aniston" },
                new Actor { Id = 4, Name = "Pedro Pascal" },
                new Actor { Id = 5, Name = "Millie Bobby Brown" },
                new Actor { Id = 6, Name = "Henry Cavill" },
                new Actor { Id = 7, Name = "Emma D'Arcy" },
                new Actor { Id = 8, Name = "Tom Hiddleston" },
                new Actor { Id = 9, Name = "Anya Taylor-Joy" },
                new Actor { Id = 10, Name = "Matthew McConaughey" },
                new Actor { Id = 11, Name = "Zendaya" },
                new Actor { Id = 12, Name = "Rami Malek" },
                new Actor { Id = 13, Name = "Elizabeth Olsen" },
                new Actor { Id = 14, Name = "Kit Harington" },
                new Actor { Id = 15, Name = "Oscar Isaac" }
            );
        }

        private void PopulateTvShows(ModelBuilder modelBuilder)
        {
            // === TV Shows ===
            modelBuilder.Entity<TvShow>().HasData(
                new TvShow { Id = 1, Title = "Peaky Blinders", Description = "British crime drama", ReleaseDate = new DateTime(2013, 9, 12), Rating = 9.1 },
                new TvShow { Id = 2, Title = "Breaking Bad", Description = "Chemistry teacher turns to crime", ReleaseDate = new DateTime(2008, 1, 20), Rating = 9.5 },
                new TvShow { Id = 3, Title = "Friends", Description = "Six friends navigate life in NYC", ReleaseDate = new DateTime(1994, 9, 22), Rating = 8.9 },
                new TvShow { Id = 4, Title = "The Mandalorian", Description = "Star Wars bounty hunter saga", ReleaseDate = new DateTime(2019, 11, 12), Rating = 8.7 },
                new TvShow { Id = 5, Title = "The Witcher", Description = "A monster hunter struggles with his destiny", ReleaseDate = new DateTime(2019, 12, 20), Rating = 8.2 },
                new TvShow { Id = 6, Title = "Game of Thrones", Description = "Noble families vie for control of Westeros", ReleaseDate = new DateTime(2011, 4, 17), Rating = 9.3 },
                new TvShow { Id = 7, Title = "Stranger Things", Description = "A group of kids uncover supernatural mysteries", ReleaseDate = new DateTime(2016, 7, 15), Rating = 8.9 },
                new TvShow { Id = 8, Title = "Loki", Description = "God of Mischief faces the TVA", ReleaseDate = new DateTime(2021, 6, 9), Rating = 8.4 },
                new TvShow { Id = 9, Title = "The Queen’s Gambit", Description = "Chess prodigy battles addiction and rivals", ReleaseDate = new DateTime(2020, 10, 23), Rating = 8.6 },
                new TvShow { Id = 10, Title = "House of the Dragon", Description = "Targaryen civil war begins", ReleaseDate = new DateTime(2022, 8, 21), Rating = 8.8 },
                new TvShow { Id = 11, Title = "Mr. Robot", Description = "Hacker tries to take down corporate America", ReleaseDate = new DateTime(2015, 6, 24), Rating = 8.6 },
                new TvShow { Id = 12, Title = "Euphoria", Description = "Teens navigate love and addiction", ReleaseDate = new DateTime(2019, 6, 16), Rating = 8.4 },
                new TvShow { Id = 13, Title = "The Boys", Description = "A group of vigilantes fight corrupt superheroes", ReleaseDate = new DateTime(2019, 7, 26), Rating = 8.9 },
                new TvShow { Id = 14, Title = "WandaVision", Description = "Superhero sitcom blending reality and fantasy", ReleaseDate = new DateTime(2021, 1, 15), Rating = 8.0 },
                new TvShow { Id = 15, Title = "True Detective", Description = "Detectives uncover dark truths", ReleaseDate = new DateTime(2014, 1, 12), Rating = 9.0 },
                new TvShow { Id = 16, Title = "Better Call Saul", Description = "A lawyer's descent into moral ambiguity", ReleaseDate = new DateTime(2015, 2, 8), Rating = 8.9 },
                new TvShow { Id = 17, Title = "Narcos", Description = "The story of Pablo Escobar and the DEA", ReleaseDate = new DateTime(2015, 8, 28), Rating = 8.8 },
                new TvShow { Id = 18, Title = "The Expanse", Description = "A sci-fi political thriller set in space", ReleaseDate = new DateTime(2015, 12, 14), Rating = 8.5 },
                new TvShow { Id = 19, Title = "The Last of Us", Description = "Survivors navigate a post-apocalyptic world", ReleaseDate = new DateTime(2023, 1, 15), Rating = 9.2 },
                new TvShow { Id = 20, Title = "Sherlock", Description = "Modern adaptation of Sherlock Holmes", ReleaseDate = new DateTime(2010, 7, 25), Rating = 9.1 }
            );
        }

        private void PopulateTvShowsGenres(ModelBuilder modelBuilder)
        {
            // === TvShowGenres ===
            modelBuilder.Entity<TvShowGenre>().HasData(
                // Peaky Blinders
                new TvShowGenre { TvShowId = 1, GenreId = 1 },
                new TvShowGenre { TvShowId = 1, GenreId = 7 },
                new TvShowGenre { TvShowId = 1, GenreId = 3 },
                // Breaking Bad
                new TvShowGenre { TvShowId = 2, GenreId = 1 },
                new TvShowGenre { TvShowId = 2, GenreId = 7 },
                // Friends
                new TvShowGenre { TvShowId = 3, GenreId = 2 },
                new TvShowGenre { TvShowId = 3, GenreId = 8 },
                // The Mandalorian
                new TvShowGenre { TvShowId = 4, GenreId = 4 },
                new TvShowGenre { TvShowId = 4, GenreId = 8 },
                // The Witcher
                new TvShowGenre { TvShowId = 5, GenreId = 6 },
                new TvShowGenre { TvShowId = 5, GenreId = 3 },
                // Game of Thrones
                new TvShowGenre { TvShowId = 6, GenreId = 6 },
                new TvShowGenre { TvShowId = 6, GenreId = 5 },
                // Stranger Things
                new TvShowGenre { TvShowId = 7, GenreId = 4 },
                new TvShowGenre { TvShowId = 7, GenreId = 1 },
                // Loki
                new TvShowGenre { TvShowId = 8, GenreId = 4 },
                new TvShowGenre { TvShowId = 8, GenreId = 2 },
                // Queen's Gambit
                new TvShowGenre { TvShowId = 9, GenreId = 1 },
                new TvShowGenre { TvShowId = 9, GenreId = 5 },
                // House of the Dragon
                new TvShowGenre { TvShowId = 10, GenreId = 6 },
                new TvShowGenre { TvShowId = 10, GenreId = 5 },
                // Mr. Robot
                new TvShowGenre { TvShowId = 11, GenreId = 1 },
                new TvShowGenre { TvShowId = 11, GenreId = 5 },
                // Euphoria
                new TvShowGenre { TvShowId = 12, GenreId = 1 },
                // The Boys
                new TvShowGenre { TvShowId = 13, GenreId = 3 },
                new TvShowGenre { TvShowId = 13, GenreId = 5 },
                // WandaVision
                new TvShowGenre { TvShowId = 14, GenreId = 4 },
                new TvShowGenre { TvShowId = 14, GenreId = 2 },
                // True Detective
                new TvShowGenre { TvShowId = 15, GenreId = 7 },
                new TvShowGenre { TvShowId = 15, GenreId = 1 },
                // Better Call Saul
                new TvShowGenre { TvShowId = 16, GenreId = 1 },
                new TvShowGenre { TvShowId = 16, GenreId = 7 },
                // Narcos
                new TvShowGenre { TvShowId = 17, GenreId = 7 },
                new TvShowGenre { TvShowId = 17, GenreId = 1 },
                // The Expanse
                new TvShowGenre { TvShowId = 18, GenreId = 4 },
                new TvShowGenre { TvShowId = 18, GenreId = 8 },
                // The Last of Us
                new TvShowGenre { TvShowId = 19, GenreId = 1 },
                new TvShowGenre { TvShowId = 19, GenreId = 8 },
                // Sherlock
                new TvShowGenre { TvShowId = 20, GenreId = 7 },
                new TvShowGenre { TvShowId = 20, GenreId = 5 }
            );
        }

        private void PopulateTvShowsActors(ModelBuilder modelBuilder)
        {
            // === TvShowActors ===
            modelBuilder.Entity<TvShowActor>().HasData(
                new TvShowActor { TvShowId = 1, ActorId = 1 },
                new TvShowActor { TvShowId = 1, ActorId = 14 },
                new TvShowActor { TvShowId = 2, ActorId = 2 },
                new TvShowActor { TvShowId = 2, ActorId = 12 },
                new TvShowActor { TvShowId = 3, ActorId = 3 },
                new TvShowActor { TvShowId = 3, ActorId = 13 },
                new TvShowActor { TvShowId = 4, ActorId = 4 },
                new TvShowActor { TvShowId = 4, ActorId = 8 },
                new TvShowActor { TvShowId = 5, ActorId = 6 },
                new TvShowActor { TvShowId = 5, ActorId = 9 },
                new TvShowActor { TvShowId = 6, ActorId = 14 },
                new TvShowActor { TvShowId = 6, ActorId = 6 },
                new TvShowActor { TvShowId = 7, ActorId = 5 },
                new TvShowActor { TvShowId = 7, ActorId = 11 },
                new TvShowActor { TvShowId = 8, ActorId = 8 },
                new TvShowActor { TvShowId = 8, ActorId = 15 },
                new TvShowActor { TvShowId = 9, ActorId = 9 },
                new TvShowActor { TvShowId = 9, ActorId = 10 },
                new TvShowActor { TvShowId = 10, ActorId = 7 },
                new TvShowActor { TvShowId = 10, ActorId = 14 },
                new TvShowActor { TvShowId = 11, ActorId = 12 },
                new TvShowActor { TvShowId = 12, ActorId = 11 },
                new TvShowActor { TvShowId = 12, ActorId = 3 },
                new TvShowActor { TvShowId = 13, ActorId = 15 },
                new TvShowActor { TvShowId = 13, ActorId = 2 },
                new TvShowActor { TvShowId = 14, ActorId = 13 },
                new TvShowActor { TvShowId = 15, ActorId = 10 },
                new TvShowActor { TvShowId = 16, ActorId = 2 },
                new TvShowActor { TvShowId = 17, ActorId = 15 },
                new TvShowActor { TvShowId = 18, ActorId = 15 },
                new TvShowActor { TvShowId = 19, ActorId = 4 },
                new TvShowActor { TvShowId = 19, ActorId = 5 },
                new TvShowActor { TvShowId = 20, ActorId = 10 },
                new TvShowActor { TvShowId = 20, ActorId = 1 }
            );
        }

        private void PopulateSeasons(ModelBuilder modelBuilder)
        {
            // === Seasons ===
            modelBuilder.Entity<Season>().HasData(
                new Season { Id = 1, TvShowId = 1, SeasonNumber = 1, ReleaseDate = new DateTime(2013, 9, 12) },
                new Season { Id = 2, TvShowId = 1, SeasonNumber = 2, ReleaseDate = new DateTime(2014, 10, 2) },
                new Season { Id = 3, TvShowId = 2, SeasonNumber = 1, ReleaseDate = new DateTime(2008, 1, 20) },
                new Season { Id = 4, TvShowId = 2, SeasonNumber = 2, ReleaseDate = new DateTime(2009, 3, 15) },
                new Season { Id = 5, TvShowId = 3, SeasonNumber = 1, ReleaseDate = new DateTime(1994, 9, 22) },
                new Season { Id = 6, TvShowId = 3, SeasonNumber = 2, ReleaseDate = new DateTime(1995, 9, 21) },
                new Season { Id = 7, TvShowId = 4, SeasonNumber = 1, ReleaseDate = new DateTime(2019, 11, 12) },
                new Season { Id = 8, TvShowId = 5, SeasonNumber = 1, ReleaseDate = new DateTime(2019, 12, 20) },
                new Season { Id = 9, TvShowId = 5, SeasonNumber = 2, ReleaseDate = new DateTime(2021, 12, 17) },
                new Season { Id = 10, TvShowId = 6, SeasonNumber = 1, ReleaseDate = new DateTime(2011, 4, 17) },
                new Season { Id = 11, TvShowId = 6, SeasonNumber = 2, ReleaseDate = new DateTime(2012, 4, 1) },
                new Season { Id = 12, TvShowId = 7, SeasonNumber = 1, ReleaseDate = new DateTime(2016, 7, 15) },
                new Season { Id = 13, TvShowId = 7, SeasonNumber = 2, ReleaseDate = new DateTime(2017, 10, 27) },
                new Season { Id = 14, TvShowId = 8, SeasonNumber = 1, ReleaseDate = new DateTime(2021, 6, 9) },
                new Season { Id = 15, TvShowId = 9, SeasonNumber = 1, ReleaseDate = new DateTime(2020, 10, 23) },
                new Season { Id = 16, TvShowId = 10, SeasonNumber = 1, ReleaseDate = new DateTime(2022, 8, 21) },
                new Season { Id = 17, TvShowId = 11, SeasonNumber = 1, ReleaseDate = new DateTime(2015, 6, 24) },
                new Season { Id = 18, TvShowId = 12, SeasonNumber = 1, ReleaseDate = new DateTime(2019, 6, 16) },
                new Season { Id = 19, TvShowId = 13, SeasonNumber = 1, ReleaseDate = new DateTime(2019, 7, 26) },
                new Season { Id = 20, TvShowId = 14, SeasonNumber = 1, ReleaseDate = new DateTime(2021, 1, 15) },
                new Season { Id = 21, TvShowId = 15, SeasonNumber = 1, ReleaseDate = new DateTime(2014, 1, 12) },
                new Season { Id = 22, TvShowId = 16, SeasonNumber = 1, ReleaseDate = new DateTime(2015, 2, 8) },
                new Season { Id = 23, TvShowId = 17, SeasonNumber = 1, ReleaseDate = new DateTime(2015, 8, 28) },
                new Season { Id = 24, TvShowId = 18, SeasonNumber = 1, ReleaseDate = new DateTime(2015, 12, 14) },
                new Season { Id = 25, TvShowId = 19, SeasonNumber = 1, ReleaseDate = new DateTime(2023, 1, 15) },
                new Season { Id = 26, TvShowId = 20, SeasonNumber = 1, ReleaseDate = new DateTime(2010, 7, 25) },
                new Season { Id = 27, TvShowId = 20, SeasonNumber = 2, ReleaseDate = new DateTime(2011, 7, 25) }
            );
        }

        private void PopulateEpisodes(ModelBuilder modelBuilder)
        {
            var random = new Random();

            int RandDuration() => random.Next(35, 71);

            modelBuilder.Entity<SeasonEpisode>().HasData(
                // Show 1
                new SeasonEpisode { Id = 1, SeasonId = 1, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2013, 9, 12), Duration = 52, Rating = 8.6 },
                new SeasonEpisode { Id = 2, SeasonId = 1, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2013, 9, 19), Duration = RandDuration(), Rating = 8.7 },
                new SeasonEpisode { Id = 3, SeasonId = 2, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2014, 10, 2), Duration = RandDuration(), Rating = 8.9 },

                // Show 2
                new SeasonEpisode { Id = 4, SeasonId = 3, EpisodeNumber = 1, Title = "Pilot", AirDate = new DateTime(2008, 1, 20), Duration = RandDuration(), Rating = 9.0 },
                new SeasonEpisode { Id = 5, SeasonId = 3, EpisodeNumber = 2, Title = "Cat's in the Bag...", AirDate = new DateTime(2008, 1, 27), Duration = RandDuration(), Rating = 8.7 },
                new SeasonEpisode { Id = 6, SeasonId = 4, EpisodeNumber = 1, Title = "Season 2 Premiere", AirDate = new DateTime(2009, 3, 15), Duration = RandDuration(), Rating = 9.1 },

                // Show 3
                new SeasonEpisode { Id = 7, SeasonId = 5, EpisodeNumber = 1, Title = "The One Where It All Began", AirDate = new DateTime(1994, 9, 22), Duration = RandDuration(), Rating = 8.3 },
                new SeasonEpisode { Id = 8, SeasonId = 5, EpisodeNumber = 2, Title = "The One with the Sonogram", AirDate = new DateTime(1994, 9, 29), Duration = RandDuration(), Rating = 8.4 },
                new SeasonEpisode { Id = 9, SeasonId = 6, EpisodeNumber = 1, Title = "Season 2 Premiere", AirDate = new DateTime(1995, 9, 21), Duration = RandDuration(), Rating = 8.5 },

                // Show 4
                new SeasonEpisode { Id = 10, SeasonId = 7, EpisodeNumber = 1, Title = "Chapter 1: The Mandalorian", AirDate = new DateTime(2019, 11, 12), Duration = RandDuration(), Rating = 8.9 },
                new SeasonEpisode { Id = 11, SeasonId = 7, EpisodeNumber = 2, Title = "Chapter 2: The Child", AirDate = new DateTime(2019, 11, 15), Duration = RandDuration(), Rating = 8.8 },

                // Show 5
                new SeasonEpisode { Id = 12, SeasonId = 8, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2019, 12, 20), Duration = RandDuration(), Rating = 8.2 },
                new SeasonEpisode { Id = 13, SeasonId = 8, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2019, 12, 27), Duration = RandDuration(), Rating = 8.4 },
                new SeasonEpisode { Id = 14, SeasonId = 9, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2021, 12, 17), Duration = RandDuration(), Rating = 8.5 },

                // Show 6
                new SeasonEpisode { Id = 15, SeasonId = 10, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2011, 4, 17), Duration = RandDuration(), Rating = 9.0 },
                new SeasonEpisode { Id = 16, SeasonId = 10, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2011, 4, 24), Duration = RandDuration(), Rating = 8.9 },
                new SeasonEpisode { Id = 17, SeasonId = 11, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2012, 4, 1), Duration = RandDuration(), Rating = 9.1 },

                // Show 7
                new SeasonEpisode { Id = 18, SeasonId = 12, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2021, 6, 9), Duration = RandDuration(), Rating = 8.4 },
                new SeasonEpisode { Id = 19, SeasonId = 12, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2021, 6, 16), Duration = RandDuration(), Rating = 8.6 },
                new SeasonEpisode { Id = 20, SeasonId = 12, EpisodeNumber = 3, Title = "Episode 3", AirDate = new DateTime(2021, 6, 23), Duration = RandDuration(), Rating = 8.5 },
                new SeasonEpisode { Id = 21, SeasonId = 13, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2020, 10, 23), Duration = RandDuration(), Rating = 7.8 },
                new SeasonEpisode { Id = 22, SeasonId = 13, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2020, 10, 30), Duration = RandDuration(), Rating = 7.9 },

                // Show 8
                new SeasonEpisode { Id = 23, SeasonId = 14, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2022, 8, 21), Duration = RandDuration(), Rating = 8.0 },
                new SeasonEpisode { Id = 24, SeasonId = 14, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2022, 8, 28), Duration = RandDuration(), Rating = 8.2 },
                new SeasonEpisode { Id = 25, SeasonId = 14, EpisodeNumber = 3, Title = "Episode 3", AirDate = new DateTime(2022, 9, 4), Duration = RandDuration(), Rating = 8.1 },

                // Show 9
                new SeasonEpisode { Id = 26, SeasonId = 15, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2015, 6, 24), Duration = RandDuration(), Rating = 8.3 },
                new SeasonEpisode { Id = 27, SeasonId = 15, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2015, 7, 1), Duration = RandDuration(), Rating = 8.2 },

                // Show 10
                new SeasonEpisode { Id = 28, SeasonId = 16, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2019, 6, 16), Duration = RandDuration(), Rating = 8.5 },
                new SeasonEpisode { Id = 29, SeasonId = 16, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2019, 6, 23), Duration = RandDuration(), Rating = 8.6 },

                // Show 11
                new SeasonEpisode { Id = 30, SeasonId = 17, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2019, 7, 26), Duration = RandDuration(), Rating = 7.9 },
                new SeasonEpisode { Id = 31, SeasonId = 17, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2019, 8, 2), Duration = RandDuration(), Rating = 8.0 },

                // Show 12
                new SeasonEpisode { Id = 32, SeasonId = 18, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2021, 1, 15), Duration = RandDuration(), Rating = 8.1 },
                new SeasonEpisode { Id = 33, SeasonId = 18, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2021, 1, 22), Duration = RandDuration(), Rating = 8.2 },

                // Show 13
                new SeasonEpisode { Id = 34, SeasonId = 19, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2014, 1, 12), Duration = RandDuration(), Rating = 8.0 },
                new SeasonEpisode { Id = 35, SeasonId = 19, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2014, 1, 19), Duration = RandDuration(), Rating = 8.1 },

                // Show 14
                new SeasonEpisode { Id = 36, SeasonId = 20, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2015, 2, 8), Duration = RandDuration(), Rating = 7.9 },

                // Show 15
                new SeasonEpisode { Id = 37, SeasonId = 21, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2015, 8, 28), Duration = RandDuration(), Rating = 8.3 },

                // Show 16
                new SeasonEpisode { Id = 38, SeasonId = 22, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2015, 12, 14), Duration = RandDuration(), Rating = 8.2 },

                // Show 17
                new SeasonEpisode { Id = 39, SeasonId = 23, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2023, 1, 15), Duration = RandDuration(), Rating = 8.4 },

                // Show 18
                new SeasonEpisode { Id = 40, SeasonId = 24, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2010, 7, 25), Duration = RandDuration(), Rating = 7.8 },
                new SeasonEpisode { Id = 41, SeasonId = 24, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2010, 8, 1), Duration = RandDuration(), Rating = 7.9 },

                // Show 19
                new SeasonEpisode { Id = 42, SeasonId = 25, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2011, 7, 25), Duration = RandDuration(), Rating = 8.0 },

                // Show 20
                new SeasonEpisode { Id = 43, SeasonId = 26, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2011, 7, 25), Duration = RandDuration(), Rating = 5.0 },
                new SeasonEpisode { Id = 44, SeasonId = 26, EpisodeNumber = 2, Title = "Episode 2", AirDate = new DateTime(2011, 12, 25), Duration = RandDuration(), Rating = 6.2 },
                new SeasonEpisode { Id = 45, SeasonId = 27, EpisodeNumber = 1, Title = "Episode 1", AirDate = new DateTime(2012, 7, 25), Duration = RandDuration(), Rating = 7.8 }
            );
        }
    }
}
