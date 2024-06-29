CREATE TABLE SaleItems (
    SaleId INTEGER NOT NULL,
    ProductId INTEGER NOT NULL,
    Amount INTEGER NOT NULL CHECK (Amount >= 1),
    CreatedAt TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT FK_SaleItems_SaleEntity FOREIGN KEY (SaleId) REFERENCES Sales(Id),
    CONSTRAINT FK_SaleItems_ProductEntity FOREIGN KEY (ProductId) REFERENCES Products(Id)
);

INSERT INTO SaleItems (SaleId, ProductId, Amount) VALUES
(1, 1, 1),
(1, 6, 2),
(2, 6, 1),
(2, 4, 1),
(3, 5, 3),
(3, 6, 2),
(4, 7, 1),
(4, 8, 2),
(5, 9, 1),
(5, 10, 1),
(6, 1, 1),
(6, 7, 1),
(7, 1, 2),
(7, 4, 1),
(8, 5, 1),
(8, 7, 2),
(9, 6, 1),
(9, 8, 1),
(10, 9, 1),
(10, 10, 1);


