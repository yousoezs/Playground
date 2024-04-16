using ASPNET.Domain.Commons.Interface;
using ASPNET.User.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
