using LoginTokenSql_Mar17.Models;

namespace LoginTokenSql_Mar17.DataAccess
{
    public interface IUser
    {
        public UserDTO loginUser(UserDTO userDTO);
        List<Tlogin> RegisterUser(Tlogin user);       
    }
}
