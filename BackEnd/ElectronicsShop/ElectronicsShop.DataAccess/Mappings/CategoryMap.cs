using ElectronicsShop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.DataAccess.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {

        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {

        }
    }
}
