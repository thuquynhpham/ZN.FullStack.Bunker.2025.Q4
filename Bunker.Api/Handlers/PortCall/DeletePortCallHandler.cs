using Bunker.Api.Handlers._Shared;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.PortCall;

public class DeletePortCallHandler : CommandHandlerBase<DeletePortCallCommand>
{
    private readonly IPortCallRepository _portCallRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePortCallHandler(IUnitOfWork unitOfWork)
    {
        _portCallRepository = unitOfWork.PortCalls;
        _unitOfWork = unitOfWork;
    }

    public override async Task<CommandApiResponse> Handle(DeletePortCallCommand request, CancellationToken ct)
    {
        try
        {
            var portCall = await _portCallRepository.GetByIdAsync(request.Id, ct);
            if (portCall == null)
            {
                return CommandApiResponse.CreateNotFound($"Port call with ID {request.Id} not found");
            }

            await _portCallRepository.DeleteAsync(portCall, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success();
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while deleting port call: {ex.Message}");
        }
    }
}

public record DeletePortCallCommand(int Id) : ICommand { }

