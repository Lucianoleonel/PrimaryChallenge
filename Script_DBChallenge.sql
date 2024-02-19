
IF NOT EXISTS (
    SELECT name 
    FROM sys.databases 
    WHERE name = N'DBChallenge'
)
BEGIN
    CREATE DATABASE [DBChallenge]
    PRINT 'La base de datos [DBChallenge] ha sido creada.'
END
ELSE
BEGIN
    PRINT 'La base de datos [DBChallenge] ya existe.'
END

USE [DBChallenge]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[BirthDate] [datetime2](7) NOT NULL,
	[CUIT] [nvarchar](12) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 
GO
INSERT [dbo].[Customer] ([Id], [Name], [Surname], [BirthDate], [CUIT], [Address], [Phone], [Email]) VALUES (8, N'name app', N'surname', CAST(N'1983-12-03T00:00:00.0000000' AS DateTime2), N'5461651', N'err  561561', N'dsfgds5161', N'mailapp')
GO
INSERT [dbo].[Customer] ([Id], [Name], [Surname], [BirthDate], [CUIT], [Address], [Phone], [Email]) VALUES (9, N'name man 9', N'surname postman 9', CAST(N'1993-10-23T00:00:00.0000000' AS DateTime2), N'15615615696', N'Address 9', N'1010121215', N'sdfad@mail.com')
GO
INSERT [dbo].[Customer] ([Id], [Name], [Surname], [BirthDate], [CUIT], [Address], [Phone], [Email]) VALUES (10, N'name post updated', N'surn postman', CAST(N'1993-10-03T00:00:00.0000000' AS DateTime2), N'15981498165', N'Address updated', N'6516516511', N'mail@mail10updated')
GO
INSERT [dbo].[Customer] ([Id], [Name], [Surname], [BirthDate], [CUIT], [Address], [Phone], [Email]) VALUES (11, N'name post', N'surn postman', CAST(N'1993-10-03T00:00:00.0000000' AS DateTime2), N'15981498', N'Address', N'dsfgds5161', N'mailupdated')
GO
INSERT [dbo].[Customer] ([Id], [Name], [Surname], [BirthDate], [CUIT], [Address], [Phone], [Email]) VALUES (13, N'name post 13', N'surn postman 13', CAST(N'1993-10-03T00:00:00.0000000' AS DateTime2), N'45645645645', N'Address  1165', N'1651651651', N'mailupdated@mail')
GO
INSERT [dbo].[Customer] ([Id], [Name], [Surname], [BirthDate], [CUIT], [Address], [Phone], [Email]) VALUES (15, N'cliente nombre', N'cliente apellido', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'31151515151', N'Direccion Cliente', N'1516516516', N'clientemail@cliente.com')
GO
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
