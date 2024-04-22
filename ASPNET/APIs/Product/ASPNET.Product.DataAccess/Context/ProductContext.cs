using ASPNET.Domain.Commons.Interface;
using ASPNET.Product.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Product.DataAccess.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
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
