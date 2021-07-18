
using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Collections.EF
{
    public class Initializer : CreateDatabaseIfNotExists<MusciCollectionModel>
    {
        protected override void Seed(MusciCollectionModel context)
        {
            base.Seed(context);
            // Country
            Country urk = context.Countries.Add(new Country() { Name = "Ukraine" });
            Country pol = context.Countries.Add(new Country() { Name = "Poland" });
            Country usa = context.Countries.Add(new Country() { Name = "United States" });
            context.SaveChanges();

            // Artish
            Artish artish1 = context.Artishes.Add(new Artish() { Name = "Alisher", Surname = "Tagirovich" });
            Artish artish2 = context.Artishes.Add(new Artish() { Name = "Muchailo", Surname = "Poplavskiy" });
            Artish artish3 = context.Artishes.Add(new Artish() { Name = "Till", Surname = "Lindeman" });
            context.SaveChanges();
            
            // Category
            Category category1 = context.Categories.Add(new Category() { Name = "Popular" });
            Category category2 = context.Categories.Add(new Category() { Name = "Love" });
            Category category3 = context.Categories.Add(new Category() { Name = "Most Listened" });
            context.SaveChanges();

            // Ganre
            Ganre ganre = context.Ganres.Add(new Ganre() { Name = "Lo-fi" });
            Ganre ganre1 = context.Ganres.Add(new Ganre() { Name = "Hip-Hop" });
            Ganre ganre2 = context.Ganres.Add(new Ganre() { Name = "Rap" });
            context.SaveChanges();

            // Album
            DateTime date = new DateTime(year: 2020,11,11);
            Album album = context.Albums.Add(new Album() { Name = "Million Dollars",Year=date });
            Album album1 = context.Albums.Add(new Album() { Name = "1000 Ukrainian music", Year = date });
            Album album2 = context.Albums.Add(new Album() { Name = "Reise", Year = date });
            context.SaveChanges();

            // Track
            Track track = context.Tracks.Add(new Track() { Duration = new TimeSpan(200) });
            Track track1 = context.Tracks.Add(new Track() { Duration = new TimeSpan(400) });
            Track track2 = context.Tracks.Add(new Track() { Duration = new TimeSpan(600) });
            context.SaveChanges();

            // Playlist
            Playlist playlist = context.Playlists.Add(new Playlist() { Name = "Favorite" });
            Playlist playlist1 = context.Playlists.Add(new Playlist() { Name = "My" });
            Playlist playlist2 = context.Playlists.Add(new Playlist() { Name = "For weather" });
            context.SaveChanges();
        }
    }
}
