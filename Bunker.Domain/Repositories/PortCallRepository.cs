using Bunker.Domain.DBI;
using Bunker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Domain.Repositories;

public interface IPortCallRepository : IRepository<PortCall>
{
}

public class PortCallRepository(BunkerDbContext context) : Repository<PortCall>(context), IPortCallRepository
{
}
