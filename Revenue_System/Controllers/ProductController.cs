using Microsoft.AspNetCore.Mvc;
using Revenue_System.Models;
using Revenue_System.ServiceImplements;
using System.Diagnostics;

namespace Revenue_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private ProductDataAccessLayer productDataAccessLayer = new ProductDataAccessLayer();
        private InvoiceDataAccessLayer invoiceDataAccessLayer = new InvoiceDataAccessLayer();

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // GET: /Product/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Product/GetProducts
        [HttpGet]
        public JsonResult GetProducts()
        {
            List<ProductModel> lstProducts = productDataAccessLayer.GetAllProducts();
            return Json(lstProducts);
        }

        // Create new product
        [HttpPost]
        public JsonResult Create([FromBody] ProductModel productModel)
        {
            Console.WriteLine("productModel: " + productModel);
            if (ModelState.IsValid)
            {
                productDataAccessLayer.InsertProduct(productModel);
                return Json(new { success = true, message = "Product created successfully." });
            }
            return Json(new { success = false, message = "Error creating product." });
        }

        // Update product info
        [HttpPost]
        public JsonResult Update([FromBody] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productDataAccessLayer.UpdateProduct(productModel);
                return Json(new { success = true, message = "Product updated successfully." });
            }
            return Json(new { success = false, message = "Error updating product." });
        }

        // Delete product by id 
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (invoiceDataAccessLayer.ProductCheck(id))
            {
                return Json(new { success = false, message = "Sản phẩm hiện đang tồn tại hóa đơn và không thể xóa." });
            }
            else
            {
                productDataAccessLayer.DeleteProduct(id);
                return Json(new { success = true, message = "Product deleted successfully." });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
