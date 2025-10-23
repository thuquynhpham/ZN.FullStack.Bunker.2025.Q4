using Bunker.Domain.Models;
using Bunker.Domain.Repositories;

namespace Bunker.UnitTest.Fakes;

public class FakePortCallRepository(IList<PortCall> collection) 
    : FakeRepository<PortCall>(collection), IPortCallRepository
{
}
