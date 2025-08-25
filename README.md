# BookTracker

![Vue.js](https://img.shields.io/badge/Vue-3.5.18-brightgreen?logo=vue.js&logoColor=white)
![TypeScript](https://img.shields.io/badge/TypeScript-5.8.3-blue?logo=typescript&logoColor=white)
![TailwindCSS](https://img.shields.io/badge/TailwindCSS-4.1.12-blue?logo=tailwind-css&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-9.0-blue?logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-3.41.2-lightgrey?logo=sqlite&logoColor=white)

A full-stack book tracker built with Vue 3, TypeScript, TailwindCSS for the frontend and C# / ASP.NET Core with SQLite for the backend. Track your books, mark them as read/unread, and manage your library easily.

## 🖥 Features

- Responsive book grid with TailwindCSS
- Read/Unread status for each book
- Edit/Delete books with buttons
- Floating Action Button (FAB) to add new books
- API-ready backend with SQLite + EF Core migrations
- Clean and modern UI

## 📸 Screenshots

### Backend
![Backend](screenshots/backend.png)

### Main Book Grid
![Book Grid](screenshots/main-grid.png)

### Edit Book
![Edit Book](screenshots/edit-book.png)

## ⚡ Tech Stack

**Frontend:**

- Vue 3 + TypeScript
- TailwindCSS
- Composition API

**Backend:**

- ASP.NET Core Web API
- Entity Framework Core
- SQLite

## 🚀 Getting Started

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

Frontend
```bash
# Navigate to frontend folder
cd frontend

# Install dependencies
bun install

# Run dev server
bun run dev
```
Visit http://localhost:5173 (or your terminal output) to see the app.

## 📌 Notes

- Commit EF Core migration scripts but do not commit the SQLite database file
- Make sure to configure CORS if frontend and backend run on different ports
