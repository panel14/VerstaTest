using Microsoft.EntityFrameworkCore;
using OrderTest.Domain.Models;
using OrderTest.ExceptionsUtils;
using OrderTest.Services;
using OrderTest.Services.Implementations;
using OrderTest.Utils.AutoMapperProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy(name: "FrontendUI", 
    policy =>
    {
        policy.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader();
    }));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(OrderMapperProfile));

builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FrontendUI");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
