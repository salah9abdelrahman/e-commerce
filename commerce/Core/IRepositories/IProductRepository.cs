using commerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using commerce.Core.Models;

namespace commerce.Core.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsWithStatusWithCategory();

    }
}