using Infrastructure;
using Infrastructure.Assembly;
using LoggerService;
using WebApi.Infrastructure.Extensions;
using NLog;
using Infrastructure.Middlewares;

var logger = LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

var builder = WebApplication.CreateBuilder(args);

// Add db context
builder.Services.AddDbContext(builder.Configuration["ConnectionString"]);

// Add services to the container.
builder.Services.AddServices();

//add logging service
builder.Services.ConfigureLoggingService();

//add auto mappaer
var applicationAssembly = typeof(AssemblyReferences).Assembly;
builder.Services.AddAutoMapper(applicationAssembly);

builder.Services.AddControllers();

// add Swagger
builder.Services.ConfigureSwagger();

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

//configure exception middleware
app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();
app.Run();
