using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.Create
{
    internal sealed class CreateLibraryCommandHandler : ICommandHandler<CreateLibraryCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryRepository _libraryRepository;

        public CreateLibraryCommandHandler(IUnitOfWork unitOfWork, ILibraryRepository libraryRepository)
        {
            _unitOfWork = unitOfWork;
            _libraryRepository = libraryRepository;
        }

        public async Task<Result<Guid>> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
        {
            var library = Library.Create(request.Name);

            _libraryRepository.Add(library);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return library.Id;
        }
    }
}
