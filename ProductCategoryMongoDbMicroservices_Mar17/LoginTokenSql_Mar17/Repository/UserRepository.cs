using LoginTokenSql_Mar17.DataAccess;
using LoginTokenSql_Mar17.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginTokenSql_Mar17.Repository
{
    public class UserRepository:IUser
    {
        private readonly LoginDbContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(LoginDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public UserDTO loginUser(UserDTO userDTO)
        {
            if(userDTO!=null)
            {
                var LoginCheck=_context.Tlogins.Where(a=>a.UserName==userDTO.UserName && a.Password==userDTO.Password).FirstOrDefault();
                if(LoginCheck!=null)
                {
                    userDTO.Token = GetToken(LoginCheck);
                    return userDTO;
                }
                else
                {
                    throw new Exception("User doesn't exist");
                }
            }
            else
            {
                throw new Exception("Please Enter User Details"); 
            }
        }

        public List<Tlogin> RegisterUser(Tlogin user)
        {
            _context.Tlogins.Add(user);
            _context.SaveChanges();
            return _context.Tlogins.ToList(); 
        }

        private string GetToken(Tlogin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email,user.UserEmail) 
            };

            var tokens = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokens); 
        }
    }
}
