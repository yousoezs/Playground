using ASPNET.User.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ASPNET.User.DataAccess.Context
{
    public class UserContext : DbContext
    {
        public DbSet<UserModel> Users { get; set;}
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }   
    }
}
