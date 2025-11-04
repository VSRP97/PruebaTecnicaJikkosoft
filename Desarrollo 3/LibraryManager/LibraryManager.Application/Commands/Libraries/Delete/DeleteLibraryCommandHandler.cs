using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.Delete
{
    internal sealed class DeleteLibraryCommandHandler : ICommandHandler<DeleteLibraryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryRepository _libraryRepository;

        public DeleteLibraryCommandHandler(IUnitOfWork unitOfWork, ILibraryRepository libraryRepository)
        {
            _unitOfWork = unitOfWork;
            _libraryRepository = libraryRepository;
        }

        public async Task<Result> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
        {
            var library = await _libraryRepository.GetById(request.Id, cancellationToken);

            if (library is null)
                return Result.Failure(LibraryErrors.NotFound);

            _libraryRepository.Delete(library);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
