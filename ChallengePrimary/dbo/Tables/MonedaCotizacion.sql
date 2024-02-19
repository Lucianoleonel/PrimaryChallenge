CREATE TABLE [dbo].[MonedaCotizacion] (
    [Id]                  INT             NOT NULL,
    [CodMoneda]           INT             NOT NULL,
    [Descripcion]         NVARCHAR (100)  NOT NULL,
    [Simbolo]             NVARCHAR (10)   NOT NULL,
    [Iso]                 NVARCHAR (10)   NOT NULL,
    [Cotizacion]          DECIMAL (18, 2) NOT NULL,
    [Fecha]               DATE            NOT NULL,
    [CotizacionValuacion] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

