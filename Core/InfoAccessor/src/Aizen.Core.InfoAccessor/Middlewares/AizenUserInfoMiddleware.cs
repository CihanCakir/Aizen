using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Aizen.Core.InfoAccessor.Abstraction;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;
using Aizen.Core.Infrastructure.Exception;

namespace Aizen.Core.InfoAccessor.Middlewares
{
    internal class AizenUserInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public AizenUserInfoMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var seyirInfoAccessor = (IAizenInfoAccessor)httpContext.RequestServices.GetRequiredService(typeof(IAizenInfoAccessor));

            if (seyirInfoAccessor.UserInfoAccessor.UserInfo != null)
            {
                await _next(httpContext);
                return;
            }

            AizenUserInfo userInfo = null;
            string token = null;

            if (httpContext?.Request?.Path.Value?.Contains("Authentication/RefreshLogin") == true)
            {
                httpContext.Request.EnableBuffering();
                using (var reader = new StreamReader(httpContext.Request.Body, leaveOpen: true))
                {
                    var body = await reader.ReadToEndAsync();
                    var jObject = JObject.Parse(body);
                    token = jObject["accessToken"]?.ToString();
                    httpContext.Request.Body.Position = 0;
                }
            }
            else if (httpContext?.Request?.Headers != null && httpContext.Request.Headers.ContainsKey("Authorization"))
            {
                token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            }

            if (!string.IsNullOrEmpty(token))
            {
                var isTokenValid = TryGetUserInfoFromToken(token, out userInfo, out string errorMessage);
                if (!isTokenValid)
                {
                    throw new AizenBusinessException(errorMessage);
                }
            }
            else
            {
                userInfo = new AizenUserInfo();
            }

            var container = (IAizenInfoContainer)httpContext.RequestServices.GetRequiredService(typeof(IAizenInfoContainer));
            container.Set(userInfo);

            await _next(httpContext);
        }

        private bool TryGetUserInfoFromToken(string token, out AizenUserInfo userInfo, out string errorMessage)
        {
            userInfo = null;
            errorMessage = string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                errorMessage = "Invalid token.";
                return false;
            }

            // Extract the RefreshTokenExpire claim and check expiration
            var refreshTokenExpireClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "RefreshTokenExpire")?.Value;
            if (refreshTokenExpireClaim == null)
            {
                errorMessage = "RefreshTokenExpire claim is missing.";
                return false;
            }

            if (!DateTime.TryParse(refreshTokenExpireClaim, out DateTime refreshTokenExpireDateTime))
            {
                errorMessage = "Invalid RefreshTokenExpire date format.";
                return false;
            }

            if (refreshTokenExpireDateTime <= DateTime.UtcNow)
            {
                errorMessage = "Refresh token has expired.";
                return false;
            }

            // Extract other user info from token
            userInfo = new AizenUserInfo
            {
                UserId = long.Parse(jwtToken.Claims.First(c => c.Type == "Id").Value),
                ApplicationId = long.Parse(jwtToken.Claims.First(c => c.Type == "ApplicationId").Value),
                TenantId = long.Parse(jwtToken.Claims.First(c => c.Type == "TenantId").Value),
                RoleId = long.Parse(jwtToken.Claims.First(x => x.Type == "RoleId").Value),
                PhoneNumber = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub).Value,
            };

            return true;
        }
    }
}
