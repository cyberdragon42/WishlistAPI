using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.BLL.Dto;
using WishlistAPI.Domain.Models;
using WishlistAPI.BLL.Automapping.Resolvers;

namespace WishlistAPI.BLL.Automapping.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<CreateItemDto, Item>();
            CreateMap<Item, ShowItemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom<ItemCategoryNameResolver>())
                .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom<ItemCurrencyCodeResolver>());
        }
    }
}
