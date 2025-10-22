using Bunker.Domain.Models;

namespace Bunker.Domain.Repositories;

public interface IPortRepository : IRepository<Port>
{
}

public class PortRepository : Repository<Port>, IPortRepository
{
    public PortRepository(DbContext context) : base(context)
    {
    }
}
