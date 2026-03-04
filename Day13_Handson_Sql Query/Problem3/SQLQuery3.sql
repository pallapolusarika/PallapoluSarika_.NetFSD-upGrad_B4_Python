
USE CustomerDB;
GO


IF OBJECT_ID('sales_order_items', 'U') IS NOT NULL DROP TABLE sales_order_items;
IF OBJECT_ID('sales_orders', 'U') IS NOT NULL DROP TABLE sales_orders;
IF OBJECT_ID('sales_stores', 'U') IS NOT NULL DROP TABLE sales_stores;
GO


CREATE TABLE sales_stores (
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100)
);

CREATE TABLE sales_orders (
    order_id INT PRIMARY KEY IDENTITY(100,1),
    store_id INT,
    order_status INT,
    FOREIGN KEY (store_id) REFERENCES sales_stores(store_id)
);

CREATE TABLE sales_order_items (
    order_item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES sales_orders(order_id)
);
GO

INSERT INTO sales_stores (store_name)
VALUES 
('Hyderabad Store'),
('Chennai Store');

INSERT INTO sales_orders (store_id, order_status)
VALUES 
(1,4),
(1,4),
(2,4);

INSERT INTO sales_order_items (order_id, quantity, list_price, discount)
VALUES
(100,2,1000,0.10),
(101,1,2000,0.05),
(102,3,500,0.00);
GO


SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM sales_stores s
INNER JOIN sales_orders o
    ON s.store_id = o.store_id
INNER JOIN sales_order_items oi
    ON o.order_id = oi.order_id
WHERE o.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC;