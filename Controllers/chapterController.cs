using Library.Models;
using Library.repository;
using Library.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class chapterController : ControllerBase
    {
        private Chapter_Repo _repository = new Chapter_Repo();
        [HttpGet]
        public async Task<List<Chapter>> GetChapter()
        {
            var books = await _repository.GetChapter();
            if (books == null)
                return books;
            else return books;
        }
        [HttpPost]
        public async Task<string> PossNewChapter([FromBody] ChapterRequest request)
        {

            return await _repository.PostNewChapter(request.Name);
        }
        [HttpPatch("{Name}")]
        public async Task<string> UpdateChapter(string Name, [FromBody] ChapterRequest request)
        {

            return await _repository.UpdateChapter(request.Name);

        }
        [HttpDelete("{Name}")]
        public async Task<string> DeleteChapter(string Name)
        {
            return await _repository.DeleteChapter(Name);
        }
        public LibraryLyContext context = new LibraryLyContext();
    }
}
