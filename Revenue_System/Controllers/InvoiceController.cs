using Microsoft.AspNetCore.Mvc;
using Revenue_System.Models;
using Revenue_System.ServiceImplements;
using System.Diagnostics;
using System.Reflection;

namespace Revenue_System.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        private InvoiceDataAccessLayer invoiceDataAccessLayer = new InvoiceDataAccessLayer();
        private ProductDataAccessLayer productDataAccessLayer = new ProductDataAccessLayer();
        private CustomerDataAccessLayer customerDataAccessLayer = new CustomerDataAccessLayer();

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<InvoiceWithDetailsModel> invoiceWithDetailsModels = invoiceDataAccessLayer.GetInvoiceWithDetails();
            var customers = customerDataAccessLayer.GetAllCustomer();
            var productList = productDataAccessLayer.GetAllProducts();

            ViewBag.Customers = customers;
            ViewBag.Products = productList;

            return View(invoiceWithDetailsModels);
        }

        // Get all invoices with details
        [HttpGet]
        public JsonResult GetInvoices()
        {
            List<InvoiceWithDetailsModel> invoiceWithDetailsModels = invoiceDataAccessLayer.GetInvoiceWithDetails();
            return Json(invoiceWithDetailsModels);
        }

        // POST: Insert new invoice
        [HttpPost]
        public JsonResult Create([FromBody] InvoiceCreateModel invoiceCreateModel)
        {
            Console.WriteLine("da vo");
            try
            {
                Console.WriteLine("SelectedQuantities: " + invoiceCreateModel.SelectedQuantities);
                foreach (var productId in invoiceCreateModel.ProductIDs)
                {
                    Console.WriteLine("da vo day: " + productId);
                }
                List<int> numbers = invoiceCreateModel.SelectedQuantities.Split(',')
                                  .Select(int.Parse)
                                  .ToList();
                invoiceDataAccessLayer.InsertInvoice(invoiceCreateModel.InvoiceModel, numbers, invoiceCreateModel.ProductIDs);

                TempData["SuccessMessage"] = "Invoice created successfully. Would you like to add another invoice?";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TempData["ErrorMessage"] = "The invoice ID or invoice detail ID already exists.";
                return Json(new { success = false, message = TempData["ErrorMessage"] });
            }
        }

        // DELETE: Delete invoice
        [HttpPost]
        public JsonResult Delete(string id, string invoiceid)
        {
            try
            {
                invoiceDataAccessLayer.DeleteInvoice(id, invoiceid);
                TempData["SuccessMessage"] = "Delete Successfully";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TempData["ErrorMessage"] = "Delete Failure";
                return Json(new { success = false, message = TempData["ErrorMessage"] });
            }
        }

        // PUT: Update invoice and invoice detail
        [HttpPost]
        public JsonResult Update([Bind] InvoiceModel invoiceModel, [Bind] InvoiceDetailModel invoiceDetailModel)
        {
            try
            {
                invoiceDataAccessLayer.UpdateInvoiceAndInvoiceDetail(invoiceModel, invoiceDetailModel);
                TempData["SuccessMessage"] = "Invoice updated successfully";
                return Json(new { success = true, message = TempData["SuccessMessage"] });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TempData["ErrorMessage"] = "Update Failure";
                return Json(new { success = false, message = TempData["ErrorMessage"] });
            }
        }
    }
}
