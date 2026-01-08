using Core.Entities.Concrete;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;

        public JwtHelper(IConfiguration configuration)
        {
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(ApplicationUser user, IList<string> roles)
        {
            // Token expiration süresi
            var expiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

            // Token içerisinde kullanıcıya ait taşımak istediğimiz alanları ekliyoruz
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            // Kullanıcının birden fazla rolü olabileceği için Rol bilgisi üzerinde dönerek tek tek eklenir
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // SecurityKey bilgimizi helper ile gizliyoruz
            var key = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);

            // Gelen key bilgisini Hashliyoruz
            var creds = SigningCredentialsHelper.CreateSigningCredentials(key);

            // Oluşturulan JwtSecurityKey'imin parametleri
            var jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            // Verilen Jwt'yi Token halinde yaz döndür
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Oluşturulan Token'ı döndür
            return new AccessToken
            {
                Token = token,
                Expiration = expiration,
            };
        }
    }
}
