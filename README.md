# Oneironautics
> A dream journaling suite inspired by Stephen LaBerge’s lucid dreaming methodology — with first-class support for **dream signs**, **lucidity levels**, and rich metadata.

---

## Overview

**Oneironautics** is a .NET-based dream journaling system designed around Stephen LaBerge’s principles:
- Systematic **recording** of dreams immediately after waking
- Categorization of **dream signs** to train recognition
- Tracking **lucidity** and sleep context (e.g., sleeping position)
- Reviewing patterns to improve **prospective memory** and increase the frequency/clarity of lucid dreams

The solution is split into three parts:

- **Desktop App (WPF, MVVM)** — a clean UI to capture dreams, annotate them with signs, lucidity, and notes, and review your history.
- **API Service (ASP.NET Core Web API)** — a REST layer intended for integrations (mobile/automation).
- **Data Layer (.NET library)** — models, entities, repositories, and enums shared across the app and API.

---

## Why LaBerge’s Method?

Stephen LaBerge’s approach emphasizes:
1. **Dream journaling** — write dreams down ASAP to boost recall.
2. **Dream signs** — identify recurring cues in your dreams.
3. **Prospective memory training** — practice recognizing those cues while dreaming (e.g., via MILD/RC techniques).
4. **Review & feedback** — analyze patterns to improve lucidity rate and stability.

Oneironautics encodes these pillars directly in the data model and UI.

---

## Features (Mapped to LaBerge)

### 1) Dream Journaling
- **Title, Content, Notes, DateTime**  
  Record detailed narratives as soon as you wake up.  
  Model: `Dream` → `Title`, `Content`, `Notes`, `DreamDateTime`

### 2) Dream Signs (LaBerge Taxonomy)
- **Categorized signs** you can link to dreams:
  - `Awareness` — odd states of mind (e.g., telepathy, missing time)
  - `Action` — impossible or incongruent actions (e.g., flying)
  - `Form` — shape/identity anomalies (e.g., distorted objects/people)
  - `Context` — unlikely settings/situations (e.g., school as an adult)
  - `Person` — specific recurring individuals
  - `Object` — specific recurring objects
- Model: `Sign (Title, Description, Type)` with `SignType` enum:  
  **`Person, Object, Awareness, Action, Form, Context`**  
- Relationships: Many-to-many via `SignToDream`

### 3) Lucidity Tracking
- **Lucidity levels** to measure experience quality over time:
  - `None, Transient, Foggy, Clear, Total`
- Model: `Dream.Lucidity` (`LucidityLevel` enum)

### 4) Sleep Context Metadata
- **Sleeping position** can be tracked to correlate with recall/lucidity:
  - `Unknown, Right, Back, Left, Stomach`
- Model: `Dream.Position` (`SleepingPosition` enum)
- Plus **indexing and timestamps** to support trend analysis.

### 5) Review & Pattern Discovery
- **Dream listing** and **sign-centric browsing** help you notice cues.  
- The structure is designed for future stats (e.g., per-sign lucidity lift, position correlations, time-of-night effects).

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

## License

Copyright (c) Movsar Bekaev.
