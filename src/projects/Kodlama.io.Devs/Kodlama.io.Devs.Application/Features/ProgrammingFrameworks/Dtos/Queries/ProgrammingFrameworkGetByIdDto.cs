namespace Kodlama.io.Devs.Application.Features.ProgrammingFrameworks.Dtos.Queries;

public class ProgrammingFrameworkGetByIdDto {
    public Guid Id { get; set; }
    public String Name { get; set; }
    public String ProgrammingLanguageName { get; set; }
    public Double Version { get; set; }
    public String Tag { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}