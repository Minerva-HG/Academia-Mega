using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


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

app.UseHttpsRedirection();
app.Run();