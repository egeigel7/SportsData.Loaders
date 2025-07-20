# SportsData NbaDataLoaders

## Overview

**NbaDataLoaders** is a cloud-native, enterprise-grade Azure Function App designed to ingest, process, and persist NBA data from third-party APIs into a Cosmos DB database. This data pipeline abstracts away the source data provider, enabling a clean separation of concerns and supporting a CQRS (Command Query Responsibility Segregation) architecture. The loaded data is then surfaced through a read-only Sports Data API, ensuring optimal performance and scalability for downstream consumers.

This project exemplifies modern software engineering best practices, including SOLID principles, Domain-Driven Design (DDD), and the repository pattern. It is architected for extensibility, testability, and maintainability, making it an ideal showcase for senior engineering skills.

---

## Purpose

- **Abstract and decouple** third-party NBA data sources from the core application logic.
- **Ingest and transform** NBA game, team, and odds data into a normalized, query-optimized format.
- **Persist data** securely and efficiently in Azure Cosmos DB.
- **Support CQRS** by handling all write operations, while the main Sports Data API remains read-only.
- **Enable scalability** and reliability through Azure Functions' event-driven, serverless architecture.

---

## Architecture & Design

### High-Level Flow

1. **Trigger**: Data loading is initiated via HTTP requests, Azure Queue messages, or timer-based triggers.
2. **Service Layer**: Business logic is orchestrated by services that implement domain interfaces.
3. **Repository Layer**: Data access is abstracted using the repository pattern, supporting both third-party APIs and Cosmos DB.
4. **Persistence**: Transformed data is written to Cosmos DB, ready for consumption by the read-only API.

### Main Components

- **Azure Functions**: Multiple triggers (HTTP, Queue, Timer) for flexible, event-driven data ingestion.
- **Domain Entities & DTOs**: Rich domain models (e.g., `Game`, `Statistics`, `CompletedGameDbDto`) and DTOs for strong typing and validation.
- **Services**: Encapsulate business logic, orchestrate data flow, and enforce domain invariants.
- **Repositories**: Abstract data access for both external APIs (`NbaApiRepository`) and Cosmos DB (`NbaDbRepository`).
- **Mappers**: Transform external data into domain models and DTOs.
- **Exception Handling**: Custom exceptions for robust error management.

### Example Data Flow

- **Timer Trigger** (`TimedNbaDataLoader`):
  - Runs daily, fetches NBA games for the current date from the external API.
  - Pushes game data to an Azure Queue for further processing.
- **Queue Trigger** (`QueueTriggeredNbaTeamStatsLoader`):
  - Consumes messages, processes team performance data, and persists results to Cosmos DB.
- **HTTP Trigger** (`HttpNbaTeamStatsDataLoader`):
  - Allows on-demand ingestion of team stats via HTTP POST.
- **Odds Loader** (`QueueTriggeredNbaOddsLoader`):
  - Processes and persists betting odds data.

---

## Key Domain Models

- **AddTeamPerformanceRequestDto**: Represents incoming team performance data.
- **CompletedGameDbDto**: Represents a completed NBA game as persisted in Cosmos DB.
- **Statistics**: Encapsulates detailed game statistics (points, rebounds, assists, etc.).

---

## Example: Timer-Driven Data Load

```csharp
[FunctionName(nameof(TimedNbaDataLoader))]
public async Task Run([TimerTrigger("0 0 9 * * *")]TimerInfo myTimer, [Queue("new-game")] ICollector<AddTeamPerformanceRequestDto> newGames)
{
    var date = DateTime.UtcNow;
    var playedGames = await _service.GetGamesWithStatsByDateAsync(date);
    playedGames.ForEach(game => newGames.Add(game));
}
```

---

## Why This Codebase Stands Out

- **Demonstrates senior-level design patterns and principles.**
- **Cloud-native, event-driven, and highly scalable.**
- **Separation of concerns and clean architecture.**
- **Ready for enterprise extension and robust testing.**

---

## Getting Started

1. Clone the repository.
2. Configure environment variables for Cosmos DB, API keys, and storage.
3. Deploy to Azure Functions or run locally using the Azure Functions Core Tools.

---

## License

This project is for demonstration purposes and is not licensed for production use. 