namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Queries;

public class ProgrammingLanguageGetByIdDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}