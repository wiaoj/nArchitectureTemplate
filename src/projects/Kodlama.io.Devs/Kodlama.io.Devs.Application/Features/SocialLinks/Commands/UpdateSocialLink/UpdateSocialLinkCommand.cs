using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.SocialLinks.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Commands.UpdateSocialLink;
public class UpdateSocialLinkCommand : IRequest<UpdatedSocialLinkDto> {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public String Name { get; set; }
    public String LinkUrl { get; set; }

    internal class UpdateSocialLinkCommandHandler : IRequestHandler<UpdateSocialLinkCommand, UpdatedSocialLinkDto> {
        private readonly ISocialLinkWriteRepository _socialLinkWriteRepository;
        private readonly IMapper _mapper;
        private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

        public UpdateSocialLinkCommandHandler(
            ISocialLinkWriteRepository socialLinkWriteRepository,
            IMapper mapper,
            SocialLinkBusinessRules socialLinkBusinessRules
            ) {
            _socialLinkWriteRepository = socialLinkWriteRepository;
            _mapper = mapper;
            _socialLinkBusinessRules = socialLinkBusinessRules;
        }

        public async Task<UpdatedSocialLinkDto> Handle(UpdateSocialLinkCommand request, CancellationToken cancellationToken) {
            await _socialLinkBusinessRules.SocialLinkShouldExistWhenRequestId(request.Id);
            await _socialLinkBusinessRules.SocialLinkNameCanNotBeDuplicatedWhenInserted(request.Name, request.LinkUrl);
            SocialLink mappedSocialLink = _mapper.Map<SocialLink>(request);
            SocialLink updatedSocialLink = await _socialLinkWriteRepository.UpdateAsync(mappedSocialLink);
            UpdatedSocialLinkDto updatedSocialLinkDto = _mapper.Map<UpdatedSocialLinkDto>(updatedSocialLink);
            return updatedSocialLinkDto;
        }
    }
}