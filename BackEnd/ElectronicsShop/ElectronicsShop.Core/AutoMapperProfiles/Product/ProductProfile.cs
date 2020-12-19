using AutoMapper;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.AutoMapperProfiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
