$(document).ready(function () {
    // Kendo Grid for displaying customers
    $("#customerGrid").kendoGrid({
        dataSource: {
            data: @Html.Raw(Json.Serialize(Model)),
            schema: {
                model: {
                    fields: {
                        customerID: { type: "string" },
                        customerName: { type: "string" },
                        phone: { type: "string" }
                    }
                }
            },
            pageSize: 5
        },
        height: 400,
        scrollable: true,
        sortable: true,
        pageable: {
            input: true,
            numeric: false
        },
        columns: [
            { field: "customerID", title: "Customer ID", width: "130px", attributes: { class: "attribute-table" } },
            { field: "customerName", title: "Customer Name", width: "250px", attributes: { class: "attribute-table" } },
            { field: "phone", title: "Phone Number", width: "150px", attributes: { class: "attribute-table" } },
            { command: [{ text: "Edit", click: editCustomer }, { text: "Delete", click: deleteCustomer }], title: "Action", width: "200px" }
        ]
    });

    // Attach submit event for the update form
    $("#updateCustomerForm").on("submit", function (e) {
        e.preventDefault();
        submitUpdateCustomerForm();
    });
});

function editCustomer(e) {
    e.preventDefault();
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    $("#displayCustomerID").text(dataItem.customerID);
    $("#updateCustomerID").val(dataItem.customerID);
    $("#updateCustomerName").val(dataItem.customerName);
    $("#updatePhone").val(dataItem.phone);
    $("#updateCustomerForm").show();
    $("#overlay").show();
}

function deleteCustomer(e) {
    e.preventDefault();
    let dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    if (confirm('Are you sure you want to delete this customer?')) {
        $.ajax({
            type: "POST",
            url: '/Home/Delete',
            data: { id: dataItem.customerID },
            success: function (response) {
                if (response.success) {
                    showSpinner()
                } else {
                    showAlert(response.message, false);
                }
            },
            error: function () {
                showAlert("An error occurred, please try again later.", false);
            }
        });
    }
}

// Function to submit the customer update form via AJAX
function submitUpdateCustomerForm() {
    var customerData = {
        CustomerID: $("#updateCustomerID").val(),
        CustomerName: $("#updateCustomerName").val(),
        Phone: $("#updatePhone").val()
    };

    $.ajax({
        url: '/Home/Update',
        type: 'POST',
        data: customerData,
        success: function (response) {
            if (response.success) {
                hideUpdateCustomerForm();
                showSpinner();
            } else {
                showAlert(response.message, false);
            }
        },
        error: function () {
            showAlert("An error occurred, please try again later.", false);
        }
    });
}

// Function to display alerts
function showAlert(message, isSuccess) {
    $("#alert-overlay").show();
    $(".alert-form").show();
    $("#alertMessage").text(message);
    $(".okButton").off().on("click", hideAlertForm);
}

// Functions to show/hide forms
function showCustomerForm() {
    document.getElementById('customerForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideCustomerForm() {
    document.getElementById('customerForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

function hideUpdateCustomerForm() {
    document.getElementById('updateCustomerForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

function showSpinner() {
    $("#loadingSpinner").show();

    setTimeout(function () {
        window.location.reload();
    }, 800);
}

function hideAlertForm() {
    $("#alert-overlay").hide();
    $(".alert-form").hide();
    showSpinner();
}