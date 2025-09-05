using BookTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTrackerAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", Notes = "Classic adventure", Rating = 5, Status = ReadingStatus.Finished },
            new Book { Id = 2, Title = "1984", Author = "George Orwell", Genre = "Dystopian", Notes = null, Rating = null, Status = ReadingStatus.NotStarted },
            new Book { Id = 3, Title = "Clean Code", Author = "Robert C. Martin", Genre = "Programming", Notes = "Must-read for devs", Rating = 4, Status = ReadingStatus.Reading },
            new Book { Id = 4, Title = "The Hitchhiker's Guide to the Galaxy", Author = "Douglas Adams", Genre = "Science Fiction", Notes = "Don't Panic!", Rating = 5, Status = ReadingStatus.Finished }
        );
    }
}
