namespace Core.Security.Dtos;

public class UserForLoginDto {
    public String Email { get; set; }
    public String Password { get; set; }
    public String? AuthenticatorCode { get; set; }
}