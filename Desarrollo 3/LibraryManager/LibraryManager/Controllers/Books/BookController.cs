using LibraryManager.Application.Commands.Books.GetAllPaginated;
using LibraryManager.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers.Books
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ISender _sender;

        public BookController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginated(
            [FromQuery] int skip,
            [FromQuery] int limit,
            [FromQuery] string? search)
        {
            GetAllBooksPaginatedQuery cmd = new(
                skip,
                limit,
                search);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
