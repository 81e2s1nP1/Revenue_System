using Microsoft.AspNetCore.Mvc;
using Revenue_System.Models;
using Revenue_System.ServiceImplements;
using System.Diagnostics;

namespace Revenue_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CustomerDataAccessLayer customerDataAccessLayer = new CustomerDataAccessLayer();
        private InvoiceDataAccessLayer invoiceDataAccessLayer = new InvoiceDataAccessLayer();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<CustomerModel> lstCustomers = customerDataAccessLayer.GetAllCustomer();
            return View(lstCustomers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: /Home/GetCustomers
        [HttpGet]
        public JsonResult GetCustomers()
        {
            List<CustomerModel> lstCustomers = customerDataAccessLayer.GetAllCustomer();
            return Json(lstCustomers);
        }

        // Create new customer
        [HttpPost]
        public JsonResult Create(CustomerModel customerModel)
        {
            try
            {
                customerDataAccessLayer.InsertCustomer(customerModel);
                TempData["SuccessMessage"] = "New Customer created successfully. Would you like to add another customer?";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TempData["ErrorMessage"] = "The customer ID or invoice detail ID already exists";
                return Json(new { success = false, message = TempData["ErrorMessage"] });
            }
        }

        // Update customer information
        [HttpPost]
        public JsonResult Update([Bind] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                customerDataAccessLayer.UpdateCustomer(customerModel);
                TempData["SuccessMessage"] = "Customer updated successfully";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
            TempData["ErrorMessage"] = "Invalid model data";
            return Json(new { success = false, message = TempData["ErrorMessage"] });
        }

        // Delete customer
        [HttpPost]
        public JsonResult Delete(string id)
        {
            Console.WriteLine("delete: " + id);
            if (invoiceDataAccessLayer.CustomerCheck(id))
            {
                TempData["ErrorMessage"] = "The customer currently has existing invoices and cannot be deleted";
                return Json(new { success = false, message = TempData["ErrorMessage"] });
            }
            else
            {
                customerDataAccessLayer.DeleteCustomer(id);
                TempData["SuccessMessage"] = "Delete Successfully";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
        }
    }
}
