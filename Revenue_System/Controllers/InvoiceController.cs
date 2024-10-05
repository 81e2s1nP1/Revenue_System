using Microsoft.AspNetCore.Mvc;
using Revenue_System.Models;
using Revenue_System.ServiceImplements;
using System.Diagnostics;

namespace Revenue_System.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private InvoiceDataAccessLayer invoiceDataAccessLayer = new InvoiceDataAccessLayer();

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /Invoice/GetInvoices
        [HttpGet]
        public JsonResult GetInvoices()
        {
            List<InvoiceWithDetailsModel> invoiceWithDetailsModels = invoiceDataAccessLayer.GetInvoiceWithDetails();

            var customerIDs = invoiceDataAccessLayer.GetAllCustomerIDs();
            var productIDs = invoiceDataAccessLayer.GetAllProductIDs();

            var result = new
            {
                Invoices = invoiceWithDetailsModels,
                CustomerIDs = customerIDs,
                ProductIDs = productIDs
            };

            return Json(result);
        }


        [HttpPost]
        public JsonResult Create([Bind] InvoiceModel invoiceModel, [Bind] InvoiceDetailModel invoiceDetailModel)
        {
            if (ModelState.IsValid)
            {
                invoiceDataAccessLayer.InsertInvoice(invoiceModel, invoiceDetailModel);
                return Json(new { success = true, message = "Invoice created successfully." });
            }
            return Json(new { success = false, message = "Error creating invoice." });
        }


        // Delete invoice
        [HttpPost]
        public JsonResult Delete([FromBody] InvoiceModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.InvoiceID))
            {
                return Json(new { success = false, message = "Invoice ID không hợp lệ." });
            }
            invoiceDataAccessLayer.DeleteInvoice(model.InvoiceID);
            return Json(new { success = true, message = "Invoice deleted successfully." });
        }


        [HttpPost]
        public JsonResult Update([FromBody] UpdateInvoiceRequest request)
        {
            Console.WriteLine("invoiceModel: " + request.InvoiceModel);
            Console.WriteLine("invoiceDetailModel: " + request.InvoiceDetailModel);

            //if (ModelState.IsValid)
            //{
                invoiceDataAccessLayer.UpdateInvoiceAndInvoiceDetail(request.InvoiceModel, request.InvoiceDetailModel);
                return Json(new { success = true, message = "Invoice updated successfully." });
            //}
            //return Json(new { success = false, message = "Error updating invoice." });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
