using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Queries.GetAll
{
    public class GetAllBrandsQuery : IRequest<IEnumerable<Brand>>
    {
    }
    internal class BrandQueryHandler(ICatalogDbContext context) : IRequestHandler<GetAllBrandsQuery, IEnumerable<Brand>>
    {
        public async Task<IEnumerable<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await context.Brands.OrderBy(x => x.Id).ToListAsync(cancellationToken: cancellationToken);
            if (brands == null) throw new Exception("Brands Not Found!");
            return brands;
        }
    }
}
