using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AllTheWayUp.Api.Extensions;
using AllTheWayUp.Api.Core;
using AllTheWayUp.Api.Interfaces;
using AllTheWayUp.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AllTheWayUp.Api.Features
{
    public class GetTracksPage
    {
        public class Request : IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response : ResponseBase
        {
            public int Length { get; set; }
            public List<TrackDto> Entities { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAllTheWayUpDbContext _context;

            public Handler(IAllTheWayUpDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from track in _context.Tracks
                            select track;

                var length = await _context.Tracks.CountAsync();

                var tracks = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();

                return new()
                {
                    Length = length,
                    Entities = tracks
                };
            }

        }
    }
}
