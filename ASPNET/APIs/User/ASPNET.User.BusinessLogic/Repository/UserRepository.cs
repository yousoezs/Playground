using ASPNET.Domain.Commons.Record;
using ASPNET.Service.Database.Abstraction;
using ASPNET.User.DataAccess.Context;
using ASPNET.User.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.User.BusinessLogic.Repository
{
    public class UserRepository : GenericRepository<UserContext, UserModel, Guid>
    {
        public UserRepository(UserContext dbContext) : base(dbContext) {}

        public override async ValueTask<ServiceResponse<UserModel>> AddEntity(UserModel entity)
        {
            if(entity is null)
                return await Task.FromResult(new ServiceResponse<UserModel>(entity, false, "UserModel is null"));

            await dbContext.Users.AddAsync(entity);

            return await Task.FromResult(new ServiceResponse<UserModel>(entity, true, "UserModel is added successfully"));
        }

        public override async ValueTask<ServiceResponse<UserModel>> DeleteEntity(Guid id)
        {
           if(id.Equals(Guid.Empty))
                return new ServiceResponse<UserModel>(null, false, "Id is empty");

            UserModel entity = await dbContext.Users.FindAsync(id);

            if(entity is null)
                return await Task.FromResult( new ServiceResponse<UserModel>(null, false, "UserModel is not found"));

            dbContext.Users.Remove(entity);

            return new ServiceResponse<UserModel>(entity, true, "UserModel is deleted successfully");
        }

        public override async ValueTask<ServiceResponse<IEnumerable<UserModel>>> GetAllEntities()
        {
            return new ServiceResponse<IEnumerable<UserModel>>(await dbContext.Users.ToListAsync(), true, "UserModels are fetched successfully");
        }

        public override async ValueTask<ServiceResponse<UserModel>> GetEntity(Guid id)
        {
            return await dbContext.Users.FindAsync(id) is UserModel entity
                ? new ServiceResponse<UserModel>(entity, true, "UserModel is fetched successfully")
                : new ServiceResponse<UserModel>(null, false, "UserModel is not found");
        }

        public override async ValueTask<ServiceResponse<UserModel>> UpdateEntity(UserModel entity)
        {
            if(entity is null)
                return await Task.FromResult(new ServiceResponse<UserModel>(entity, false, "UserModel is null"));

            return new ServiceResponse<UserModel>(await EntityToUpdate(entity), true, "UserModel is updated successfully");
        }

        protected sealed override async ValueTask<UserModel> EntityToUpdate(UserModel entity)
        {
            var entityToUpdate = await dbContext.Users.FindAsync(entity.Id);

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.Phone = entity.Phone;

            return await Task.FromResult(entityToUpdate);
        }
    }
}
