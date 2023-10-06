using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Ticket_Reservation_system.Models;
using Ticket_Reservation_system.Models.TrainModel;
using Ticket_Reservation_system.Models.TravelerModule;
using Ticket_Reservation_system.Services;
using Ticket_Reservation_system.Services.TrainService;
using Ticket_Reservation_system.Services.TravelerService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Student Service container
builder.Services.Configure<StudentStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(StudentStoreDatabaseSettings)));

builder.Services.AddSingleton<IStudentStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<StudentStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("StudentStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IStudentService, StudentService>();

// Train Service container
builder.Services.Configure<TrainStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(TrainStoreDatabaseSettings)));

builder.Services.AddSingleton<ITrainStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<TrainStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("TrainStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ITrainService, TrainService>();



// traveler Service container

builder.Services.Configure<TravelerStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(TravelerStoreDatabaseSettings)));

builder.Services.AddSingleton<ITravelerStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<TravelerStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("TravelerStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ITravelerService, TravelerService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
