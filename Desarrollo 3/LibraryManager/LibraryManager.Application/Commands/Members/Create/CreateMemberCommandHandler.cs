using LibraryManager.Application.Abstractions.Messaging;
using LibraryManager.Domain.Abstractions;
using LibraryManager.Domain.Entities.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Application.Commands.Members.Create
{
    internal sealed class CreateMemberCommandHandler : ICommandHandler<CreateMemberCommand, Guid>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberCommandHandler(IMemberRepository memberRepository, IUnitOfWork unitOfWork)
        {
            _memberRepository = memberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var existingMember = await _memberRepository.GetByEmail(request.Email, cancellationToken);

            if (existingMember is not null)
                return Result.Failure<Guid>(MemberErrors.EmailAlreadyExists);

            var newMember = Member.Create(
                request.Name,
                request.Email);

            _memberRepository.Add(newMember);

            await _unitOfWork.SaveChangesAsync();

            return newMember.Id;
        }
    }
}
