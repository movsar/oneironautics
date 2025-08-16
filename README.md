# Oneironautics

> A cross-platform dream journaling application with desktop UI, API service, and data layer.

---

## Overview

**Oneironautics** is a software suite for recording, organizing, and exploring dreams.  
It is designed for dream journaling enthusiasts, lucid dreamers, and researchers interested in tracking dream signs and patterns.

The project consists of three main parts:

- **Desktop App (WPF, MVVM)**  
  A Windows desktop application that provides a clean UI for recording dreams, editing them, and associating dream signs.  
- **API Service (ASP.NET Core Web API)**  
  A REST service that exposes dream data for integration with other platforms or mobile clients.  
- **Data Layer (.NET library)**  
  A shared library containing entities, models, repositories, and enums that power both the API and the desktop app.

---

## Features

- 📖 **Dream Journal** — record dreams with metadata such as lucidity level, sleeping position, and associated dream signs.  
- ✍️ **Dream Editor** — add, edit, and manage dream entries through the desktop UI.  
- 🏷 **Dream Signs** — define recurring dream signs (symbols, events, people, emotions) and link them to dreams.  
- 🔍 **Search & Listing** — view and filter journal entries, browse by signs, and track patterns.  
- 🌐 **API Integration** — access dream data via REST endpoints (`DreamsController`) for external apps.  
- 🧪 **Unit Tests** — repository layer is tested with xUnit to ensure reliability.  

---

## Project Structure

```

Oneironautics/
├── Oneironautics/        # WPF desktop app (MVVM)
│   ├── Views/            # XAML views (DreamEditor, DreamListing, SignEditor, etc.)
│   ├── ViewModels/       # ViewModels for each view
│   ├── Commands/         # MVVM command implementations
│   └── Stores/           # Application state management
│
├── ApiService/           # ASP.NET Core Web API
│   ├── Controllers/      # DreamsController exposes REST endpoints
│   └── appsettings.json  # Config files
│
├── Data/                 # Shared data access layer
│   ├── Entities/         # EF Core entities (DreamEntity, SignEntity, etc.)
│   ├── Models/           # Domain models (Dream, Sign, etc.)
│   ├── Repositories/     # Generic + specialized repositories
│   ├── Interfaces/       # Repository and model interfaces
│   └── Enums/            # Dream metadata enums (LucidityLevel, SleepingPosition, etc.)
│
├── Data.Test/            # Unit tests (xUnit)
│   └── DreamRepositoryTest.cs
│
└── README.md

````

---

## Tech Stack

- **.NET 6 / C# 10**  
- **WPF (MVVM)** for the desktop application  
- **ASP.NET Core Web API** for backend service  
- **Entity Framework Core** (repository pattern for persistence)  
- **xUnit** for unit testing  

---

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)  
- Windows (for WPF desktop app)  
- Any SQL database supported by EF Core (SQLite / SQL Server, configurable)

### Build & Run

Clone the repository:

```bash
git clone https://github.com/movsar/oneironautics.git
cd oneironautics
````

#### Run the Desktop App

```bash
cd Oneironautics
dotnet build
dotnet run
```

#### Run the API Service

```bash
cd ApiService
dotnet build
dotnet run
```

API will be available at `https://localhost:5001/api/dreams`.

#### Run Tests

```bash
cd Data.Test
dotnet test
```

## Screenshots

<img width="40%"  alt="image" src="https://github.com/user-attachments/assets/f28cf85b-6f79-44e8-8a26-a90f9502015a" />
<img width="40%"  alt="image" src="https://github.com/user-attachments/assets/6f321bd0-4746-40c4-8315-04a76d86c9f1" />

---

## Roadmap

* [ ] Add mobile client (Xamarin/.NET MAUI)
* [ ] Advanced dream analysis & statistics
* [ ] Cloud synchronization
* [ ] Tagging system and full-text search

---

## Contributing

Pull requests are welcome!
For major changes, please open an issue first to discuss what you’d like to change.

---

## License

Copyright (c) Movsar Bekaev.
Would you like me to **include screenshots / mockup images** of the desktop app (from your Views/XAML) into the `README.md` for a more visual impression, or keep it text-only and professional?
```
