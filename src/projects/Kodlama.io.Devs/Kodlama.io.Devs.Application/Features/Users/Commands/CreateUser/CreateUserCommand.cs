using Kodlama.io.Devs.Application.Features.Users.Dtos.Commands;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.CreateUser;
public class CreateUserCommand : IRequest<CreatedUserDto> {
    public String FirstName { get; set; }
    public String LastName { get; set; }
    public String Email { get; set; }

    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserDto> {
        public Task<CreatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
    }
}