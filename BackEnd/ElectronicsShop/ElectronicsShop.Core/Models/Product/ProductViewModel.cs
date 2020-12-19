using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.Models
{
    public class ProductViewModel: BaseViewModel
    {
        public ProductViewModel()
        {

        }

        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public long? CreatedByUserId { get; set; }
        public long? ModifiedByUserId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int TwoPiecesDiscount { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
