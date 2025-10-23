using Bunker.Domain.DBI;
using Bunker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Domain.Repositories;

public interface IVesselRepository : IRepository<Vessel>
{
}

public class VesselRepository(BunkerDbContext context) : Repository<Vessel>(context), IVesselRepository
{
}
