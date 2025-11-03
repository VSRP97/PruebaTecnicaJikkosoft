using LibraryManager.Application.Commands.Libraries.Create;
using LibraryManager.Application.Commands.Libraries.Delete;
using LibraryManager.Application.Commands.Libraries.GetAllPaginated;
using LibraryManager.Application.Commands.Libraries.GetById;
using LibraryManager.Application.Commands.Libraries.Update;
using LibraryManager.Domain.Entities.Libraries;
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
            [FromQuery] string? search,
            [FromQuery] int skip = 0,
            [FromQuery] int limit = 10)
        {
            GetAllLibrariesPaginatedQuery cmd = new(
                skip,
                limit,
                search);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            [FromRoute] Guid id)
        {
            GetLibraryByIdQuery cmd = new(id);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateLibraryRequest request)
        {
            CreateLibraryCommand cmd = new(request.Name);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateLibraryRequest request)
        {
            UpdateLibraryCommand cmd = new(id, request.Name);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id)
        {
            DeleteLibraryCommand cmd = new(id);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }
    }
}
