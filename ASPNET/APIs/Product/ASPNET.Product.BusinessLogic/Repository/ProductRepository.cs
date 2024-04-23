using ASPNET.Domain.Commons.Record;
using ASPNET.Product.DataAccess.Context;
using ASPNET.Product.DataAccess.Model;
using ASPNET.Service.Database.Abstraction;

namespace ASPNET.Product.BusinessLogic.Repository
{
    public class ProductRepository : GenericRepository<ProductModel, Guid>
    {
        private readonly ProductContext _dbContext;
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public sealed override async ValueTask<ServiceResponse<ProductModel>> AddEntity(ProductModel entity)
        {
            if(entity is null)
                return await Task.FromResult(new ServiceResponse<ProductModel>(null, false, "Entity is null"));

            await _dbContext.Products.AddAsync(entity);

            return await Task.FromResult(new ServiceResponse<ProductModel>(entity, true, "Entity added"));
        }

        public sealed override async ValueTask<ServiceResponse<ProductModel>> DeleteEntity(Guid id)
        {
            var entity = await _dbContext.Products.FindAsync(id);
            if(entity is null)
                return await Task.FromResult(new ServiceResponse<ProductModel>(null, false, "Id is empty"));

            _dbContext.Products.Remove(entity);
            return await Task.FromResult(new ServiceResponse<ProductModel>(entity, true, "Entity removed"));
        }

        public sealed override async ValueTask<ServiceResponse<IEnumerable<ProductModel>>> GetAllEntities()
        {
            return await Task.FromResult(new ServiceResponse<IEnumerable<ProductModel>>(_dbContext.Products, true, "Entities returned"));
        }

        public sealed override async ValueTask<ServiceResponse<ProductModel>> GetEntity(Guid id)
        {
            var entityToReturn = await _dbContext.Products.FindAsync(id);
            if(entityToReturn is null)
                return await Task.FromResult(new ServiceResponse<ProductModel>(null, false, "Id is empty"));

            return await Task.FromResult(new ServiceResponse<ProductModel>(entityToReturn, true, "Entity returned"));
        }


        public sealed override async ValueTask<ServiceResponse<ProductModel>> UpdateEntity(ProductModel entity)
        {
            if(entity is null)
                return await Task.FromResult(new ServiceResponse<ProductModel>(null, false, "Entity is null"));

            _dbContext.Products.Update(await EntityToUpdate(entity));

            return await Task.FromResult(new ServiceResponse<ProductModel>(entity, true, "Entity updated"));
        }
        public sealed override async ValueTask SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        protected sealed override async ValueTask<ProductModel> EntityToUpdate(ProductModel entity)
        {
            var entityToUpdate = _dbContext.Products.Find(entity.Id);

            entityToUpdate.Id = entity.Id;
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Description = entity.Description;
            entityToUpdate.Price = entity.Price;

            return await Task.FromResult(entityToUpdate);
        }
    }
}
