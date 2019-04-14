using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogApi.Domain.Entities;

namespace ProductCatalogApi.Domain.Repository
{
    public interface ICatalogRepository
    {
        Task<IReadOnlyList<CatalogType>> GetCatalogTypes();
        Task<IReadOnlyList<CatalogBrand>> GetCatalogBrands();
        Task<IReadOnlyList<CatalogItem>> GetCatalogItems();
    }
}
