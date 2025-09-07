using BookTracker.Data;
using BookTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Repositories;

public class BookRepository(AppDbContext context) : IBookRepository
{
    public async Task<IEnumerable<Book>> GetBooksAsync() =>
        await context.Books.ToListAsync();

    public async Task<Book?> GetBookByIdAsync(int id) =>
        await context.Books.FindAsync(id);

    public async Task<Book> AddBookAsync(Book book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }

    public async Task UpdateBookAsync(Book book)
    {
        context.Entry(book).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book != null)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}
