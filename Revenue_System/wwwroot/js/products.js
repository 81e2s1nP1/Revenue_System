// PRODUCT FORM
function showProductForm() {
    document.getElementById('productForm').style.display = 'block';
    document.getElementById('overlay').style.display = 'block';
}

function hideProductForm() {
    document.getElementById('productForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

// Update
//function showUpdateProductForm(productID, productName, price) {
//    document.getElementById('updateProductForm').style.display = 'block';
//    document.getElementById('overlay').style.display = 'block';

//    document.getElementById('displayProductID').textContent = productID;
//    document.getElementById('updateProductID').value = productID;
//    document.getElementById('updateProductName').value = productName;
//    document.getElementById('updatePrice').value = price;
//}

function hideUpdateProductForm() {
    document.getElementById('updateProductForm').style.display = 'none';
    document.getElementById('overlay').style.display = 'none';
}

$(document).ready(function () {
    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: '/Product/GetProducts',
                    dataType: "json"
                },
                create: {
                    url: '/Product/Create',
                    type: "POST",
                    dataType: "json"
                },
                update: {
                    url: '/Product/Update',
                    type: "POST",
                    dataType: "json"
                },
                destroy: {
                    url: '/Product/Delete',
                    type: "POST",
                    dataType: "json"
                },
            },
            schema: {
                model: {
                    id: "ProductID",
                    fields: {
                        productID: { editable: false, nullable: true },
                        productName: { validation: { required: true } },
                        price: { type: "number", validation: { required: true } }
                    }
                }
            },
            pageSize: 10
        },
        pageable: true,
        sortable: true,
        columns: [
            { field: "productID", title: "Product ID" },
            { field: "productName", title: "Product Name" },
            { field: "price", title: "Price", format: "{0:c}" },
            { command: [{ text: "Edit", click: editProduct }, { text: "Delete", click: deleteProduct }], title: "Action", width: "200px" }
        ]
    });
});
function editProduct(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    $("#displayProductID").text(dataItem.productID);
    $("#updateProductID").val(dataItem.productID);
    $("#updateProductName").val(dataItem.productName);
    $("#updatePrice").val(dataItem.price);
    $("#updateProductForm").show();
    $("#overlay").show();
}


function createProduct() {
    var data = {
        productID: $("#productID").val(),
        productName: $("#productName").val(),
        price: $("#price").val()
    };

    $.ajax({
        type: "POST",
        url: '/Product/Create',
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (response) {
            if (response.success) {
                $("#grid").data("kendoGrid").dataSource.read();
                hideProductForm();
            } else {
                alert(response.message);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error("Error: " + textStatus, errorThrown);
            alert("Thêm sản phẩm không thành công. Vui lòng kiểm tra và thử lại.");
        }
    });
}

function updateProduct() {
    var data = {
        productID: $("#updateProductID").val(),
        productName: $("#updateProductName").val(),
        price: $("#updatePrice").val()
    };

    $.ajax({
        type: "POST",
        url: '/Product/Update',
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (response) {
            if (response.success) {
                $("#grid").data("kendoGrid").dataSource.read();
                hideUpdateProductForm();
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

function deleteProduct(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    if (confirm('Bạn có chắc chắn muốn xóa sản phẩm này không?')) {
        $.ajax({
            type: "POST",
            url: '/Product/Delete',
            data: { id: dataItem.productID },
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
