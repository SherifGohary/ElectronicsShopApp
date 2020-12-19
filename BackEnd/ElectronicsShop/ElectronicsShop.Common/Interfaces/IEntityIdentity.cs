using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Common.Interfaces
{
    public interface IEntityIdentity<TEntityIdentity>
    {
        TEntityIdentity Id { get; set; }
    }
}
