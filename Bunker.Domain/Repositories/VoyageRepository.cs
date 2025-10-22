using Bunker.Domain.Models;

namespace Bunker.Domain.Repositories;

public interface IVoyageRepository : IRepository<Voyage>
{
}

public class VoyageRepository : Repository<Voyage>, IVoyageRepository
{
    public VoyageRepository(DbContext context) : base(context)
    {
    }
}
