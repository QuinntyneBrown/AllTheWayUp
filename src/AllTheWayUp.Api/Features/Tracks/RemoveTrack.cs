using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using AllTheWayUp.Api.Models;
using AllTheWayUp.Api.Core;
using AllTheWayUp.Api.Interfaces;

namespace AllTheWayUp.Api.Features
{
    public class RemoveTrack
    {
        public class Request : IRequest<Response>
        {
            public Guid TrackId { get; set; }
        }

        public class Response : ResponseBase
        {
            public TrackDto Track { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAllTheWayUpDbContext _context;

            public Handler(IAllTheWayUpDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var track = await _context.Tracks.SingleAsync(x => x.TrackId == request.TrackId);

                _context.Tracks.Remove(track);

                await _context.SaveChangesAsync(cancellationToken);

                return new Response()
                {
                    Track = track.ToDto()
                };
            }

        }
    }
}
