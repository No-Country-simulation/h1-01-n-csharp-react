using API;
using Core;
using Domain.Entities.Users;
using Infrastructure;
using Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
});

//CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // JWT
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Auth Bearer Scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement
   {
      {
        securitySchema, new[] {"Bearer"}
      }
   };

    c.AddSecurityRequirement(securityRequirement);
});

builder.Services.AddCoreServiceCollection();
builder.Services.AddMappingsServiceCollection();
builder.Services.AddInfrastructureServiceCollection(builder.Configuration);
builder.Services.AddAPIServiceCollection();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

#region Roles
//Roles

using (var scope = app.Services.CreateScope())
{
    var roleManager =
        scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

    //If modified, make sure to check UserRoles in DTOs layer -> Register -> UserRoles
    var roles = new[] { "Admin", "Medic", "Patient", "Healthcare", "Lab", "GovEnt" };

    foreach (var role in roles)
    {
        //This conditional ensures the roles are unique
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new ApplicationRole(role));
    }
}


#endregion

#region Admin

using (var scope = app.Services.CreateScope())
{
    //Creating a default admin user with Admin role, one time
    var userManager =
        scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string email = "admin@admin.com";
    string password = "Admin123-";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new ApplicationUser();
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;
        user.Address = "";

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}
#endregion

app.Run();
