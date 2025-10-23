using Bunker.Domain.Models;
using Bunker.Domain.Repositories;

namespace Bunker.UnitTest.Fakes;

public class FakeVesselRepository(IList<Vessel> collection) 
    : FakeRepository<Vessel>(collection), IVesselRepository
{
}
