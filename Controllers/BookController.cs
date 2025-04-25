using Library.Models;
using Library.repository;
using Library.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Pipelines;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private book_Repo _repository = new book_Repo();
        [HttpGet]
        public async Task <List<Book>> GetBooks()
        {
            var books = await _repository.Getbooks();
            if (books == null)
                return books;
            else return books;
        }
        [HttpPost]
        public async Task<int> PostNewBook([FromBody] BookRequest request)
        {
            
            return await _repository.PostNewBook(request.IdUser, request.IdWriter, request.IdChapter,request.DataPost,request.Price, request.Name);
        }
        [HttpPatch("{IdBook}")]
        public async Task<int> UpdateBook(int IdBook, [FromBody] BookRequest request)
        {

            return await _repository.UpdateBook(IdBook,request.IdUser, request.IdWriter, request.IdChapter,request.DataPost, request.Price, request.Name);

        }
        [HttpDelete("{Name}")]
        public async Task<string> DeleteBook(string Name)
        {
            return await _repository.DeleteBook(Name);
        }
        public LibraryLyContext context = new LibraryLyContext();
        }
    }
