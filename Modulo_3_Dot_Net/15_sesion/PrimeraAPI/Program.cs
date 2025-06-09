using PrimeraAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddSwaggerGen();

// middleware
//var keyString = Encoding.ASCII.GetBytes(builder.Configuration["JwtKey"]);
var jwtKey = builder.Configuration["JwtKey"];
if (string.IsNullOrWhiteSpace(jwtKey))
    throw new InvalidOperationException("Falta configurar el jwtKey en appsettings");

var key = Encoding.ASCII.GetBytes(jwtKey);

//if (string.IsNullOrWhiteSpace(keyString))
//    throw new InvalidOperationException("Falta configurar el jwtKey en appsettings");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
            
        };
    });

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization(); 
app.UseHttpsRedirection();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
