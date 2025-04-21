using Library.Models;
using Library.repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
    }
}
