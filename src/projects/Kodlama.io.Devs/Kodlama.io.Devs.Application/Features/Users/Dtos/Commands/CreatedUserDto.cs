namespace Kodlama.io.Devs.Application.Features.Users.Dtos.Commands;
public record CreatedUserDto {
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }
}