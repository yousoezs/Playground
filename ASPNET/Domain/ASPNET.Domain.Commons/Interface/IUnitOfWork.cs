using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.Interface
{
    public interface IUnitOfWork<TRepository, TEntity, TId> where TRepository : 
        IGenericRepository<TEntity, TId> where TEntity : 
        IEntity<TId>, 
        IDisposable
    {
    }
}
