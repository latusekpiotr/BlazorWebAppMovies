using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models;

public class TodoList
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string? Name { get; set; }

    public List<TodoItem> Items { get; set; } = new List<TodoItem>();
}