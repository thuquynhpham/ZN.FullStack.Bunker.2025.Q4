using Microsoft.EntityFrameworkCore;
using Bunker.Domain.Models;

namespace Bunker.Domain.DBI;

public class BunkerDbContext : DbContext
{
    public BunkerDbContext(DbContextOptions<BunkerDbContext> options) : base(options)
    {
    }

    public DbSet<Vessel> Vessels { get; set; }
    public DbSet<Port> Ports { get; set; }
    public DbSet<Voyage> Voyages { get; set; }
    public DbSet<PortCall> PortCalls { get; set; }
    public DbSet<BunkerOrder> BunkerOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureRelationships(modelBuilder);
    }

    private void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Voyage>(entity =>
        {
            entity.HasOne(e => e.Vessel)
                .WithMany(v => v.Voyages)
                .HasForeignKey(e => e.VesselId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.DeparturePort)
                .WithMany(p => p.Voyages)
                .HasForeignKey(e => e.DeparturePortId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ArrivalPort)
                .WithMany(p => p.Voyages)
                .HasForeignKey(e => e.ArrivalPortId)
                .OnDelete(DeleteBehavior.Restrict);
        });

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
}
