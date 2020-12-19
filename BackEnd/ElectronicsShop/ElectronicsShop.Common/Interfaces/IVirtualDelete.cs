using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Common.Interfaces
{
    public interface IVirtualDelete
    {
        bool IsDeleted { get; set; }
        DateTime? LastDeletedDate { get; set; }
        DateTime? LastRestoredDate { get; set; }
    }
}
