using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.Interface
{
    public interface ICustomer : IEntity<Guid>
    {
        [Required, MaxLength(50)]
        public string Name { get; }

        [EmailAddress]
        public string Email { get; }
        [Phone]
        public string Phone { get; }
    }
}
