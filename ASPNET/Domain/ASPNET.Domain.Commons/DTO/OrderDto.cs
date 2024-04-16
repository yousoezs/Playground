using ASPNET.Domain.Commons.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.DTO
{
    public class OrderDto : IOrder
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
