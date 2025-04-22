
using Azure.Core;
using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.repository

{
    public class book_Repo
    {
        public LibraryLyContext context = new LibraryLyContext();
        public async Task<List<Book>> Getbooks()
        {
            return (context.Books.ToList());
        }
        public async Task<int> PostNewBook(int IdUser, int IdWriter, int IdChapter,string DataPost, decimal Price, string Name) { 
        var NewBook = new Book()
         {
             IdUser = IdUser,
             IdWriter = IdWriter,
             IdChapter = IdChapter,
             DataPost = DataPost,
             Price = Price,
             Name = Name,
         };
        await context.Books.AddAsync(NewBook);
        await context.SaveChangesAsync();
            return 0;
        }
        
        public async Task<int> UpdateBook(int IdBook, int IdUser, int IdWriter, int IdChapter, string DataPost, decimal Price, string Name)
        {
            var updateBook = context.Books.Find(IdBook);
            if (updateBook is null)
            {
                return (IdBook);
            }
            updateBook.IdUser = IdUser;
            updateBook.IdWriter = IdWriter;
            updateBook.IdChapter = IdChapter;
            updateBook.DataPost = DataPost;
            updateBook.Price = Price;

            await context.SaveChangesAsync();
            return (IdBook);
        }
        public async Task<string> DeleteBook(string Name) { await context.Books.Where(x => x.Name == Name).ExecuteDeleteAsync(); return (Name); }
    }
}
