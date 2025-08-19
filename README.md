# Blazor Web App Movies

A feature-rich Blazor Server web application for managing movie collections with additional utility features. Originally built following the [Build a Blazor movie database app (Overview)](https://learn.microsoft.com/aspnet/core/blazor/tutorials/movie-database-app/) tutorial, this application has been expanded with modern functionality and user-friendly interfaces.

## Features

### 🎬 Movie Database Management
- **Complete CRUD Operations**: Create, view, edit, and delete movies from your collection
- **Advanced Movie Search**: Real-time filtering by movie title
- **Detailed Movie Information**: Track title, release date, genre, price, and MPAA rating
- **Data Validation**: Form validation with proper error handling and user feedback
- **Pagination & Sorting**: Efficient browsing through large movie collections with QuickGrid
- **Pre-seeded Data**: Comes with a curated collection of sci-fi movies (Mad Max series) for demonstration

### 🧮 Interactive Counter
- Simple interactive counter demonstrating Blazor's server-side interactivity

### 🌤️ Weather Information
- Weather data display (currently with sample data, real weather integration planned)

### 🎨 Modern UI/UX
- Responsive Bootstrap-based design
- Clean, professional interface with intuitive navigation
- Form validation with real-time feedback

### 🔧 Technical Features
- **Blazor Server**: Server-side rendering with interactive components
- **Entity Framework Core**: InMemory database for easy setup and deployment
- **Data Seeding**: Automatic database initialization with sample data
- **Component-based Architecture**: Modular, maintainable code structure

## Planned Features

The following features are currently in development or planned for future releases:

### 📝 To-Do Lists Management
- Create and manage multiple to-do or shopping lists
- Add, edit, and remove items from lists
- Organize tasks with custom list names
- Database integration for persistent storage

### 🌍 Real Weather Integration
- Live weather data using Open-Meteo API (no API key required)
- Location search functionality with OpenStreetMap Nominatim API
- Choose custom locations for weather information
- Enhanced user interface for weather display

### 🎨 Enhanced Movie Interface
- Modern, stylish redesign of movie management pages
- Improved table layouts and detail views
- Enhanced user experience with contemporary UI elements
- Mobile-responsive design improvements

### 🏠 Insurance Quote Integration
- MyFlood residential quote request functionality
- Comprehensive property details input forms
- Integration with MyFlood API for real-time quotes
- Error handling and response display
- Quick-fill demo data for testing

## Requirements

- .NET 8.0 or later
- Any modern web browser
- No external database setup required (uses InMemory database)

## Getting Started

This application uses an InMemory database for simplicity and works across all platforms with no additional setup required.

1. Clone this repository or download a ZIP archive of the repository. For more information, see [How to download a sample](https://learn.microsoft.com/aspnet/core/introduction-to-aspnet-core#how-to-download-a-sample).

2. Build and run the application:
   ```
   dotnet build
   dotnet run
   ```

3. The application uses Entity Framework Core InMemory database provider, so no database setup is required. Sample sci-fi movie data (Mad Max series) will be automatically seeded when the application starts.

4. The default URLs for the application are `https://localhost:7073` (secure HTTPS) and `http://localhost:5261` (insecure HTTP).
   
   You can use the existing URLs or update them in the `Properties/launchSettings.json` file.

5. Navigate to the application in your browser to explore:
   - **Home**: Welcome page
   - **Counter**: Interactive counter demonstration
   - **Weather**: Weather information display
   - **Movies**: Complete movie database management with search, filtering, and CRUD operations

## Movie Data Model

Each movie in the database contains the following information:
- **Title**: Movie name (3-60 characters, required)
- **Release Date**: When the movie was released
- **Genre**: Movie category with validation (letters, spaces, hyphens, parentheses)
- **Price**: Cost information (0-100, currency format)
- **Rating**: MPAA rating (G, PG, PG-13, R, NC-17)

## Technology Stack

- **Frontend**: Blazor Server with Razor components
- **Backend**: ASP.NET Core 8.0
- **Database**: Entity Framework Core with InMemory provider
- **UI Framework**: Bootstrap for responsive design
- **Data Grid**: QuickGrid component for efficient data display
- **Validation**: Data Annotations for form validation
- **Architecture**: Component-based with dependency injection

## Package roll-forward behavior

The NuGet packages referenced in the project file (`.csproj`) aren't necessarily the latest patch package releases. However, patch releases in .NET roll-forward automatically when the app is built and packages are restored. There's no need to update the package versions in the project file to the latest patch releases.

## Clean up

When you're finished exploring the application, you can simply delete the application folder. Since the application uses an InMemory database, no database cleanup is required - all data is automatically cleared when the application stops.

## Contributing

This project welcomes contributions! Feel free to:
- Report bugs or request features via GitHub Issues
- Submit pull requests for improvements
- Suggest new functionality or enhancements

## Learn More

- [ASP.NET Core Blazor Documentation](https://learn.microsoft.com/aspnet/core/blazor/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/ef/core/)
- [Bootstrap Documentation](https://getbootstrap.com/docs/)
