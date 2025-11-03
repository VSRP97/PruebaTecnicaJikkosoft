using LibraryManager.Application.Commands.LibraryBooks.GetAllPaginated;
using LibraryManager.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers.LibraryBooks
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryBookController : ControllerBase
    {
        private readonly ISender _sender;

        public LibraryBookController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginated(
            [FromQuery] string? search,
            [FromQuery] int skip = 0,
            [FromQuery] int limit = 10)
        {
            GetAllLibraryBooksPaginatedQuery cmd = new(
                skip,
                limit,
                search);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
