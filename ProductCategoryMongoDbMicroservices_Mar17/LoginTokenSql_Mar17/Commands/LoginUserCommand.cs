using LoginTokenSql_Mar17.Models;
using MediatR;

namespace LoginTokenSql_Mar17.Commands
{
    public record LoginUserCommand(UserDTO userDTO):IRequest<UserDTO>; 
   
}
