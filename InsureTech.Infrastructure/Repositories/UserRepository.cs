using InsureTech.Application.Interfaces;
using InsureTech.Domain.Entities;
using InsureTech.Domain.Entities.InsureTech.Domain.Entities;
using InsureTech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace InsureTech.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string passwordHash)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == passwordHash);
        }

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
