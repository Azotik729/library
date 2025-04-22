
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
        public async Task<int> PostNewWriter(Writer writer)
        {
            var NewWriter = new Writer()
            {
                Id = writer.Id,
                Name = writer.Name,
            };
            await context.Writers.AddAsync(NewWriter);
            await context.SaveChangesAsync();
            return writer.Id;
        }
        public async Task<int> UpdateWriter(Writer writer, int IdWriter)
        {
            var updateWriter = context.Writers.Find(IdWriter);
            if (updateWriter is null)
            {
                return 0;
            }
            updateWriter.Id = IdWriter;
            updateWriter.Name = writer.Name;
            await context.SaveChangesAsync();
            context.SaveChanges();
            return (IdWriter);
        }
        public async Task<int> DeleteBook(int IdWriter) { await context.Writers.Where(x => x.Id == IdWriter).ExecuteDeleteAsync(); return (IdWriter); }
    }
}
