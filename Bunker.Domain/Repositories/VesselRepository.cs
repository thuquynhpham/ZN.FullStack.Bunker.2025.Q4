using Bunker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Domain.Repositories;

public interface IVesselRepository : IRepository<Vessel>
{
}

public class VesselRepository : Repository<Vessel>, IVesselRepository
{
    public VesselRepository(DbContext context) : base(context)
    {
    }
}
