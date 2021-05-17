using AllTheWayUp.Api.Core;
using AllTheWayUp.Api.Interfaces;
using AllTheWayUp.Api.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AllTheWayUp.Api.Features
{
    public class CreateArtist
    {
        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Artist).NotNull();
                RuleFor(request => request.Artist).SetValidator(new ArtistValidator());
            }

        }

        public class Request : IRequest<Response>
        {
            public ArtistDto Artist { get; set; }
        }

        public class Response : ResponseBase
        {
            public ArtistDto Artist { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IAllTheWayUpDbContext _context;

            public Handler(IAllTheWayUpDbContext context)
                => _context = context;

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var artist = new Artist(request.Artist.Name);

                _context.Artists.Add(artist);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Artist = artist.ToDto()
                };
            }

        }
    }
}
