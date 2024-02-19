IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PrimaryChallenge')
BEGIN
    CREATE DATABASE PrimaryChallenge;
    PRINT 'Se ha creado la base de datos PrimaryChallenge';
END
ELSE
BEGIN
    PRINT 'La base de datos PrimaryChallenge ya existe, no es necesario crearla nuevamente';
END

USE [ChallengePrimary]

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Cliente')
BEGIN
CREATE TABLE Cliente (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL
);
PRINT 'Se ha creado la tabla Cliente';
END
ELSE
BEGIN
    PRINT 'La la tabla Cliente ya existe';
END
  

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Moneda')
BEGIN
CREATE TABLE [dbo].[Moneda] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Descripcion]  NVARCHAR (50) NOT NULL,
    [Simbolo] NVARCHAR (10)  NOT NULL,
    [Iso] NVARCHAR(10) NULL, 
    [Codigo] INT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

PRINT 'Se ha creado la tabla Moneda';
END
ELSE
BEGIN
    PRINT 'La la tabla Moneda ya existe';
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TipoCambio')
BEGIN
CREATE TABLE TipoCambio (
    Id INT PRIMARY KEY IDENTITY,
    Origen NVARCHAR(100) NOT NULL,
    Fecha  NVARCHAR(100) NULL,
    Comprador DECIMAL(18, 2) NOT NULL,
    Vendedor DECIMAL(18, 2) NOT NULL,
    MonedaId INT NOT NULL,
    FOREIGN KEY (MonedaId) REFERENCES Moneda(Id)
);
PRINT 'Se ha creado la tabla TipoCambio';
END
ELSE
BEGIN
    PRINT 'La la tabla TipoCambio ya existe';
END

--esta tabla emula la invocacion al servicio /api/v9/get-all-cotizaciones-monedas
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'MonedaCotizacion')
BEGIN
    CREATE TABLE MonedaCotizacion (
        Id INT PRIMARY KEY,
        CodMoneda INT NOT NULL,
        Descripcion NVARCHAR(100) NOT NULL,
        Simbolo NVARCHAR(10) NOT NULL,
        Iso NVARCHAR(10) NOT NULL,
        Cotizacion DECIMAL(18, 2) NOT NULL,
        Fecha DATE NOT NULL,
        CotizacionValuacion DECIMAL(18, 2) NOT NULL
    );
    PRINT 'Se ha creado la tabla MonedaCotizacion';
END
ELSE
BEGIN
    PRINT 'La tabla MonedaCotizacion ya existe.';
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Transaccion')
BEGIN
    -- Crea la tabla Transaccion solo si no existe
    CREATE TABLE Transaccion (
        Id INT PRIMARY KEY IDENTITY,
        ClienteId INT NOT NULL,
        MonedaId INT NOT NULL,
        MontoOperado DECIMAL(18, 2) NOT NULL,
        TipoCambio DECIMAL(18, 2) NOT NULL,
        TipoCambioDescripcion NVARCHAR(50) NULL,
        Fecha DATETIME NOT NULL,
        Tipo NVARCHAR(10) NOT NULL,
        CONSTRAINT FK_Transaccion_Cliente FOREIGN KEY (ClienteId) REFERENCES Cliente(Id),
        CONSTRAINT FK_Transaccion_Moneda FOREIGN KEY (MonedaId) REFERENCES Moneda(Id),
        CONSTRAINT CK_Tipo CHECK (Tipo IN ('Compra', 'Venta'))
    );
    PRINT 'Se ha creado la tabla Transaccion';
END
ELSE
BEGIN
    PRINT 'La la tabla Transaccion ya existe';
END

ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_Cliente]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [CK_Tipo] CHECK  (([TipoOperacion]='Venta' OR [TipoOperacion]='Compra'))
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [CK_Tipo]
GO
