using Bunker.Api.Handlers._Shared;
using Bunker.Api.Handlers.BunkerOrder.DTOs;
using Bunker.Domain.Models;
using Bunker.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Api.Handlers.BunkerOrder;

public class CreateBunkerOrderHandler : CommandHandlerBase<CreateBunkerOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IVesselRepository _vesselRepository;
    private readonly IPortRepository _portRepository;
    private readonly IVoyageRepository _voyageRepository;
    private readonly IPortCallRepository _portCallRepository;
    private readonly IBunkerOrderRepository _bunkerOrderRepository;

    public CreateBunkerOrderHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _vesselRepository = _unitOfWork.Vessels;
        _portRepository = _unitOfWork.Ports;
        _voyageRepository = _unitOfWork.Voyages;
        _portCallRepository = _unitOfWork.PortCalls;
        _bunkerOrderRepository = _unitOfWork.BunkerOrders;
    }

    public override async Task<CommandApiResponse> Handle(CreateBunkerOrderCommand command, CancellationToken ct)
    {
        try
        {
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

            // Check if OrderNumber already exists
            var existingOrder = await _bunkerOrderRepository.GetAllAsync(ct);
            if (existingOrder.Any(bo => bo.OrderNumber == command.BunkerOrder.OrderNumber))
            {
                return CommandApiResponse.CreateValidationFailed($"Order number '{command.BunkerOrder.OrderNumber}' already exists");
            }

            var bunkerOrder = new Domain.Models.BunkerOrder
            {
                VesselId = command.BunkerOrder.VesselId,
                PortId = command.BunkerOrder.PortId,
                VoyageId = command.BunkerOrder.VoyageId,
                PortCallId = command.BunkerOrder.PortCallId,
                OrderNumber = command.BunkerOrder.OrderNumber,
                Status = command.BunkerOrder.Status,
                FuelType = command.BunkerOrder.FuelType,
                QuantityMT = command.BunkerOrder.QuantityMT,
                UnitPriceUSDPerMT = command.BunkerOrder.UnitPriceUSDPerMT,
                TotalPriceUSD = command.BunkerOrder.TotalPriceUSD,
                Currency = command.BunkerOrder.Currency,
                ExchangeRate = command.BunkerOrder.ExchangeRate,
                LocalPrice = command.BunkerOrder.LocalPrice,
                LocalCurrency = command.BunkerOrder.LocalCurrency,
                SupplierName = command.BunkerOrder.SupplierName,
                SupplierContactPerson = command.BunkerOrder.SupplierContactPerson,
                SupplierPhone = command.BunkerOrder.SupplierPhone,
                SupplierEmail = command.BunkerOrder.SupplierEmail,
                SupplierAddress = command.BunkerOrder.SupplierAddress,
                SupplierLicenseNumber = command.BunkerOrder.SupplierLicenseNumber,
                RequestedDate = command.BunkerOrder.RequestedDate,
                ApprovedDate = command.BunkerOrder.ApprovedDate,
                ScheduledDeliveryDate = command.BunkerOrder.ScheduledDeliveryDate,
                ActualDeliveryDate = command.BunkerOrder.ActualDeliveryDate,
                DeliveryStartTime = command.BunkerOrder.DeliveryStartTime,
                DeliveryEndTime = command.BunkerOrder.DeliveryEndTime,
                DeliveryDurationHours = command.BunkerOrder.DeliveryDurationHours,
                DeliveryMethod = command.BunkerOrder.DeliveryMethod,
                BargeName = command.BunkerOrder.BargeName,
                BargeCapacityMT = command.BunkerOrder.BargeCapacityMT,
                BargeIMO = command.BunkerOrder.BargeIMO,
                TruckCount = command.BunkerOrder.TruckCount,
                TruckLicensePlates = command.BunkerOrder.TruckLicensePlates,
                PipelineDelivery = command.BunkerOrder.PipelineDelivery,
                PipelineLengthMeters = command.BunkerOrder.PipelineLengthMeters,
                DeliveryLocation = command.BunkerOrder.DeliveryLocation,
                BerthNumber = command.BunkerOrder.BerthNumber,
                TerminalName = command.BunkerOrder.TerminalName,
                AnchorageArea = command.BunkerOrder.AnchorageArea,
                QualitySpecifications = command.BunkerOrder.QualitySpecifications,
                DensityAt15C = command.BunkerOrder.DensityAt15C,
                ViscosityAt50C = command.BunkerOrder.ViscosityAt50C,
                SulfurContentPercent = command.BunkerOrder.SulfurContentPercent,
                FlashPointCelsius = command.BunkerOrder.FlashPointCelsius,
                PourPointCelsius = command.BunkerOrder.PourPointCelsius,
                WaterContentPercent = command.BunkerOrder.WaterContentPercent,
                SedimentContentPercent = command.BunkerOrder.SedimentContentPercent,
                AshContentPercent = command.BunkerOrder.AshContentPercent,
                CarbonResiduePercent = command.BunkerOrder.CarbonResiduePercent,
                VanadiumContentPPM = command.BunkerOrder.VanadiumContentPPM,
                AluminumContentPPM = command.BunkerOrder.AluminumContentPPM,
                SiliconContentPPM = command.BunkerOrder.SiliconContentPPM,
                CertificateNumber = command.BunkerOrder.CertificateNumber,
                CertificateDate = command.BunkerOrder.CertificateDate,
                CertificateIssuedBy = command.BunkerOrder.CertificateIssuedBy,
                CertificateValidUntil = command.BunkerOrder.CertificateValidUntil,
                SampleTaken = command.BunkerOrder.SampleTaken,
                SampleDate = command.BunkerOrder.SampleDate,
                SampleLocation = command.BunkerOrder.SampleLocation,
                SampleSealedBy = command.BunkerOrder.SampleSealedBy,
                SampleReceivedBy = command.BunkerOrder.SampleReceivedBy,
                SampleStorageLocation = command.BunkerOrder.SampleStorageLocation,
                PaymentTerms = command.BunkerOrder.PaymentTerms,
                PaymentMethod = command.BunkerOrder.PaymentMethod,
                PaymentDueDate = command.BunkerOrder.PaymentDueDate,
                PaymentStatus = command.BunkerOrder.PaymentStatus,
                PaymentDate = command.BunkerOrder.PaymentDate,
                InvoiceNumber = command.BunkerOrder.InvoiceNumber,
                InvoiceDate = command.BunkerOrder.InvoiceDate,
                InvoiceAmountUSD = command.BunkerOrder.InvoiceAmountUSD,
                TaxAmountUSD = command.BunkerOrder.TaxAmountUSD,
                DiscountAmountUSD = command.BunkerOrder.DiscountAmountUSD,
                FinalAmountUSD = command.BunkerOrder.FinalAmountUSD,
                DeliveryConfirmation = command.BunkerOrder.DeliveryConfirmation,
                QualityAcceptance = command.BunkerOrder.QualityAcceptance,
                QualityIssues = command.BunkerOrder.QualityIssues,
                DisputeStatus = command.BunkerOrder.DisputeStatus,
                DisputeDescription = command.BunkerOrder.DisputeDescription,
                DisputeResolution = command.BunkerOrder.DisputeResolution,
                DisputeResolutionDate = command.BunkerOrder.DisputeResolutionDate,
                RefundAmountUSD = command.BunkerOrder.RefundAmountUSD,
                RefundDate = command.BunkerOrder.RefundDate,
                EnvironmentalCompliance = command.BunkerOrder.EnvironmentalCompliance,
                IMO2020Compliant = command.BunkerOrder.IMO2020Compliant,
                LowSulfurFuel = command.BunkerOrder.LowSulfurFuel,
                BioFuelBlend = command.BunkerOrder.BioFuelBlend,
                BioFuelPercentage = command.BunkerOrder.BioFuelPercentage,
                CarbonFootprintMTCO2 = command.BunkerOrder.CarbonFootprintMTCO2,
                SustainabilityCertificate = command.BunkerOrder.SustainabilityCertificate,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = command.BunkerOrder.CreatedBy,
                Notes = command.BunkerOrder.Notes
            };

            await _bunkerOrderRepository.AddAsync(bunkerOrder, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return CommandApiResponse.Success(bunkerOrder.Id);
        }
        catch (Exception ex)
        {
            return CommandApiResponse.CreateServerError($"An error occurred while creating the bunker order: {ex.Message}");
        }
    }
}

public class CreateBunkerOrderCommand : ICommand
{
    public CreateBunkerOrderDto BunkerOrder { get; set; } = new();
}
