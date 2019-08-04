using commerce.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using commerce.Core.Models;

namespace commerce.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public ApplicationDbContext ApplicationDbContext => dbContext as ApplicationDbContext;

        public IEnumerable<Product> GetProductsWithStatusWithCategory()
        {
            return ApplicationDbContext.Products
                .Where(x => x.IsDeleted == false)
                .Include(x => x.ProductStatus)
                .Include(c => c.Category)
                .ToList();
        }
    }
}