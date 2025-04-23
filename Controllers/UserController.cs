using Library.Models;
using Library.repository;
using Library.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
          private User_Repo _repository = new User_Repo();
        [HttpGet]
        public ActionResult<List<User>> GetUser()
        {
            var users = _repository.GetUsers();
            if (users == null)
                return BadRequest(users);
            else return Ok(users);
        }
        [HttpPost]
        public async Task<int> PostNewUser([FromBody] UserRequest request)
        {
           
            return await _repository.PostNewUser(request.IdUser, request.Login, request.Password, request.Role, request.Adres, request.Phone, request.DateOfBirth ?? new DateOnly(2005, 2, 13), request.Fio, request.Roly);
        }
        [HttpPatch("{IdUser||fio}")]
        public async Task<int> UpdateUser( [FromBody] UserRequest request)
        {

            return await _repository.UpdateUser(request.IdUser, request.Login, request.Password,request.Role, request.Adres, request.Phone, request.DateOfBirth ?? new DateOnly(2005, 2, 13), request.Fio, request.Roly);

        }
        [HttpDelete("{IdUser}")]
        public async Task<int> DeleteBook(int IdUser)
        {
            return await _repository.DeleteUser(IdUser);
        }
        public LibraryLyContext context = new LibraryLyContext();
    }
}
