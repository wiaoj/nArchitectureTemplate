using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Queries;
using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Queries.GetByIdProgrammingFramework;
public class GetByIdProgrammingFrameworkQuery : IRequest<ProgrammingFrameworkGetByIdDto>{
    public Guid Id { get; set; }

    internal class GetByIdProgrammingFrameworkQueryHandler : IRequestHandler<GetByIdProgrammingFrameworkQuery, ProgrammingFrameworkGetByIdDto> {
        private readonly IProgrammingFrameworkReadRepository _programmingFrameworkReadRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingFrameworkBusinessRules _programmingFrameworkBusinessRules;

        public GetByIdProgrammingFrameworkQueryHandler(IProgrammingFrameworkReadRepository programmingFrameworkReadRepository, IMapper mapper, ProgrammingFrameworkBusinessRules programmingFrameworkBusinessRules) {
            this._programmingFrameworkReadRepository = programmingFrameworkReadRepository;
            this._mapper = mapper;
            this._programmingFrameworkBusinessRules = programmingFrameworkBusinessRules;
        }

        public async Task<ProgrammingFrameworkGetByIdDto> Handle(GetByIdProgrammingFrameworkQuery request, CancellationToken cancellationToken) {
            var programmingFramework = await _programmingFrameworkReadRepository.GetByIdAsync(request.Id,
                include: x => x.Include(l => l.ProgrammingLanguage), 
                enableTracking: false);
            await _programmingFrameworkBusinessRules.ProgrammingFrameworkShouldExistWhenRequest(programmingFramework);
            ProgrammingFrameworkGetByIdDto programmingFrameworkGetByIdDto = _mapper.Map<ProgrammingFrameworkGetByIdDto>(programmingFramework);
            return programmingFrameworkGetByIdDto;
        }
    }
}