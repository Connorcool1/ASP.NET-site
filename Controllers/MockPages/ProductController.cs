using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

// Primary controller for mock shop site
public class ProductController : BaseShopController {
    public IActionResult Index() {
        ProductsDAO productsDAO = new ProductsDAO();
        List<ProductModel> productsList = productsDAO.GetAllProducts();

        if (productsList )

        return View("~/Views/MockPages/Products/Index.cshtml", productsList);
    }

    // Filters items based on search term
    public IActionResult SearchResults(string searchTerm) {
        ProductsDAO productsDAO = new ProductsDAO();
        Console.WriteLine(searchTerm);

        List<ProductModel> productsList = productsDAO.SearchProducts(searchTerm);
        return View("~/Views/MockPages/Products/Index.cshtml", productsList);
    }

    public IActionResult ViewProduct(int productID) {
        ProductsDAO productsDAO = new ProductsDAO();
        ProductModel product = productsDAO.GetProductByID(productID);

        return View("~/Views/MockPages/Products/product.cshtml", product);
    }
 
    public IActionResult Update(int ID) {
        ProductsDAO productsDAO = new ProductsDAO();
        ProductModel product = productsDAO.GetProductByID(ID);

        return View("~/Views/MockPages/Products/Update.cshtml", product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Update(ProductModel product)
    {
        ProductsDAO productsDAO = new ProductsDAO();

        if (ModelState.IsValid)
        {
            product.ImageToBinary();

            productsDAO.Update(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View("~/Views/MockPages/Products/Create.cshtml");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductModel product, IFormFile imageFile)
    {
        ProductsDAO productsDAO = new ProductsDAO();

        if (ModelState.IsValid)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    product.Image = memoryStream.ToArray();
                }
            }

            productsDAO.Insert(product);
            return RedirectToAction("Index");
        }
        return View(product);
    }

    public IActionResult Populate()
    {
        ProductPopulator productPopulator = new ProductPopulator();

        productPopulator.PopulateDatabase();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int productId) {
        ProductsDAO productsDAO = new ProductsDAO();

        productsDAO.Delete(productId);

        return RedirectToAction("Index");
    }

        public IActionResult DeleteAll(int productId) {
        ProductsDAO productsDAO = new ProductsDAO();

        productsDAO.DeleteAll();

        return RedirectToAction("Index");
    }
}