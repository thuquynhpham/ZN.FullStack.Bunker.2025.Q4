using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.PortCall.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.PortCall;

public class GetPortCallByIdHandler(IUnitOfWork unitOfWork) : QueryHandlerBase<GetPortCallByIdQuery, GetPortCallByIdResponse>
{
    private readonly IPortCallRepository _portCallRepository = unitOfWork.PortCalls;

    public override async Task<GetPortCallByIdResponse> Handle(GetPortCallByIdQuery request, CancellationToken ct)
    {
        try
        {
            var portCalls = await _portCallRepository.GetAllAsync(
                query => query
                    .Include(pc => pc.Vessel)
                    .Include(pc => pc.Port)
                    .Include(pc => pc.Voyage),
                ct);

            var portCall = portCalls.FirstOrDefault(pc => pc.Id == request.Id);

            if (portCall == null)
            {
                return QueryApiResponse<GetPortCallByIdResponse>.CreateNotFound($"Port call with ID {request.Id} not found");
            }

            var portCallDto = PortCallResponseDto.Create(portCall);

            return QueryApiResponse<GetPortCallByIdResponse>.Success(new GetPortCallByIdResponse
            {
                PortCall = portCallDto
            });
        }
        catch (Exception ex)
        {
            return QueryApiResponse<GetPortCallByIdResponse>.CreateServerError($"An error occurred while retrieving port call: {ex.Message}");
        }
    }
}

public class GetPortCallByIdQuery : IQuery<GetPortCallByIdResponse>
{
    public int Id { get; set; }
}
