using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.GetAllPaginated
{
    internal class GetAllMemberPaginatedQueryHandler
        : IQueryHandler<GetAllMemberPaginatedQuery, GetAllMembersPaginatedResponse>
    {
        private readonly IMemberRepository _memberRepo;

        public GetAllMemberPaginatedQueryHandler(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public async Task<Result<GetAllMembersPaginatedResponse>> Handle(GetAllMemberPaginatedQuery request, CancellationToken cancellationToken)
        {
            var result = await _memberRepo.GetAllMembersPaginated(
                request.Skip,
                request.Limit,
                request.Search);

            var members = result.Item1.Select(m =>
            {
                return new GetMemberResponse 
                {
                    Id = m.Id,
                    Name = m.Name,
                    Email = m.Email
                };
            });

            GetAllMembersPaginatedResponse response = new()
            {
                 Members = [.. members],
                 TotalCount = result.Item2
            };

            return response;
        }
    }
}
