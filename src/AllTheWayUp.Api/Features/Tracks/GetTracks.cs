using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AllTheWayUp.Api.Core;
using AllTheWayUp.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AllTheWayUp.Api.Features
{
    public class GetTracks
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<TrackDto> Tracks { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAllTheWayUpDbContext _context;

            public Handler(IAllTheWayUpDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new()
                {
                    Tracks = await _context.Tracks.Select(x => x.ToDto()).ToListAsync()
                };
            }

        }
    }
}
