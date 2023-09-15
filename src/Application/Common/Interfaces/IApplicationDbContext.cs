using House.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace House.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Apartment> Apartments { get; }
    DbSet<Owner> Owners { get; }
    DbSet<Contract> Contracts { get; }
    DbSet<Region> Regions { get; }
    DbSet<City> Cities { get; }
    DbSet<Neighborhood> Neighborhoods { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}
