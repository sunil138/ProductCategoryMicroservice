using LoginTokenSql_Mar17.Models;
using MediatR;

namespace LoginTokenSql_Mar17.Commands
{
    public record RegisterUserCommand(Tlogin user):IRequest<List<Tlogin>>;   
  
}
