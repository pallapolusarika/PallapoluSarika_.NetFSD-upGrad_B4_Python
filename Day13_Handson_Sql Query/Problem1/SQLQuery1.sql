
IF DB_ID('CustomerDB') IS NULL
    CREATE DATABASE CustomerDB;
GO

USE CustomerDB;
GO


IF OBJECT_ID('customers', 'U') IS NULL
CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50)
);
GO


IF OBJECT_ID('orders', 'U') IS NULL
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    customer_id INT,
    order_date DATE,
    order_status INT,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);
GO


IF NOT EXISTS (SELECT 1 FROM customers)
INSERT INTO customers VALUES
(1,'Ravi','Kumar'),
(2,'Sita','Rao'),
(3,'Aman','Sharma');
GO

IF NOT EXISTS (SELECT 1 FROM orders)
INSERT INTO orders VALUES
(101,1,'2026-03-01',1),
(102,2,'2026-03-02',4),
(103,3,'2026-03-03',2),
(104,1,'2026-03-04',4);
GO


SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM customers c
INNER JOIN orders o
    ON c.customer_id = o.customer_id
WHERE o.order_status = 1 
   OR o.order_status = 4
ORDER BY o.order_date DESC;