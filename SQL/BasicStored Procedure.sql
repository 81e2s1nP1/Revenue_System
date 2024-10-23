-- Stored Procedure để thêm sản phẩm mới
CREATE PROCEDURE InsertProduct 
    @ProductID NVARCHAR(50), 
    @ProductName NVARCHAR(255), 
    @Price DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Product(ProductID, ProductName, Price) 
    VALUES (@ProductID, @ProductName, @Price);
END
GO

-- Stored Procedure tính tổng doanh thu theo ngày
CREATE PROCEDURE TotalRevenue 
    @Date DATETIME
AS
BEGIN
    SELECT SUM(InvoiceDetails.TotalPrice) AS TotalRevenue
    FROM InvoiceDetails
    INNER JOIN Invoice ON InvoiceDetails.InvoiceID = Invoice.InvoiceID
    WHERE Invoice.InvoiceDate = @Date;	
END
GO

-- Stored Procedure tìm hóa đơn theo khách hàng
CREATE PROCEDURE GetInvoiceByCustomer 
    @CustomerID NVARCHAR(50)
AS
BEGIN
    SELECT *
    FROM Invoice
    INNER JOIN Customer ON Invoice.CustomerID = Customer.CustomerID
    WHERE Customer.CustomerID = @CustomerID;
END
GO

-- Stored Procedure để cập nhật giá sản phẩm
CREATE PROCEDURE UpdateProductPrice 
    @ProductID NVARCHAR(50), 
    @NewPrice DECIMAL(18,2)
AS
BEGIN
    UPDATE Product 
    SET Price = @NewPrice
    WHERE ProductID = @ProductID;
END
GO

-- Stored Procedure xóa sản phẩm
CREATE PROCEDURE DeleteProduct 
    @ProductID NVARCHAR(50)
AS
BEGIN
    DELETE FROM InvoiceDetails
    WHERE ProductID = @ProductID;
    DELETE FROM Product
    WHERE ProductID = @ProductID;
END
GO

EXEC InsertProduct 'SP04', 'Sản phẩm D', 250000; -- Ví dụ
EXEC TotalRevenue '2024-09-17'; -- Ví dụ
EXEC GetInvoiceByCustomer 'KH01'; -- Ví dụ
EXEC UpdateProductPrice 'SP01', 120000;  -- Ví dụ
EXEC DeleteProduct 'SP01';  -- Ví dụ
