using ElectronicsShop.Core.IRepositories;
using ElectronicsShop.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ElectronicsShopContext _context;

        public UnitOfWork(ElectronicsShopContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }
    }
}
