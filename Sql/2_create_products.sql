CREATE TABLE Products (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(12, 2) NOT NULL CHECK (Price >= 0),
    Stock INTEGER NOT NULL CHECK (Stock >= 0),
    CreatedAt TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO products (Name, Description, Price, Stock) VALUES
('Laptop', 'A high performance laptop', 999.99, 50),
('Smartphone', 'A latest model smartphone', 699.99, 150),
('Headphones', 'Noise-cancelling headphones', 199.99, 200),
('Monitor', '27-inch 4K monitor', 399.99, 75),
('Keyboard', 'Mechanical keyboard with RGB lighting', 89.99, 300),
('Mouse', 'Wireless ergonomic mouse', 49.99, 250),
('Printer', 'All-in-one laser printer', 159.99, 100),
('Tablet', '10-inch Android tablet', 299.99, 120),
('Camera', 'Digital SLR camera with 24MP sensor', 599.99, 80),
('Smartwatch', 'Fitness smartwatch with heart rate monitor', 149.99, 180);
