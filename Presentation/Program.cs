using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Presentation.Extensions.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientAddressRepository, ClientAddressRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectStatusRepository, ProjectStatusRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectStatusService, ProjectStatusService>();

builder.Services.AddCors(x =>
{
    x.AddPolicy("Strict", x =>
    {
        x.WithOrigins("http://localhost:5173")
        .WithMethods("POST", "GET", "PUT", "DELETE")
        .WithHeaders("Content-Type", "Authorization")
        .AllowCredentials();
    });

    x.AddPolicy("AllowFrontend", x =>
    {
        x.WithOrigins("http://localhost:5173")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(x =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    x.IncludeXmlComments(xmlPath);
});
builder.Services.AddMemoryCache();


var app = builder.Build();

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "AlphaPortal API"));

app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

//app.UseMiddleware<DefaultApiKeyMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
