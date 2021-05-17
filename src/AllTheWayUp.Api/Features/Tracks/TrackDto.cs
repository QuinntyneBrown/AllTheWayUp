using System;

namespace AllTheWayUp.Api.Features
{
    public class TrackDto
    {
        public Guid TrackId { get; set; }
        public Guid ArtistId { get; set; }
        public string Name { get; set; }
    }
}
