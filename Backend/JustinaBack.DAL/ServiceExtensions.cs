using JustinaBack.Models.Entities.Users;
using JustinaBack.Models;
using JustinaBack.DAL.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace JustinaBack.DAL
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Extension method to register services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Application Db
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<WebAppContext>(options => options.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 31))
            ));

            //Repositories


            // Identity
            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebAppContext>();
            services.AddIdentity<UserEF, Role>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<WebAppContext>();

            services.Configure<IdentityOptions>(
                options => options.SignIn.RequireConfirmedEmail = true
            );

            // JWT
            //Adding jwt service to program pipeline
            services.AddJWTTokenServices(configuration);

            return services;
        }
    }
}
