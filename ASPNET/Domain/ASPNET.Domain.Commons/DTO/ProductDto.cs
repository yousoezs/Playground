using ASPNET.Domain.Commons.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.DTO
{
    public class ProductDto : IProduct
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = string.Empty;

        public string? Description { get; set;} = string.Empty;

        public decimal Price { get; set; } = decimal.Zero;

    }
}
