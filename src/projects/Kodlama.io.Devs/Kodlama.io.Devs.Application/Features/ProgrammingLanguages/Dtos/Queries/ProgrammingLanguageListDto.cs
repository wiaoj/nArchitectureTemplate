namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;

public record ProgrammingLanguageListDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public DateTime CreatedDate { get; set; }
}