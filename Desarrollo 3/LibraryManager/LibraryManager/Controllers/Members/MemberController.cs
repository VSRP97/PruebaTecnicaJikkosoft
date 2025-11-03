using LibraryManager.Application.Commands.Members.GetAllPaginated;
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
            int skip,
            int limit,
            string? search)
        {
            GetAllMemberPaginatedQuery cmd = new(
                skip,
                limit,
                search);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
