# Running the service
## Prerequisites
- [Git](https://git-scm.com/downloads)
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)

## Instructions
1. Clone the repository to your local machine using Git
2. In a terminal (e.g. Windows Command Prompt), navigate to the root of the repository and run the following command:

    `dotnet watch run --project src\pokedex`
3. The solution will build/run and open a browser to the Swagger UI where you can execute the two endpoints:
    - `GET /pokemon/{pokemonName}`
    - `GET /pokemon/translated/{pokemonName}`
4. Alternatively you can make API requests with any client of your choice (e.g. Postman) to the URL that the service is running on (this is configured by default to be http://localhost:5083/)

# Changes if used in production
- Implement a caching decorator on `IPokemonRepository` and `IPokemonTranslatorService` to avoid excessive API calls.
    - If the service is deployed on a single instance then use an in memory cache implementation.
    - If the service is deployed across multiple instances then consider using a distributed cache e.g. Redis.
- Store sensitive configuration e.g. API key for FunTranslations in a secure resource e.g. Azure Key Vault / AWS Secrets Manager.
- If there was future business requirements which involves extending the `Pokedex.Common.Models.Pokemon` class (e.g. for internal processing), consider introducing a `Pokemon` View Model to ensure only necessary properties are being exposed to the client.
    - On a similar note, consider using a mapping library such as AutoMapper to avoid adding unnecessary mapping code (providing the property names are the same between models).
- Use a different logging provider such as [Microsoft.Extensions.Logging.ApplicationInsights ](https://www.nuget.org/packages/Microsoft.Extensions.Logging.ApplicationInsights) to ensure other team members and departments (e.g. App Support) can monitor the application.
- Add a `ApplicationInsights.config` file to ensure that request and dependencies telemetry can be viewed within the Application Insights Azure resource to ease the process of monitoring and investigating production issues.
- Writing and running automated availability tests for the `GET /pokemon/{pokemonName}` and `GET /pokemon/translated/{pokemonName}` endpoints and run them on a frequent schedule (every minute?) in production to ensure the highest availability SLA possible.
- Configure HTTPS
- Pay Fun Translations for unlimited API calls :)