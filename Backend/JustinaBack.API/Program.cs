
using JustinaBack.DAL;
using JustinaBack.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace JustinaBack.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<WebAppContext>(options => options.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 31))
            ));

            //Adding jwt service to program pipeline
            builder.Services.AddJWTTokenServices(builder.Configuration);

            //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<WebAppContext>();
            builder.Services.AddIdentity<UserEF, Role>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<WebAppContext>();

            //Add Automapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            ConfigureSwagger();
            ConfigureDependencyInjection();

            builder.Services.Configure<IdentityOptions>(
                options => options.SignIn.RequireConfirmedEmail = true
            );
                                 
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();              
                SeedDatabase();

                app.UseHttpsRedirection();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();



            void SeedDatabase()
            {

                using var scope = app.Services.CreateScope();
                var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
                dbInitializer.Initialize();
            }


            void ConfigureSwagger()
            {
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                    // Add JWT Authentication
                    var securityScheme = new OpenApiSecurityScheme
                    {
                        Name = "JWT Authentication",
                        Description = "Enter JWT Bearer token **_only_**",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Reference = new OpenApiReference
                        {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme
                        }
                    };
                    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, new string[] { } }
            }
                    );
                });
            }


            void ConfigureDependencyInjection()
            {
                builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
                builder.Services.AddScoped<IDbInitializer, DbInitializer>();
                //builder.Services.AddScoped<ISecurityManager, SecurityManager>();                
                //builder.Services.AddScoped<ICustomerProfileManager, CustomerProfileManager>();

                builder.Services.AddHttpContextAccessor();
            }
        }
    }
}
