using ASPNET.Domain.Commons.Record;
using ASPNET.Product.DataAccess.Context;
using ASPNET.Product.DataAccess.Model;
using ASPNET.Service.Database.Abstraction;

namespace ASPNET.Product.BusinessLogic.Repository
{
    public class ProductRepository : GenericRepository<ProductModel, Guid>
    {
        public ProductRepository(ProductContext dbContext)
        {
        }

        public override ValueTask<ServiceResponse<ProductModel>> AddEntity(ProductModel entity)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<ServiceResponse<ProductModel>> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<ServiceResponse<IEnumerable<ProductModel>>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public override ValueTask<ServiceResponse<ProductModel>> GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public override ValueTask SaveAsync()
        {
            throw new NotImplementedException();
        }

        public override ValueTask<ServiceResponse<ProductModel>> UpdateEntity(ProductModel entity)
        {
            throw new NotImplementedException();
        }

        protected sealed override ValueTask<ProductModel> EntityToUpdate(ProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
