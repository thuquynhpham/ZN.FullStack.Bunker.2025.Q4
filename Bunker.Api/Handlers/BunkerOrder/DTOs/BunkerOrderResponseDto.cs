using Bunker.Api.Handlers._Shared;

namespace Bunker.Api.Handlers.BunkerOrder.DTOs;

public class BunkerOrderResponseDto : QueryApiResponse<BunkerOrderResponseDto>
{
    public int Id { get; set; }
    public int VesselId { get; set; }
    public int PortId { get; set; }
    public int? VoyageId { get; set; }
    public int? PortCallId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string FuelType { get; set; } = string.Empty;
    public decimal QuantityMT { get; set; }
    public decimal? UnitPriceUSDPerMT { get; set; }
    public decimal? TotalPriceUSD { get; set; }
    public string? Currency { get; set; }
    public decimal? ExchangeRate { get; set; }
    public decimal? LocalPrice { get; set; }
    public string? LocalCurrency { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public string? SupplierContactPerson { get; set; }
    public string? SupplierPhone { get; set; }
    public string? SupplierEmail { get; set; }
    public string? SupplierAddress { get; set; }
    public string? SupplierLicenseNumber { get; set; }
    public DateTime? RequestedDate { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public DateTime? ScheduledDeliveryDate { get; set; }
    public DateTime? ActualDeliveryDate { get; set; }
    public DateTime? DeliveryStartTime { get; set; }
    public DateTime? DeliveryEndTime { get; set; }
    public decimal? DeliveryDurationHours { get; set; }
    public string? DeliveryMethod { get; set; }
    public string? BargeName { get; set; }
    public decimal? BargeCapacityMT { get; set; }
    public string? BargeIMO { get; set; }
    public int? TruckCount { get; set; }
    public string? TruckLicensePlates { get; set; }
    public bool PipelineDelivery { get; set; }
    public decimal? PipelineLengthMeters { get; set; }
    public string? DeliveryLocation { get; set; }
    public string? BerthNumber { get; set; }
    public string? TerminalName { get; set; }
    public string? AnchorageArea { get; set; }
    public string? QualitySpecifications { get; set; }
    public decimal? DensityAt15C { get; set; }
    public decimal? ViscosityAt50C { get; set; }
    public decimal? SulfurContentPercent { get; set; }
    public decimal? FlashPointCelsius { get; set; }
    public decimal? PourPointCelsius { get; set; }
    public decimal? WaterContentPercent { get; set; }
    public decimal? SedimentContentPercent { get; set; }
    public decimal? AshContentPercent { get; set; }
    public decimal? CarbonResiduePercent { get; set; }
    public decimal? VanadiumContentPPM { get; set; }
    public decimal? AluminumContentPPM { get; set; }
    public decimal? SiliconContentPPM { get; set; }
    public string? CertificateNumber { get; set; }
    public DateTime? CertificateDate { get; set; }
    public string? CertificateIssuedBy { get; set; }
    public DateTime? CertificateValidUntil { get; set; }
    public bool SampleTaken { get; set; }
    public DateTime? SampleDate { get; set; }
    public string? SampleLocation { get; set; }
    public string? SampleSealedBy { get; set; }
    public string? SampleReceivedBy { get; set; }
    public string? SampleStorageLocation { get; set; }
    public string? PaymentTerms { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime? PaymentDueDate { get; set; }
    public string? PaymentStatus { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? InvoiceNumber { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public decimal? InvoiceAmountUSD { get; set; }
    public decimal? TaxAmountUSD { get; set; }
    public decimal? DiscountAmountUSD { get; set; }
    public decimal? FinalAmountUSD { get; set; }
    public bool DeliveryConfirmation { get; set; }
    public bool QualityAcceptance { get; set; }
    public string? QualityIssues { get; set; }
    public string? DisputeStatus { get; set; }
    public string? DisputeDescription { get; set; }
    public string? DisputeResolution { get; set; }
    public DateTime? DisputeResolutionDate { get; set; }
    public decimal? RefundAmountUSD { get; set; }
    public DateTime? RefundDate { get; set; }
    public string? EnvironmentalCompliance { get; set; }
    public bool IMO2020Compliant { get; set; }
    public bool LowSulfurFuel { get; set; }
    public bool BioFuelBlend { get; set; }
    public decimal? BioFuelPercentage { get; set; }
    public decimal? CarbonFootprintMTCO2 { get; set; }
    public string? SustainabilityCertificate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public string? Notes { get; set; }

    // Navigation properties
    public string? VesselName { get; set; }
    public string? PortName { get; set; }
    public string? VoyageNumber { get; set; }
    public string? PortCallNumber { get; set; }

    public static BunkerOrderResponseDto Create(Domain.Models.BunkerOrder bunkerOrder)
    {
        return new BunkerOrderResponseDto
        {
            Id = bunkerOrder.Id,
            VesselId = bunkerOrder.VesselId,
            PortId = bunkerOrder.PortId,
            VoyageId = bunkerOrder.VoyageId,
            PortCallId = bunkerOrder.PortCallId,
            OrderNumber = bunkerOrder.OrderNumber,
            Status = bunkerOrder.Status,
            FuelType = bunkerOrder.FuelType,
            QuantityMT = bunkerOrder.QuantityMT,
            UnitPriceUSDPerMT = bunkerOrder.UnitPriceUSDPerMT,
            TotalPriceUSD = bunkerOrder.TotalPriceUSD,
            Currency = bunkerOrder.Currency,
            ExchangeRate = bunkerOrder.ExchangeRate,
            LocalPrice = bunkerOrder.LocalPrice,
            LocalCurrency = bunkerOrder.LocalCurrency,
            SupplierName = bunkerOrder.SupplierName,
            SupplierContactPerson = bunkerOrder.SupplierContactPerson,
            SupplierPhone = bunkerOrder.SupplierPhone,
            SupplierEmail = bunkerOrder.SupplierEmail,
            SupplierAddress = bunkerOrder.SupplierAddress,
            SupplierLicenseNumber = bunkerOrder.SupplierLicenseNumber,
            RequestedDate = bunkerOrder.RequestedDate,
            ApprovedDate = bunkerOrder.ApprovedDate,
            ScheduledDeliveryDate = bunkerOrder.ScheduledDeliveryDate,
            ActualDeliveryDate = bunkerOrder.ActualDeliveryDate,
            DeliveryStartTime = bunkerOrder.DeliveryStartTime,
            DeliveryEndTime = bunkerOrder.DeliveryEndTime,
            DeliveryDurationHours = bunkerOrder.DeliveryDurationHours,
            DeliveryMethod = bunkerOrder.DeliveryMethod,
            BargeName = bunkerOrder.BargeName,
            BargeCapacityMT = bunkerOrder.BargeCapacityMT,
            BargeIMO = bunkerOrder.BargeIMO,
            TruckCount = bunkerOrder.TruckCount,
            TruckLicensePlates = bunkerOrder.TruckLicensePlates,
            PipelineDelivery = bunkerOrder.PipelineDelivery,
            PipelineLengthMeters = bunkerOrder.PipelineLengthMeters,
            DeliveryLocation = bunkerOrder.DeliveryLocation,
            BerthNumber = bunkerOrder.BerthNumber,
            TerminalName = bunkerOrder.TerminalName,
            AnchorageArea = bunkerOrder.AnchorageArea,
            QualitySpecifications = bunkerOrder.QualitySpecifications,
            DensityAt15C = bunkerOrder.DensityAt15C,
            ViscosityAt50C = bunkerOrder.ViscosityAt50C,
            SulfurContentPercent = bunkerOrder.SulfurContentPercent,
            FlashPointCelsius = bunkerOrder.FlashPointCelsius,
            PourPointCelsius = bunkerOrder.PourPointCelsius,
            WaterContentPercent = bunkerOrder.WaterContentPercent,
            SedimentContentPercent = bunkerOrder.SedimentContentPercent,
            AshContentPercent = bunkerOrder.AshContentPercent,
            CarbonResiduePercent = bunkerOrder.CarbonResiduePercent,
            VanadiumContentPPM = bunkerOrder.VanadiumContentPPM,
            AluminumContentPPM = bunkerOrder.AluminumContentPPM,
            SiliconContentPPM = bunkerOrder.SiliconContentPPM,
            CertificateNumber = bunkerOrder.CertificateNumber,
            CertificateDate = bunkerOrder.CertificateDate,
            CertificateIssuedBy = bunkerOrder.CertificateIssuedBy,
            CertificateValidUntil = bunkerOrder.CertificateValidUntil,
            SampleTaken = bunkerOrder.SampleTaken,
            SampleDate = bunkerOrder.SampleDate,
            SampleLocation = bunkerOrder.SampleLocation,
            SampleSealedBy = bunkerOrder.SampleSealedBy,
            SampleReceivedBy = bunkerOrder.SampleReceivedBy,
            SampleStorageLocation = bunkerOrder.SampleStorageLocation,
            PaymentTerms = bunkerOrder.PaymentTerms,
            PaymentMethod = bunkerOrder.PaymentMethod,
            PaymentDueDate = bunkerOrder.PaymentDueDate,
            PaymentStatus = bunkerOrder.PaymentStatus,
            PaymentDate = bunkerOrder.PaymentDate,
            InvoiceNumber = bunkerOrder.InvoiceNumber,
            InvoiceDate = bunkerOrder.InvoiceDate,
            InvoiceAmountUSD = bunkerOrder.InvoiceAmountUSD,
            TaxAmountUSD = bunkerOrder.TaxAmountUSD,
            DiscountAmountUSD = bunkerOrder.DiscountAmountUSD,
            FinalAmountUSD = bunkerOrder.FinalAmountUSD,
            DeliveryConfirmation = bunkerOrder.DeliveryConfirmation,
            QualityAcceptance = bunkerOrder.QualityAcceptance,
            QualityIssues = bunkerOrder.QualityIssues,
            DisputeStatus = bunkerOrder.DisputeStatus,
            DisputeDescription = bunkerOrder.DisputeDescription,
            DisputeResolution = bunkerOrder.DisputeResolution,
            DisputeResolutionDate = bunkerOrder.DisputeResolutionDate,
            RefundAmountUSD = bunkerOrder.RefundAmountUSD,
            RefundDate = bunkerOrder.RefundDate,
            EnvironmentalCompliance = bunkerOrder.EnvironmentalCompliance,
            IMO2020Compliant = bunkerOrder.IMO2020Compliant,
            LowSulfurFuel = bunkerOrder.LowSulfurFuel,
            BioFuelBlend = bunkerOrder.BioFuelBlend,
            BioFuelPercentage = bunkerOrder.BioFuelPercentage,
            CarbonFootprintMTCO2 = bunkerOrder.CarbonFootprintMTCO2,
            SustainabilityCertificate = bunkerOrder.SustainabilityCertificate,
            CreatedAt = bunkerOrder.CreatedAt,
            UpdatedAt = bunkerOrder.UpdatedAt,
            CreatedBy = bunkerOrder.CreatedBy,
            UpdatedBy = bunkerOrder.UpdatedBy,
            Notes = bunkerOrder.Notes,
            VesselName = bunkerOrder.Vessel?.Name,
            PortName = bunkerOrder.Port?.Name,
            VoyageNumber = bunkerOrder.Voyage?.VoyageNumber,
            PortCallNumber = bunkerOrder.PortCall?.PortCallNumber
        };
    }
}