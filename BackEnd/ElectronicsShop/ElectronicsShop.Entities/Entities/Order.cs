using ElectronicsShop.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Entities.Entities
{
    public class Order : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public long ProductId { get; set; }
        public virtual Product Product { get; set; }
        public long? UserId { get; set; }
        public virtual User User { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
