﻿using ASPNET.Domain.Commons.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.DTO
{
    public class UserDto : ICustomer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;

    }
}
