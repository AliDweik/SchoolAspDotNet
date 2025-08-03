using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Helpers;
using School.Models.AuthModels;

namespace School.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDbContext _dbContext;

        public AuthService(AuthDbContext dBContext) {
            _dbContext = dBContext;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _dbContext.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return null;
            }
            if(!PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user;
        }

        public async Task<User> Register(User user, string passwrord)
        {
            PasswordHelper.CreatePasswordHash(passwrord, out var passwordHash, out var passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = 1
            };

            await _dbContext.UserRoles.AddAsync(userRole);
            await _dbContext.SaveChangesAsync();

            return user;

        }

        public async Task<bool> UserExists(string username)
        {
            return await _dbContext.Users.AnyAsync(u => u.Username == username);
        }
    }
}
