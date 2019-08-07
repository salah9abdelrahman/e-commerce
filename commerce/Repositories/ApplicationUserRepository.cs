using commerce.Core.IRepositories;
using commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace commerce.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUsersRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => dbContext as ApplicationDbContext;

        public IEnumerable<ApplicationUser> GetApplicationUsersWithRole()
        {
            return ApplicationDbContext.Users
                .Where(x => x.IsDeleted == false)
                .Include(x => x.Role)
                .ToList();
        }
    }
}