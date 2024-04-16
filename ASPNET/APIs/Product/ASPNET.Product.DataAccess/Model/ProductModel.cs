using ASPNET.Domain.Commons.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Product.DataAccess.Model
{
    public class ProductModel : IProduct
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        [Precision(38, 2)]
        public decimal Price { get; set; } = decimal.Zero;
    }
}
