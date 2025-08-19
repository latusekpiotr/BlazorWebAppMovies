using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.Models;

namespace BlazorWebAppMovies.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new BlazorWebAppMoviesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BlazorWebAppMoviesContext>>());

        if (context == null || context.Movie == null)
        {
            throw new NullReferenceException(
                "Null BlazorWebAppMoviesContext or Movie DbSet");
        }

        if (context.Movie.Any())
        {
            return;
        }

        context.Movie.AddRange(
            new Movie
            {
                Title = "Mad Max",
                ReleaseDate = new DateOnly(1979, 4, 12),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 2.51M,
                Rating = "R",
            },
            new Movie
            {
                Title = "The Road Warrior",
                ReleaseDate = new DateOnly(1981, 12, 24),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 2.78M,
                Rating = "R",
            },
            new Movie
            {
                Title = "Mad Max: Beyond Thunderdome",
                ReleaseDate = new DateOnly(1985, 7, 10),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 3.55M,
                Rating = "PG-13",
            },
            new Movie
            {
                Title = "Mad Max: Fury Road",
                ReleaseDate = new DateOnly(2015, 5, 15),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 8.43M,
                Rating = "R",
            },
            new Movie
            {
                Title = "Furiosa: A Mad Max Saga",
                ReleaseDate = new DateOnly(2024, 5, 24),
                Genre = "Sci-fi (Cyberpunk)",
                Price = 13.49M,
                Rating = "R",
            });

        // Add sample todo lists and items
        var groceryList = new TodoList { Name = "Grocery Shopping" };
        var workList = new TodoList { Name = "Work Tasks" };
        var homeList = new TodoList { Name = "Home Improvements" };

        context.TodoList.AddRange(groceryList, workList, homeList);
        context.SaveChanges(); // Save to get the IDs

        context.TodoItem.AddRange(
            // Grocery Shopping items
            new TodoItem { Name = "Buy milk", IsCompleted = false, TodoListId = groceryList.Id },
            new TodoItem { Name = "Get bread", IsCompleted = true, TodoListId = groceryList.Id },
            new TodoItem { Name = "Pick up vegetables", IsCompleted = false, TodoListId = groceryList.Id },
            new TodoItem { Name = "Buy coffee", IsCompleted = false, TodoListId = groceryList.Id },

            // Work Tasks items
            new TodoItem { Name = "Complete project proposal", IsCompleted = true, TodoListId = workList.Id },
            new TodoItem { Name = "Review code changes", IsCompleted = false, TodoListId = workList.Id },
            new TodoItem { Name = "Attend team meeting", IsCompleted = false, TodoListId = workList.Id },

            // Home Improvements items
            new TodoItem { Name = "Fix leaky faucet", IsCompleted = false, TodoListId = homeList.Id },
            new TodoItem { Name = "Paint bedroom", IsCompleted = false, TodoListId = homeList.Id },
            new TodoItem { Name = "Clean garage", IsCompleted = true, TodoListId = homeList.Id }
        );

        context.SaveChanges();
    }
}
