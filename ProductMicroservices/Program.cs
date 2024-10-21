using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot();
var app = builder.Build();
builder.Configuration.AddJsonFile("Ocelot.json");
app.UseRouting();
try
{
   
    await app.UseOcelot();
}
catch (Exception ex)
{
    Console.WriteLine($"Error configuring Ocelot: {ex.Message}");
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
