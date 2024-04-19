using ASPNET.Domain.Commons.Record;

namespace ASPNET.Domain.Commons.Interface
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        ValueTask<ServiceResponse<TEntity>> AddEntity(TEntity entity);
        ValueTask<ServiceResponse<TEntity>> UpdateEntity(TEntity entity);
        ValueTask<ServiceResponse<TEntity>> DeleteEntity(TId id);
        ValueTask<ServiceResponse<TEntity>> GetEntity(TId id);
        ValueTask<ServiceResponse<IEnumerable<TEntity>>> GetAllEntities();
        ValueTask SaveAsync();
    }
}
