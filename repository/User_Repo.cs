using Library.DataAccess;
using Library.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Numerics;

namespace Library.repository
{
    public class User_Repo
    {
        public AppDbContext context = new AppDbContext();
        public async Task<List<User>> GetUsers()
        {
            return (context.Users.ToList());
        }
        public async Task<int> PostNewUser(User user)
        {
            var NewUser = new User()
            {
                IdUser = user.IdUser,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,
                Adres = user.Adres,
                Phone = user.Phone,
                DateOfBirth = user.DateOfBirth,
                Fio = user.Fio,
            };
            await context.Users.AddAsync(NewUser);
            await context.SaveChangesAsync();
            return user.IdUser;
        }
        public async Task<int> UpdateUser(User user, int IdUser)
        {
            var updateUser = context.Users.Find(IdUser);
            if (updateUser is null)
            {
                return 0;
            }
            updateUser.IdUser = user.IdUser;
                updateUser.Login = user.Login;
                updateUser.Password = user.Password;
                updateUser.Role = user.Role;
                updateUser.Adres = user.Adres;
                updateUser.Phone = user.Phone;
                updateUser.DateOfBirth = user.DateOfBirth;
                updateUser.Fio = user.Fio;
            context.SaveChanges();
            return (IdUser);
        }
        public async Task<int> DeleteUser(int IdUser) { await context.Users.Where(x => x.IdUser == IdUser).ExecuteDeleteAsync(); return (IdUser); }
    }
}
