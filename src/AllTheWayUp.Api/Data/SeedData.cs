using AllTheWayUp.Api.Models;
using System.Linq;

namespace AllTheWayUp.Api.Data
{
    public static class SeedData
    {
        public static void Seed(AllTheWayUpDbContext context)
        {
            ArtistConfiguration.Seed(context);
            TrackConfiguration.Seed(context);
        }

        internal static class ArtistConfiguration
        {
            internal static void Seed(AllTheWayUpDbContext context)
            {
                AddIfDoesntExist(new ("Drake"));
                AddIfDoesntExist(new ("Jay-Z"));
                AddIfDoesntExist(new ("Lucy Pearl"));

                void AddIfDoesntExist(Artist artist)
                {
                    if(context.Artists.SingleOrDefault(x => x.Name == artist.Name) == null)
                    {
                        context.Artists.Add(artist);
                        context.SaveChanges();
                    }
                }
            }
        }

        internal static class TrackConfiguration
        {
            internal static void Seed(AllTheWayUpDbContext context)
            {
                var drake = context.Artists.Single(x => x.Name == "Drake");
                var jayZ = context.Artists.Single(x => x.Name == "Jay-Z");
                var lucyPearl = context.Artists.Single(x => x.Name == "Lucy Pearl");

                AddIfDoesntExist(new(drake.ArtistId, "Successful"));
                AddIfDoesntExist(new(drake.ArtistId, "Over"));
                AddIfDoesntExist(new(drake.ArtistId, "Worst Behaviour"));
                AddIfDoesntExist(new(drake.ArtistId, "Laugh Now Cry Later"));
                AddIfDoesntExist(new(drake.ArtistId, "Behind Barz"));
                AddIfDoesntExist(new(drake.ArtistId, "Only You Freestyle"));
                AddIfDoesntExist(new(drake.ArtistId, "4PM in Calabasas"));
                AddIfDoesntExist(new(drake.ArtistId, "5AM In Toronto"));

                AddIfDoesntExist(new(jayZ.ArtistId, "Big Pimpin"));
                AddIfDoesntExist(new(jayZ.ArtistId, "Frontin'"));
                AddIfDoesntExist(new(jayZ.ArtistId, "Sorry Not Sorry'"));
                AddIfDoesntExist(new(jayZ.ArtistId, "Song Cry"));
                AddIfDoesntExist(new(jayZ.ArtistId, "Hard Knock Life"));
                AddIfDoesntExist(new(jayZ.ArtistId, "Girls Girls Girls"));

                AddIfDoesntExist(new(lucyPearl.ArtistId, "Dance Tonight"));
                AddIfDoesntExist(new(lucyPearl.ArtistId, "Without You"));
                AddIfDoesntExist(new(lucyPearl.ArtistId, "Don't Mess with My Man"));

                void AddIfDoesntExist(Track track)
                {
                    if (context.Tracks.SingleOrDefault(x => x.Name == track.Name) == null)
                    {
                        context.Tracks.Add(track);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
