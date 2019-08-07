using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using commerce.Core.Models;
using commerce.Repositories;

namespace commerce.Core.IRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersWithCouponWithUser();
        Order GetOneOrderWithCouponWithUser(int id);
    }
}
