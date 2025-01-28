using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PcPartsStore.Application.Contracts.Infrastructure;
using PcPartsStore.Identity.Models;
using PcPartsStore.Identity.Token;

namespace PcPartsStore.Identity
{
    public static class IdentityServiceExtension
    {
        public static void AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PcPartsStoreIdentityDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("PcPartsStoreIdentity")));

            services.AddIdentity<AppUser, IdentityRole>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<PcPartsStoreIdentityDbContext>();

            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme =
                opts.DefaultChallengeScheme =
                opts.DefaultForbidScheme =
                opts.DefaultScheme =
                opts.DefaultSignInScheme =
                opts.DefaultSignOutScheme =
                         JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
                };
            });

            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
