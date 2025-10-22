using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.Port.DTOs;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.Port;

public class GetPortByIdHandler : QueryHandlerBase<GetPortByIdQuery, GetPortByIdResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPortRepository _portRepository;

    public GetPortByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _portRepository = _unitOfWork.Ports;
    }

    public override async Task<GetPortByIdResponse> Handle(GetPortByIdQuery request, CancellationToken ct)
    {
        try
        {
            var port = (await _portRepository.GetAllAsync(ct))
                .FirstOrDefault(p => p.Id == request.Id);

            if (port == null)
            {
                return GetPortByIdResponse.CreateNotFound($"Port with ID {request.Id} not found");
            }

            var response = new GetPortByIdResponse
            {
                Port = PortResponseDto.Create(port)
            };

            return response;
        }
        catch (Exception ex)
        {
            return GetPortByIdResponse.CreateServerError($"An error occurred while retrieving the port: {ex.Message}");
        }
    }
}

public class GetPortByIdQuery : IQuery<GetPortByIdResponse>
{
    public int Id { get; set; }
}

public class GetPortByIdResponse : QueryApiResponse<GetPortByIdResponse>
{
    public PortResponseDto? Port { get; set; }
}
