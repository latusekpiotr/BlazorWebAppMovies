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

        // Seed Movies
        if (!context.Movie.Any())
        {
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
        }

        // Seed To-Do Lists and Items
        if (!context.ToDoList.Any())
        {
            var groceryList = new ToDoList
            {
                Name = "Grocery Shopping",
                CreatedDate = DateTime.Now.AddDays(-3)
            };

            var workTasks = new ToDoList
            {
                Name = "Work Tasks",
                CreatedDate = DateTime.Now.AddDays(-1)
            };

            var personalTasks = new ToDoList
            {
                Name = "Personal To-Do",
                CreatedDate = DateTime.Now
            };

            context.ToDoList.AddRange(groceryList, workTasks, personalTasks);
            context.SaveChanges(); // Save to get IDs for items

            context.ToDoItem.AddRange(
                // Grocery items
                new ToDoItem { Name = "Milk", ToDoListId = groceryList.Id, IsCompleted = true, CreatedDate = DateTime.Now.AddDays(-3) },
                new ToDoItem { Name = "Bread", ToDoListId = groceryList.Id, IsCompleted = true, CreatedDate = DateTime.Now.AddDays(-3) },
                new ToDoItem { Name = "Eggs", ToDoListId = groceryList.Id, IsCompleted = false, CreatedDate = DateTime.Now.AddDays(-3) },
                new ToDoItem { Name = "Apples", ToDoListId = groceryList.Id, IsCompleted = false, CreatedDate = DateTime.Now.AddDays(-2) },
                
                // Work items
                new ToDoItem { Name = "Review pull request", ToDoListId = workTasks.Id, IsCompleted = true, CreatedDate = DateTime.Now.AddDays(-1) },
                new ToDoItem { Name = "Update documentation", ToDoListId = workTasks.Id, IsCompleted = false, CreatedDate = DateTime.Now.AddDays(-1) },
                new ToDoItem { Name = "Plan sprint meeting", ToDoListId = workTasks.Id, IsCompleted = false, CreatedDate = DateTime.Now },
                
                // Personal items
                new ToDoItem { Name = "Call dentist", ToDoListId = personalTasks.Id, IsCompleted = false, CreatedDate = DateTime.Now },
                new ToDoItem { Name = "Fix leaky faucet", ToDoListId = personalTasks.Id, IsCompleted = false, CreatedDate = DateTime.Now },
                new ToDoItem { Name = "Plan weekend trip", ToDoListId = personalTasks.Id, IsCompleted = false, CreatedDate = DateTime.Now }
            );
        }

        context.SaveChanges();
    }
}
