CREATE TABLE [dbo].[Transaccion] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [ClienteId]    INT             NOT NULL,
    [MonedaId]     INT             NOT NULL,
    [MontoOperado] DECIMAL (18, 2) NOT NULL,
    [TipoCambio]   DECIMAL (18, 2) NOT NULL,
    [Fecha]        DATETIME        NOT NULL,
    [Tipo]         NVARCHAR (10)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_Tipo] CHECK ([Tipo]='Venta' OR [Tipo]='Compra'),
    CONSTRAINT [FK_Transaccion_Cliente] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[Cliente] ([Id])
);

