using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.Models
{
    public class CategoryViewModel: BaseViewModel
    {
        public CategoryViewModel()
        {

        }

        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
