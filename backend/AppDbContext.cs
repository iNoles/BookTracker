using Microsoft.EntityFrameworkCore;

namespace BookTrackerAPI;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", Genre = "Fantasy", IsRead = true },
            new Book { Id = 2, Title = "1984", Author = "George Orwell", Genre = "Dystopian", IsRead = false },
            new Book { Id = 3, Title = "Clean Code", Author = "Robert C. Martin", Genre = "Programming", IsRead = false }
        );
    }
}
