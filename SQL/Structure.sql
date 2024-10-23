USE WFRevenueSystem;
GO

CREATE TABLE Customer
(
	CustomerID NVARCHAR(50) PRIMARY KEY,
	CustomerName NVARCHAR(255) NOT NULL DEFAULT N'Invalid Name',
	phone NVARCHAR(20) NOT NULL
)
GO

CREATE TABLE Product 
(
	ProductID NVARCHAR(50) PRIMARY KEY,
	ProductName NVARCHAR(255) NOT NULL,
	Price DECIMAL(18,2) NOT NULL
)
GO

CREATE TABLE Invoice
(
	InvoiceID NVARCHAR(50) PRIMARY KEY,
	CustomerID NVARCHAR(50) NOT NULL,
	InvoiceDate DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
)
GO

CREATE TABLE InvoiceDetails 
(
	InvoiceDetailID NVARCHAR(50) PRIMARY KEY,
	InvoiceID NVARCHAR(50) NOT NULL,
	ProductID NVARCHAR(50) NOT NULL,
	Quantity INT NOT NULL DEFAULT 1,
	TotalPrice DEC NOT NULL DEFAULT 1

	FOREIGN KEY (InvoiceID) REFERENCES Invoice(InvoiceID),
	FOREIGN KEY (ProductID) REFERENCES Product(ProductID)
);
GO

-- Thêm sản phẩm mới vào bảng Product với mã sản phẩm dạng SP01, SP02...
INSERT INTO Product (ProductID, ProductName, Price) VALUES
('SP01', 'Sản phẩm A', 100000),
('SP02', 'Sản phẩm B', 200000),
('SP03', 'Sản phẩm C', 150000);
-- Thêm khách hàng mới vào bảng Customer với mã khách hàng dạng KH01, KH02...
INSERT INTO Customer (CustomerID, CustomerName, Phone) VALUES
('KH01', 'Nguyễn Văn A', '0909123456'),
('KH02', 'Trần Thị B', '0909234567');

-- Thêm hóa đơn mới vào bảng Invoice với mã hóa đơn dạng HD01, HD02...
INSERT INTO Invoice (InvoiceID, CustomerID, InvoiceDate) VALUES
('HD01', 'KH01', '2024-09-17'),
('HD02', 'KH02', '2024-09-17'),
('HD03', 'KH01', '2024-09-18'),
('HD04', 'KH02', '2024-09-18'),
('HD05', 'KH01', '2024-09-19');

-- Thêm chi tiết hóa đơn mới vào bảng InvoiceDetails với mã hóa đơn dạng HD01, HD02...
INSERT INTO InvoiceDetails (InvoiceDetailID, InvoiceID, ProductID, Quantity, TotalPrice) VALUES
(1, 'HD01', 'SP01', 2, 200000),
(2, 'HD01', 'SP02', 1, 200000),
(3, 'HD02', 'SP03', 3, 450000),
(4, 'HD03', 'SP01', 1, 100000),
(5, 'HD04', 'SP02', 2, 400000),
(6, 'HD05', 'SP03', 1, 150000);

-- Xóa Bảng nếu tôn tại
DROP TABLE IF EXISTS InvoiceDetails;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS Invoice;
DROP TABLE IF EXISTS Customer;
