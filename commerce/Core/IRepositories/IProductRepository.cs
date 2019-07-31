using commerce.Models;
using commerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Core.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetTopSalesProducts(int count);
    }
}