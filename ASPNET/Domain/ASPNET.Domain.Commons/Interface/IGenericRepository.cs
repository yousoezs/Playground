using ASPNET.Domain.Commons.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
