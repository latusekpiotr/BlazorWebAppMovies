using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models;

public class ToDoList
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string? Name { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public List<ToDoItem> Items { get; set; } = new();
}