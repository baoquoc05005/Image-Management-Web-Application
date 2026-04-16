# Image Management Web Application

## ASP.NET Core MVC Final Exam Project

This is a complete Image Management Web Application built with ASP.NET Core MVC, Entity Framework Core, and Bootstrap.

## Features

✅ **Upload Functionality** - Upload images with user details (Name, Age, DOB)  
✅ **Display Page** - View individual image with all details  
✅ **List All Images** - Grid view of all uploaded images  
✅ **Delete Functionality** - Delete images from both database and file system  
✅ **Validation** - Client-side and server-side validation  
✅ **Error Handling** - Comprehensive error handling  
✅ **Modern UI** - Bootstrap 5 with responsive design  

## Technologies Used

- ASP.NET Core 10.0 MVC
- Entity Framework Core 10.0
- SQLite Database
- Bootstrap 5.3
- Bootstrap Icons
- jQuery Validation

## Project Structure

```
ImageManagementApp/
├── Controllers/
│   └── ImageController.cs          # Main controller with all CRUD operations
├── Data/
│   └── ApplicationDbContext.cs     # EF Core DbContext
├── Models/
│   └── ImageUploadMVC.cs          # Model with validations
├── Views/
│   ├── Image/
│   │   ├── Upload.cshtml          # Upload form
│   │   ├── Display.cshtml         # Display single image
│   │   ├── List.cshtml            # List all images
│   │   └── Delete.cshtml          # Delete confirmation
│   ├── Shared/
│   │   ├── _Layout.cshtml         # Main layout
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/
│   └── images/                    # Uploaded images stored here
├── appsettings.json               # Configuration including connection string
├── Program.cs                     # Application startup
└── ImageManagementApp.csproj      # Project file with dependencies
```

## Setup Instructions

### 1. Prerequisites
- .NET 8.0 SDK or later
- SQL Server (LocalDB comes with Visual Studio)
- Visual Studio 2022 or VS Code

### 2. Database Setup

Open Package Manager Console or Terminal in the project directory and run:

```powershell
# Add Entity Framework Core tools (if not already installed)
dotnet tool install --global dotnet-ef

# Create initial migration
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update
```

### 3. Run the Application

```powershell
dotnet run
```

Or press F5 in Visual Studio.

The application will start at `https://localhost:5001` or `http://localhost:5000`

## Database Configuration

The application uses SQLite database. Connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=ImageManagement.db"
}
```

The database file `ImageManagement.db` will be created automatically in the project root folder.

## Usage Guide

### Upload Image
1. Navigate to Upload page (default landing page)
2. Fill in Name, Age, and Date of Birth
3. Select an image file (JPG, PNG, GIF, BMP)
4. Click "Upload Image"
5. You'll be redirected to the Display page

### View All Images
1. Click "View All" in the navigation or after uploading
2. See all uploaded images in a grid layout
3. Click on image or name to view details
4. Click "Delete" button to remove an image

### Delete Image
1. From List page, click "Delete" button on any image
2. Confirm deletion on the confirmation page
3. Image will be removed from both database and file system

## Model Validations

The `ImageUploadMVC` model includes:

- **Name**: Required, max 100 characters
- **Age**: Required, must be between 1-120
- **Date of Birth**: Required, must be a valid date
- **Image File**: Required, must be image format (jpg, jpeg, png, gif, bmp)

## Controller Actions

### ImageController

- `GET Upload` - Display upload form
- `POST Upload` - Handle image upload and save to database
- `GET Display/{id}` - Display single image details
- `GET List` - Display all images
- `GET Delete/{id}` - Show delete confirmation
- `POST DeleteConfirmed` - Delete image from database and file system

## Error Handling

The application includes:
- Model validation errors
- File type validation
- Database operation error handling
- File system error handling
- User-friendly error messages via TempData

## Screenshots Required for Submission

Take screenshots of:
1. **Upload Page** - With form filled and image preview
2. **Display Page** - Showing uploaded image and details
3. **List Page** - Showing multiple uploaded images
4. **Delete Page** - Showing delete confirmation
5. **After Delete** - List page after successful deletion

## Marking Scheme Coverage

| Requirement | Marks | Implementation |
|------------|-------|----------------|
| Model & Database | 10 | ✅ ImageUploadMVC model with validations, EF Core DbContext |
| Upload | 20 | ✅ Complete upload with file saving and database insert |
| Display | 15 | ✅ Display page with image and all details |
| List | 15 | ✅ Grid view with clickable images and delete buttons |
| Delete | 20 | ✅ Delete from both folder and database with confirmation |
| Database Operations | 20 | ✅ EF Core CRUD operations (Insert, Retrieve, Delete) |
| Validation | 10 | ✅ Client and server-side validation with error handling |
| **Total** | **100** | ✅ **Complete Implementation** |

## Additional Features

- Modern, responsive UI with Bootstrap 5
- Image preview before upload
- Success/Error notifications
- Bootstrap Icons for better UX
- Hover effects on cards
- Mobile-friendly design

## Troubleshooting

### Database Connection Issues
- Ensure SQL Server LocalDB is installed
- Check connection string in appsettings.json
- Run migrations again: `dotnet ef database update`

### Image Upload Issues
- Ensure wwwroot/images folder exists (created automatically)
- Check file permissions
- Verify image file format

### Build Errors
- Restore NuGet packages: `dotnet restore`
- Clean and rebuild: `dotnet clean && dotnet build`

## License

This project is created for educational purposes as part of ASP.NET Core MVC final examination.

---

**Developed for Humber College - ASP.NET Core MVC Final Exam**
