CREATE TABLE [dbo].[Cliente] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Nombre]   NVARCHAR (100) NOT NULL,
    [Apellido] NVARCHAR (100) NOT NULL,
    [Email]    NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

