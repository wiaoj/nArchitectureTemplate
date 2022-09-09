using AutoMapper;
using Kodlama.io.Devs.Application.Features.SocialLinks.Dtos.Commands;
using Kodlama.io.Devs.Application.Features.SocialLinks.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.WriteRepositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.SocialLinks.Commands.CreateSocialLink;
public class CreateSocialLinkCommand : IRequest<CreatedSocialLinkDto> {
    public Guid UserId { get; set; }
    public String Name { get; set; }
    public String LinkUrl { get; set; }

    internal class CreateSocialLinkCommandHandler : IRequestHandler<CreateSocialLinkCommand, CreatedSocialLinkDto> {
        private readonly ISocialLinkWriteRepository _socialLinkWriteRepository;
        private readonly IMapper _mapper;
        private readonly SocialLinkBusinessRules _socialLinkBusinessRules;

        public CreateSocialLinkCommandHandler(
            ISocialLinkWriteRepository socialLinkWriteRepository,
            IMapper mapper,
            SocialLinkBusinessRules socialLinkBusinessRules
            ) {
            _socialLinkWriteRepository = socialLinkWriteRepository;
            _mapper = mapper;
            _socialLinkBusinessRules = socialLinkBusinessRules;
        }

        public async Task<CreatedSocialLinkDto> Handle(CreateSocialLinkCommand request, CancellationToken cancellationToken) {
            await _socialLinkBusinessRules.SocialLinkNameCanNotBeDuplicatedWhenInserted(request.Name, request.LinkUrl);
            SocialLink mappedSocialLink = _mapper.Map<SocialLink>(request);
            SocialLink createdSocialLink = await _socialLinkWriteRepository.AddAsync(mappedSocialLink);
            CreatedSocialLinkDto createdSocialLinkDto = _mapper.Map<CreatedSocialLinkDto>(createdSocialLink);
            return createdSocialLinkDto;
        }
    }
}