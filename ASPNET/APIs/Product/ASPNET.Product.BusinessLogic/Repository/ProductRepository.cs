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

        public sealed override ValueTask<ServiceResponse<IEnumerable<ProductModel>>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public sealed override ValueTask<ServiceResponse<ProductModel>> GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public sealed override ValueTask SaveAsync()
        {
            throw new NotImplementedException();
        }

        public sealed override async ValueTask<ServiceResponse<ProductModel>> UpdateEntity(ProductModel entity)
        {
            if(entity is null)
                return await Task.FromResult(new ServiceResponse<ProductModel>(null, false, "Entity is null"));

            return await Task.FromResult(new ServiceResponse<ProductModel>(entity, true, "Entity updated"));
        }

        protected sealed override ValueTask<ProductModel> EntityToUpdate(ProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
