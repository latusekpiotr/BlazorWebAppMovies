using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models;

public class TodoItem
{
    public int Id { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string? Name { get; set; }

    public bool IsCompleted { get; set; } = false;

    public int TodoListId { get; set; }
    public TodoList? TodoList { get; set; }
}