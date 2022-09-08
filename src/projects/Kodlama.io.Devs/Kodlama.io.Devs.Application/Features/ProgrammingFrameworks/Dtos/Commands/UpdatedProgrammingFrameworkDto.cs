namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Commands;

public class UpdatedProgrammingFrameworkDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public Double Version { get; set; }
    public String Tag { get; set; }
    public Guid ProgrammingLanguageId { get; set; }
}