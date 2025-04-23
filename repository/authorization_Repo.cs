
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.repository
{
    public class authorization_Repo
    {
        public LibraryLyContext context = new LibraryLyContext();
        public async Task<List<Authorization>> GetAutorizatione()
        {
            return (context.Authorizations.ToList());
        }
        public async Task<string> CreateAutorizatione(string Login,string Password)
        {
            var NewAuto = new Authorization()
            {
                Login = Login,
                Password = Password,
            };
            await context.Authorizations.AddAsync(NewAuto);
            await context.SaveChangesAsync();
            return Login;
        }
        public async Task<string> UpdateAutorizatione(string Login, string Password)
        {
            var updateAuto = context.Authorizations.Find(Login);
            if (updateAuto is null)
            {
                return (Password);
            }
            
            updateAuto.Password = Password;
            context.SaveChanges();
            return (Password);
        }
        public async Task<string> DeleteAutorizatione(string login) { await context.Authorizations.Where(x => x.Login == login).ExecuteDeleteAsync(); return (login); }
    }
}
