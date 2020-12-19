using AutoMapper;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.AutoMapperProfiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
