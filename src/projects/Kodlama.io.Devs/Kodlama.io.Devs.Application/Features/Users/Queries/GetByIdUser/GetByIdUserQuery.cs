using AutoMapper;
using Kodlama.io.Devs.Application.Features.Users.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.Users.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.Users.Queries.GetByIdUser;
public class GetByIdUserQuery : IRequest<UserGetByIdDto> {
    public Guid Id { get; set; }

    internal class GetBIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserGetByIdDto> {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public GetBIdUserQueryHandler(
            IUserReadRepository userReadRepository,
            IMapper mapper,
            UserBusinessRules userBusinessRules
            ) {
            _userReadRepository = userReadRepository;
            _mapper = mapper;
            _userBusinessRules = userBusinessRules;
        }

        public async Task<UserGetByIdDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken) {
            await _userBusinessRules.UserShouldExistWhenRequestId(request.Id);

            ApplicationUser? user = await _userReadRepository.GetByIdAsync(
                request.Id,
                include: x => x.Include(l => l.SocialLinks),
                enableTracking: false
                );

            UserGetByIdDto userGetByIdDto = _mapper.Map<UserGetByIdDto>(user);
            return userGetByIdDto;
        }
    }
}