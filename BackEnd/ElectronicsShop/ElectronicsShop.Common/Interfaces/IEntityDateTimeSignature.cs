using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Common.Interfaces
{
    public interface IEntityDateTimeSignature
    {
		DateTime CreationDate { get; set; }
		DateTime? ModificationDate { get; set; }
	}
}
