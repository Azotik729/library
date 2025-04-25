
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.repository
{
    public class Writer_Repo
    {
        public LibraryLyContext context = new LibraryLyContext();
        public async Task<List<Writer>> GetWriter()
        {
            return (context.Writers.ToList());
        }
        public async Task<string> PostNewWriter(int id,string Name)
        {
            var updateWriter = context.Writers.Find(Name);
            if (updateWriter is null)
            {
                return (Name);
            }
            updateWriter.Id = id;
            updateWriter.Name = Name;
            await context.SaveChangesAsync();
            context.SaveChanges();
            return (Name);
        }
        public async Task<string> UpdateWriter(string Name)
        {
            var updateWriter = context.Writers.Find(Name);
            if (updateWriter is null)
            {
                return Name;
            }
            updateWriter.Name = Name;
            context.SaveChanges();
            return (Name);
        }

        public async Task<string> DeleteWriter(string Name) { await context.Writers.Where(x => x.Name == Name).ExecuteDeleteAsync(); return (Name); }
    }
}
