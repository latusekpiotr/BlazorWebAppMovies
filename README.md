# Blazor Web App Movies tutorial sample app

This sample app is the completed app for the Blazor Web App Movies tutorial:

[Build a Blazor movie database app (Overview)](https://learn.microsoft.com/aspnet/core/blazor/tutorials/movie-database-app/)

## Steps to run the sample

This sample app uses an InMemory database for simplicity and works across all platforms.

1. Clone this repository or download a ZIP archive of the repository. For more information, see [How to download a sample](https://learn.microsoft.com/aspnet/core/introduction-to-aspnet-core#how-to-download-a-sample).

2. Build and run the application:
   ```
   dotnet build
   dotnet run
   ```

3. The app uses Entity Framework Core InMemory database provider, so no database setup is required. Sample movie data will be automatically seeded when the application starts.

4. The default URLs for the app are `https://localhost:7073` (secure HTTPs) and `http://localhost:5261` (insecure HTTP).
   
   You can use the existing URLs or update them in the `Properties/launchSettings.json` file.

5. Navigate to the app in your browser to see the movie database functionality.

## Package roll-forward behavior

The NuGet packages referenced in the project file (`.csproj`) aren't necessarily the latest patch package releases. However, patch releases in .NET roll-forward automatically when the app is built and packages are restored. There's no need to update the package versions in the project file to the latest patch releases.

## Clean up

When you're finished with the tutorial, you can simply delete the application folder. Since the app uses an InMemory database, no database cleanup is required.
