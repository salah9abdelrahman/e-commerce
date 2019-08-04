using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using commerce.Core.IRepositories;
using commerce.Core.Models;

namespace commerce.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => dbContext as ApplicationDbContext;
    }
}