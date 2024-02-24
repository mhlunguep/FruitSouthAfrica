using FruitSouthAfrica.Models;
using FruitSouthAfrica.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FruitSouthAfrica.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductController(IProductService productService, IWebHostEnvironment hostingEnvironment)
        {
            _productService = productService;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: /Product
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ImageFile != null && product.ImageFile.Length > 0)
                    {
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extension = Path.GetExtension(product.ImageFile.FileName).ToLowerInvariant();
                        if (!allowedExtensions.Contains(extension))
                        {
                            ModelState.AddModelError("ImageFile", "Invalid image file format. Please upload a JPEG, PNG, or GIF image.");
                            return View(product);
                        }

                        var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await product.ImageFile.CopyToAsync(fileStream);
                        }

                        product.Image = "/images/" + uniqueFileName;
                    }

                    await _productService.AddProductAsync(product);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Unable to save changes. {ex.Message}");
                }
            }

            return View(product);
        }


        // GET: /Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: /Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.UpdateProductAsync(product);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Unable to save changes. {ex.Message}");
                }
            }
            return View(product);
        }

        // GET: /Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: /Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
