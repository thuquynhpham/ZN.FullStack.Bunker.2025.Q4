using Bunker.Api.Handlers._Shared;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.BunkerOrder;

public class DeleteBunkerOrderHandler : CommandHandlerBase<DeleteBunkerOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBunkerOrderRepository _bunkerOrderRepository;

    public DeleteBunkerOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _bunkerOrderRepository = _unitOfWork.BunkerOrders;
    }

    public override async Task<CommandApiResponse> Handle(DeleteBunkerOrderCommand command, CancellationToken ct)
    {
        try
        {
            var bunkerOrder = await _bunkerOrderRepository.GetByIdAsync(command.Id, ct);
            if (bunkerOrder == null)
            {
                return CommandApiResponse.CreateNotFound($"Bunker order with ID {command.Id} not found");
            }

            await _bunkerOrderRepository.DeleteAsync(bunkerOrder, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success();
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while deleting the bunker order: {ex.Message}");
        }
    }
}

public class DeleteBunkerOrderCommand : ICommand
{
    public int Id { get; set; }
}
