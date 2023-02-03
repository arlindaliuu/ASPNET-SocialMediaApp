using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMediaApp.Configuration
{
    public class Authentication: IAuthentication
    {
        private readonly AppSettings _appSettings;
        private readonly SocialNetworkDbContext service;
        private readonly IHttpContextAccessor context;
        public Authentication(IOptions<AppSettings> appSettings, SocialNetworkDbContext service, IHttpContextAccessor context)
        {
            _appSettings = appSettings.Value;
            this.service = service;
            this.context = context;
        }   
        public string Authenticate(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {new Claim("Email", email)}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            context.HttpContext.Items["User"] = this.service.Users.Where(u => email == email).FirstOrDefault().Email;
            return tokenHandler.WriteToken(token);
        }
    }
}
