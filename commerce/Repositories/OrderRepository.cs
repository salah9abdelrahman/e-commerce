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
    }
}