using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeNaEstrada.Infrastructure.Identity;
using PeNaEstrada.Infrastructure.Persistence;
using PeNaEstrada.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;               
using System.Text;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("PeNaEstrada.Infrastructure")));

builder.Services.AddIdentity < ApplicationUser, IdentityRole > ()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        // Pega os dados do appsettings.json
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
        )
    };
});

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
options.AddPolicy("AllowAll", policy=>
        {

    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
});
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TokenService>();

builder.Services.AddScoped<PeNaEstrada.Application.Interfaces.IExperienciaRepository, PeNaEstrada.Infrastructure.Persistence.Repositories.ExperienciaRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();