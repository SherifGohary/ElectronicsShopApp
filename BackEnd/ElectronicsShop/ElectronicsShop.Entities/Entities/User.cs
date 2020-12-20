using ElectronicsShop.Common.Enums;
using ElectronicsShop.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Entities.Entities
{
    public class User : IEntityIdentity<long>, IEntityDateTimeSignature
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public RoleEnum Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
