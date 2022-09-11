namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos.Commands;
public record CreatedProgrammingLanguageDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public DateTime CreatedDate { get; set; }
}