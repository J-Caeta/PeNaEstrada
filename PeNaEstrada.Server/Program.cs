using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeNaEstrada.Infrastructure.Identity;
using PeNaEstrada.Infrastructure.Persistence;
using PeNaEstrada.Server.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly("PeNaEstrada.Infrastructure")));

builder.Services.AddIdentity < ApplicationUser, IdentityRole > ()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


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