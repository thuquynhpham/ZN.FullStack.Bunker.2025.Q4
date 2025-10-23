using Bunker.Api.Handlers._Shared;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Voyage;

public class DeleteVoyageHandler(IUnitOfWork unitOfWork) : CommandHandlerBase<DeleteVoyageCommand>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IVoyageRepository _voyageRepository = unitOfWork.Voyages;

    public override async Task<CommandApiResponse> Handle(DeleteVoyageCommand request, CancellationToken ct)
    {
        try
        {
            var voyage = await _voyageRepository.GetByIdAsync(request.Id, ct);
            if (voyage == null)
            {
                return CommandApiResponse.CreateNotFound($"Voyage with ID {request.Id} not found");
            }

            await _voyageRepository.DeleteAsync(voyage, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success($"Voyage {voyage.VoyageNumber} deleted successfully");
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while deleting voyage: {ex.Message}");
        }
    }
}

public class DeleteVoyageCommand : ICommand
{
    public int Id { get; set; }
}
