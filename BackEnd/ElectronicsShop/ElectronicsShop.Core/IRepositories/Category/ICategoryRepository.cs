using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.IRepositories
{
    public interface ICategoryRepository : IBaseRepository<Category, long>
    {
    }
}
