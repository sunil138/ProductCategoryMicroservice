using LoginTokenSql_Mar17.Commands;
using LoginTokenSql_Mar17.DataAccess;
using LoginTokenSql_Mar17.Models;
using MediatR;

namespace LoginTokenSql_Mar17.Handlers
{
    public class RegisterUserHandler:IRequestHandler<RegisterUserCommand,List<Tlogin>>
    {
        private readonly IUser _user;
        public RegisterUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<List<Tlogin>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_user.RegisterUser(request.user)); 
        }
    }
}
