using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Middleware;
using TaskTracker.Application.Profiles;
using TaskTracker.Application.Services;
using TaskTracker.Infrastructure.Data;
using TaskTracker.Infrastructure.Interfaces;
using TaskTracker.Infrastructure.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .MinimumLevel.Error()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddDbContext<TaskTrackerDbContext>(options =>
    options.UseInMemoryDatabase("TaskTrackerDb"));


builder.Services.AddAutoMapper(typeof(TaskTrackerProfile));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
       policy => policy.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod());

});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });


var app = builder.Build();
app.UseCors("AllowFrontend");
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskTrackerDbContext>();
    context.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();



app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
