using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.Models
{
    public class OrderViewModel : BaseViewModel
    {
        public OrderViewModel()
        {

        }

        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public long ProductId { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public long? UserId { get; set; }
        public virtual UserViewModel User { get; set; }
        public int NumberOfItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
