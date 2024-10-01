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

        // CUSTOMER CONTROLLER
        // Create new customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
             
                customerDataAccessLayer.InsertCustomer(customerModel);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //Update customer infor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind] CustomerModel customerModel)
        {
            if (ModelState.IsValid)
            {
                customerDataAccessLayer.UpdateCustomer(customerModel);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        //Delete customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            customerDataAccessLayer.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

    }
}
