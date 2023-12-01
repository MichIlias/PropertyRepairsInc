using PropertyRepairsIncConsumerAPI;
using PropertyRepairsIncConsumerAPI.Data;
using PropertyRepairsIncConsumerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PropertyRepairsDbContext>();

builder.Services.AddScoped<IHouseService, HouseService>();
builder.Services.AddScoped<IRepairService, RepairService>();
builder.Services.AddLogging();

//builder.Services.AddHostedService<WatcherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
