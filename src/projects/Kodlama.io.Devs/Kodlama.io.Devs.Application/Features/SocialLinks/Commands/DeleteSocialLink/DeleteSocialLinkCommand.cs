using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.SocialLinks.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Commands.DeleteSocialLink;
public class DeleteSocialLinkCommand : IRequest<DeletedSocialLinkDto>, ISecuredRequest {
    public Guid Id { get; set; }

    public String[] Roles { get; } = { "Admin", "User" };

    internal class DeleteSocialLinkCommandHandler : IRequestHandler<DeleteSocialLinkCommand, DeletedSocialLinkDto> {
        private readonly ISocialLinkWriteRepository _socialLinkWriteRepository;
        private readonly IMapper _mapper;
        private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

        public DeleteSocialLinkCommandHandler(
            ISocialLinkWriteRepository socialLinkWriteRepository,
            IMapper mapper,
            SocialLinkBusinessRules socialLinkBusinessRules
            ) {
            _socialLinkWriteRepository = socialLinkWriteRepository;
            _mapper = mapper;
            _socialLinkBusinessRules = socialLinkBusinessRules;
        }

        public async Task<DeletedSocialLinkDto> Handle(DeleteSocialLinkCommand request, CancellationToken cancellationToken) {
            await _socialLinkBusinessRules.SocialLinkShouldExistWhenRequestId(request.Id);
            SocialLink mappedSocialLink = _mapper.Map<SocialLink>(request);
            SocialLink deletedSocialLink = await _socialLinkWriteRepository.DeleteAsync(mappedSocialLink);
            DeletedSocialLinkDto deletedSocialLinkDto = _mapper.Map<DeletedSocialLinkDto>(deletedSocialLink);
            return deletedSocialLinkDto;
        }
    }
}