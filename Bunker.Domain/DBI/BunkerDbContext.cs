using Bunker.Domain.Models;
using Bunker.Domain.DBI.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Bunker.Domain.DBI;

public class BunkerDbContext(DbContextOptions<BunkerDbContext> options) : DbContext(options)
{
    public DbSet<Vessel> Vessels { get; set; }
    public DbSet<Port> Ports { get; set; }
    public DbSet<Voyage> Voyages { get; set; }
    public DbSet<PortCall> PortCalls { get; set; }
    public DbSet<BunkerOrder> BunkerOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureRelationships(modelBuilder);
        SeedData(modelBuilder);
    }

    private void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        // Configure Voyage relationships
        modelBuilder.Entity<Voyage>(entity =>
        {
            // Vessel relationship
            entity.HasOne(e => e.Vessel)
                .WithMany(v => v.Voyages)
                .HasForeignKey(e => e.VesselId)
                .OnDelete(DeleteBehavior.Restrict);

            // Departure Port relationship
            entity.HasOne(e => e.DeparturePort)
                .WithMany(p => p.DepartureVoyages)
                .HasForeignKey(e => e.DeparturePortId)
                .OnDelete(DeleteBehavior.Restrict);

            // Arrival Port relationship
            entity.HasOne(e => e.ArrivalPort)
                .WithMany(p => p.ArrivalVoyages)
                .HasForeignKey(e => e.ArrivalPortId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure PortCall relationships
        modelBuilder.Entity<PortCall>(entity =>
        {
            entity.HasOne(e => e.Vessel)
                .WithMany(v => v.PortCalls)
                .HasForeignKey(e => e.VesselId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Port)
                .WithMany(p => p.PortCalls)
                .HasForeignKey(e => e.PortId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Voyage)
                .WithMany(v => v.PortCalls)
                .HasForeignKey(e => e.VoyageId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Configure BunkerOrder relationships
        modelBuilder.Entity<BunkerOrder>(entity =>
        {
            entity.HasOne(e => e.Vessel)
                .WithMany(v => v.BunkerOrders)
                .HasForeignKey(e => e.VesselId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Port)
                .WithMany(p => p.BunkerOrders)
                .HasForeignKey(e => e.PortId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Voyage)
                .WithMany(v => v.BunkerOrders)
                .HasForeignKey(e => e.VoyageId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.PortCall)
                .WithMany(pc => pc.BunkerOrders)
                .HasForeignKey(e => e.PortCallId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vessel>(e => e.HasData(VesselDataInitializer.Data));
        modelBuilder.Entity<Port>(e => e.HasData(PortDataInitializer.Data));
        modelBuilder.Entity<Voyage>(e => e.HasData(VoyageDataInitializer.Data));
        modelBuilder.Entity<PortCall>(e => e.HasData(PortCallDataInitializer.Data));
        modelBuilder.Entity<BunkerOrder>(e => e.HasData(BunkerOrderDataInitializer.Data));
    }
}


