using BookTrackerAPI.Data;
using BookTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookTrackerAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class BooksController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Book>> GetBooks() => await context.Books.ToListAsync();

    [HttpPost]
    public async Task<IActionResult> AddBook(Book book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        context.Entry(book).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null) return NotFound();
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return NoContent();
    }
}