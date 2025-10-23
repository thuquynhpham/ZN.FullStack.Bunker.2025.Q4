using Microsoft.EntityFrameworkCore;
using Bunker.Domain.Models;
using Bunker.Domain.DBI;

namespace Bunker.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    IVesselRepository Vessels { get; }
    IPortRepository Ports { get; }
    IVoyageRepository Voyages { get; }
    IPortCallRepository PortCalls { get; }
    IBunkerOrderRepository BunkerOrders { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class UnitOfWork : IUnitOfWork
{
    private readonly BunkerDbContext _context;
    private bool _disposed = false;

    public UnitOfWork(BunkerDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    private IVesselRepository? _vessels;
    public IVesselRepository Vessels => _vessels ??= new VesselRepository(_context);

    private IPortRepository? _ports;
    public IPortRepository Ports => _ports ??= new PortRepository(_context);

    private IVoyageRepository? _voyages;
    public IVoyageRepository Voyages => _voyages ??= new VoyageRepository(_context);

    private IPortCallRepository? _portCalls;
    public IPortCallRepository PortCalls => _portCalls ??= new PortCallRepository(_context);

    private IBunkerOrderRepository? _bunkerOrders;
    public IBunkerOrderRepository BunkerOrders => _bunkerOrders ??= new BunkerOrderRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
            _disposed = true;
        }
    }
}
