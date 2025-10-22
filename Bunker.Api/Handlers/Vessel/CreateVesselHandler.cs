using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Vessel.DTOs;
using Bunker.Domain.Models;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Vessel;

public class CreateVesselHandler : CommandHandlerBase<CreateVesselCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVesselRepository _vesselRepository;

    public CreateVesselHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _vesselRepository = _unitOfWork.Vessels;
    }

    public override async Task<CommandApiResponse> Handle(CreateVesselCommand command, CancellationToken ct)
    {
        try
        {
            // Check if IMO already exists
            var existingVessel = await _vesselRepository.GetAllAsync(ct);
            if (existingVessel.Any(v => v.IMO == command.Vessel.IMO))
            {
                return CommandApiResponse.CreateValidationFailed($"Vessel with IMO '{command.Vessel.IMO}' already exists");
            }

            var vessel = new Domain.Models.Vessel
            {
                IMO = command.Vessel.IMO,
                Name = command.Vessel.Name,
                VesselType = command.Vessel.VesselType,
                Flag = command.Vessel.Flag,
                CallSign = command.Vessel.CallSign,
                MMSI = command.Vessel.MMSI,
                LengthOverall = command.Vessel.LengthOverall,
                Beam = command.Vessel.Beam,
                Draft = command.Vessel.Draft,
                GrossTonnage = command.Vessel.GrossTonnage,
                DeadweightTonnage = command.Vessel.DeadweightTonnage,
                YearBuilt = command.Vessel.YearBuilt,
                Owner = command.Vessel.Owner,
                Status = command.Vessel.Status,
                MaxCrew = command.Vessel.MaxCrew,
                EnginePowerKW = command.Vessel.EnginePowerKW,
                MaxSpeedKnots = command.Vessel.MaxSpeedKnots,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = command.Vessel.CreatedBy,
                Notes = command.Vessel.Notes
            };

            await _vesselRepository.AddAsync(vessel, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success(vessel.Id);
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while creating the vessel: {ex.Message}");
        }
    }
}

public class CreateVesselCommand : ICommand
{
    public CreateVesselDto Vessel { get; set; } = new();
}
