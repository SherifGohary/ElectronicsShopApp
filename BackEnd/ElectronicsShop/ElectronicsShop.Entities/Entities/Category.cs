using ElectronicsShop.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Entities.Entities
{
    public class Category : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
