using BookTracker.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add DbContext (using SQLite for simplicity)
var dbPath = Path.Combine(AppContext.BaseDirectory, "booktracker.db");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}")
);

var app = builder.Build();

// Ensure database is created and migrated
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // creates DB file and tables if missing
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map controllers
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
