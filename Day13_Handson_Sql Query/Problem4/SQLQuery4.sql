


USE customerdb;
GO


DROP TABLE IF EXISTS order_items;
DROP TABLE IF EXISTS stocks;
DROP TABLE IF EXISTS stores;
DROP TABLE IF EXISTS products;
GO



CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100)
);

CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE stocks (
    stock_id INT PRIMARY KEY,
    product_id INT,
    store_id INT,
    stock_quantity INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    store_id INT,
    quantity_sold INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);
GO




INSERT INTO products (product_id, product_name) VALUES 
(1, 'Apple'),
(2, 'Banana'),
(3, 'Orange');


INSERT INTO stores (store_id, store_name) VALUES 
(1, 'Hyderabad'),
(2, 'Chennai');


INSERT INTO stocks (stock_id, product_id, store_id, stock_quantity) VALUES
(1, 1, 1, 50),   
(2, 1, 2, 20),   
(3, 2, 1, 100),  
(4, 2, 2, 60),   
(5, 3, 1, 30);   


INSERT INTO order_items (order_item_id, order_id, product_id, store_id, quantity_sold) VALUES
(1, 101, 1, 1, 30),  
(2, 102, 2, 1, 70),  
(3, 103, 2, 2, 50);  
GO



SELECT 
    p.product_name,
    s.store_name,
    st.stock_quantity AS available_stock,
    COALESCE(SUM(oi.quantity_sold), 0) AS total_sold
FROM stocks st
INNER JOIN products p ON st.product_id = p.product_id
INNER JOIN stores s ON st.store_id = s.store_id
LEFT JOIN order_items oi 
    ON st.product_id = oi.product_id 
    AND st.store_id = oi.store_id
GROUP BY 
    p.product_name,
    s.store_name,
    st.stock_quantity
ORDER BY 
    p.product_name;