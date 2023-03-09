using EmailService.Service;
using EmailService.Settings;
using Microservices.API.gRPC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Grpc
builder.Services.AddScoped<IOffersGrpcDataClient, OffersGrpcDataClient>();
builder.Services.AddScoped<IClientsGrpcDataClient, ClientsGrpcDataClient>();

// Data
builder.Services.AddDbContext<FutureSystemsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//MailService
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IMailingService, MailingService>();

// Cache
builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("Services", policy => policy.Tag("Services").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Projects", policy => policy.Tag("Projects").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Clients", policy => policy.Tag("Clients").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Employees", policy => policy.Tag("Employees").Expire(TimeSpan.FromHours(1)));
});

//SeriLog
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Cors
builder.Services.AddCors();

Log.Information("Starting web server.");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.UseOutputCache();

app.Run();