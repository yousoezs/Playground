using ASPNET.Domain.Commons.Record;
using ASPNET.Service.Database.Abstraction;
using ASPNET.User.DataAccess.Context;
using ASPNET.User.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.User.BusinessLogic.Repository
{
    public class UserRepository : GenericRepository<UserModel, Guid>
    {
        private readonly UserContext _dbContext;
        public UserRepository(UserContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public sealed override async ValueTask<ServiceResponse<UserModel>> AddEntity(UserModel entity)
        {
            if(entity is null)
                return await Task.FromResult(new ServiceResponse<UserModel>(entity, false, "UserModel is null"));

            await _dbContext.Users.AddAsync(entity);

            return await Task.FromResult(new ServiceResponse<UserModel>(entity, true, "UserModel is added successfully"));
        }

        public sealed override async ValueTask<ServiceResponse<UserModel>> DeleteEntity(Guid id)
        {
           if(id.Equals(Guid.Empty))
                return await Task.FromResult(new ServiceResponse<UserModel>(null, false, "Id is empty"));

            UserModel entity = await _dbContext.Users.FindAsync(id);

            if(entity is null)
                return await Task.FromResult( new ServiceResponse<UserModel>(null, false, "UserModel is not found"));

            _dbContext.Users.Remove(entity);

            return await Task.FromResult(new ServiceResponse<UserModel>(entity, true, "UserModel is deleted successfully"));
        }

        public sealed override async ValueTask<ServiceResponse<IEnumerable<UserModel>>> GetAllEntities()
        {
            return await Task.FromResult(new ServiceResponse<IEnumerable<UserModel>>(await _dbContext.Users.ToListAsync(), true, "UserModels are fetched successfully"));
        }

        public sealed override async ValueTask<ServiceResponse<UserModel>> GetEntity(Guid id)
        {
            return await _dbContext.Users.FindAsync(id) is UserModel entity
                ? await Task.FromResult(new ServiceResponse<UserModel>(entity, true, "UserModel is fetched successfully"))
                : await Task.FromResult(new ServiceResponse<UserModel>(null, false, "UserModel is not found"));
        }

        public sealed override async ValueTask<ServiceResponse<UserModel>> UpdateEntity(UserModel entity)
        {
            if(entity is null)
                return await Task.FromResult(new ServiceResponse<UserModel>(entity, false, "UserModel is null"));

            _dbContext.Users.Update(await EntityToUpdate(entity));

            return await Task.FromResult(new ServiceResponse<UserModel>(entity, true, "UserModel is updated successfully"));
        }

        protected sealed override async ValueTask<UserModel> EntityToUpdate(UserModel entity)
        {
            var entityToUpdate = await _dbContext.Users.FindAsync(entity.Id);

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.Phone = entity.Phone;

            return await Task.FromResult(entityToUpdate);
        }
        public sealed override async ValueTask SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
