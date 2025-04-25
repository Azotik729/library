using Library.Models;
using Library.repository;
using Library.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private Writer_Repo _repository = new Writer_Repo();
        [HttpGet]
        public async Task<List<Writer>> GetWriter()
        {
            var Auto = await _repository.GetWriter();
            if (Auto == null)
                return Auto;
            else return Auto;
        }
        [HttpPost]
        public async Task<string> PostNewWriter([FromBody] WriterRequest request)
        {

            return await _repository.PostNewWriter( request.Id , request.Name);
        }
        [HttpPatch("{Name}")]
        public async Task<string> UpdateWriter([FromBody] WriterRequest request)
        {

            return await _repository.UpdateWriter(request.Name);
            

        }
        [HttpDelete("{Name}")]
        public async Task<string> DeleteWriter(string Name)
        {
            return await _repository.DeleteWriter(Name);
        }
    }
}
