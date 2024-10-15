// PRODUCT FORM
function showProductForm() {
    document.getElementById('productForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideProductForm() {
    document.getElementById('productForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';

    hideAlertForm()
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

function hideAlertForm-product()() {
    document.getElementById('alert-overlay').style.display = 'none';
    document.getElementsByClassName('alert-form')[0].style.display = 'none';
}