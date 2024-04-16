using ASPNET.Domain.Commons.Interface;
using ASPNET.Domain.Commons.Record;
using ASPNET.User.BusinessLogic.Repository;
using ASPNET.User.DataAccess.Context;
using ASPNET.User.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.User.Testing
{
    public class UserRepository_Test
    {
        private static UserRepository_Test _instance;
        private IGenericRepository<UserModel, Guid> _userRepository;
        private static async Task<UserContext> CreateShopContextWithInMemoryDbAsync()
        {
            var options = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: $"{Guid.NewGuid()}")
                .Options;

            var context = new UserContext(options);

            context.Users.AddRange(
                new UserModel() { Id = Guid.NewGuid(), Name = "Albin", Email = "mail@mailo.com", Phone = "123 123 12 12" },
                new UserModel() { Id = Guid.NewGuid(), Name = "Toni", Email = "mailis@mailos.com", Phone = "134 134 15 15" }
            );

            await context.SaveChangesAsync();

            _instance._userRepository = new UserRepository(context);

            return context;
        }

        [Fact]
        public async Task UserAPI_UserRepository_AddEntity_Test()
        {
            // Arrange
            UserContext dbContext = await CreateShopContextWithInMemoryDbAsync();
            var newUser = new UserModel() { Id = Guid.NewGuid(), Name = "Gegosh", Email = "Gegosh@gegosh.com", Phone = "070 070 05 05" };
            
            // Act
            ServiceResponse<UserModel> response = await _userRepository.AddEntity(newUser);
            
            // Assert
            if(response.IsSuccess)
            {
                Assert.Contains(newUser, dbContext.Users);
                Assert.True(response.IsSuccess);
            }
            else
            {
                Assert.False(response.IsSuccess);
                Assert.Fail(response.Message);
            }
        }
    }
}