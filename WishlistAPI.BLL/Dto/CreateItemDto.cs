using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Dto
{
    public class CreateItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public decimal Price { get; set; }

        public string CategoryId { get; set; }
        public string CurrencyId { get; set; }
    }
}
