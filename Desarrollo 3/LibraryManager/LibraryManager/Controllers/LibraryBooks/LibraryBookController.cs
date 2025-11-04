using LibraryManager.Application.Commands.LibraryBooks.GetAllPaginated;
using LibraryManager.Application.Commands.LibraryBooks.GetById;
using LibraryManager.Application.Commands.LibraryBooks.Create;
using LibraryManager.Application.Commands.LibraryBooks.Delete;
using LibraryManager.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.Application.Commands.LibraryBooks.UpdateTotalCopies;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            [FromRoute] Guid id)
        {
            GetLibraryBookByIdQuery cmd = new(id);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateLibraryBookRequest request)
        {
            CreateLibraryBookCommand cmd = new(request.LibraryId, request.BookId, request.TotalCopies, request.TotalCopies);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateLibraryBookRequest request)
        {
            UpdateTotalCopiesCommand cmd = new(id, request.NewCopiesAmount);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id)
        {
            DeleteLibraryBookCommand cmd = new(id);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
