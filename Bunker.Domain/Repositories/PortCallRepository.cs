using Bunker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Domain.Repositories;

public interface IPortCallRepository : IRepository<PortCall>
{
}

public class PortCallRepository : Repository<PortCall>, IPortCallRepository
{
    public PortCallRepository(DbContext context) : base(context)
    {
    }
}
