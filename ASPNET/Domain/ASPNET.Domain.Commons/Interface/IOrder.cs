using ASPNET.Domain.Commons.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.Interface
{
    public interface IOrder : IEntity<Guid>
    {
        public UserDto? UserId { get; }
        public ProductDto? ProductId { get; }
        public int Quantity { get; }
        public decimal TotalPrice { get; }
    }
}
