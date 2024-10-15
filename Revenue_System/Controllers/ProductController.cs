using Microsoft.AspNetCore.Mvc;
using Revenue_System.Models;
using Revenue_System.ServiceImplements;
using System.Diagnostics;

namespace Revenue_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductDataAccessLayer productDataAccessLayer = new ProductDataAccessLayer();
        private InvoiceDataAccessLayer invoiceDataAccessLayer = new InvoiceDataAccessLayer();
        public IActionResult Index()
        {
            List<ProductModel> lstProductModel = productDataAccessLayer.GetAllProducts();
            return View(lstProductModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ProductController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Get all products
        [HttpGet]
        public JsonResult GetAllProducts()
        {
            List<ProductModel> lstProductModel = productDataAccessLayer.GetAllProducts();
            return Json(lstProductModel);
        }

        // Create new product
        [HttpPost]
        public JsonResult Create(ProductModel productModel)
        {
            try
            {
                productDataAccessLayer.InsertProduct(productModel);
                TempData["SuccessMessage"] = "New product created successfully.";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex);
                TempData["ErrorMessage"] = "The product ID already exists";
                return Json(new { success = false, message = TempData["ErrorMessage"] });
            }
        }

        // Update product
        [HttpPost]
        public JsonResult Update([Bind] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productDataAccessLayer.UpdateProduct(productModel);
                TempData["SuccessMessage"] = "Product updated successfully.";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
            TempData["ErrorMessage"] = "Invalid model data.";
            return Json(new { success = false, message = TempData["ErrorMessage"] });
        }

        // Delete product by id
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (invoiceDataAccessLayer.ProductCheck(id))
            {
                TempData["ErrorMessage"] = "The product is currently associated with existing invoices and cannot be deleted.";
                return Json(new { success = false, message = TempData["ErrorMessage"] });
            }
            else
            {
                productDataAccessLayer.DeleteProduct(id);
                TempData["SuccessMessage"] = "Delete Successfully.";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
        }
    }
}
