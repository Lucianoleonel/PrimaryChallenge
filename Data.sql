USE [ChallengePrimary]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email]) VALUES (1, N'Jose', N'Larralde', N'jlarra@gmail.com')
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email]) VALUES (2, N'Facundo', N'Cabral', N'facab@outlook.com')
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email]) VALUES (1002, N'Luciano', N'Gomez', N'lucianolgomez@gmail.com')
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email]) VALUES (1003, N'UserTest', N'ApellidoTest', N'mail.d@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaccion] ON 
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (9, 1, 1, CAST(1500.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), N'Pesos Oficial', CAST(N'2024-02-16T00:00:00.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (10, 1, 1, CAST(100.00 AS Decimal(18, 2)), CAST(1515.00 AS Decimal(18, 2)), N'Pesos Oficial', CAST(N'2024-02-16T16:29:53.537' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1002, 1, 2, CAST(200.00 AS Decimal(18, 2)), CAST(1515.00 AS Decimal(18, 2)), N'Dólar Oficial', CAST(N'2024-02-16T16:29:53.537' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1003, 2, 2, CAST(2.00 AS Decimal(18, 2)), CAST(1515.00 AS Decimal(18, 2)), N'Dólar Blue', CAST(N'2024-02-16T16:29:53.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1004, 2, 2, CAST(1.00 AS Decimal(18, 2)), CAST(1023.00 AS Decimal(18, 2)), N'Dólar Oficial', CAST(N'2024-02-16T16:29:53.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1005, 2, 1, CAST(15.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), N'Pesos Oficial', CAST(N'2024-02-16T16:29:53.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1006, 2, 2, CAST(10.30 AS Decimal(18, 2)), CAST(1269.33 AS Decimal(18, 2)), N'Dolar Soja', CAST(N'2024-02-16T16:29:53.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1007, 2, 2, CAST(12.00 AS Decimal(18, 2)), CAST(1053.20 AS Decimal(18, 2)), N'Dólar Oficial', CAST(N'2024-02-16T00:00:00.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1008, 2, 2, CAST(50.00 AS Decimal(18, 2)), CAST(1630.00 AS Decimal(18, 2)), N'Dolar Soja', CAST(N'2024-02-19T02:02:22.787' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1009, 2, 2, CAST(1.00 AS Decimal(18, 2)), CAST(1630.00 AS Decimal(18, 2)), N'Dólar Blue', CAST(N'2024-02-19T02:02:22.787' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1010, 2, 2, CAST(1.00 AS Decimal(18, 2)), CAST(1630.00 AS Decimal(18, 2)), N'Dólar Oficial', CAST(N'2024-02-19T02:02:22.787' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1013, 2, 2, CAST(15.00 AS Decimal(18, 2)), CAST(1566.00 AS Decimal(18, 2)), N'Dolar Oficial', CAST(N'2024-02-19T16:30:45.300' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [TipoCambioDescripcion], [Fecha], [TipoOperacion]) VALUES (1014, 2, 2, CAST(1.00 AS Decimal(18, 2)), CAST(1053.20 AS Decimal(18, 2)), N'Dolar Oficial', CAST(N'2024-02-19T00:00:00.000' AS DateTime), N'Compra')
GO
SET IDENTITY_INSERT [dbo].[Transaccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Moneda] ON 
GO
INSERT [dbo].[Moneda] ([Id], [Descripcion], [Simbolo], [Iso], [Codigo]) VALUES (1, N'Pesos', N'$', N'ARS', 1)
GO
INSERT [dbo].[Moneda] ([Id], [Descripcion], [Simbolo], [Iso], [Codigo]) VALUES (2, N'Dólar', N'U$S', N'U$S', 2)
GO
SET IDENTITY_INSERT [dbo].[Moneda] OFF
GO
INSERT [dbo].[MonedaCotizacion] ([Id], [CodMoneda], [Descripcion], [Simbolo], [Iso], [Cotizacion], [Fecha], [CotizacionValuacion]) VALUES (1, 1, N'Pesos', N'$', N'ARS', CAST(1053.20 AS Decimal(18, 2)), CAST(N'2024-02-16' AS Date), CAST(10.20 AS Decimal(18, 2)))
GO
INSERT [dbo].[MonedaCotizacion] ([Id], [CodMoneda], [Descripcion], [Simbolo], [Iso], [Cotizacion], [Fecha], [CotizacionValuacion]) VALUES (2, 2, N'Dólar', N'U$S', N'U$S', CAST(1.00 AS Decimal(18, 2)), CAST(N'2024-02-16' AS Date), CAST(2.30 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[TipoCambio] ON 
GO
INSERT [dbo].[TipoCambio] ([Id], [Origen], [Fecha], [Comprador], [Vendedor], [MonedaId]) VALUES (1, N'Oficial', NULL, CAST(1081.20 AS Decimal(18, 2)), CAST(1001.30 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[TipoCambio] ([Id], [Origen], [Fecha], [Comprador], [Vendedor], [MonedaId]) VALUES (2, N'Contado con Liquidación', NULL, CAST(973.55 AS Decimal(18, 2)), CAST(961.20 AS Decimal(18, 2)), 2)
GO
SET IDENTITY_INSERT [dbo].[TipoCambio] OFF
GO
