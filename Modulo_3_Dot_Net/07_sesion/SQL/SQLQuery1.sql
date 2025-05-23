USE TiendaDB;

CREATE TABLE Productos
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre NVARCHAR(100) NOT NULL,
	Precio DECIMAL(18,2) NOT NULL
);

INSERT INTO Productos (Nombre, Precio) VALUES
('iPhone 16',2000.00),
('Galaxy S25 Edge', 21000.00);