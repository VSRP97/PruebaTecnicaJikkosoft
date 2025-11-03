using LibraryManager.Application.Commands.Loans.GetAllPaginated;
using LibraryManager.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers.Loans
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanControllers : ControllerBase
    {
        private readonly ISender _sender;

        public LoanControllers(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginated(
            [FromQuery] int skip,
            [FromQuery] int limit,
            [FromQuery] string? search,
            [FromQuery] string? status,
            [FromBody] GetLoansPaginatedRequest? request)
        {
            GetAllLoansPaginatedQuery cmd = new(
                skip,
                limit,
                search,
                status,
                request?.BookId,
                request?.MemberId);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }
    }
}
