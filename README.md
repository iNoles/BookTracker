# Book Tracker App

![Vue.js](https://img.shields.io/badge/Vue-3.5.18-brightgreen?logo=vue.js&logoColor=white)
![TypeScript](https://img.shields.io/badge/TypeScript-5.8.3-blue?logo=typescript&logoColor=white)
![TailwindCSS](https://img.shields.io/badge/TailwindCSS-4.1.12-blue?logo=tailwind-css&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-9.0-blue?logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-3.41.2-lightgrey?logo=sqlite&logoColor=white)

A full-stack .NET 9 application with Vue for managing book items. The application follows the controller/service/repository pattern, utilizing Entity Framework Core for persistence, and includes a comprehensive test suite.

## 🖥 Features

- Add Book Items: Create new book items with title, author, genre, notes, rating, and status
- List Book Items: View all book items
- Edit Books Items: Update existing book items
- Delete Book Items: Remove book items
- Data Persistence: All data is persisted to a SQLite database using EF Core
- Seeded Data: Application starts with 3 pre-loaded book items

## Screenshots

### Backend
![Backend](screenshots/backend.png)

### Main Book Grid
![Book Grid](screenshots/main-grid.png)

### Edit Book
![Edit Book](screenshots/edit-book.png)

## Tech Stack

- .NET 9
- ASP.NET Core Web API / MVC
- Entity Framework Core 9.0
- SQLite Database
- xUnit for Testing
- Vue 3 + TypeScript
- TailwindCSS for Styling

## Getting Started

Frontend
```bash
# Navigate to frontend folder
cd frontend

# Install dependencies
bun install

# Build
bun run build
```

Backend
```bash
# Navigate to backend folder
cd backend

# Restore .NET packages
dotnet restore

# Apply EF Core migrations
dotnet ef database update

# Run backend API
dotnet run
```
Default API URL: https://localhost:5001/api/books

Visit http://localhost:5173 (or your terminal output) to see the app.

## API Endpoints

The application exposes REST API endpoints:

The application exposes REST API endpoints:

- `GET /api/books` - Get all book items
- `GET /api/books/{id}` - Get book item by ID
- `POST /api/books` - Create new book item
- `PUT /api/books/{id}` - Update book item
- `DELETE /api/books/{id}` - Delete book item

## Notes

- Commit EF Core migration scripts but do not commit the SQLite database file
- The database will be automatically created with seeded data on the first run
