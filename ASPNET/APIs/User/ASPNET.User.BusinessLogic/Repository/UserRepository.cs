using ASPNET.Domain.Commons.Abstraction;
using ASPNET.Domain.Commons.Interface;
using ASPNET.Domain.Commons.Record;
using ASPNET.User.DataAccess.Context;
using ASPNET.User.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.User.BusinessLogic.Repository
{
    public class UserRepository : GenericRepository<UserContext, UserModel, Guid>
    {
        
        public UserRepository(UserContext dbContext) : base(dbContext)
        {
            
        }

        public override Task<ServiceResponse<UserModel>> AddEntity(UserModel entity)
        {
            throw new NotImplementedException();
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
