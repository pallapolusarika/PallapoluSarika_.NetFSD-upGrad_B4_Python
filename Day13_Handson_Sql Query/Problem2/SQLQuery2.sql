USE CustomerDB;
GO


IF NOT EXISTS (SELECT 1 FROM brands)
INSERT INTO brands (brand_name) VALUES
('Nike'),
('Adidas'),
('Puma');
GO


IF NOT EXISTS (SELECT 1 FROM categories)
INSERT INTO categories (category_name) VALUES
('Shoes'),
('Clothing'),
('Accessories');
GO


IF NOT EXISTS (SELECT 1 FROM products)
INSERT INTO products (product_name, brand_id, category_id, model_year, list_price) VALUES
('Running Shoes',1,1,2023,800),
('Sports T-Shirt',2,2,2022,400),
('Cap',3,3,2023,600),
('Sneakers',1,1,2024,1200),
('Jacket',2,2,2023,300);
GO
USE CustomerDB;
GO

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b 
    ON p.brand_id = b.brand_id
INNER JOIN categories c 
    ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC;