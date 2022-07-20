using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Extensions;
using ProductApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureProductWrapper();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.OperationFilter<AddCustomHeaderParameter>();
    });

builder.Services.AddDbContext<ProductDBContext>(
    s => s.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddHealthChecks();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/Ok").AllowAnonymous();
app.MapDefaultControllerRoute().RequireAuthorization();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();

