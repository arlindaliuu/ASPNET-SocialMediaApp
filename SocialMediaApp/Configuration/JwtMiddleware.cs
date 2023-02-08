using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SocialMediaApp.Configuration
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        public async Task Invoke(HttpContext context, SocialNetworkDbContext service)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if(token != null)
            {
                await DecomposeTokenAndAtachUserToContext(token, context, service);
            }
            await _next(context);
        }
        private async Task DecomposeTokenAndAtachUserToContext(string token, HttpContext context, SocialNetworkDbContext service)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validateToken);
                var jwtToken = (JwtSecurityToken)validateToken;
                var userEmail = jwtToken.Claims.First(x => x.Type == "Email").Value;

                context.Items["User"] = await service.Users.Where(user => user.Email == userEmail).FirstAsync();
            }
            catch
            {

            }
        }
    }
}
