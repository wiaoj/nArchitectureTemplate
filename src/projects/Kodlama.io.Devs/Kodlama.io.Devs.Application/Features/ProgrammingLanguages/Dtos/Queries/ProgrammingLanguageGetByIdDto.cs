using Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Queries;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;

public record ProgrammingLanguageGetByIdDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public ICollection<ProgrammingFrameworkGetByProgrammingLanguageDto> Frameworks { get; set; }
}