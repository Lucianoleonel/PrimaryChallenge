CREATE TABLE [dbo].[TipoCambio] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Origen]    NVARCHAR (100)  NOT NULL,
    [Comprador] DECIMAL (18, 2) NOT NULL,
    [Vendedor]  DECIMAL (18, 2) NOT NULL,
    [MonedaId]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

