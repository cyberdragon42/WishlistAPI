using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishlistAPI.Domain.Models;

namespace WishlistAPI.BLL.Dto
{
    public class CreateCurrencyDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal DollarCoefficient { get; set; }
    }
}
