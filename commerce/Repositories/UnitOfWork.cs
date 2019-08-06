using commerce.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using commerce.Core;
using commerce.Core.Models;

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
            Roles = new RoleRepository(context);
            Categories = new CategoriesRepository(context);
            Coupons = new CouponRepository(context);
            Transactions = new TransactionRepository(context);
            Orders = new OrderRepository(context);
            OrderProducts = new OrderProductRepository(context);
        }

        public IProductRepository Products { get; private set; }
        public IProductStatusesRepository ProductStatuses { get; private set; }
        public IRolesRepository Roles { get; private set; }
        public ICategoriesRepository Categories { get; private set; }
        public ICouponRepository Coupons { get; private set; }
        public ITransactionRepository Transactions { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderProductRepository OrderProducts { get; private set; }


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