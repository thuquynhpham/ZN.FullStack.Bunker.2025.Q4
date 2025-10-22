using Bunker.Api.Handlers._Shared;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.Port;

public class DeletePortHandler : CommandHandlerBase<DeletePortCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPortRepository _portRepository;

    public DeletePortHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _portRepository = _unitOfWork.Ports;
    }

    public override async Task<CommandApiResponse> Handle(DeletePortCommand command, CancellationToken ct)
    {
        try
        {
            var port = await _portRepository.GetByIdAsync(command.Id, ct);
            if (port == null)
            {
                return CommandApiResponse.CreateNotFound($"Port with ID {command.Id} not found");
            }

            await _portRepository.DeleteAsync(port, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success();
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while deleting the port: {ex.Message}");
        }
    }
}

public class DeletePortCommand : ICommand
{
    public int Id { get; set; }
}
