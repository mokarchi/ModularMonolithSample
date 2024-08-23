using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Abstractions;

public interface ICatalogDbContext
{
    public DbSet<Brand> Brands { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}