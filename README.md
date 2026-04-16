# Image Management Web Application

ASP.NET Core MVC application for uploading, displaying, and managing images with user details.

## Setup Instructions

### Prerequisites
- .NET 10.0 SDK or later
- Git

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/baoquoc05005/Image-Management-Web-Application.git
cd Image-Management-Web-Application
```

2. **Restore packages**
```bash
dotnet restore
```

3. **Create database**
```bash
dotnet ef database update
```

4. **Run the application**
```bash
dotnet run
```

5. **Access the application**
- Open browser: `http://localhost:5000` or `https://localhost:5001`

## Features

- Upload images with user details (Name, Age, Date of Birth)
- View all uploaded images in gallery
- Display individual image details
- Delete images from database and storage
- Modern UI with gradient design
- Form validation and error handling

## Technologies

- ASP.NET Core 10.0 MVC
- Entity Framework Core 10.0
- SQLite Database
- Bootstrap 5.3

## Supported Image Formats

JPG, JPEG, PNG, GIF, BMP, WEBP
