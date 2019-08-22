using commerce.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Core
{
    public interface IUnitOfWork : IDisposable
    {

        IProductRepository Products { get; }
        IProductStatusesRepository ProductStatuses { get; }
        IRolesRepository Roles { get; }
        ICategoriesRepository Categories { get; }
        ICouponRepository Coupons { get; }
        ITransactionRepository Transactions { get; }
        IOrderRepository Orders { get; }
        IOrderProductRepository OrderProducts { get; }
        IApplicationUsersRepository ApplicationUsers { get; }
        int Save();

    }
}