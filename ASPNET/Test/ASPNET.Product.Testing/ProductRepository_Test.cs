using ASPNET.Domain.Commons.Interface;
using ASPNET.Product.BusinessLogic.Repository;
using ASPNET.Product.DataAccess.Context;
using ASPNET.Product.DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using FakeItEasy;

namespace ASPNET.Product.Testing
{
    public class ProductRepository_Test
    {
        private static ProductRepository_Test _instance = new();
        private IGenericRepository<ProductModel, Guid> _userRepository;
        private static async Task<ProductContext> CreateShopContextWithInMemoryDbAsync()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: $"{Guid.NewGuid()}")
                .Options;

            var context = new ProductContext(options);

            context.Products.AddRange(
                new ProductModel() { Id = Guid.NewGuid(), Name = "Korv", Description = "En Korv", Price = 12 },
                new ProductModel() { Id = Guid.NewGuid(), Name = "Bagel", Description = "En Bagel", Price = 24 }
            );

            await context.SaveChangesAsync();

            _instance._userRepository = new ProductRepository(context);

            return context;
        }

        [Fact]
        public async Task ProductRepository_AddEntity_Test()
        {
            // Arrange
            var context = await CreateShopContextWithInMemoryDbAsync();
            var product = A.Fake<ProductModel>();
            product.Name = "Test";
            product.Description = "Test";
            product.Price = 17;

            // Act
            var response = await _instance._userRepository.AddEntity(product);
            if(response.IsSuccess)
            {
                await context.SaveChangesAsync();
            }

            // Assert
            Assert.True(response.IsSuccess);
            Assert.Contains(context.Products, p => p.Name.Equals(product.Name));
        }
        [Fact]
        public async Task ProductRepository_DeleteEnttiy_Test()
        {
            // Arrange
            var context = await CreateShopContextWithInMemoryDbAsync();
            var product = context.Products.First();
            // Act
            var response = await _instance._userRepository.DeleteEntity(product.Id);
            if(response.IsSuccess)
            {
                await context.SaveChangesAsync();
            }

            // Assert
            Assert.True(!context.Products.Contains(product));
            Assert.Collection(context.Products, p => p.Equals(product));
        }
        [Fact]
        public async Task ProductRepository_UpdateEntity_Test()
        {
            // Arrange
            var context = await CreateShopContextWithInMemoryDbAsync();
            var product = context.Products.First();
            product.Name = "Test";
            product.Description = "Test";
            product.Price = 17;


            // Act
            var response = await _instance._userRepository.UpdateEntity(product);
            if(response.IsSuccess)
            {
                await context.SaveChangesAsync();
            }

            // Assert
            Assert.Same(context.Products.First(), product);
        }

        [Fact]
        public async Task ProductRepository_GetAllEntities_Test()
        {
            // Arrange
            var context = await CreateShopContextWithInMemoryDbAsync();

            // Act
            var response = await _instance._userRepository.GetAllEntities();

            // Assert
            Assert.Equal(context.Products, response.Data);
        }

        [Fact]
        public async Task ProductRepository_GetEntityById_Test()
        {
            // Arrange
            var context = await CreateShopContextWithInMemoryDbAsync();
            var product = context.Products.First();
            // Act
            var response = await _instance._userRepository.GetEntity(product.Id);

            // Assert
            Assert.Equal(product, response.Data);
            Assert.True(response.IsSuccess);
        }
    }
}
