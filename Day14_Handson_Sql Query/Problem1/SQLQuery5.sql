
IF DB_ID('AutomobileDB') IS NULL
CREATE DATABASE AutomobileDB;
GO

USE AutomobileDB;
GO


DROP TABLE IF EXISTS products;
DROP TABLE IF EXISTS brands;
DROP TABLE IF EXISTS categories;
GO



CREATE TABLE categories (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    category_name VARCHAR(255) NOT NULL
);

CREATE TABLE brands (
    brand_id INT IDENTITY(1,1) PRIMARY KEY,
    brand_name VARCHAR(255) NOT NULL
);

CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_name VARCHAR(255) NOT NULL,
    brand_id INT,
    category_id INT,
    model_year SMALLINT,
    list_price DECIMAL(10,2),
    FOREIGN KEY (brand_id) REFERENCES brands(brand_id),
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
);



INSERT INTO categories(category_name)
VALUES ('Cars'), ('Bikes');

INSERT INTO brands(brand_name)
VALUES ('Toyota'), ('Honda'), ('BMW');

INSERT INTO products(product_name,brand_id,category_id,model_year,list_price)
VALUES
('Toyota Camry',1,1,2019,25000),
('Toyota Corolla',1,1,2018,20000),
('Honda Civic',2,1,2020,27000),
('BMW X5',3,1,2021,60000),
('Honda Bike',2,2,2019,8000),
('BMW Bike',3,2,2020,12000);



SELECT 
    CONCAT(product_name,' (',model_year,')') AS Product_Details,
    product_name,
    model_year,
    list_price,

    (SELECT AVG(p2.list_price)
     FROM products p2
     WHERE p2.category_id = p1.category_id) AS Category_Average,

    list_price -
    (SELECT AVG(p3.list_price)
     FROM products p3
     WHERE p3.category_id = p1.category_id) AS Price_Difference

FROM products p1

WHERE list_price >
      (SELECT AVG(p4.list_price)
       FROM products p4
       WHERE p4.category_id = p1.category_id); 