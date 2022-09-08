namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Commands;
public class CreatedProgrammingFrameworkDto
{
    public String Name { get; set; }
    public Double Version { get; set; }
    public String Tag { get; set; }
    public Guid ProgrammingLanguageId { get; set; }
}