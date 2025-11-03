using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Libraries.Update
{
    internal sealed class UpdateLibraryCommandHandler : ICommandHandler<UpdateLibraryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryRepository _libraryRepository;

        public UpdateLibraryCommandHandler(IUnitOfWork unitOfWork, ILibraryRepository libraryRepository)
        {
            _unitOfWork = unitOfWork;
            _libraryRepository = libraryRepository;
        }

        public async Task<Result> Handle(UpdateLibraryCommand request, CancellationToken cancellationToken)
        {
            var library = await _libraryRepository.GetById(request.Id);

            if (library is null)
                return Result.Failure(LibraryErrors.NotFound);

            var result = library.Update(request.Name);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
