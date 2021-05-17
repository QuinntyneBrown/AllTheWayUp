using AllTheWayUp.Api.Models;
using System.Linq;

namespace AllTheWayUp.Api.Features
{
    public static class ArtistExtensions
    {
        public static ArtistDto ToDto(this Artist artist)
        {
            return new()
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name,
                Tracks = artist.Tracks.Select(x => x.ToDto()).ToList()
            };
        }
    }
}
