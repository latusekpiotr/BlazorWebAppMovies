# BlazorWebAppMovies - Comprehensive Movie Database & Utility Application

BlazorWebAppMovies is a feature-rich **Blazor Server application** built with **.NET 8** that serves as both a movie database management system and a multi-purpose utility platform. This application demonstrates modern web development practices with Blazor while providing practical functionality for managing movies, weather information, to-do lists, and insurance quotes.

Originally based on the [Build a Blazor movie database app tutorial](https://learn.microsoft.com/aspnet/core/blazor/tutorials/movie-database-app/), this application has been significantly enhanced with additional features and modern styling.

## Key Features

### 🎬 Movie Database Management
- **Complete CRUD Operations**: Create, read, update, and delete movies with comprehensive details
- **Advanced Search & Filtering**: Real-time search functionality with title-based filtering
- **Data Validation**: Robust client and server-side validation for all movie fields
- **Modern UI**: Stylish, user-friendly interface with improved styling and responsive design
- **Pagination**: Efficient data browsing with QuickGrid pagination controls
- **Movie Details**: Track title, release date, genre, price, and MPAA rating for each movie

### 🌤️ Live Weather Information
- **Real-time Weather Data**: Current weather conditions for London, UK using the Open-Meteo API
- **Temperature Display**: Shows both Celsius and Fahrenheit temperatures
- **Weather Summaries**: Descriptive weather conditions and forecasts
- **No API Key Required**: Utilizes free Open-Meteo service for reliable weather data

### ✅ To-Do List Management
- **Multiple Lists**: Create and manage multiple to-do lists or shopping lists
- **List Organization**: Each list has a customizable name for easy identification
- **Item Management**: Add, edit, and remove items from any list
- **Persistent Storage**: All lists and items are saved in the database
- **User-Friendly Interface**: Intuitive design for efficient task management

### 🏠 MyFlood Insurance Integration
- **Residential Quote Requests**: Submit insurance quote requests through MyFlood API integration
- **Comprehensive Property Details**: Input location, property details, and risk factors
- **Smart Form Controls**: Dropdown selections for enum values with pre-defined options
- **Quick Testing**: "Load dummy data" button for easy form testing and demonstration
- **Error Handling**: Detailed error messages from API responses for troubleshooting
- **Quote Results Display**: Formatted presentation of successful quote responses

### 🔧 Additional Utilities
- **Interactive Counter**: Sample component demonstrating Blazor's interactive capabilities
- **Responsive Design**: Bootstrap 5-based UI that works on all device sizes
- **Real-time Updates**: SignalR-powered live updates across all interactive components

## Technology Stack

- **Framework**: .NET 8
- **Application Type**: Blazor Server App with server-side rendering and SignalR real-time communication
- **Database**: Entity Framework Core with InMemory database provider
- **UI Framework**: Bootstrap 5 with custom CSS styling
- **Data Components**: Microsoft QuickGrid for advanced data display and pagination
- **External APIs**: Open-Meteo Weather API, MyFlood Insurance API
- **Hosting**: Configured for Azure App Service deployment with Bicep infrastructure templates

## Steps to Run the Application

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- A web browser (Chrome, Firefox, Safari, or Edge)

### Quick Start

1. **Clone the Repository**: 
   ```bash
   git clone https://github.com/latusekpiotr/BlazorWebAppMovies.git
   cd BlazorWebAppMovies
   ```
   
   Or download a ZIP archive of the repository. For more information, see [How to download a sample](https://learn.microsoft.com/aspnet/core/introduction-to-aspnet-core#how-to-download-a-sample).

2. **Build and Run**: 
   ```bash
   dotnet build
   dotnet run
   ```

3. **Database Setup**: The app uses Entity Framework Core InMemory database provider, so no database setup is required. Sample data will be automatically seeded when the application starts, including:
   - Pre-loaded movie collection (Mad Max series)
   - Sample to-do lists with items
   - Demo data for testing all features

4. **Access the Application**: The default URLs are:
   - `https://localhost:7073` (secure HTTPS)
   - `http://localhost:5261` (insecure HTTP)
   
   You can customize these URLs in the `Properties/launchSettings.json` file.

5. **Explore the Features**: Navigate through the tabs to explore:
   - **Movies**: Browse, search, and manage the movie database
   - **Weather**: View current weather conditions for London, UK
   - **To-Do**: Manage your to-do lists and shopping lists
   - **MyFlood**: Request residential insurance quotes (uses demo API)
   - **Counter**: Interactive counter demonstration

## Application Structure

The application follows Blazor best practices with a clean, component-based architecture:

```
BlazorWebAppMovies/
├── Components/
│   ├── Layout/           # Layout components (MainLayout, NavMenu)
│   ├── Pages/            # Routable page components
│   │   └── MoviePages/   # Movie CRUD operations
│   └── App.razor         # Root application component
├── Data/                 # Entity Framework context and seeding
├── Models/               # Entity models and DTOs
├── wwwroot/              # Static assets (CSS, JavaScript, images)
├── infrastructure/       # Azure deployment (Bicep templates)
└── Program.cs            # Application startup and configuration
```

## Configuration

### API Settings
The application integrates with external APIs through configuration:

- **Open-Meteo API**: No configuration required (free service)
- **MyFlood API**: Base URL configured in `appsettings.json`
  ```json
  {
    "MyFloodApi": {
      "BaseUrl": "https://myflood.fake.url.com/"
    }
  }
  ```

### Database Configuration
The InMemory database is configured for both development and production environments, making deployment simple without external database dependencies.

## Development Features

### Code Quality & Architecture
- **Component-based Design**: Modular Blazor components for maintainability
- **Dependency Injection**: Proper service registration and lifetime management
- **Data Validation**: Comprehensive validation using Data Annotations
- **Error Handling**: Graceful error handling with user-friendly messages
- **Responsive Design**: Mobile-first approach with Bootstrap 5

### Real-time Capabilities
- **SignalR Integration**: Live updates and real-time communication
- **Interactive Components**: Server-side interactivity with minimal JavaScript
- **State Management**: Efficient state handling across components

### Deployment Ready
- **Azure Integration**: Infrastructure as Code with Bicep templates
- **CI/CD Pipelines**: GitHub Actions workflows for automated deployment
- **Environment Configuration**: Separate settings for development and production
- **Linux Container Support**: Optimized for Azure App Service Linux containers

## Learning Resources

This application serves as an excellent learning resource for:
- **Blazor Server Development**: Real-world examples of Blazor patterns and best practices
- **Entity Framework Core**: Database operations with Code First approach
- **API Integration**: Consuming external REST APIs with proper error handling
- **Modern Web UI**: Bootstrap 5 styling and responsive design techniques
- **Azure Deployment**: Cloud deployment strategies and infrastructure automation

## Support & Documentation

For detailed development guidelines and project-specific instructions, see:
- [.github/copilot-instructions.md](.github/copilot-instructions.md) - Comprehensive development guidelines
- [Microsoft Blazor Documentation](https://docs.microsoft.com/aspnet/core/blazor/) - Official Blazor resources
- [Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.0/) - UI framework reference

## Package Management

### NuGet Package Behavior
The NuGet packages referenced in the project file (`.csproj`) aren't necessarily the latest patch package releases. However, patch releases in .NET roll-forward automatically when the app is built and packages are restored. There's no need to update the package versions in the project file to the latest patch releases.

### Key Dependencies
- **Microsoft.EntityFrameworkCore.InMemory**: In-memory database provider
- **Microsoft.AspNetCore.Components.QuickGrid**: Advanced data grid functionality
- **Microsoft.Extensions.Http**: HTTP client factory for API integrations

## Cleanup

When you're finished with the application, you can simply delete the application folder. Since the app uses an InMemory database, no database cleanup is required. All data is automatically cleared when the application stops.

## Contributing

This project welcomes contributions and suggestions. Whether you're fixing bugs, adding features, or improving documentation, your contributions help make this sample application more valuable for the community.

## License

This project is provided as a sample application for educational purposes. Feel free to use it as a foundation for your own Blazor applications.
