using BookTracker.Controller;
using BookTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTracker.Tests;

public class BooksControllerTests
{
    [Fact]
    public async Task AddBook_ShouldReturnCreated()
    {
        var repo = new FakeBookRepository();
        var controller = new BooksController(repo);

        var book = new Book { Title = "Test Book", Author = "X" };

        var result = await controller.AddBook(book);

        // Assert the response type
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);

        // Assert the returned book inside the CreatedAtActionResult
        var returnedBook = Assert.IsType<Book>(createdResult.Value);
        Assert.Equal("Test Book", returnedBook.Title);

        // Assert the repo actually saved the book
        var books = await repo.GetBooksAsync();
        Assert.Single(books);
        Assert.Equal("Test Book", books.First().Title);
    }

    [Fact]
    public async Task GetBook_ShouldReturnNotFound_WhenMissing()
    {
        var repo = new FakeBookRepository();
        var controller = new BooksController(repo);

        var result = await controller.GetBook(42);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetBook_ShouldReturnOk_WhenExists()
    {
        var repo = new FakeBookRepository();
        var controller = new BooksController(repo);

        await repo.AddBookAsync(new Book { Title = "Book A", Author = "Someone" });

        var result = await controller.GetBook(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBook = Assert.IsType<Book>(okResult.Value);

        Assert.Equal("Book A", returnedBook.Title);
    }
}
