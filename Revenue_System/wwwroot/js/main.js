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

$(document).ready(function () {
    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: '/Home/GetCustomers',
                    dataType: "json"
                },
                create: {
                    url: '/Home/Create',
                    type: "POST",
                    dataType: "json"
                },
                update: {
                    url: '/Home/Update',
                    type: "POST",
                    dataType: "json"
                },
                destroy: {
                    url: '/Home/Delete',
                    type: "POST",
                    dataType: "json"
                },
            },
            schema: {
                model: {
                    id: "CustomerID",
                    fields: {
                        customerID: { editable: false, nullable: true },
                        customerName: { validation: { required: true } },
                        phone: { validation: { required: true } }
                    }
                }
            },
            pageSize: 10
        },
        pageable: true,
        sortable: true,
        columns: [
            { field: "customerID", title: "Customer ID" },
            { field: "customerName", title: "Customer Name" },
            { field: "phone", title: "Phone Number" },
            { command: [{ text: "Edit", click: editCustomer }, { text: "Delete", click: deleteCustomer }], title: "Action", width: "200px" }
        ]
    });
});

function createCustomer() {
    var data = {
        customerID: $("#customerID").val(),
        customerName: $("#customerName").val(),
        phone: $("#phone").val()
    };

    $.ajax({
        type: "POST",
        url: '/Home/Create',
        data: data,
        success: function (response) {
            if (response.success) {
                $("#grid").data("kendoGrid").dataSource.read();
                hideCustomerForm();
            } else {
                alert(response.message);
            }
        }
    });
}

function editCustomer(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    $("#displayCustomerID").text(dataItem.customerID);
    $("#updateCustomerID").val(dataItem.customerID);
    $("#updateCustomerName").val(dataItem.customerName);
    $("#updatePhone").val(dataItem.phone);
    $("#updateCustomerForm").show();
    $("#overlay").show();
}

function updateCustomer() {
    var data = {
        customerID: $("#updateCustomerID").val(),
        customerName: $("#updateCustomerName").val(),
        phone: $("#updatePhone").val()
    };

    $.ajax({
        type: "POST",
        url: '/Home/Update',
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (response) {
            if (response.success) {
                $("#grid").data("kendoGrid").dataSource.read();
                hideUpdateCustomerForm();
            } else {
                alert(response.message);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("Error: " + textStatus, errorThrown);
            alert("Cập nhật không thành công. Vui lòng kiểm tra và thử lại.");
        }
    });
}

function deleteCustomer(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    if (confirm('Bạn có chắc chắn muốn xóa khách hàng này không?')) {
        $.ajax({
            type: "POST",
            url: '/Home/Delete',
            data: { id: dataItem.customerID },
            success: function (response) {
                if (response.success) {
                    $("#grid").data("kendoGrid").dataSource.read();
                } else {
                    alert(response.message);
                }
            }
        });
    }
}
