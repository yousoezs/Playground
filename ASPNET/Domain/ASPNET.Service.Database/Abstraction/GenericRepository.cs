using ASPNET.Domain.Commons.Interface;
using ASPNET.Domain.Commons.Record;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Service.Database.Abstraction
{
    public abstract class GenericRepository<TContext, TEntity, TId> :
        IGenericRepository<TEntity, TId> where TEntity :
        IEntity<TId> where TContext : DbContext
    {
        protected TContext dbContext;
        public GenericRepository(TContext dbContext) => this.dbContext = dbContext;
        public abstract Task<ServiceResponse<TEntity>> AddEntity(TEntity entity);
        public abstract Task<ServiceResponse<TEntity>> DeleteEntity(TId id);
        public abstract Task<ServiceResponse<IEnumerable<TEntity>>> GetAllEntities();
        public abstract Task<ServiceResponse<TEntity>> GetEntity(TId id);
        public abstract Task<ServiceResponse<TEntity>> UpdateEntity(TEntity entity);
    }
}
