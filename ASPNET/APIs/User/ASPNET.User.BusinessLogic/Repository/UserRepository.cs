using ASPNET.Domain.Commons.Record;
using ASPNET.Service.Database.Abstraction;
using ASPNET.User.DataAccess.Context;
using ASPNET.User.DataAccess.Model;

namespace ASPNET.User.BusinessLogic.Repository
{
    public class UserRepository : GenericRepository<UserContext, UserModel, Guid>
    {
        
        public UserRepository(UserContext dbContext) : base(dbContext)
        {
            
        }

        public override async Task<ServiceResponse<UserModel>> AddEntity(UserModel entity)
        {
            await Task.Delay(100);
            if(entity is null)
                return new ServiceResponse<UserModel>(entity, false, "UserModel is null");

            return new ServiceResponse<UserModel>(entity, true, "UserModel is added successfully");
        }

        public override Task<ServiceResponse<UserModel>> DeleteEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceResponse<IEnumerable<UserModel>>> GetAllEntities()
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceResponse<UserModel>> GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceResponse<UserModel>> UpdateEntity(UserModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
