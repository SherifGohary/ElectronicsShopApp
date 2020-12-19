using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.IRepositories
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
