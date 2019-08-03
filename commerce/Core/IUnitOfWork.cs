using commerce.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //here we put the specific repositories interfaces to mock unit test
        // and complete (or save) function
        IProductRepository Products { get; }
        IProductStatusesRepository ProductStatuses { get; }
        IRolesRepository Roles { get; }
        ICategoriesRepository Categories { get; }
        IUserRepository Users { get; }
        ICouponRepository Coupons { get; }
        ITransactionRepository Transactions { get; }
        IOrderRepository Orders { get; }
        IOrderProductRepository OrderProducts { get; }
        int Save();

    }
}