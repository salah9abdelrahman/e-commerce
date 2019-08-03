using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using commerce.Core.IRepositories;
using commerce.Models;

namespace commerce.Repositories
{
    public class RoleRepository : Repository<Role>, IRolesRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => dbContext as ApplicationDbContext;


    }
}