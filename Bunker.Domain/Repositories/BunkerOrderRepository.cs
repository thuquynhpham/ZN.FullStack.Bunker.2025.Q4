using Bunker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Domain.Repositories;

public interface IBunkerOrderRepository : IRepository<BunkerOrder>
{
}

public class BunkerOrderRepository : Repository<BunkerOrder>, IBunkerOrderRepository
{
    public BunkerOrderRepository(DbContext context) : base(context)
    {
    }
}
