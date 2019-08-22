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

        public IProductRepository Products
        {
            get
            {
                if (_Products == null)
                {
                    _Products = new ProductRepository(_dbContext);
                }
                return _Products;
            }
        }
        public IProductStatusesRepository ProductStatuses
        {
            get
            {
                if (_ProductStatuses == null)
                {
                    _ProductStatuses = new ProductStatusesRepository(_dbContext);
                }
                return _ProductStatuses;
            }
        }
        public IRolesRepository Roles
        {
            get
            {
                if (_Roles == null)
                {
                    _Roles = new RoleRepository(_dbContext);
                }
                return _Roles;
            }
        }
        public ICategoriesRepository Categories
        {
            get
            {
                if (_Categories == null)
                {
                    _Categories = new CategoriesRepository(_dbContext);
                }
                return _Categories;
            }
        }
        public ICouponRepository Coupons
        {
            get
            {
                if (_Coupons == null)
                {
                    _Coupons = new CouponRepository(_dbContext);
                }
                return _Coupons;
            }
        }
        public ITransactionRepository Transactions
        {
            get
            {
                if (_Transactions == null)
                {
                    _Transactions = new TransactionRepository(_dbContext);
                }
                return _Transactions;
            }
        }
        public IOrderRepository Orders
        {
            get
            {
                if (_Orders == null)
                {
                    _Orders = new OrderRepository(_dbContext);
                }
                return _Orders;
            }
        }
        public IOrderProductRepository OrderProducts
        {
            get
            {
                if (_OrderProducts == null)
                {
                    _OrderProducts = new OrderProductRepository(_dbContext);
                }
                return _OrderProducts;
            }
        }
        public IApplicationUsersRepository ApplicationUsers
        {
            get
            {
                if (_ApplicationUsers == null)
                {
                    _ApplicationUsers = new ApplicationUserRepository(_dbContext);
                }
                return _ApplicationUsers;
            }
        }

        private IProductRepository _Products;
        private IProductStatusesRepository _ProductStatuses;
        private IRolesRepository _Roles;
        private ICategoriesRepository _Categories;
        private ICouponRepository _Coupons;
        private ITransactionRepository _Transactions;
        private IOrderRepository _Orders;
        private IOrderProductRepository _OrderProducts;
        private IApplicationUsersRepository _ApplicationUsers;

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