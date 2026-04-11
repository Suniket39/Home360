using Home360.API.Core;
using Home360.API.Core.Extension;
using Home360.API.Core.Middleware;
using Home360.Application;
using Home360.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add JWT Settings from appsettings.json
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

// Register DIs here
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApi();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtHandlerMiddleware>();

builder.Services.AddAuthorization();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

// add JWT Middleware 

app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Custom Middleware

//app.UseMiddleware<ShortCircuitingMiddleware>();

app.MapControllers();

app.Run();