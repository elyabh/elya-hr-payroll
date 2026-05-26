# ELYA HR & Payroll - Claude Instructions

Always follow the ELYA System Architecture Package.

## Architecture

- Modular Monolith
- Multi-Tenant SaaS
- ASP.NET Core Web API
- React + TypeScript
- SQL Server
- Entity Framework Core

## Rules

- Never bypass TenantId.
- Always apply Permission + Data Scope.
- Do not modify unrelated modules.
- Work sprint by sprint only.
- Always create migrations for database changes.
- Always add tests for business logic.
- Payroll logic must be handled carefully.
- Do not build the full system at once.
