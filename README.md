# ELYA HR & Payroll

ELYA HR & Payroll is the first product inside the ELYA Platform.

## Architecture

- Layered Modular Monolith
- Multi-Tenant SaaS
- ASP.NET Core Web API (.NET 9)
- React + TypeScript + Material UI
- SQL Server + Entity Framework Core
- Redis + Hangfire (placeholders in Sprint 0)
- Docker for local infrastructure

## Repository structure

```
ELYA.sln
src/
  ELYA.Api/              # Web API host
  ELYA.Application/      # Use cases (module folders in future sprints)
  ELYA.Domain/            # Domain entities and rules
  ELYA.Infrastructure/     # External services (email, cache, jobs, etc.)
  ELYA.Persistence/      # EF Core, DbContext, migrations
  ELYA.Shared/            # Shared primitives and constants
  ELYA.Worker/            # Background worker + Hangfire placeholder
frontend/
  elya-web/               # React + Vite + MUI SPA
```

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Node.js 22+](https://nodejs.org/)
- [Docker](https://www.docker.com/) (optional, for SQL Server and Redis)

## Quick start

### 1. Infrastructure

```bash
cp .env.example .env
docker compose up -d
```

### 2. Backend

```bash
dotnet restore ELYA.sln
dotnet build ELYA.sln
dotnet run --project src/ELYA.Api
```

- API: http://localhost:5080
- Swagger: http://localhost:5080/swagger
- Health: http://localhost:5080/health

### 3. Frontend

```bash
cd frontend/elya-web
cp .env.example .env
npm install
npm run dev
```

- Web: http://localhost:5173

### Tenant header

Send `X-Tenant-Id: <guid>` on API requests when testing multi-tenancy.

## Status

Sprint 0 complete — solution bootstrap only. No HR business modules implemented yet.
