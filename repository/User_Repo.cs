
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
        public LibraryLyContext context = new LibraryLyContext();
        public async Task<List<User>> GetUsers()
        {
            return (context.Users.ToList());
        }
        public async Task<int> PostNewUser(int IdUser, string Login, string Password, int Role, string Adres, string Phone, DateOnly DateOfBirth, string Fio, string Roly)
        {
            var NewUser = new User()
            {
                Login = Login,
                Password = Password,
                Role = Role,
                Adres = Adres,
                Phone = Phone,
                DateOfBirth = DateOfBirth,
                Fio = Fio,
            };
            await context.Users.AddAsync(NewUser);
            await context.SaveChangesAsync();
            return IdUser;
        }
        public async Task<int> UpdateUser(int IdUser, string Login, string Password, int Role, string Adres, string Phone, DateOnly DateOfBirth, string Fio, string Roly)
        {
            var updateUser = context.Users.Find(IdUser);
            if (updateUser is null)
            {
                return 0;
            }
            updateUser.IdUser = IdUser;
            updateUser.Login = Login;
            updateUser.Password = Password;
            updateUser.Role = Role;
            updateUser.Adres =  Adres;
            updateUser.Phone = Phone;
            updateUser.DateOfBirth = DateOfBirth;
            updateUser.Fio = Fio;
            updateUser.Roly = Roly;
            context.SaveChanges();
            return (IdUser);
        }
        public async Task<int> DeleteUser(int IdUser) { await context.Users.Where(x => x.IdUser == IdUser).ExecuteDeleteAsync(); return (IdUser); }
    }
}
