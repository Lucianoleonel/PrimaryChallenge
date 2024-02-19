CREATE TABLE [dbo].[Customer] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Surname]       NVARCHAR (MAX) NOT NULL,
    [BirthDate]   DATETIME2 (7)  NOT NULL,
    [CUIT]        NVARCHAR (12) NOT NULL,
    [Address]        NVARCHAR (MAX) NOT NULL,
    [Phone]       NVARCHAR (15) NOT NULL,
    [Email] NVARCHAR (30) NOT NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([Id] ASC)
);
