# BookTracker – Full-Stack Web Application

![Vue.js](https://img.shields.io/badge/Vue-3.5.18-brightgreen?logo=vue.js&logoColor=white)
![TypeScript](https://img.shields.io/badge/TypeScript-5.8.3-blue?logo=typescript&logoColor=white)
![TailwindCSS](https://img.shields.io/badge/TailwindCSS-4.1.12-blue?logo=tailwind-css&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-9.0-blue?logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-3.41.2-lightgrey?logo=sqlite&logoColor=white)

BookTracker is a full-stack web application for managing a personal book collection. It demonstrates end-to-end development, including backend API design, database integration, and frontend UI implementation.

## Technologies Used

- **Backend**: ASP.NET Core Web API, Entity Framework Core, SQLite
- **Frontend**: Vue 3, TypeScript, Tailwind CSS
- **Testing**: xUnit (backend unit tests)
- **Tools**: Git, GitHub, Visual Studio Code

## Features

- **Full CRUD functionality**: Add, view, edit, and delete books
- **Persistent storage**: Data stored in SQLite database via Entity Framework Core
- **Responsive UI**: Dynamic frontend built with Vue and Tailwind
- **API integration**: Frontend communicates with backend via RESTful endpoints
- **Automated testing**: Unit tests validate backend logic and data integrity

## Key Skills Demonstrated

- Full-stack development and end-to-end application design
- Designing and implementing RESTful APIs
- Database modeling and querying with Entity Framework Core
- Frontend state management and dynamic rendering with Vue 3
- Writing maintainable, testable code using professional practices

## Screenshots

### Backend
![Backend](screenshots/backend.png)

### Main Book Grid
![Book Grid](screenshots/main-grid.png)

### Edit Book
![Edit Book](screenshots/edit-book.png)

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

## Demonstration of Professional Practices

- Structured development using Git branches and commits
- Documentation of setup, usage, and architecture
- Separation of frontend and backend concerns, reflecting real-world full-stack projects
- Implementation of automated unit tests for backend endpoints

## Notes

- Commit EF Core migration scripts but do not commit the SQLite database file
- The database will be automatically created with seeded data on the first run
