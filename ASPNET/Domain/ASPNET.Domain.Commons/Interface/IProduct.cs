using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.Interface
{
    public interface IProduct : IEntity<Guid>
    {
        [Required, MaxLength(50)]
        public string Name { get; }
        [Required]
        public string Description { get; }
        public decimal Price { get; }
    }
}
