# CQRS and MediatR ASP.NET Core Web API

## Overview

This project demonstrates how to implement the CQRS (Command Query Responsibility Segregation) pattern along with MediatR in an ASP.NET Core Web API. CQRS and MediatR are used to separate the handling of commands (which modify state) and queries (which retrieve data), leading to better scalability, maintainability, and testability of the application.

## Why Use CQRS and MediatR?

### CQRS Benefits

- **Separation of Concerns**: CQRS separates the operations that modify data (commands) from those that retrieve data (queries), making each aspect easier to manage and understand.
- **Optimized Data Access**: Different models can be used for reading and writing data, optimizing performance and scalability.
- **Scalability**: By separating reads and writes, you can scale them independently based on the needs of your application.
- **Security and Validation**: Clear separation allows for better control over security and validation, ensuring that commands and queries are handled appropriately.
- **Simplified Testing**: Easier to test commands and queries separately due to their distinct responsibilities.

### MediatR Benefits

- **Decoupling**: MediatR helps in decoupling components by acting as a mediator between requests and handlers, leading to a more maintainable codebase.
- **Centralized Request Handling**: All requests go through MediatR, enabling centralized handling of cross-cutting concerns like logging and validation.
- **Pipeline Behaviors**: Supports behaviors (middleware) to handle common tasks uniformly across requests.
- **Improved Readability**: Commands and queries are handled by separate classes, making the code more organized and readable.
- **Asynchronous Handling**: Facilitates asynchronous processing of requests, improving performance.

## Dependencies

- **ASP.NET Core**: The web framework for building the API.
- **MediateR**: Provides the mediator pattern for handling commands and queries.
- **Microsoft.EntityFrameworkCore.InMemory**: In-memory database for data storage (used for development and testing).

### NuGet Packages

- `MediatR` - `9.1.1` (or latest version)
- `MediatR.Extensions.Microsoft.DependencyInjection` - `11.0.0` (or latest version)
- `Microsoft.EntityFrameworkCore.InMemory` - `8.0.0` (or latest version)

## Setup Instructions

### 1. Clone the Repository

```sh
git clone https://github.com/yourusername/your-repository.git
cd your-repository
```

### Install Dependencies

Ensure you have the required NuGet packages installed. You can use the `.csproj` file to manage dependencies or use the following commands:

```sh
dotnet add package MediatR --version 10.0.0
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection --version 10.0.0
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 8.0.0
```

## How It Works

### Command and Query Handling

- **Commands**: Represent actions that change the state of the system. Examples include:
  - `CreatePlayerCommand`: Command to create a new player.
  - `UpdatePlayerCommand`: Command to update an existing player’s details.
  - `DeletePlayerCommand`: Command to delete a player from the database.
  
  Commands are processed by corresponding handlers that implement the logic for executing these actions.

- **Queries**: Represent requests that retrieve data without modifying it. Examples include:
  - `GetAllPlayersQuery`: Query to retrieve all players.
  - `GetPlayerByIdQuery`: Query to retrieve a player by their ID.
  
  Queries are handled by specific handlers that return the requested data.

### MediatR Mediation

- **Sending Requests**: 
  - When a command or query is sent via MediatR, it is routed to the appropriate handler. 
  - MediatR acts as a mediator, ensuring that the request is handled by the correct handler.

- **Handlers**:
  - Implement the logic for processing commands and queries.
  - For instance, `CreatePlayerHandler` processes the creation of a new player, while `GetAllPlayersHandler` retrieves all player data.

- **Pipeline Behaviors**:
  - MediatR allows for the addition of behaviors (middleware) that can handle cross-cutting concerns such as logging, validation, and authorization.
  - These behaviors are applied to all requests and can be used to enforce policies consistently across the application.

### Example Workflow

1. **Create a Player**:
   - The client sends a `POST` request to `/api/players` with a `CreatePlayerCommand` containing player details.
   - MediatR routes the command to `CreatePlayerHandler`.
   - `CreatePlayerHandler` processes the request, updates the in-memory database, and returns the ID of the newly created player.

2. **Retrieve Players**:
   - The client sends a `GET` request to `/api/players`.
   - MediatR routes the `GetAllPlayersQuery` to `GetAllPlayersHandler`.
   - `GetAllPlayersHandler` retrieves the list of all players from the in-memory database and returns it.

3. **Update a Player**:
   - The client sends a `PUT` request to `/api/players/{id}` with an `UpdatePlayerCommand` containing updated player details.
   - MediatR routes the command to `UpdatePlayerHandler`.
   - `UpdatePlayerHandler` processes the request, updates the player information in the database, and confirms the update.

4. **Delete a Player**:
   - The client sends a `DELETE` request to `/api/players/{id}` with a `DeletePlayerCommand`.
   - MediatR routes the command to `DeletePlayerHandler`.
   - `DeletePlayerHandler` processes the request, removes the player from the in-memory database, and confirms the deletion.



<hr>

<p align="center">
  Developer: <a href="mailto:mehedihasan9339@gmail.com">Mehedi Hasan</a>
</p>
