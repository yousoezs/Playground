using ASPNET.Domain.Commons.Interface;
using Microsoft.EntityFrameworkCore;


namespace ASPNET.Order.DataAccess.Model
{
    public class OrderModel : IOrder
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
        [Precision(38, 2)]
        public decimal TotalPrice { get; set; }

    }
}
