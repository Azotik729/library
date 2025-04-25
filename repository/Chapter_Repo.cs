
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
        public async Task<string> PostNewChapter(string Name)
        {
            var NewChapter = new Chapter()
            {
                Name = Name,
            };
            await context.Chapters.AddAsync(NewChapter);
            await context.SaveChangesAsync();
            return Name;
        }
        public async Task<string> UpdateChapter(string Name)
        {
            var updateChapter = context.Chapters.Find(Name);
            if (updateChapter is null)
            {
                return (Name);
            }
            updateChapter.Name = Name;
            context.SaveChanges();
            return (Name);
        }
        public async Task<string> DeleteChapter(string Name) { await context.Chapters.Where(x => x.Name == Name).ExecuteDeleteAsync(); return (Name); }
    }
}

