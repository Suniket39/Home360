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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:4200",         // Your development computer
                    "http://192.168.1.15:4200"       // Change this to your actual IoT device/computer IP
                )
                .AllowAnyHeader()
                .AllowAnyMethod()

                // 2. CRITICAL: This allows the browser to accept and send the refresh token cookie
                .AllowCredentials();
        });
});

builder.Services.AddControllers();
//builder.Services.AddDistributedMemoryCache();
builder.Services.AddDataProtection();
//builder.Services.AddSession();

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAngular");
//app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

//Custom Middleware
//app.UseMiddleware<ShortCircuitingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();