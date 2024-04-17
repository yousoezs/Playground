using ASPNET.Domain.Commons.Record;
using ASPNET.Product.DataAccess.Context;
using ASPNET.Product.DataAccess.Model;
using ASPNET.Service.Database.Abstraction;

namespace ASPNET.Product.BusinessLogic.Repository
{
    public class ProductRepository : GenericRepository<ProductContext, ProductModel, Guid>
    {
        public ProductRepository(ProductContext dbContext) : base(dbContext)
        {
        }

        public override Task<ServiceResponse<ProductModel>> AddEntity(ProductModel entity)
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceResponse<ProductModel>> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceResponse<IEnumerable<ProductModel>>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceResponse<ProductModel>> GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceResponse<ProductModel>> UpdateEntity(ProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
