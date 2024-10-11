using InsureTech.Application.DTOs;
using InsureTech.Domain.Entities;
using InsureTech.Domain.Entities.InsureTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureTech.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterUser(UserDto userDto);
        Task<User> Login(string username, string password);
    }
}
