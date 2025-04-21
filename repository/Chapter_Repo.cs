using Library.DataAccess;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.repository
{
    public class Chapter_Repo
    {
        public AppDbContext context = new AppDbContext();
        public async Task<List<Chapter>> GetChapter()
        {
            return (context.Chapters.ToList());
        }
        public async Task<int> PostNewChapter(Chapter chapter)
        {
            var NewChapter = new Chapter()
            {
                IdChapter=chapter.IdChapter,
                Name = chapter.Name,
            };
            await context.Chapters.AddAsync(NewChapter);
            await context.SaveChangesAsync();
            return chapter.IdChapter;
        }
        public async Task<int> UpdateChapter(Chapter chapter, int IdChapter)
        {
            var updateChapter = context.Chapters.Find(IdChapter);
            if (updateChapter is null)
            {
                return 0;
            }
            updateChapter.IdChapter = chapter.IdChapter;
            context.SaveChanges();
            return (IdChapter);
        }
        public async Task<int> DeleteChapter(int IdChapter) { await context.Chapters.Where(x => x.IdChapter == IdChapter).ExecuteDeleteAsync(); return (IdChapter); }
    }
}

