using System;

namespace AllTheWayUp.Api.Models
{
    public class Track
    {
        public Guid TrackId { get; private set; }
        public Guid ArtistId { get; private set; }
        public string Name { get; private set; }
        public Track(Guid artistId, string name)
        {
            ArtistId = artistId;
            Name = name;
        }

        private Track()
        {

        }
    }
}
