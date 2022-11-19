using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishlistAPI.Domain.Models
{
    public class Currency
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal DollarCoefficient { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
