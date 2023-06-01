using ConnOutlineMessenger.BuisnessLogic.Services.Interfaces;
using ConnOutlineMessenger.BuisnessLogic.Tools;
using ConnOutlineMessenger.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConnOutlineMessenger.BuisnessLogic.Services.Realization
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IUserRepository _userRepository;
        public JwtTokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string CreateToken(string email, string password)
        {
            var identity = GetIdentity(email, password);
            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                                issuer: AuthOptions.ISSUER,
                                audience: AuthOptions.AUDIENCE,
                                notBefore: now,
                                claims: identity.Claims,
                                expires: now.Add(TimeSpan.FromDays(AuthOptions.LIFETIME)),
                                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public uint GetUserIdByToken(string tokenString)
        {
            var token = new JwtSecurityToken(tokenString);
            return uint.Parse(token.Payload["Id"].ToString());
        }

        private ClaimsIdentity? GetIdentity(string email, string password)
        {
            var user = _userRepository.GetAll().
                FirstOrDefault(user => user.Email == email && user.Password == HashPasswordTool.HashPassword(password));

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Email", user.Email),
                    new Claim("UserName", user.UserName),
                    new Claim("Id", user.Id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
    public class AuthOptions
    {

        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient";
        public const int LIFETIME = 2;
        public const string KEY = "C*F-JaNdRgUkXp2s5v8y/B?D(G+KbPeS";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
