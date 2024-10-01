// CUSTOMER FORM
//create
function showCustomerForm() {
    document.getElementById('customerForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideCustomerForm() {
    document.getElementById('customerForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

//update
function showUpdateCustomerForm(customerID, customerName, phone) {
    document.getElementById('updateCustomerForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';

    document.getElementById('displayCustomerID').textContent = customerID;
    document.getElementById('updateCustomerID').value = customerID;
    document.getElementById('updateCustomerName').value = customerName;
    document.getElementById('updatePhone').value = phone;
}

function hideUpdateCustomerForm() {
    document.getElementById('updateCustomerForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

//delete

// INVOICE FORM
function showinvoiceForm() {
    document.getElementById('invoiceForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideinvoiceForm() {
    document.getElementById('invoiceForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
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

    console.log("test: " + document.getElementById('updateCustomerForm').value)
    console.log("testttt: " + InvoiceID);
    console.log("testttt: " + InvoiceDetailID);
    console.log("testttt: " + Quantity);
    console.log("testttt: " + formattedDate);
}

function hideUpdateInvoiceForm() {
    document.getElementById('updateInvoiceForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}


// PRODUCT FORM
function showProductForm() {
    document.getElementById('productForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideProductForm() {
    document.getElementById('productForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

//update
function showUpdateProductForm(productID, productName, price) {
    document.getElementById('updateProductForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';

    document.getElementById('displayCustomerID').textContent = productID;
    document.getElementById('updateProductID').value = productID;
    document.getElementById('updateProductName').value = productName;
    document.getElementById('updatePrice').value = price;
}

function hideUpdateProductForm() {
    document.getElementById('updateProductForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}
