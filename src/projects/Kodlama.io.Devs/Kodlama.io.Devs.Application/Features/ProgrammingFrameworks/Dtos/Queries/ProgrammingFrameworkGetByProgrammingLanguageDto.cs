namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Queries;

public record ProgrammingFrameworkGetByProgrammingLanguageDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public Double Version { get; set; }
    public String Tag { get; set; }
}