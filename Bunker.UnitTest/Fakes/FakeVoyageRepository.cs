using Bunker.Domain.Models;
using Bunker.Domain.Repositories;

namespace Bunker.UnitTest.Fakes;

public class FakeVoyageRepository(IList<Voyage> collection) 
    : FakeRepository<Voyage>(collection), IVoyageRepository
{
}
