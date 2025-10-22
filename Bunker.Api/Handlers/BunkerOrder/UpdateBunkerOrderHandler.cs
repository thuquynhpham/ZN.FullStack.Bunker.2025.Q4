using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.BunkerOrder.DTOs;
using Bunker.Domain.Repositories;

namespace Bunker.Api.Handlers.BunkerOrder;

public class UpdateBunkerOrderHandler : CommandHandlerBase<UpdateBunkerOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVesselRepository _vesselRepository;
    private readonly IPortRepository _portRepository;
    private readonly IVoyageRepository _voyageRepository;
    private readonly IPortCallRepository _portCallRepository;
    private readonly IBunkerOrderRepository _bunkerOrderRepository;

    public UpdateBunkerOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _vesselRepository = _unitOfWork.Vessels;
        _portRepository = _unitOfWork.Ports;
        _voyageRepository = _unitOfWork.Voyages;
        _portCallRepository = _unitOfWork.PortCalls;
        _bunkerOrderRepository = _unitOfWork.BunkerOrders;
    }

    public override async Task<CommandApiResponse> Handle(UpdateBunkerOrderCommand command, CancellationToken ct)
    {
        try
        {
            var existingBunkerOrder = await _bunkerOrderRepository.GetByIdAsync(command.BunkerOrder.Id, ct);
            if (existingBunkerOrder == null)
            {
                return CommandApiResponse.CreateNotFound($"Bunker order with ID {command.BunkerOrder.Id} not found");
            }

            // Validate that Vessel exists
            var vessel = await _vesselRepository.GetByIdAsync(command.BunkerOrder.VesselId, ct);
            if (vessel == null)
            {
                return CommandApiResponse.CreateNotFound($"Vessel with ID {command.BunkerOrder.VesselId} not found");
            }

            // Validate that Port exists
            var port = await _portRepository.GetByIdAsync(command.BunkerOrder.PortId, ct);
            if (port == null)
            {
                return CommandApiResponse.CreateNotFound($"Port with ID {command.BunkerOrder.PortId} not found");
            }

            // Validate Voyage if provided
            if (command.BunkerOrder.VoyageId.HasValue)
            {
                var voyage = await _voyageRepository.GetByIdAsync(command.BunkerOrder.VoyageId.Value, ct);
                if (voyage == null)
                {
                    return CommandApiResponse.CreateNotFound($"Voyage with ID {command.BunkerOrder.VoyageId} not found");
                }
            }

            // Validate PortCall if provided
            if (command.BunkerOrder.PortCallId.HasValue)
            {
                var portCall = await _portCallRepository.GetByIdAsync(command.BunkerOrder.PortCallId.Value, ct);
                if (portCall == null)
                {
                    return CommandApiResponse.CreateNotFound($"PortCall with ID {command.BunkerOrder.PortCallId} not found");
                }
            }

            // Check if OrderNumber already exists (excluding current order)
            var existingOrder = await _bunkerOrderRepository.GetAllAsync(ct);
            if (existingOrder.Any(bo => bo.OrderNumber == command.BunkerOrder.OrderNumber && bo.Id != command.BunkerOrder.Id))
            {
                return CommandApiResponse.CreateValidationFailed($"Order number '{command.BunkerOrder.OrderNumber}' already exists");
            }

            // Update the bunker order
            existingBunkerOrder.VesselId = command.BunkerOrder.VesselId;
            existingBunkerOrder.PortId = command.BunkerOrder.PortId;
            existingBunkerOrder.VoyageId = command.BunkerOrder.VoyageId;
            existingBunkerOrder.PortCallId = command.BunkerOrder.PortCallId;
            existingBunkerOrder.OrderNumber = command.BunkerOrder.OrderNumber;
            existingBunkerOrder.Status = command.BunkerOrder.Status;
            existingBunkerOrder.FuelType = command.BunkerOrder.FuelType;
            existingBunkerOrder.QuantityMT = command.BunkerOrder.QuantityMT;
            existingBunkerOrder.UnitPriceUSDPerMT = command.BunkerOrder.UnitPriceUSDPerMT;
            existingBunkerOrder.TotalPriceUSD = command.BunkerOrder.TotalPriceUSD;
            existingBunkerOrder.Currency = command.BunkerOrder.Currency;
            existingBunkerOrder.ExchangeRate = command.BunkerOrder.ExchangeRate;
            existingBunkerOrder.LocalPrice = command.BunkerOrder.LocalPrice;
            existingBunkerOrder.LocalCurrency = command.BunkerOrder.LocalCurrency;
            existingBunkerOrder.SupplierName = command.BunkerOrder.SupplierName;
            existingBunkerOrder.SupplierContactPerson = command.BunkerOrder.SupplierContactPerson;
            existingBunkerOrder.SupplierPhone = command.BunkerOrder.SupplierPhone;
            existingBunkerOrder.SupplierEmail = command.BunkerOrder.SupplierEmail;
            existingBunkerOrder.SupplierAddress = command.BunkerOrder.SupplierAddress;
            existingBunkerOrder.SupplierLicenseNumber = command.BunkerOrder.SupplierLicenseNumber;
            existingBunkerOrder.RequestedDate = command.BunkerOrder.RequestedDate;
            existingBunkerOrder.ApprovedDate = command.BunkerOrder.ApprovedDate;
            existingBunkerOrder.ScheduledDeliveryDate = command.BunkerOrder.ScheduledDeliveryDate;
            existingBunkerOrder.ActualDeliveryDate = command.BunkerOrder.ActualDeliveryDate;
            existingBunkerOrder.DeliveryStartTime = command.BunkerOrder.DeliveryStartTime;
            existingBunkerOrder.DeliveryEndTime = command.BunkerOrder.DeliveryEndTime;
            existingBunkerOrder.DeliveryDurationHours = command.BunkerOrder.DeliveryDurationHours;
            existingBunkerOrder.DeliveryMethod = command.BunkerOrder.DeliveryMethod;
            existingBunkerOrder.BargeName = command.BunkerOrder.BargeName;
            existingBunkerOrder.BargeCapacityMT = command.BunkerOrder.BargeCapacityMT;
            existingBunkerOrder.BargeIMO = command.BunkerOrder.BargeIMO;
            existingBunkerOrder.TruckCount = command.BunkerOrder.TruckCount;
            existingBunkerOrder.TruckLicensePlates = command.BunkerOrder.TruckLicensePlates;
            existingBunkerOrder.PipelineDelivery = command.BunkerOrder.PipelineDelivery;
            existingBunkerOrder.PipelineLengthMeters = command.BunkerOrder.PipelineLengthMeters;
            existingBunkerOrder.DeliveryLocation = command.BunkerOrder.DeliveryLocation;
            existingBunkerOrder.BerthNumber = command.BunkerOrder.BerthNumber;
            existingBunkerOrder.TerminalName = command.BunkerOrder.TerminalName;
            existingBunkerOrder.AnchorageArea = command.BunkerOrder.AnchorageArea;
            existingBunkerOrder.QualitySpecifications = command.BunkerOrder.QualitySpecifications;
            existingBunkerOrder.DensityAt15C = command.BunkerOrder.DensityAt15C;
            existingBunkerOrder.ViscosityAt50C = command.BunkerOrder.ViscosityAt50C;
            existingBunkerOrder.SulfurContentPercent = command.BunkerOrder.SulfurContentPercent;
            existingBunkerOrder.FlashPointCelsius = command.BunkerOrder.FlashPointCelsius;
            existingBunkerOrder.PourPointCelsius = command.BunkerOrder.PourPointCelsius;
            existingBunkerOrder.WaterContentPercent = command.BunkerOrder.WaterContentPercent;
            existingBunkerOrder.SedimentContentPercent = command.BunkerOrder.SedimentContentPercent;
            existingBunkerOrder.AshContentPercent = command.BunkerOrder.AshContentPercent;
            existingBunkerOrder.CarbonResiduePercent = command.BunkerOrder.CarbonResiduePercent;
            existingBunkerOrder.VanadiumContentPPM = command.BunkerOrder.VanadiumContentPPM;
            existingBunkerOrder.AluminumContentPPM = command.BunkerOrder.AluminumContentPPM;
            existingBunkerOrder.SiliconContentPPM = command.BunkerOrder.SiliconContentPPM;
            existingBunkerOrder.CertificateNumber = command.BunkerOrder.CertificateNumber;
            existingBunkerOrder.CertificateDate = command.BunkerOrder.CertificateDate;
            existingBunkerOrder.CertificateIssuedBy = command.BunkerOrder.CertificateIssuedBy;
            existingBunkerOrder.CertificateValidUntil = command.BunkerOrder.CertificateValidUntil;
            existingBunkerOrder.SampleTaken = command.BunkerOrder.SampleTaken;
            existingBunkerOrder.SampleDate = command.BunkerOrder.SampleDate;
            existingBunkerOrder.SampleLocation = command.BunkerOrder.SampleLocation;
            existingBunkerOrder.SampleSealedBy = command.BunkerOrder.SampleSealedBy;
            existingBunkerOrder.SampleReceivedBy = command.BunkerOrder.SampleReceivedBy;
            existingBunkerOrder.SampleStorageLocation = command.BunkerOrder.SampleStorageLocation;
            existingBunkerOrder.PaymentTerms = command.BunkerOrder.PaymentTerms;
            existingBunkerOrder.PaymentMethod = command.BunkerOrder.PaymentMethod;
            existingBunkerOrder.PaymentDueDate = command.BunkerOrder.PaymentDueDate;
            existingBunkerOrder.PaymentStatus = command.BunkerOrder.PaymentStatus;
            existingBunkerOrder.PaymentDate = command.BunkerOrder.PaymentDate;
            existingBunkerOrder.InvoiceNumber = command.BunkerOrder.InvoiceNumber;
            existingBunkerOrder.InvoiceDate = command.BunkerOrder.InvoiceDate;
            existingBunkerOrder.InvoiceAmountUSD = command.BunkerOrder.InvoiceAmountUSD;
            existingBunkerOrder.TaxAmountUSD = command.BunkerOrder.TaxAmountUSD;
            existingBunkerOrder.DiscountAmountUSD = command.BunkerOrder.DiscountAmountUSD;
            existingBunkerOrder.FinalAmountUSD = command.BunkerOrder.FinalAmountUSD;
            existingBunkerOrder.DeliveryConfirmation = command.BunkerOrder.DeliveryConfirmation;
            existingBunkerOrder.QualityAcceptance = command.BunkerOrder.QualityAcceptance;
            existingBunkerOrder.QualityIssues = command.BunkerOrder.QualityIssues;
            existingBunkerOrder.DisputeStatus = command.BunkerOrder.DisputeStatus;
            existingBunkerOrder.DisputeDescription = command.BunkerOrder.DisputeDescription;
            existingBunkerOrder.DisputeResolution = command.BunkerOrder.DisputeResolution;
            existingBunkerOrder.DisputeResolutionDate = command.BunkerOrder.DisputeResolutionDate;
            existingBunkerOrder.RefundAmountUSD = command.BunkerOrder.RefundAmountUSD;
            existingBunkerOrder.RefundDate = command.BunkerOrder.RefundDate;
            existingBunkerOrder.EnvironmentalCompliance = command.BunkerOrder.EnvironmentalCompliance;
            existingBunkerOrder.IMO2020Compliant = command.BunkerOrder.IMO2020Compliant;
            existingBunkerOrder.LowSulfurFuel = command.BunkerOrder.LowSulfurFuel;
            existingBunkerOrder.BioFuelBlend = command.BunkerOrder.BioFuelBlend;
            existingBunkerOrder.BioFuelPercentage = command.BunkerOrder.BioFuelPercentage;
            existingBunkerOrder.CarbonFootprintMTCO2 = command.BunkerOrder.CarbonFootprintMTCO2;
            existingBunkerOrder.SustainabilityCertificate = command.BunkerOrder.SustainabilityCertificate;
            existingBunkerOrder.UpdatedAt = DateTime.UtcNow;
            existingBunkerOrder.UpdatedBy = command.BunkerOrder.UpdatedBy;
            existingBunkerOrder.Notes = command.BunkerOrder.Notes;

            await _bunkerOrderRepository.UpdateAsync(existingBunkerOrder, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success(existingBunkerOrder.Id);
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while updating the bunker order: {ex.Message}");
        }
    }
}

public class UpdateBunkerOrderCommand : ICommand
{
    public UpdateBunkerOrderDto BunkerOrder { get; set; } = new();
}
