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

function showUpdateInvoiceForm(invoiceID, quantity, invoiceDate) {
    document.getElementById('updateCustomerForm').style.display = 'block';
    document.getElementById('InvoiceId').value = invoiceID;
    document.getElementById('Quantity').value = quantity;
    document.getElementById('InvoiceDate').value = invoiceDate;
}

/*submit invoice function*/

// PRODUCT FORM
function showProductForm() {
    document.getElementById('productForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideProductForm() {
    document.getElementById('productForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

/*submit product function*/