using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.Interface
{
    public interface IEntity<out T>
    {
        public T Id { get; }
    }
}
