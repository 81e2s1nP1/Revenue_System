using Microsoft.AspNetCore.Mvc;
using Revenue_System.Models;
using Revenue_System.ServiceImplements;
using System.Diagnostics;
using Microsoft.AspNetCore.Cors;

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

        // GET: /Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/GetCustomers
        [HttpGet]
        public JsonResult GetCustomers()
        {
            List<CustomerModel> lstCustomers = customerDataAccessLayer.GetAllCustomer();
            return Json(lstCustomers);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // CUSTOMER CONTROLLER
        // Create new customer
        [HttpPost]
        public JsonResult Create([Bind] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                customerDataAccessLayer.InsertCustomer(customerModel);
                return Json(new { success = true, message = "Customer created successfully." });
            }
            return Json(new { success = false, message = "Error creating customer." });
        }

        // Update customer info
        [HttpPost]
        public JsonResult Update([FromBody] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                customerDataAccessLayer.UpdateCustomer(customerModel);
                return Json(new { success = true, message = "Customer updated successfully." });
            }
            return Json(new { success = false, message = "Error updating customer." });
        }

        // Delete customer
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (invoiceDataAccessLayer.CustomerCheck(id))
            {
                return Json(new { success = false, message = "Khách hàng hiện đang tồn tại hóa đơn và không thể xóa." });
            }
            else
            {
                customerDataAccessLayer.DeleteCustomer(id);
                return Json(new { success = true, message = "Customer deleted successfully." });
            }
        }
    }
}
