using commerce.Core.IRepositories;
using commerce.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace commerce.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext context)
        {
            _dbContext = context;
            Products = new ProductRepository(context);
            ProductStatuses = new ProductStatusesRepository(context);
            //use dbsets to initialize repositories
        }

        public IProductRepository Products { get; private set; }
        public IProductStatusesRepository ProductStatuses { get; private set; }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }


        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}