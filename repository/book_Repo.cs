using Library.DataAccess;
using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.repository

{
    public class book_Repo
    {
        public AppDbContext context = new AppDbContext();
        public async Task<List<Book>> Getbooks()
        {
            return (context.Books.ToList());
        }
        public async Task<int> PostNewBook(Book book)
        {
            var NewBook = new Book()
            {
                IdBook=book.IdBook,
                IdUser = book.IdUser,
                IdWriter = book.IdWriter,
                IdChapter = book.IdChapter,
                DataPost = book.DataPost,
                Price = book.Price,
            };
            await context.Books.AddAsync(NewBook);
            await context.SaveChangesAsync();
            return book.IdUser;
        }
        public async Task<int> UpdateBook(Book book, int Idbook)
        {
            var updateBook = context.Books.Find(Idbook);
            if (updateBook is null)
            {
                return 0;
            }
            updateBook.IdBook = book.IdBook;
            updateBook.IdUser = book.IdUser;
            updateBook.IdWriter = book.IdWriter;
            updateBook.IdChapter = book.IdChapter;
            updateBook.DataPost = book.DataPost;
            updateBook. Price = book.Price;
            context.SaveChanges();
            return (Idbook);
        }
        public async Task<int> DeleteBook(int Idbook) { await context.Books.Where(x => x.IdUser == Idbook).ExecuteDeleteAsync(); return (Idbook); }
    }
}
