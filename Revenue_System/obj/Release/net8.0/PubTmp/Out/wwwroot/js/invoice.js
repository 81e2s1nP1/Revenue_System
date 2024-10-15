// INVOICE FORM
function showinvoiceForm() {
    document.getElementById('invoiceForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideinvoiceForm() {
    document.getElementById('invoiceForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';

    hideAlertForm()
}

function showUpdateInvoiceForm(InvoiceID, InvoiceDetailID, Quantity, InvoiceDate) {
    document.getElementById('updateInvoiceForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';

    document.getElementById('UpdateInvoiceID').value = InvoiceID;
    document.getElementById('UpdateInvoiceDetailID').value = InvoiceDetailID;
    document.getElementById('UpdateQuantity').value = Quantity;


    // Convert InvoiceDate from "dd/MM/yyyy" to "yyyy-MM-dd"
    var dateParts = InvoiceDate.split("/");
    var formattedDate = dateParts[2] + "-" + dateParts[1] + "-" + dateParts[0];

    document.getElementById('UpdateInvoiceDate').value = formattedDate;
}

function hideUpdateInvoiceForm() {
    document.getElementById('updateInvoiceForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

function hideAlertForm() {
    document.getElementById('alert-overlay').style.display = 'none';
    document.getElementsByClassName('alert-form')[0].style.display = 'none';
}