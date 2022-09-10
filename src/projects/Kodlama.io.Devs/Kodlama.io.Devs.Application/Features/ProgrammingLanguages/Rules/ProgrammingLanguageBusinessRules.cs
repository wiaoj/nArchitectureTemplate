using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Services.Repositories.ReadRepositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
internal class ProgrammingLanguageBusinessRules {
    private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageReadRepository programmingLanguageReadRepository) {
        _programmingLanguageReadRepository = programmingLanguageReadRepository;
    }

    public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(String name) {
        IPaginate<ProgrammingLanguage> result = await _programmingLanguageReadRepository.GetListAsync(x => x.Name.Equals(name), enableTracking: false);
        if(result.Items.Any())
            throw new BusinessException("Programming language name exists.");
    }

    public Task ProgrammingLanguageShouldExistWhenRequest(ProgrammingLanguage? programmingLanguage) {
        if(programmingLanguage is null)
            throw new BusinessException("Requested programming language does not exists.");
        return Task.CompletedTask;
    }

    public async Task ProgrammingLanguageShouldExistWhenRequestId(Guid id) {
        _ = await _programmingLanguageReadRepository.GetByIdAsync(id, enableTracking: false)
            ?? throw new BusinessException("Programming language does not exists.");
    }
}