-- Relatório de total de vendas por período

SELECT
    DATE_TRUNC('day', s.SaleDate) AS SaleDate,
    COUNT(*) AS TotalSales,
    SUM(si.Amount) AS TotalItemsSold,
    SUM(p.Price * si.Amount) AS TotalRevenue
FROM
    Sales s
JOIN
    SaleItems si ON s.Id = si.SaleId
JOIN
    Products p ON si.ProductId = p.Id
GROUP BY
    DATE_TRUNC('day', s.SaleDate)
ORDER BY
    SaleDate;


-- Relatório de produtos mais vendidos

SELECT
    p.Name AS ProductName,
    SUM(si.Amount) AS TotalSold
FROM
    SaleItems si
JOIN
    Products p ON si.ProductId = p.Id
GROUP BY
    p.Name
ORDER BY
    TotalSold DESC;

-- Relatório de vendas por cliente

SELECT
    c.Name AS CustomerName,
    COUNT(*) AS TotalSales,
    SUM(si.Amount) AS TotalItemsSold,
    SUM(p.Price * si.Amount) AS TotalRevenue
FROM
    Sales s
JOIN
    SaleItems si ON s.Id = si.SaleId
JOIN
    Products p ON si.ProductId = p.Id
JOIN
    CustomerEntity c ON s.CostumerId = c.Id
GROUP BY
    c.Name
ORDER BY
    TotalRevenue DESC;

