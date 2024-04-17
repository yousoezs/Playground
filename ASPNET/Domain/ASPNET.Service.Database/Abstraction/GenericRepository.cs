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
        public abstract ValueTask<ServiceResponse<TEntity>> AddEntity(TEntity entity);
        public abstract ValueTask<ServiceResponse<TEntity>> DeleteEntity(TId id);
        public abstract ValueTask<ServiceResponse<IEnumerable<TEntity>>> GetAllEntities();
        public abstract ValueTask<ServiceResponse<TEntity>> GetEntity(TId id);
        public abstract ValueTask<ServiceResponse<TEntity>> UpdateEntity(TEntity entity);
        protected abstract ValueTask<TEntity> EntityToUpdate(TEntity entity);
    }
}
