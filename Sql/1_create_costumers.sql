CREATE TABLE customers (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(128) NOT NULL,
    Address VARCHAR(200) NOT NULL,
    Phone VARCHAR(20) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    CreatedAt TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT Email_Unique UNIQUE (Email)
);

INSERT INTO customers (Name, Address, Phone, Email) VALUES
('John Doe', '123 Main St, Springfield, IL', '123-456-7890', 'johndoe@example.com'),
('Jane Smith', '456 Elm St, Springfield, IL', '234-567-8901', 'janesmith@example.com'),
('Alice Johnson', '789 Oak St, Springfield, IL', '345-678-9012', 'alicejohnson@example.com'),
('Bob Brown', '101 Pine St, Springfield, IL', '456-789-0123', 'bobbrown@example.com'),
('Charlie Davis', '202 Maple St, Springfield, IL', '567-890-1234', 'charliedavis@example.com'),
('David Wilson', '303 Birch St, Springfield, IL', '678-901-2345', 'davidwilson@example.com'),
('Eva Thomas', '404 Cedar St, Springfield, IL', '789-012-3456', 'evathomas@example.com'),
('Frank Harris', '505 Cherry St, Springfield, IL', '890-123-4567', 'frankharris@example.com'),
('Grace Lee', '606 Walnut St, Springfield, IL', '901-234-5678', 'gracelee@example.com'),
('Henry White', '707 Willow St, Springfield, IL', '012-345-6789', 'henrywhite@example.com');
