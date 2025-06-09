using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);



var AllowedOrigin = "BlazorClient";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowedOrigin, policy =>
    {
        policy.WithOrigins("http://localhost:5189")
        .AllowAnyHeader()
        .AllowAnyMethod();
        //.AllowCredentials(); Sólo si usamos una cookie de sesión
    }
    );
}
);


builder.Services.AddControllers();

builder.Services.AddScoped<INotificationService, EmailNotificationService>();
builder.Services.AddScoped<INotificationService, SmsNotificationService>();
builder.Services.AddScoped<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCors(AllowedOrigin);
app.UseHttpsRedirection();
app.Run();