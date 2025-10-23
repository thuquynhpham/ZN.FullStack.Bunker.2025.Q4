using Bunker.Domain.DBI;
using Bunker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Domain.Repositories;

public interface IPortRepository : IRepository<Port>
{
}

public class PortRepository(BunkerDbContext context) : Repository<Port>(context), IPortRepository
{
}
