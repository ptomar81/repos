using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Extensions
{
    /// <summary>
    /// JWT Authentication Service Extensions
    /// </summary>
    public static class JWTServiceExtensions
    {
        /// <summary>
        /// Adds JWTAuthentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            return services;
        }

        //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
        //services.AddAuthentication(x =>
        //{
        //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //})
        //.AddJwtBearer(x =>
        //{
        //    x.Events = new JwtBearerEvents
        //    {
        //        OnTokenValidated = context =>
        //        {
        //            var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
        //            var userId = int.Parse(context.Principal.Identity.Name);
        //            var user = userService.GetById(userId);
        //            if (user == null)
        //            {
        //                // return unauthorized if user no longer exists
        //                context.Fail("Unauthorized");
        //            }
        //            return Task.CompletedTask;
        //        }
        //    };
        //    x.RequireHttpsMetadata = false;
        //    x.SaveToken = true;
        //    x.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuerSigningKey = true,
        //        IssuerSigningKey = new SymmetricSecurityKey(key),
        //        ValidateIssuer = false,
        //        ValidateAudience = false
        //    };
        //});

    }
}
