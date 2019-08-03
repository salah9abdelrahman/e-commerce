using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using commerce.Models;
using commerce.Repositories;

namespace commerce.Core.IRepositories
{
    public interface ICategoriesRepository : IRepository<Category>
    {
    }
}
