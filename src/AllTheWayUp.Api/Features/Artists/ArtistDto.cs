using System;
using System.Collections.Generic;

namespace AllTheWayUp.Api.Features
{
    public class ArtistDto
    {
        public Guid ArtistId { get; set; }
        public string Name { get; set; }
        public List<TrackDto> Tracks { get; set; } = new();
    }
}
