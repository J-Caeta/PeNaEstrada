// PeNaEstrada.Server/Program.cs

// --- IMPORTAÇÕES NECESSÁRIAS ---
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeNaEstrada.Infrastructure.Identity;     // Nossa classe ApplicationUser
using PeNaEstrada.Infrastructure.Persistence; // Nosso ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAR SERVIÇOS (Injeção de Dependência) ---

// Pega a string de conexão que acabamos de adicionar no appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Adiciona o ApplicationDbContext ao contêiner de serviços
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); // Diz a ele para usar SQL Server

// Adiciona o sistema .NET Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>() // Usa nossas classes
    .AddEntityFrameworkStores < ApplicationV.modelos`?