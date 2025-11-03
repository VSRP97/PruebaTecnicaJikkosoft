using LibraryManager.Application.Commands.Libraries.GetAllPaginated;
using LibraryManager.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers.Libraries
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ISender _sender;

        public LibraryController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginated(
            [FromQuery] int skip,
            [FromQuery] int limit,
            [FromQuery] string? search)
        {
            GetAllLibrariesPaginatedQuery cmd = new(
                skip,
                limit,
                search);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
