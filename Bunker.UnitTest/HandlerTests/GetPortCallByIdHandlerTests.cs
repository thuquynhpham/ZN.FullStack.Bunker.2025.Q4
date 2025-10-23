using Bunker.Api.Handlers.PortCall;
using Bunker.UnitTest.Fakes;
using Bunker.UnitTest.ModelBuilders;
using NSubstitute;
using NUnit.Framework;

namespace Bunker.UnitTest.HandlerTests
{
    public class GetPortCallByIdHandlerTestContext : TestContextBase
    {
        protected GetPortCallByIdHandler _handler = null!;
        protected GetPortCallByIdQuery _query = null!;

        public override void SetUp()
        {
            base.SetUp();
            _query = new GetPortCallByIdQuery();
            _handler = new GetPortCallByIdHandler(_unitOfWork);
        }
    }

    [TestFixture]
    public class GetPortCallByIdHandlerTests : GetPortCallByIdHandlerTestContext
    {
        protected override void SetUpData()
        {
            // Create test vessels
            _vessels = [
                new VesselBuilder(1, "Test Vessel 1").Build(),
                new VesselBuilder(2, "Test Vessel 2").Build(),
            ];

            // Create test ports
            _ports = [
                new PortBuilder(1, "Test Port 1").Build(),
                new PortBuilder(2, "Test Port 2").Build(),
            ];

            // Create test voyages
            _voyages = [
                new VoyageBuilder(1, "Test Voyage 1", 1).Build(),
                new VoyageBuilder(2, "Test Voyage 2", 2).Build(),
            ];

            // Create test port calls
            _portCalls = [
                new PortCallBuilder(1, 1, 1, "PC001").WithVessel(_vessels[0]).WithPort(_ports[0]).WithVoyage(_voyages[0]).Build(),
                new PortCallBuilder(2, 2, 2, "PC002").WithVessel(_vessels[0]).WithPort(_ports[0]).WithVoyage(_voyages[0]).Build(),
                new PortCallBuilder(3, 1, 2, "PC003").WithVessel(_vessels[1]).WithPort(_ports[1]).WithVoyage(_voyages[1]).Build(),
            ];
        }

        [Test]
        public async Task Handle_ShouldReturnPortCall_WhenValidIdProvided()
        {
            var query = new GetPortCallByIdQuery
            {
                Id = 1
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.NotFound, Is.False);
            Assert.That(result.ServerError, Is.False);
            Assert.That(result.PortCall, Is.Not.Null);
            Assert.That(result.PortCall.Id, Is.EqualTo(1));
            Assert.That(result.PortCall.PortCallNumber, Is.EqualTo("PC001"));
            Assert.That(result.PortCall.Status, Is.EqualTo("In Progress"));
            Assert.That(result.PortCall.CallType, Is.EqualTo("Scheduled"));
        }

        [Test]
        public async Task Handle_ShouldReturnPortCall_WhenSecondValidIdProvided()
        {
            var query = new GetPortCallByIdQuery
            {
                Id = 2
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.NotFound, Is.False);
            Assert.That(result.ServerError, Is.False);
            Assert.That(result.PortCall, Is.Not.Null);
            Assert.That(result.PortCall.Id, Is.EqualTo(2));
            Assert.That(result.PortCall.PortCallNumber, Is.EqualTo("PC002"));
            Assert.That(result.PortCall.Status, Is.EqualTo("In Progress"));
            Assert.That(result.PortCall.CallType, Is.EqualTo("Scheduled"));
        }

        [Test]
        public async Task Handle_ShouldReturnPortCall_WhenThirdValidIdProvided()
        {
            var query = new GetPortCallByIdQuery
            {
                Id = 3
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.NotFound, Is.False);
            Assert.That(result.ServerError, Is.False);
            Assert.That(result.PortCall, Is.Not.Null);
            Assert.That(result.PortCall.Id, Is.EqualTo(3));
            Assert.That(result.PortCall.PortCallNumber, Is.EqualTo("PC003"));
            Assert.That(result.PortCall.Status, Is.EqualTo("In Progress"));
            Assert.That(result.PortCall.CallType, Is.EqualTo("Scheduled"));
        }

        [Test]
        public async Task Handle_ShouldReturnNotFound_WhenInvalidIdProvided()
        {
            var query = new GetPortCallByIdQuery
            {
                Id = 999
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.NotFound, Is.True);
            Assert.That(result.Message, Does.Contain("Port call with ID 999 not found"));
        }

        [Test]
        public async Task Handle_ShouldReturnNotFound_WhenNegativeIdProvided()
        {
            var query = new GetPortCallByIdQuery
            {
                Id = -1
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.NotFound, Is.True);
            Assert.That(result.Message, Does.Contain("Port call with ID -1 not found"));
        }

        [Test]
        public async Task Handle_ShouldReturnNotFound_WhenZeroIdProvided()
        {
            // Arrange
            _portCallRepository = new FakePortCallRepository(_portCalls);
            _unitOfWork.PortCalls.Returns(_portCallRepository);

            var query = new GetPortCallByIdQuery
            {
                Id = 0
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.NotFound, Is.True);
            Assert.That(result.Message, Does.Contain("Port call with ID 0 not found"));
        }


        [Test]
        public async Task Handle_ShouldReturnPortCallWithRelatedEntities_WhenValidIdProvided()
        {
            var query = new GetPortCallByIdQuery
            {
                Id = 1
            };

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.NotFound, Is.False);
            Assert.That(result.ServerError, Is.False);
            Assert.That(result.PortCall, Is.Not.Null);
            Assert.That(result.PortCall.Id, Is.EqualTo(1));
            
            // Verify related entities are included
            Assert.That(result.PortCall.VesselName, Is.Not.Null);
            Assert.That(result.PortCall.PortName, Is.Not.Null);
            Assert.That(result.PortCall.VoyageNumber, Is.Not.Null);
        }
    }
}
