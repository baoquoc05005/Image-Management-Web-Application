# Quick Setup Guide

## Step-by-Step Instructions to Run the Application

### Step 1: Open Project
Open the `ImageManagementApp` folder in Visual Studio 2022 or VS Code.

### Step 2: Restore Packages
```powershell
dotnet restore
```

### Step 3: Install EF Core Tools (if not already installed)
```powershell
dotnet tool install --global dotnet-ef
```

### Step 4: Create Database
```powershell
# Create migration
dotnet ef migrations add InitialCreate

# Apply migration to database
dotnet ef database update
```

### Step 5: Run Application
```powershell
dotnet run
```

Or press **F5** in Visual Studio.

### Step 6: Access Application
Open browser and navigate to:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

## Testing the Application

### Test Upload
1. Fill in Name: "John Doe"
2. Enter Age: 25
3. Select Date of Birth
4. Choose an image file
5. Click "Upload Image"

### Test Display
- After upload, you'll see the image with all details

### Test List
- Click "View All" to see all uploaded images
- Click on any image or name to view details

### Test Delete
1. From List page, click "Delete" on any image
2. Confirm deletion
3. Verify image is removed from list

## Common Commands

### View Database
```powershell
# List migrations
dotnet ef migrations list

# View database info
dotnet ef dbcontext info
```

### Reset Database
```powershell
# Remove database
dotnet ef database drop

# Recreate database
dotnet ef database update
```

### Build and Run
```powershell
# Build project
dotnet build

# Run project
dotnet run

# Run with watch (auto-reload)
dotnet watch run
```

## Verification Checklist

- [ ] Database created successfully
- [ ] Application runs without errors
- [ ] Upload page loads
- [ ] Can upload image with details
- [ ] Image displays correctly
- [ ] List shows all images
- [ ] Can delete image
- [ ] Image removed from folder and database
- [ ] Validation works (try submitting empty form)
- [ ] Error messages display properly

## Screenshots for Submission

Take screenshots of:
1. Upload form with data filled
2. Display page showing uploaded image
3. List page with multiple images
4. Delete confirmation page
5. Success message after operations

---

**Ready for Submission!** ✅
