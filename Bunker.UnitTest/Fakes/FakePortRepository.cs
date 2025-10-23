using Bunker.Domain.Models;
using Bunker.Domain.Repositories;

namespace Bunker.UnitTest.Fakes;

public class FakePortRepository(IList<Port> collection) 
    : FakeRepository<Port>(collection), IPortRepository
{
}
