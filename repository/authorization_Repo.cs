using Library.DataAccess;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.repository
{
    public class authorization_Repo
    {
        public AppDbContext context = new AppDbContext();
        public async Task<List<Authorization>> GetAutorizatione()
        {
            return (context.Authorizations.ToList());
        }
        public async Task<string> CreateAutorizatione(Authorization Auto)
        {
            var NewAuto = new Authorization()
            {
                Login = Auto.Login,
                Password = Auto.Password,
            };
            await context.Authorizations.AddAsync(NewAuto);
            await context.SaveChangesAsync();
            return Auto.Login;
        }
        public async Task<string> UpdateAutorizatione(Authorization Auto,string Password)
        {
            var updateAuto = context.Authorizations.Find(Password);
            if (updateAuto is null)
            {
                return (Password);
            }
            updateAuto.Login = Auto.Login;
            updateAuto.Password = Auto.Password;
            context.SaveChanges();
            return (Password);
        }
        public async Task<string> DeleteAutorizatione(string login) { await context.Authorizations.Where(x => x.Login == login).ExecuteDeleteAsync(); return (login); }
    }
}
