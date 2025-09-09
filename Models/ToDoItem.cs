using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.Models;

public class ToDoItem
{
    public int Id { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string? Name { get; set; }

    public bool IsCompleted { get; set; } = false;

    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public int ToDoListId { get; set; }
    
    public ToDoList? ToDoList { get; set; }
}