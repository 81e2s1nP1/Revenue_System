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