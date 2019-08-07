using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using commerce.Core.IRepositories;
using commerce.Core.Models;

namespace commerce.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => dbContext as ApplicationDbContext;

        public Order GetOneOrderWithCouponWithUser(int id)
        {
            return ApplicationDbContext.Orders
                .Include(x => x.Coupon)
                .Include(x => x.User)
                .SingleOrDefault(x => x.OrderId == id);
        }

        public IEnumerable<Order> GetOrdersWithCouponWithUser()
        {
            return ApplicationDbContext.Orders
                .Where(x => x.IsDeleted == false)
                .Include(o => o.Coupon)
                .Include(o => o.User)
                .ToList();
        }
        // db.Orders.Include(o => o.Coupon).Include(o => o.User);
    }
}