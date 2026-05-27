# Booking System API (C# / ASP.NET Core)

A clean, intermediate-level booking system built with ASP.NET Core Web API, Entity Framework Core, and SQLite. This project demonstrates real-world backend engineering skills including scheduling logic, conflict detection, layered architecture, and unit testing.

## Features
- Create bookings
- Prevent double-booking
- Check availability by date
- Clean architecture (API → Service → Repository → DB)
- Entity Framework Core + SQLite
- Unit tests for booking conflict logic
- Swagger UI documentation

## Endpoints
POST /api/bookings
GET /api/bookings/{date}

## Tech Stack
- C# 12
- ASP.NET Core 8
- Entity Framework Core
- SQLite
- xUnit + NSubstitute

## Run
dotnet ef database update
dotnet run
