using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Commands.Register;

public class RegisterBrandCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Detail { get; set; }
}
internal class BrandCommandHandler(ICatalogDbContext context) : IRequestHandler<RegisterBrandCommand, int>
{
    public async Task<int> Handle(RegisterBrandCommand command, CancellationToken cancellationToken)
    {
        if (await context.Brands.AnyAsync(c => c.Name == command.Name, cancellationToken))
        {
            throw new Exception("Brand with the same name already exists.");
        }
        var brand = new Brand { Detail = command.Detail, Name = command.Name };
        await context.Brands.AddAsync(brand, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return brand.Id;
    }
}