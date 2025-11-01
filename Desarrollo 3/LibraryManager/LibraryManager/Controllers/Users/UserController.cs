using LibraryManager.Application.Commands.Users.CreateUser;
using LibraryManager.Application.Commands.Users.GetUserByEmail;
using LibraryManager.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var res = await _sender.Send(new GetUserByEmailQuery(email));
            var response = ResponseStandardFactory.HandleResultValue(res);

            return res.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            CreateUserCommand cmd = new(
                request.FirstName,
                request.SecondName,
                request.LastName,
                request.SecondLastName,
                request.Email);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
