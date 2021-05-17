using System;
using System.Collections.Generic;

namespace AllTheWayUp.Api.Models
{
    public class Artist
    {
        public Guid ArtistId { get; private set; }
        public string Name { get; private set; }
        public List<Track> Tracks { get; private set; } = new();
        public Artist(string name)
        {
            Name = name;
        }

        private Artist()
        {

        }
    }
}
