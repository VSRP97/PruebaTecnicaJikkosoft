using LibraryManager.Application.Commands.Loans.Create;
using LibraryManager.Application.Commands.Loans.Delete;
using LibraryManager.Application.Commands.Loans.GetAllPaginated;
using LibraryManager.Application.Commands.Loans.GetById;
using LibraryManager.Application.Commands.Loans.Return;
using LibraryManager.Domain.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Controllers.Loans
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ISender _sender;

        public LoanController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaginated(
            [FromQuery] string? search,
            [FromQuery] string? status,
            [FromQuery] Guid? BookId,
            [FromQuery] Guid? MemberId,
            [FromQuery] int skip = 0,
            [FromQuery] int limit = 10)
        {
            GetAllLoansPaginatedQuery cmd = new(
                skip,
                limit,
                search,
                status,
                BookId,
                MemberId);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateLoanRequest request)
        {
            CreateLoanCommand cmd = new(
                request.LibraryBookId,
                request.MemberId,
                request.LoanQuantity,
                request.ExpectedReturnDate);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var cmd = new GetLoanByIdQuery(id);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpPatch("return/{id}")]
        public async Task<IActionResult> Return(
            [FromRoute] Guid id,
            [FromBody] ReturnLoanRequest request)
        {
            var cmd = new ReturnLoanCommand(
                id,
                request.ReturnQuantity);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var cmd = new DeleteLoanCommand(id);

            var res = await _sender.Send(cmd);
            var response = ResponseStandardFactory.HandleResultValue(res);
            return res.IsSuccess ? Ok(response) : NotFound(response);
        }
    }
}
