var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

//app.MapGet("/saludo", () => "Hola esta es mi primera API");

app.UseHttpsRedirection();
app.MapControllers();
app.Run();