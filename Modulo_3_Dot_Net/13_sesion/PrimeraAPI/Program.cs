using PrimeraAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<UsuarioService>();

//Middleware ...
var KeyString = builder.Configuration["JwtJey"];
 if (string.IsNullOrWhiteSpace(KeyString))
    throw new InvalidOperationException("Falta cnfigurar el jwtkey en el appJson");


var key = Encoding.ASCII.GetBytes(KeyString!);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer( opts =>
        {
            opts.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)                
            };
        }
    );


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();


//@->20250514T0855 Siempre debe de ir al último !!!
app.Run();



