using ASPNET.Domain.Commons.Record;

namespace ASPNET.Domain.Commons.Interface
{
    public interface IGenericRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        Task<ServiceResponse<TEntity>> AddEntity(TEntity entity);
        Task<ServiceResponse<TEntity>> UpdateEntity(TEntity entity);
        Task<ServiceResponse<TEntity>> DeleteEntity(TId id);
        Task<ServiceResponse<TEntity>> GetEntity(TId id);
        Task<ServiceResponse<IEnumerable<TEntity>>> GetAllEntities();
    }
}
