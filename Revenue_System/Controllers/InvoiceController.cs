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
            List<InvoiceWithDetailsModel> InvoiceWithDetailsModel = invoiceDataAccessLayer.GetInvoiceWithDetails();
            return View(InvoiceWithDetailsModel);

        }

        // INVOICES CONTROLLER
        // Create new invoices
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] InvoiceModel invoiceModel, InvoiceDetailModel invoiceDetailModel)
        {   
             
                Console.WriteLine("this is inside: " + invoiceModel.ToString() + " " + invoiceDetailModel.ToString());
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
