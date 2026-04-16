using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImageManagementApp.Data;
using ImageManagementApp.Models;

namespace ImageManagementApp.Controllers
{
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Image/Upload
        public IActionResult Upload()
        {
            return View();
        }

        // POST: Image/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(ImageUploadMVC model, IFormFile imageFile)
        {
            try
            {
                if (imageFile == null || imageFile.Length == 0)
                {
                    ModelState.AddModelError("ImageFileName", "Please select an image file");
                    return View(model);
                }

                // Validate image file type
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp"  };
                var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
                
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageFileName", "Only image files (jpg, jpeg, png, gif, bmp) are allowed");
                    return View(model);
                }

                if (ModelState.IsValid)
                {
                    // Generate unique filename
                    string uniqueFileName = Guid.NewGuid().ToString() + extension;
                    
                    // Save image to wwwroot/images folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    
                    // Create directory if it doesn't exist
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    // Save data to database
                    model.ImageFileName = uniqueFileName;
                    _context.Add(model);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Image uploaded successfully!";
                    return RedirectToAction(nameof(Display), new { id = model.Id });
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error uploading image: {ex.Message}");
            }

            return View(model);
        }

        // GET: Image/Display/5
        public async Task<IActionResult> Display(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var imageUpload = await _context.ImageUploads
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (imageUpload == null)
                {
                    return NotFound();
                }

                return View(imageUpload);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving image: {ex.Message}";
                return RedirectToAction(nameof(List));
            }
        }

        // GET: Image/List
        public async Task<IActionResult> List()
        {
            try
            {
                var images = await _context.ImageUploads.ToListAsync();
                return View(images);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving images: {ex.Message}";
                return View(new List<ImageUploadMVC>());
            }
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var imageUpload = await _context.ImageUploads
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (imageUpload == null)
                {
                    return NotFound();
                }

                return View(imageUpload);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction(nameof(List));
            }
        }

        // POST: Image/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var imageUpload = await _context.ImageUploads.FindAsync(id);
                
                if (imageUpload != null)
                {
                    // Delete image file from folder
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", imageUpload.ImageFileName);
                    
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    // Delete record from database
                    _context.ImageUploads.Remove(imageUpload);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Image deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Image not found!";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting image: {ex.Message}";
            }

            return RedirectToAction(nameof(List));
        }
    }
}
