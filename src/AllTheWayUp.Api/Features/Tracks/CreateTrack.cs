using AllTheWayUp.Api.Core;
using AllTheWayUp.Api.Interfaces;
using AllTheWayUp.Api.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AllTheWayUp.Api.Features
{
    public class CreateTrack
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Track).NotNull();
                RuleFor(request => request.Track).SetValidator(new TrackValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public TrackDto Track { get; set; }
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
                var track = new Track(request.Track.ArtistId, request.Track.Name);

                _context.Tracks.Add(track);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Track = track.ToDto()
                };
            }
        }
    }
}
