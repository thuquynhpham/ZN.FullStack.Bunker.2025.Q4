using Bunker.Domain.Repositories;
using Bunker.UnitTest.Fakes;
using Microsoft.Extensions.Time.Testing;
using NSubstitute;

namespace Bunker.UnitTest
{
    public abstract class TestContextBase
    {
        protected IUnitOfWork _unitOfWork = null!;

        protected IBunkerOrderRepository? _bunkerOrderRepository;
        protected IPortCallRepository? _portCallRepository;
        protected IPortRepository? _portRepository;
        protected IVesselRepository? _vesselRepository;
        protected IVoyageRepository? _voyageRepository;

        protected List<Domain.Models.BunkerOrder> _bunkerOrders = [];
        protected List<Domain.Models.PortCall> _portCalls = [];
        protected List<Domain.Models.Port> _ports = [];
        protected List<Domain.Models.Vessel> _vessels = [];
        protected List<Domain.Models.Voyage> _voyages = [];

        protected DateTimeOffset _now;
        protected TimeProvider _timeProvider = null!;

        protected Exception? _exception;

        protected string _userId = "user@test.com";

        [OneTimeSetUp]
        public virtual void SetUp()
        {
            InitializeProviders();
            SetUpData();
            InitializeRepositories();
            InitializeUnitOfWork();
        }

        [SetUp]
        public virtual Task RunHandlerAsync()
        {
            return Task.CompletedTask;
        }

        [TearDown]
        public virtual void TearDown()
        {
            _unitOfWork?.Dispose();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            _unitOfWork?.Dispose();
        }

        protected virtual void SetUpData()
        {

        }

        protected virtual void InitializeRepositories()
        {
            _bunkerOrderRepository = new FakeBunkerOrderRepository(_bunkerOrders);
            _portCallRepository = new FakePortCallRepository(_portCalls);
            _portRepository = new FakePortRepository(_ports);
            _vesselRepository = new FakeVesselRepository(_vessels);
            _voyageRepository = new FakeVoyageRepository(_voyages);
        }

        protected virtual void InitializeUnitOfWork()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _unitOfWork.BunkerOrders.Returns(_bunkerOrderRepository);
            _unitOfWork.PortCalls.Returns(_portCallRepository);
            _unitOfWork.Ports.Returns(_portRepository);
            _unitOfWork.Vessels.Returns(_vesselRepository);
            _unitOfWork.Voyages.Returns(_voyageRepository);
        }

        protected virtual void InitializeProviders()
        {
            _now = TimeProvider.System.GetUtcNow();
            _timeProvider = new FakeTimeProvider(_now);
        }

    }
}
