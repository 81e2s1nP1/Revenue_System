-- Tính tổng doanh thu bán hàng
SELECT 
	SUM(TotalPrice) AS TotalRevenue
FROM 
	InvoiceDetails;

-- Tính doanh thu theo từng khách hàng
DECLARE @id NVARCHAR(50) = 'KH01'; -- data test

SELECT  
    SUM(InvoiceDetails.TotalPrice) AS TotalRevenue
FROM 
    InvoiceDetails
INNER JOIN Invoice ON InvoiceDetails.InvoiceID = Invoice.InvoiceID
INNER JOIN Customer ON Invoice.CustomerID = Customer.CustomerID
WHERE 
    Customer.CustomerID = @id

-- Liệt kê các sản phẩm đã bán với tổng số lượng bán ra
SELECT
	Product.ProductName,
	SUM(InvoiceDetails.Quantity) AS TotalQuantity
FROM
	InvoiceDetails
INNER JOIN Product ON InvoiceDetails.ProductID = Product.ProductID
GROUP BY
    Product.ProductName;

-- Tính doanh thu theo ngày
DECLARE @Date NVARCHAR(50) = '2024-09-18'; -- data test

SELECT
	SUM(InvoiceDetails.TotalPrice) AS TotalRevenue
FROM 
    InvoiceDetails
INNER JOIN Invoice ON InvoiceDetails.InvoiceID = Invoice.InvoiceID
WHERE
	Invoice.InvoiceDate = @Date