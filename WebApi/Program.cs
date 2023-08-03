using Infrastructure;
using Infrastructure.Assembly;
using Microsoft.Extensions.Configuration;
using WebApi.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add db context
builder.Services.AddDbContext(builder.Configuration["ConnectionString"]);

// Add services to the container.
builder.Services.AddServices();

//add auto mappaer
var applicationAssembly = typeof(AssemblyReferences).Assembly;
builder.Services.AddAutoMapper(applicationAssembly);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//identity config
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
