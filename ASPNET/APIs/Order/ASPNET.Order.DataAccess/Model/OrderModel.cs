using ASPNET.Domain.Commons.DTO;
using ASPNET.Domain.Commons.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Order.DataAccess.Model
{
    public class OrderModel : IOrder
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public UserDto? UserId { get; set; }

        public ProductDto? ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
