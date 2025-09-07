namespace BookTracker.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public int? Rating { get; set; } // 1-5 stars

    public ReadingStatus Status { get; set; } = ReadingStatus.NotStarted;
}
