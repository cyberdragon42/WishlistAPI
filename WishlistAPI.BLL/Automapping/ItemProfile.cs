using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.BLL.Dto;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Automapping
{
    public class ItemProfile: Profile
    {
        public ItemProfile()
        {
            CreateMap<CreateItemDto, Item>();
        }
    }
}
