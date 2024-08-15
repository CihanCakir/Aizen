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
            where TUser : IdentityUser<long>
            where TRole : IdentityRole<long>
            where TContext : IdentityDbContext<TUser, TRole, long>
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
                    opts.User.RequireUniqueEmail = true; // E-posta adreslerinin benzersiz olması gerekiyor
    opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"; // Kullanıcı adında e-posta için gerekli olan karakterler kullanılabilir
                    opts.Password.RequiredLength = 6; // Parolanın en az 6 karakterden oluşması gerekiyor
                    opts.Password.RequireNonAlphanumeric = false; // Parolada sembol kullanımı zorunlu değil
                    opts.Password.RequireLowercase = true; // Parolada en az bir küçük harf bulunmalı
                    opts.Password.RequireUppercase = true; // Parolada en az bir büyük harf bulunmalı
                    opts.Password.RequireDigit = true; // Parolada en az bir rakam bulunmalı
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