using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.BLL.Dto;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Automapping.Resolvers
{
    public class ItemCategoryNameResolver : IValueResolver<Item, ShowItemDto, string>
    {
        public string Resolve(Item source, ShowItemDto destination, string destMember, ResolutionContext context)
        {
            return source.Category?.Name;
        }
    }
}
