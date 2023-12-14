using System.Reflection;
using API.Extension;
using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.ConfigureRateLimiting();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.ConfigureCors();
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DotnetContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("MySQLConex");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseIpRateLimiting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();