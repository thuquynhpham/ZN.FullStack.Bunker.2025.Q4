using Bunker.Api.Handlers._Shared;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Vessel;

public class DeleteVesselHandler : CommandHandlerBase<DeleteVesselCommand>
{
    private readonly IVesselRepository _vesselRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVesselHandler(IUnitOfWork unitOfWork)
    {
        _vesselRepository = unitOfWork.Vessels;
        _unitOfWork = unitOfWork;
    }

    public override async Task<CommandApiResponse> Handle(DeleteVesselCommand request, CancellationToken ct)
    {
        try
        {
            var vessel = await _vesselRepository.GetByIdAsync(request.Id, ct);
            if (vessel == null)
            {
                return CommandApiResponse.CreateNotFound($"Vessel with ID {request.Id} not found");
            }

            await _vesselRepository.DeleteAsync(vessel, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success($"Vessel {vessel.Name} deleted successfully");
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while deleting vessel: {ex.Message}");
        }
    }
}

public class DeleteVesselCommand : ICommand
{
    public int Id { get; set; }
}
