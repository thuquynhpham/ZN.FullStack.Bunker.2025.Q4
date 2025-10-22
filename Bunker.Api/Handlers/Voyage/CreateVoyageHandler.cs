using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Voyage.DTOs;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Voyage;

public class CreateVoyageHandler : CommandHandlerBase<CreateVoyageCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVesselRepository _vesselRepository;
    private readonly IPortRepository _portRepository;
    private readonly IVoyageRepository _voyageRepository;

    public CreateVoyageHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _vesselRepository = _unitOfWork.Vessels;
        _portRepository = _unitOfWork.Ports;
        _voyageRepository = _unitOfWork.Voyages;
    }

    public override async Task<CommandApiResponse> Handle(CreateVoyageCommand command, CancellationToken ct)
    {
        try
        {
            // Validate that Vessel exists
            var vessel = await _vesselRepository.GetByIdAsync(command.Voyage.VesselId, ct);
            if (vessel == null)
            {
                return CommandApiResponse.CreateNotFound($"Vessel with ID {command.Voyage.VesselId} not found");
            }

            // Validate DeparturePort if provided
            if (command.Voyage.DeparturePortId.HasValue)
            {
                var departurePort = await _portRepository.GetByIdAsync(command.Voyage.DeparturePortId.Value, ct);
                if (departurePort == null)
                {
                    return CommandApiResponse.CreateNotFound($"Departure port with ID {command.Voyage.DeparturePortId} not found");
                }
            }

            // Validate ArrivalPort if provided
            if (command.Voyage.ArrivalPortId.HasValue)
            {
                var arrivalPort = await _portRepository.GetByIdAsync(command.Voyage.ArrivalPortId.Value, ct);
                if (arrivalPort == null)
                {
                    return CommandApiResponse.CreateNotFound($"Arrival port with ID {command.Voyage.ArrivalPortId} not found");
                }
            }

            // Check if VoyageNumber already exists
            var existingVoyage = await _voyageRepository.GetAllAsync(ct);
            if (existingVoyage.Any(v => v.VoyageNumber == command.Voyage.VoyageNumber))
            {
                return CommandApiResponse.CreateValidationFailed($"Voyage number '{command.Voyage.VoyageNumber}' already exists");
            }

            var voyage = new Domain.Models.Voyage
            {
                VoyageNumber = command.Voyage.VoyageNumber,
                VesselId = command.Voyage.VesselId,
                Status = command.Voyage.Status,
                DeparturePortId = command.Voyage.DeparturePortId,
                ArrivalPortId = command.Voyage.ArrivalPortId,
                ScheduledDeparture = command.Voyage.ScheduledDeparture,
                ActualDeparture = command.Voyage.ActualDeparture,
                ScheduledArrival = command.Voyage.ScheduledArrival,
                ActualArrival = command.Voyage.ActualArrival,
                DistanceNauticalMiles = command.Voyage.DistanceNauticalMiles,
                EstimatedDurationHours = command.Voyage.EstimatedDurationHours,
                ActualDurationHours = command.Voyage.ActualDurationHours,
                AverageSpeedKnots = command.Voyage.AverageSpeedKnots,
                MaxSpeedKnots = command.Voyage.MaxSpeedKnots,
                FuelConsumptionMT = command.Voyage.FuelConsumptionMT,
                FuelCostUSD = command.Voyage.FuelCostUSD,
                TotalCostUSD = command.Voyage.TotalCostUSD,
                RevenueUSD = command.Voyage.RevenueUSD,
                ProfitLossUSD = command.Voyage.ProfitLossUSD,
                CargoType = command.Voyage.CargoType,
                CargoWeightMT = command.Voyage.CargoWeightMT,
                CargoVolumeM3 = command.Voyage.CargoVolumeM3,
                TEUCount = command.Voyage.TEUCount,
                PassengerCount = command.Voyage.PassengerCount,
                Charterer = command.Voyage.Charterer,
                CargoOwner = command.Voyage.CargoOwner,
                CharterType = command.Voyage.CharterType,
                CharterRateUSDPerDay = command.Voyage.CharterRateUSDPerDay,
                CharterDurationDays = command.Voyage.CharterDurationDays,
                WeatherConditions = command.Voyage.WeatherConditions,
                SeaState = command.Voyage.SeaState,
                WindSpeedKnots = command.Voyage.WindSpeedKnots,
                WaveHeightMeters = command.Voyage.WaveHeightMeters,
                VisibilityNauticalMiles = command.Voyage.VisibilityNauticalMiles,
                HasIncidents = command.Voyage.HasIncidents,
                IncidentDescription = command.Voyage.IncidentDescription,
                IncidentSeverity = command.Voyage.IncidentSeverity,
                IncidentDate = command.Voyage.IncidentDate,
                HasDelays = command.Voyage.HasDelays,
                DelayReason = command.Voyage.DelayReason,
                DelayDurationHours = command.Voyage.DelayDurationHours,
                DelayCostUSD = command.Voyage.DelayCostUSD,
                PortCallCount = command.Voyage.PortCallCount,
                BunkerOrderCount = command.Voyage.BunkerOrderCount,
                TotalBunkerQuantityMT = command.Voyage.TotalBunkerQuantityMT,
                TotalBunkerCostUSD = command.Voyage.TotalBunkerCostUSD,
                CaptainName = command.Voyage.CaptainName,
                ChiefEngineerName = command.Voyage.ChiefEngineerName,
                CrewCount = command.Voyage.CrewCount,
                IsInternational = command.Voyage.IsInternational,
                CrossesEquator = command.Voyage.CrossesEquator,
                CrossesDateLine = command.Voyage.CrossesDateLine,
                TimeZoneChanges = command.Voyage.TimeZoneChanges,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = command.Voyage.CreatedBy,
                Notes = command.Voyage.Notes
            };

            await _voyageRepository.AddAsync(voyage, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success(voyage.Id);
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while creating the voyage: {ex.Message}");
        }
    }
}

public class CreateVoyageCommand : ICommand
{
    public CreateVoyageDto Voyage { get; set; } = new();
}
