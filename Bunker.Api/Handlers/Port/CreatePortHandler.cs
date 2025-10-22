using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Port.DTOs;
using Bunker.Domain.Models;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Port;

public class CreatePortHandler : CommandHandlerBase<CreatePortCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPortRepository _portRepository;

    public CreatePortHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _portRepository = _unitOfWork.Ports;
    }

    public override async Task<CommandApiResponse> Handle(CreatePortCommand command, CancellationToken ct)
    {
        try
        {
            // Check if UNLOCODE already exists
            var existingPort = await _portRepository.GetAllAsync(ct);
            if (existingPort.Any(p => p.UNLOCODE == command.Port.UNLOCODE))
            {
                return CommandApiResponse.CreateValidationFailed($"Port with UNLOCODE '{command.Port.UNLOCODE}' already exists");
            }

            var port = new Domain.Models.Port
            {
                UNLOCODE = command.Port.UNLOCODE,
                Name = command.Port.Name,
                AlternativeName = command.Port.AlternativeName,
                Country = command.Port.Country,
                City = command.Port.City,
                State = command.Port.State,
                Latitude = command.Port.Latitude,
                Longitude = command.Port.Longitude,
                TimeZone = command.Port.TimeZone,
                PortType = command.Port.PortType,
                Size = command.Port.Size,
                MaxDraft = command.Port.MaxDraft,
                MaxVesselLength = command.Port.MaxVesselLength,
                MaxVesselBeam = command.Port.MaxVesselBeam,
                MaxDWT = command.Port.MaxDWT,
                NumberOfBerths = command.Port.NumberOfBerths,
                NumberOfTerminals = command.Port.NumberOfTerminals,
                HasContainerFacilities = command.Port.HasContainerFacilities,
                HasBulkFacilities = command.Port.HasBulkFacilities,
                HasLiquidFacilities = command.Port.HasLiquidFacilities,
                HasRoRoFacilities = command.Port.HasRoRoFacilities,
                HasPassengerFacilities = command.Port.HasPassengerFacilities,
                HasBunkeringFacilities = command.Port.HasBunkeringFacilities,
                HasRepairFacilities = command.Port.HasRepairFacilities,
                Is24Hours = command.Port.Is24Hours,
                IsIceFree = command.Port.IsIceFree,
                Status = command.Port.Status,
                PortAuthority = command.Port.PortAuthority,
                ContactPhone = command.Port.ContactPhone,
                ContactEmail = command.Port.ContactEmail,
                Website = command.Port.Website,
                AverageWaitingTimeHours = command.Port.AverageWaitingTimeHours,
                AverageTurnaroundTimeHours = command.Port.AverageTurnaroundTimeHours,
                AnnualCargoThroughputTEU = command.Port.AnnualCargoThroughputTEU,
                AnnualVesselCalls = command.Port.AnnualVesselCalls,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = command.Port.CreatedBy,
                Notes = command.Port.Notes
            };

            await _portRepository.AddAsync(port, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success(port.Id);
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while creating the port: {ex.Message}");
        }
    }
}

public class CreatePortCommand : ICommand
{
    public CreatePortDto Port { get; set; } = new();
}
