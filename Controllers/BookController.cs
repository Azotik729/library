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
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = _repository.Getbooks();
            if (books == null)
                return BadRequest(books);
            else return Ok(books);
        }
        [HttpPost]
        public async Task<int> PostNewBook([FromBody] BookRequest request)
        {
            
            return await _repository.PostNewBook(request.IdUser, request.IdWriter, request.IdChapter,Convert.ToString(request.Price),Convert.ToDecimal(request.DataPost),request.Name);
        }
        [HttpPut("{Name}")]
        public async Task<string> UpdateBook(string Name, [FromBody] BookRequest request)
        {
            return await _repository.UpdateBook( request.IdUser, request.IdWriter, request.IdChapter, Convert.ToString(request.Price), Convert.ToInt32(request.DataPost), request.Name);

        }
        [HttpDelete("{Name}")]
        public async Task<string> DeleteBook(string Name)
        {
            return await _repository.DeleteBook(Name);
        }
        public LibraryLyContext context = new LibraryLyContext();
        }
    }
