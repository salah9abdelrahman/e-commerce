using commerce.Core.IRepositories;
using commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace commerce.Repositories
{
    public class ProductStatusesRepository : Repository<ProductStatus>, IProductStatusesRepository
    {
        public ProductStatusesRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
        public ApplicationDbContext ApplicationDbContext { get => dbContext as ApplicationDbContext; }

    }
}