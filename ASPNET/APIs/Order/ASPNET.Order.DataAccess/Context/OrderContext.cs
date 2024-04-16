using ASPNET.Domain.Commons.Interface;
using ASPNET.Order.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Order.DataAccess.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
    }
}
