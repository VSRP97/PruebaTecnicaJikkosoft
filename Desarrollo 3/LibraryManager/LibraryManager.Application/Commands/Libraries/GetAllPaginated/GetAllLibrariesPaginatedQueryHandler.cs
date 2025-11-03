using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.GetAllPaginated
{
    internal class GetAllLibrariesPaginatedQueryHandler
        : IQueryHandler<GetAllLibrariesPaginatedQuery, GetAllLibrariesPaginatedResponse>
    {
        private readonly ILibraryRepository _libraryRepo;

        public GetAllLibrariesPaginatedQueryHandler(ILibraryRepository libraryRepo)
        {
            _libraryRepo = libraryRepo;
        }

        public async Task<Result<GetAllLibrariesPaginatedResponse>> Handle(GetAllLibrariesPaginatedQuery request, CancellationToken cancellationToken)
        {
            var result = await _libraryRepo.GetAllLibrariesPaginated(
                request.Skip,
                request.Limit,
                request.Search);

            var libraries = result.Item1.Select(l =>
            {
                return new GetLibraryResponse()
                {
                    Id = l.Id,
                    Name = l.Name
                };
            });

            GetAllLibrariesPaginatedResponse response = new()
            {
                Libraries = [.. libraries],
                TotalCount = result.Item2
            };

            return response;
        }
    }
}
