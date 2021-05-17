using AllTheWayUp.Api.Core;
using AllTheWayUp.Api.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AllTheWayUp.Api.Features
{
    public class GetArtists
    {
        public class Request : IRequest<Response> { }

        public class Response : ResponseBase
        {
            public List<ArtistDto> Artists { get; set; }
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
                    Artists = await _context.Artists
                    .Include(x => x.Tracks)
                    .Select(x => x.ToDto()).ToListAsync()
                };
            }
        }
    }
}
