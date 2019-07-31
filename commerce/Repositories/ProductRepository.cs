using commerce.Core.IRepositories;
using commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get => dbContext as ApplicationDbContext;
        }
        public IEnumerable<Product> GetTopSalesProducts(int count)
        {
            // throw new NotImplementedException();

            // not real implenenytation
            return ApplicationDbContext.Products.OrderBy(x => x.RegularPrice).Take(10);
        }
    }
}