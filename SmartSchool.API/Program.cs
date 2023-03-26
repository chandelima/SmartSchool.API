using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Utils;

var builder = WebApplication.CreateBuilder(args);

// -- SERVICES --

// DbContext:
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(
    context => context.UseSqlite(connectionString));

// Controllers:
builder.Services.AddControllers(context => context.UseRoutePrefix("api"));

// OpenAPI/Swagger:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// -- HTTP REQUEST PIPELINE --
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
