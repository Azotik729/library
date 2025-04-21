using Library.DataAccess;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.repository
{
    public class Writer_Repo
    {
        public AppDbContext context = new AppDbContext();
        public async Task<List<Writer>> GetWriter()
        {
            return (context.Writers.ToList());
        }
        public async Task<int> PostNewWriter(Writer writer)
        {
            var NewWriter = new Writer()
            {
                IdWriter=writer.IdWriter,
                Name = writer.Name,
            };
            await context.Writers.AddAsync(NewWriter);
            await context.SaveChangesAsync();
            return writer.IdWriter;
        }
        public async Task<int> UpdateWriter(Writer writer,int IdWriter)
        {
            var updateWriter = context.Writers.Find(IdWriter);
            if (updateWriter is null)
            {
                return 0;
            }
            updateWriter.IdWriter = IdWriter;
            updateWriter.Name = writer.Name;
            await context.SaveChangesAsync();
            context.SaveChanges();
            return (IdWriter);
        }
        public async Task<int> DeleteBook(int IdWriter) { await context.Writers.Where(x => x.IdWriter == IdWriter).ExecuteDeleteAsync(); return (IdWriter); }
    }
}
