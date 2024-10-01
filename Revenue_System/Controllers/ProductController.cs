using Microsoft.AspNetCore.Mvc;
using Revenue_System.Models;
using Revenue_System.ServiceImplements;

namespace Revenue_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductDataAccessLayer productDataAccessLayer = new ProductDataAccessLayer();

        public ProductController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ProductModel> lstProductModel = productDataAccessLayer.GetAllProducts();
            return View(lstProductModel);
        }

        // PRODUCT CONTROLLER
        // Create new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productDataAccessLayer.InsertProduct(productModel);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        //Update customer infor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                productDataAccessLayer.UpdatePoduct(productModel);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // Delete product by id 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            productDataAccessLayer.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
