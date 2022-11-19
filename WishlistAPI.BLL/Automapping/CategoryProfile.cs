using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.BLL.Dto;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Automapping
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
