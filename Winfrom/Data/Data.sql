CREATE DATABASE WFRevenueSystem
GO 

USE WFRevenueSystem
GO 

-- customers 
-- products 
-- invoices
-- invoiceInfos

CREATE TABLE Customers 
(
	CustomerID NVARCHAR(50) PRIMARY KEY,
	CustomerName NVARCHAR(255) NOT NULL DEFAULT N'Invalid Name',
	phone NVARCHAR(20) NOT NULL
)
GO

CREATE TABLE Products 
(
	ProductID NVARCHAR(50) PRIMARY KEY,
	ProductName NVARCHAR(255) NOT NULL,
	Price DECIMAL(18,2) NOT NULL
)
GO

CREATE TABLE Invoices
(
	InvoiceID NVARCHAR(50) PRIMARY KEY,
	CustomerID NVARCHAR(50) NOT NULL,
	InvoiceDate DATETIME NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)
GO

CREATE TABLE InvoiceDetails 
(
	InvoiceDetailsID NVARCHAR(50) PRIMARY KEY,
	InvoiceID NVARCHAR(50) NOT NULL,
	ProductID NVARCHAR(50) NOT NULL,
	Quantity INT NOT NULL DEFAULT 1,

	FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID),
	FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO
