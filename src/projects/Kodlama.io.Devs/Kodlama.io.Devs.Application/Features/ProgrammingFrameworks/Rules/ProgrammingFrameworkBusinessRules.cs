using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Rules;
internal class ProgrammingFrameworkBusinessRules {
    private readonly IProgrammingFrameworkReadRepository _programmingFrameworkReadRepository;
    private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

    public ProgrammingFrameworkBusinessRules(IProgrammingFrameworkReadRepository programmingFrameworkReadRepository, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules) {
        this._programmingFrameworkReadRepository = programmingFrameworkReadRepository;
        this._programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task ProgrammingFrameworkVersionTagCanNotBeDuplicatedWhenInserted(String name, Double version, String tag) {
        IPaginate<ProgrammingFramework> result = await _programmingFrameworkReadRepository.GetListAsync(x => x.Name.Equals(name), enableTracking: false);
        IEnumerable<ProgrammingFramework> versions = result.Items.Where(x => x.Version.Equals(version));
        if(versions.Any(x => x.Tag.Equals(tag)))
            throw new BusinessException("Programming framework version tag exists.");
    }

    public async Task ProgrammingFrameworkShouldExistWhenRequest(ProgrammingFramework programmingFramework) {
        if(programmingFramework is null)
            throw new BusinessException("Requested programming framework does not exists.");
    }

    public async Task ProgrammingFrameworkShouldExistWhenRequestId(Guid id) {
        ProgrammingFramework? programmingFramework = await _programmingFrameworkReadRepository.GetByIdAsync(id, enableTracking: false);
        if(programmingFramework is null)
            throw new BusinessException("Requested programming framework does not exists.");
    }

    public async Task ProgrammingFrameworkShouldExistWhenRequestProgrammingLanguageId(Guid programmingLanguageId) {
        //ProgrammingLanguage? programmingLanguage = await _programmingLanguageReadRepository.GetByIdAsync(programmingLanguageId, enableTracking: false);
        //if(programmingLanguage is null) {
        //    throw new BusinessException("Requested programming language does not exists")
        //}
        await _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequestId(programmingLanguageId);
    }
}