using BookTracker.Models;

namespace BookTracker.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<Book> AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
}
