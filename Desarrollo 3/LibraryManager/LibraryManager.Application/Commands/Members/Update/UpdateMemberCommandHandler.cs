using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.Update
{
    internal sealed class UpdateMemberCommandHandler : ICommandHandler<UpdateMemberCommand>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetById(request.Id, cancellationToken);

            if (member is null)
                return Result.Failure(MemberErrors.NotFound);

            member.Update(
                request.Name ?? member.Name,
                request.Email ?? member.Email);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
