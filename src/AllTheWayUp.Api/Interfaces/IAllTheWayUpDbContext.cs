using AllTheWayUp.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AllTheWayUp.Api.Interfaces
{
    public interface IAllTheWayUpDbContext
    {
        DbSet<Artist> Artists { get; }
        DbSet<Track> Tracks { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
