// INVOICE FORM
function showinvoiceForm() {
    document.getElementById('invoiceForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideinvoiceForm() {
    document.getElementById('invoiceForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

//function showUpdateInvoiceForm(InvoiceID, InvoiceDetailID, Quantity, InvoiceDate) {
//    document.getElementById('updateInvoiceForm').style.display = 'block';
//    document.getElementById('overlay').style.display = 'block';

//    document.getElementById('UpdateInvoiceID').value = InvoiceID;
//    document.getElementById('UpdateInvoiceDetailID').value = InvoiceDetailID;
//    document.getElementById('UpdateQuantity').value = Quantity;

//    // Convert InvoiceDate from "dd/MM/yyyy" to "yyyy-MM-dd"
//    var dateParts = InvoiceDate.split("/");
//    var formattedDate = dateParts[2] + "-" + dateParts[1] + "-" + dateParts[0];

//    document.getElementById('UpdateInvoiceDate').value = formattedDate;
//}

function hideUpdateInvoiceForm() {
    document.getElementById('updateInvoiceForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

function populateCustomerAndProductIDs(customerIDs, productIDs) {
    const customerSelect = document.getElementById('CustomerID');
    const productSelect = document.getElementById('ProductID');

    // Clear existing options
    customerSelect.innerHTML = '<option value="">Chọn Customer ID</option>';
    productSelect.innerHTML = '<option value="">Chọn Product ID</option>';

    // Populate Customer IDs
    customerIDs.forEach(function (customerID) {
        const option = document.createElement('option');
        option.value = customerID;
        option.text = customerID;
        customerSelect.appendChild(option);
    });

    // Populate Product IDs
    productIDs.forEach(function (productID) {
        const option = document.createElement('option');
        option.value = productID;
        option.text = productID;
        productSelect.appendChild(option);
    });
}

$(document).ready(function () {
    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: '/Invoice/GetInvoices',
                    dataType: "json",
                    data: function () {
                        return { invoices: [] };
                    }
                },
                create: {
                    url: '/Invoice/Create',
                    type: "POST",
                    dataType: "json"
                },
                update: {
                    url: '/Invoice/Update',
                    type: "POST",
                    dataType: "json"
                },
                destroy: {
                    url: '/Invoice/Delete',
                    type: "POST",
                    dataType: "json"
                },
            },
            schema: {
                data: function (response) {
                    populateCustomerAndProductIDs(response.customerIDs, response.productIDs);
                    return response.invoices;
                },
                model: {
                    id: "invoiceModel.invoiceID",
                    fields: {
                        invoiceID: { from: "invoiceModel.invoiceID", editable: false, nullable: true },
                        CustomerID: { from: "invoiceModel.customerID", validation: { required: true } },
                        InvoiceDate: { from: "invoiceModel.invoiceDate", validation: { required: true } },
                        ProductID: { from: "invoiceDetailModel.productID", validation: { required: true } },
                        Quantity: { from: "invoiceDetailModel.quantity", validation: { required: true } },
                        TotalPrice: { from: "invoiceDetailModel.totalPrice", validation: { required: true } }
                    }
                }
            },
            pageSize: 10
        },
        pageable: true,
        sortable: true,
        scrollable: true,
        columns: [
            { field: "invoiceModel.invoiceID", title: "Invoice ID", width: "150px" },
            { field: "invoiceModel.customerID", title: "Customer ID", width: "150px" },
            { field: "invoiceModel.invoiceDate", title: "Invoice Date", template: "#= kendo.toString(kendo.parseDate(invoiceModel.invoiceDate), 'MM/dd/yyyy') #", width: "150px" },
            { field: "invoiceDetailModel.productID", title: "Product ID", width: "150px" },
            { field: "invoiceDetailModel.quantity", title: "Quantity", width: "120px" },
            { field: "invoiceDetailModel.totalPrice", title: "Total Price", format: "{0:c}", width: "150px" },
            { command: [{ text: "Edit", click: editInvoice }, { text: "Delete", click: deleteInvoice }], title: "Action", width: "200px" }
        ],
        scrollable: {
            virtual: false
        }
    });
});


