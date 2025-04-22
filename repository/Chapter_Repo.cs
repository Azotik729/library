
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.repository
{
    public class Chapter_Repo
    {
        public LibraryLyContext context = new LibraryLyContext();
        public async Task<List<Chapter>> GetChapter()
        {
            return (context.Chapters.ToList());
        }
        public async Task<int> PostNewChapter(Chapter chapter)
        {
            var NewChapter = new Chapter()
            {
                Id = chapter.Id,
                Name = chapter.Name,
            };
            await context.Chapters.AddAsync(NewChapter);
            await context.SaveChangesAsync();
            return chapter.Id;
        }
        public async Task<int> UpdateChapter(Chapter chapter, int IdChapter)
        {
            var updateChapter = context.Chapters.Find(IdChapter);
            if (updateChapter is null)
            {
                return 0;
            }
            updateChapter.Id = chapter.Id;
            context.SaveChanges();
            return (IdChapter);
        }
        public async Task<int> DeleteChapter(int IdChapter) { await context.Chapters.Where(x => x.Id == IdChapter).ExecuteDeleteAsync(); return (IdChapter); }
    }
}

