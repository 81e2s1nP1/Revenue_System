using Microsoft.AspNetCore.Mvc;
using Revenue_System.Models;
using Revenue_System.ServiceImplements;

namespace Revenue_System.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private InvoiceDataAccessLayer invoiceDataAccessLayer = new InvoiceDataAccessLayer();

        public InvoiceController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<InvoiceWithDetailsModel> invoiceWithDetailsModels = invoiceDataAccessLayer.GetInvoiceWithDetails();

            var customerIDs = invoiceDataAccessLayer.GetAllCustomerIDs(); 
            var productIDs = invoiceDataAccessLayer.GetAllProductIDs();

            ViewBag.CustomerIDs = customerIDs;
            ViewBag.ProductIDs = productIDs;

            return View(invoiceWithDetailsModels);
        }


        // INVOICES CONTROLLER
        // Create new invoices
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel)
        {   
                invoiceDataAccessLayer.InsertInvoice(invoiceModel, invoiceDetailModel);
                return RedirectToAction("Index");
        }

        //Delete customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {   
            invoiceDataAccessLayer.DeleteInvoice(id);
            return RedirectToAction("Index");
        }

        //Update customer infor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind] InvoiceModel invoiceModel, [Bind] InvoiceDetailModel invoiceDetailModel)
        {
        
                invoiceDataAccessLayer.UpdateInvoiceAndInvoiceDetail(invoiceModel, invoiceDetailModel);
                return RedirectToAction("Index");
        }
    }
}
