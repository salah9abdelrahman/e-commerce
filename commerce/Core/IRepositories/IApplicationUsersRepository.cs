using commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace commerce.Core.IRepositories
{
    public interface IApplicationUsersRepository : IRepository<ApplicationUser>
    {
        IEnumerable<ApplicationUser> GetApplicationUsersWithRole();
    }
}