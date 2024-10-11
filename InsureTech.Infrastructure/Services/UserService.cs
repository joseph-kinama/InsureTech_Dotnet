using InsureTech.Application.DTOs;
using InsureTech.Application.Interfaces;
using InsureTech.Domain.Entities;
using InsureTech.Domain.Entities.InsureTech.Domain.Entities;
using InsureTech.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureTech.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUser(UserDto userDto)
        {
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = HashPassword(userDto.Password)
            };

            await _userRepository.RegisterUser(user);
        }

        public async Task<User> Login(string username, string password)
        {
            var passwordHash = HashPassword(password);
            return await _userRepository.GetUserByUsernameAndPassword(username, passwordHash);
        }

        private string HashPassword(string password)
        {
            // Implement password hashing
            return password;
        }
    }
}
