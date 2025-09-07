using BookTracker.Models;
using BookTracker.Repositories;

namespace BookTracker.Tests;

public class FakeBookRepository : IBookRepository
{
    private readonly List<Book> _books = [];

    public Task<IEnumerable<Book>> GetBooksAsync() =>
        Task.FromResult(_books.AsEnumerable());

    public Task<Book?> GetBookByIdAsync(int id) =>
        Task.FromResult(_books.FirstOrDefault(b => b.Id == id));

    public Task<Book> AddBookAsync(Book book)
    {
        book.Id = _books.Count + 1;
        _books.Add(book);
        return Task.FromResult(book);
    }

    public Task UpdateBookAsync(Book book)
    {
        var existing = _books.FirstOrDefault(b => b.Id == book.Id);
        if (existing != null)
        {
            existing.Title = book.Title;
            existing.Author = book.Author;
        }
        return Task.CompletedTask;
    }

    public Task DeleteBookAsync(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book != null) _books.Remove(book);
        return Task.CompletedTask;
    }
}