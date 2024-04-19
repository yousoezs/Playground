using ASPNET.Domain.Commons.DTO;
using ASPNET.User.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.User.BusinessLogic.Extensions
{
    public static class UserExtensions
    {
        public static UserModel ConvertToModel(this UserDto userDto)
        {
            return new UserModel()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                Phone = userDto.Phone
            };
        }
        public static UserDto ConvertToDto(this UserModel userModel)
        {
            return new UserDto()
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
                Phone = userModel.Phone
            };
        }
    }
}
