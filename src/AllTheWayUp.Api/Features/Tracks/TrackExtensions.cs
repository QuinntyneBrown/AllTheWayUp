using System;
using AllTheWayUp.Api.Models;

namespace AllTheWayUp.Api.Features
{
    public static class TrackExtensions
    {
        public static TrackDto ToDto(this Track track)
        {
            return new()
            {
                TrackId = track.TrackId,
                ArtistId = track.ArtistId,
                Name = track.Name
            };
        }

    }
}
