using Bunker.Domain.Models;
using Bunker.Domain.Repositories;

namespace Bunker.UnitTest.Fakes;

public class FakeBunkerOrderRepository(IList<BunkerOrder> collection) 
    : FakeRepository<BunkerOrder>(collection), IBunkerOrderRepository
{
}
