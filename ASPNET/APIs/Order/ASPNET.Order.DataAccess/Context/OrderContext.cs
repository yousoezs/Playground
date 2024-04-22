using ASPNET.Domain.Commons.Interface;
using ASPNET.Order.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ASPNET.Order.DataAccess.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
