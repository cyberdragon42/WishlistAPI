using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistAPI.Domain.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public string CategoryId { get; set; }

        /// <summary>
        /// Base currency of item's price
        /// </summary>
        public Currency Currency { get; set; }
        public string CurrencyId { get; set; }
    }
}
