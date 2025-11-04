using LibraryManager.Application.Commands.Members.Create;
using LibraryManager.Application.Commands.Members.Delete;
using LibraryManager.Application.Commands.Members.GetAllPaginated;
using LibraryManager.Application.Commands.Members.GetById;
using LibraryManager.Application.Commands.Members.Update;
using LibraryManager.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers.Members
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ISender _sender;

        public MemberController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginated(
            [FromQuery] string? search,
            [FromQuery] int skip = 0,
            [FromQuery] int limit = 10)
        {
            GetAllMemberPaginatedQuery cmd = new(
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
            GetMemberByIdQuery cmd = new(id);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateMemberRequest request)
        {
            CreateMemberCommand cmd = new(request.Name, request.Email);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] UpdateMemberRequest request)
        {
            UpdateMemberCommand cmd = new(id, request.Name, request.Email);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id)
        {
            DeleteMemberCommand cmd = new(id);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }
    }
}
