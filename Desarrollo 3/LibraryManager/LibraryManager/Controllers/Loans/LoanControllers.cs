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
    }
}
