using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.Models;

namespace BlazorWebAppMovies.Data
{
    public class BlazorWebAppMoviesContext(DbContextOptions<BlazorWebAppMoviesContext> options) : DbContext(options)
    {
        public DbSet<BlazorWebAppMovies.Models.Movie> Movie { get; set; } = default!;
        public DbSet<BlazorWebAppMovies.Models.ToDoList> ToDoList { get; set; } = default!;
        public DbSet<BlazorWebAppMovies.Models.ToDoItem> ToDoItem { get; set; } = default!;
    }
}
