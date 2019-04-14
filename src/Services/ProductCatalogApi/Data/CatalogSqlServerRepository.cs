using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Domain.Entities;
using ProductCatalogApi.Domain.Repository;

namespace ProductCatalogApi.Data
{
    public class CatalogSqlServerRepository : ICatalogRepository
    {
        private readonly CatalogDbContext _context;
        public CatalogSqlServerRepository(CatalogDbContext context)
        {
            _context = context;
            //This a readonly catalog db
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<IReadOnlyList<CatalogType>> GetCatalogTypes() => await _context.CatalogTypes.ToListAsync();
        public async Task<IReadOnlyList<CatalogBrand>> GetCatalogBrands() => await _context.CatalogBrands.ToListAsync();
        public async Task<IReadOnlyList<CatalogItem>> GetCatalogItems() => await _context.CatalogItems.ToListAsync();
    }
}
