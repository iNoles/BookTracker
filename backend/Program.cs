using BookTrackerAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Swagger (optional, nice for testing APIs)
builder.Services.AddEndpointsApiExplorer();

// Add DbContext (using SQLite for simplicity)
var dbPath = Path.Combine(AppContext.BaseDirectory, "booktracker.db");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}")
);

// Enable CORS so Vue frontend (on port 5173) can talk to API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://inoles.github.io/booktracker/")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // creates DB file and tables if missing
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
