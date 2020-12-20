using ElectronicsShop.Core.IRepositories;
using ElectronicsShop.DataAccess.Contexts;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository<Order, long>, IOrderRepository
    {
        public OrderRepository(ElectronicsShopContext electronicsShopContext)
            :base(electronicsShopContext)
        {

        }
    }
}