function createInvoice() {
    const invoiceID = document.getElementById('InvoiceID').value;
    const customerID = document.getElementById('CustomerID').value;
    const invoiceDate = document.getElementById('InvoiceDate').value;
    const invoiceDetailID = document.getElementById('InvoiceDetailID').value;
    const productID = document.getElementById('ProductID').value;
    const quantity = document.getElementById('Quantity').value;

    if (!invoiceID || !customerID || !invoiceDate || !invoiceDetailID || !productID || !quantity) {
        alert("Please fill all fields.");
        return;
    }

    $.ajax({
        url: '/Invoice/Create',
        type: 'POST',
        data: {
            InvoiceModel: {
                InvoiceID: invoiceID,
                CustomerID: customerID,
                InvoiceDate: invoiceDate
            },
            InvoiceDetailModel: {
                InvoiceDetailID: invoiceDetailID,
                InvoiceID: invoiceID,
                ProductID: productID,
                Quantity: quantity
            }
        },
        success: function (response) {
            if (response.success) {
                alert(response.message);
                hideinvoiceForm();
                $("#grid").data("kendoGrid").dataSource.read();
            } else {
                alert(response.message);
            }
        },
        error: function () {
            alert("Error occurred while creating the invoice.");
        }
    });
}

// format sang định dạng ngày hợp lệ
function formatDate(dateString) {
    // Tạo đối tượng Date từ chuỗi ngày
    var date = new Date(dateString);
    // Lấy năm, tháng, ngày
    var year = date.getFullYear();
    var month = (date.getMonth() + 1).toString().padStart(2, '0'); // Tháng bắt đầu từ 0
    var day = date.getDate().toString().padStart(2, '0');
    // Trả về định dạng YYYY-MM-DD
    return `${year}-${month}-${day}`;
}


function editInvoice(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    $("#displayInvoiceID").text(dataItem.invoiceID);
    $("#updateInvoiceID").val(dataItem.invoiceID);
    $("#displayInvoiceDetailsID").text(dataItem.invoiceDetailModel.invoiceDetailID);
    $("#updateInvoiceDetailsID").val(dataItem.invoiceDetailModel.invoiceDetailID);
    $("#updateQuantity").val(dataItem.Quantity);

    var formattedDate = formatDate(dataItem.InvoiceDate);
    $("#UpdateDate").val(formattedDate);

    $("#updateInvoiceForm").show();
    $("#overlay").show();
}


function updateInvoiceAndInvoiceDetail() {
    const invoiceID = document.getElementById('updateInvoiceID').value;
    const invoiceDetailsID = document.getElementById('updateInvoiceDetailsID').value;
    const quantity = parseInt(document.getElementById('updateQuantity').value);
    const date = document.getElementById('UpdateDate').value;

    const data = {
        InvoiceModel: {
            InvoiceID: invoiceID,
            InvoiceDate: new Date(date).toISOString()
        },
        InvoiceDetailModel: {
            InvoiceDetailID: invoiceDetailsID,
            Quantity: quantity
        }
    };

    console.log("data: " + JSON.stringify(data));

    fetch('/Invoice/Update', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                alert(data.message);
                hideUpdateInvoiceForm();
                location.reload();
            } else {
                alert(data.message);
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Error: ' + error.message);
        });
}


function deleteInvoice(e) {
    e.preventDefault();
    const dataItem = $("#grid").data("kendoGrid").dataItem($(e.currentTarget).closest("tr"));

    if (dataItem) {
        const invoiceID = dataItem.invoiceModel.invoiceID;
        if (confirm(`Bạn có chắc chắn muốn xóa hóa đơn với Invoice ID: ${invoiceID}?`)) {
            $.ajax({
                url: '/Invoice/Delete',
                type: 'POST',
                data: { InvoiceID: invoiceID },
                success: function (response) {
                    if (response.success) {
                        alert(response.message);
                        $("#grid").data("kendoGrid").dataSource.read();
                    } else {
                        alert(response.message);
                    }
                },
                error: function () {
                    alert("Đã xảy ra lỗi khi xóa hóa đơn.");
                }
            });
        }
    } else {
        alert("Không tìm thấy hóa đơn để xóa.");
    }
}


