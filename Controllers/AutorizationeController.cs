using Library.Models;
using Library.repository;
using Library.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizationeController : ControllerBase
    {
        private authorization_Repo _repository = new authorization_Repo();
        [HttpGet]
        public async Task<ActionResult<List<Authorization>>> GetAutorizatione()
        {
            var Auto = _repository.GetAutorizatione();
            if (Auto == null)
                return BadRequest(Auto);
            else return Ok(Auto);
        }
        [HttpPost]
        public async Task<string> PostNewAuthorizatione([FromBody] AuthorizationeRequest request)
        {

            return await _repository.CreateAutorizatione(request.Login,request.Password);
        }
        [HttpPatch("{Login}")]
        public async Task<string> UpdateAutorizatione( [FromBody] AuthorizationeRequest request)
        {

            return await _repository.UpdateAutorizatione(request.Login, request.Password);

        }
        [HttpDelete("{Login}")]
        public async Task<string> DeleteBook(string Login)
        {
            return await _repository.DeleteAutorizatione(Login);
        }
    }
}
