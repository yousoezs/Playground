using ASPNET.Domain.Commons.Record;
using ASPNET.Service.Database.Abstraction;
using ASPNET.User.DataAccess.Context;
using ASPNET.User.DataAccess.Model;

namespace ASPNET.User.BusinessLogic.Repository
{
    public class UserRepository : GenericRepository<UserContext, UserModel, Guid>
    {
        
        public UserRepository(UserContext dbContext) : base(dbContext) {}

        public override async Task<ServiceResponse<UserModel>> AddEntity(UserModel entity)
        {
            if(entity is null)
                return new ServiceResponse<UserModel>(entity, false, "UserModel is null");

            dbContext.Users.Add(entity);

            return new ServiceResponse<UserModel>(entity, true, "UserModel is added successfully");
        }

        public override async Task<ServiceResponse<UserModel>> DeleteEntity(Guid id)
        {
           if(id.Equals(Guid.Empty))
                return new ServiceResponse<UserModel>(null, false, "Id is empty");

            UserModel entity = await dbContext.Users.FindAsync(id);

            if(entity is null)
                return new ServiceResponse<UserModel>(null, false, "UserModel is not found");

            dbContext.Users.Remove(entity);

            return new ServiceResponse<UserModel>(entity, true, "UserModel is deleted successfully");
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
