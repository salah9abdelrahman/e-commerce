using commerce.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        //here we put the specific repositories interfaces to mock unit test
        // and complete (or save) function
        IProductRepository Products { get; }
        IProductStatusesRepository ProductStatuses { get; }
        int Save();
    }
}