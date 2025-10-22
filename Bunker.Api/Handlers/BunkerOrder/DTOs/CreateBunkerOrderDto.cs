using System.ComponentModel.DataAnnotations;
using Bunker.Domain.Models;

namespace Bunker.Api.Handlers.BunkerOrder.DTOs;

public class CreateBunkerOrderDto
{
    [Required]
    public int VesselId { get; set; }

    [Required]
    public int PortId { get; set; }

    public int? VoyageId { get; set; }

    public int? PortCallId { get; set; }

    [Required]
    [StringLength(20)]
    public string OrderNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(30)]
    public string Status { get; set; } = "Requested";

    [Required]
    [StringLength(50)]
    public string FuelType { get; set; } = string.Empty;

    [Required]
    public decimal QuantityMT { get; set; }

    public decimal? UnitPriceUSDPerMT { get; set; }

    public decimal? TotalPriceUSD { get; set; }

    public string? Currency { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? LocalPrice { get; set; }

    public string? LocalCurrency { get; set; }

    [Required]
    [StringLength(100)]
    public string SupplierName { get; set; } = string.Empty;

    [StringLength(100)]
    public string? SupplierContactPerson { get; set; }

    [StringLength(50)]
    public string? SupplierPhone { get; set; }

    [StringLength(100)]
    public string? SupplierEmail { get; set; }

    [StringLength(200)]
    public string? SupplierAddress { get; set; }

    [StringLength(50)]
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

    public bool PipelineDelivery { get; set; } = false;

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

    public bool SampleTaken { get; set; } = false;

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

    public bool DeliveryConfirmation { get; set; } = false;

    public bool QualityAcceptance { get; set; } = false;

    public string? QualityIssues { get; set; }

    public string? DisputeStatus { get; set; }

    public string? DisputeDescription { get; set; }

    public string? DisputeResolution { get; set; }

    public DateTime? DisputeResolutionDate { get; set; }

    public decimal? RefundAmountUSD { get; set; }

    public DateTime? RefundDate { get; set; }

    public string? EnvironmentalCompliance { get; set; }

    public bool IMO2020Compliant { get; set; } = true;

    public bool LowSulfurFuel { get; set; } = false;

    public bool BioFuelBlend { get; set; } = false;

    public decimal? BioFuelPercentage { get; set; }

    public decimal? CarbonFootprintMTCO2 { get; set; }

    public string? SustainabilityCertificate { get; set; }

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    public string? Notes { get; set; }
}