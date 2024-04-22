using ASPNET.Domain.Commons.Interface;

namespace ASPNET.Domain.Commons.DTO
{
    public class UserDto : ICustomer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Phone { get; set; }

    }
}
