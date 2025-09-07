using BookTracker.Repositories;
using BookTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Controller;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Book>> GetBooks() => await repository.GetBooksAsync();

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await repository.GetBookByIdAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(Book book)
    {
        var created = await repository.AddBookAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        await repository.UpdateBookAsync(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await repository.DeleteBookAsync(id);
        return NoContent();
    }
}