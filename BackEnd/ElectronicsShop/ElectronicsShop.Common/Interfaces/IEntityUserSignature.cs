using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Common.Interfaces
{
    public interface IEntityUserSignature
    {
		long? CreatedByUserId { get; set; }
		long? ModifiedByUserId { get; set; }
	}
}
