CREATE TABLE [dbo].[Moneda] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Descripcion] NVARCHAR (50) NOT NULL,
    [Simbolo]     NVARCHAR (10) NOT NULL,
    [Iso]         NVARCHAR (10) NULL,
    [Codigo]      INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

