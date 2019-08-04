using commerce.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using commerce.Core.Models;

namespace commerce.Repositories
{
    public class ProductStatusesRepository : Repository<ProductStatus>, IProductStatusesRepository
    {
        public ProductStatusesRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
        public ApplicationDbContext ApplicationDbContext => dbContext as ApplicationDbContext;
    }
}