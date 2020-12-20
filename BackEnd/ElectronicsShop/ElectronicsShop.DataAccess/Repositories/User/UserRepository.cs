using ElectronicsShop.Core.IRepositories;
using ElectronicsShop.DataAccess.Contexts;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User, long>, IUserRepository
    {
        public UserRepository(ElectronicsShopContext electronicsShopContext)
            :base(electronicsShopContext)
        {

        }
    }
}
