using Bunker.Domain.DBI;
using Bunker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Domain.Repositories;

public interface IBunkerOrderRepository : IRepository<BunkerOrder>
{
}

public class BunkerOrderRepository(BunkerDbContext context) : Repository<BunkerOrder>(context), IBunkerOrderRepository
{
}
