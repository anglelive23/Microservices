var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddOData(opt =>
    {
        opt.AddRouteComponents("gateway/odata", new GatewayDataModel().GetGatewayDataModel());
        opt.Select().Filter().Expand().OrderBy().Count().SetMaxTop(100);
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Grpc
builder.Services.AddScoped<IOffersGrpcDataClient, OffersGrpcDataClient>();
builder.Services.AddScoped<IClientsGrpcDataClient, ClientsGrpcDataClient>();
builder.Services.AddScoped<IProjectsGrpcDataClient, ProjectsGrpcDataClient>();
builder.Services.AddScoped<IEmployeeGrpcDataClient, EmployeeGrpcDataClient>();

// Data
builder.Services.AddDbContext<GatewayContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Cache
builder.Services.AddOutputCache(options =>
{
    // Collections
    options.AddPolicy("Services", policy => policy.Tag("Services").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Projects", policy => policy.Tag("Projects").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Clients", policy => policy.Tag("Clients").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Employees", policy => policy.Tag("Employees").Expire(TimeSpan.FromHours(1)));
    // Single Item
    options.AddPolicy("Service", policy => policy.Tag("Service").SetVaryByQuery("Id").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Project", policy => policy.Tag("Project").SetVaryByQuery("Id").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Client", policy => policy.Tag("Client").SetVaryByQuery("Id").Expire(TimeSpan.FromHours(1)));
    options.AddPolicy("Employee", policy => policy.Tag("Employee").SetVaryByQuery("Id").Expire(TimeSpan.FromHours(1)));
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
