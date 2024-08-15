using System.Text;
using Aizen.Core.Auth;
using Aizen.Core.Auth.Abstraction;
using Aizen.Core.Auth.Extension;
using Aizen.Core.Common.Abstraction.Exception;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Aizen.Core.Infrastructure.Auth.Extension
{
    public static class BuilderExtensions
    {
        public static IServiceCollection AddAizenAuth<TUser, TRole, TContext>(
            this IServiceCollection services, WebApplicationBuilder builder)
            where TUser : IdentityUser<int>
            where TRole : IdentityRole<int>
            where TContext : IdentityDbContext<TUser, TRole, int>
        {

            if (services == null)
            {
                throw new AizenException($"ServiceCollection: {nameof(services)} not found.");
            }
            builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenOption"));

            services.AddScoped<IAizenTokenHelper, AizenTokenHelper>();

            services.AddScoped<IAizenUserService, AizenUserService>();

            services.AddScoped(typeof(UserManager<>));

            services.AddScoped(typeof(PasswordValidator<>));

            services.AddScoped(typeof(SignInManager<>));

            builder.Services.AddIdentity<TUser, TRole>(opts =>
                {
                    opts.User.RequireUniqueEmail = false;
                    opts.User.AllowedUserNameCharacters = "0123456789";
                    opts.Password.RequiredLength = 6;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = true;
                })
                 .AddErrorDescriber<AizenCustomIdentityErrorDescriber>()
                 .AddEntityFrameworkStores<TContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options =>
                        {
                            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                            {
                                options.RequireHttpsMetadata = false;
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidIssuer = builder.Configuration["TokenOption:Issuer"],
                                    ValidAudience = builder.Configuration["TokenOption:Audience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOption:SecurityKey"])),


                                    ValidateIssuerSigningKey = true,
                                    ValidateIssuer = true,
                                    ValidateAudience = true,

                                };
                            });



            return services;
        }
    }
}