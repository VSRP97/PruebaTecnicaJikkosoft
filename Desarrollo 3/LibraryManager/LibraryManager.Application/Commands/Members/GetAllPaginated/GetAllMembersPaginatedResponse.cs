using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.GetAllPaginated
{
    public class GetAllMembersPaginatedResponse
    {
        public IReadOnlyList<GetMemberResponse> Members { get; set; }
        public int TotalCount { get; set; }
    }

    public class GetMemberResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
