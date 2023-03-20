using LoginTokenSql_Mar17.Commands;
using LoginTokenSql_Mar17.DataAccess;
using LoginTokenSql_Mar17.Models;
using MediatR;

namespace LoginTokenSql_Mar17.Handlers
{
    public class LoginUserHandler:IRequestHandler<LoginUserCommand,UserDTO>
    {
        private readonly IUser _user;
        public LoginUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<UserDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_user.loginUser(request.userDTO)); 
        }
    }
}
