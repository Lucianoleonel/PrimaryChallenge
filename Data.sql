SET IDENTITY_INSERT [dbo].[Cliente] ON 
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email]) VALUES (1, N'Jose', N'Larralde', N'jlarra@gmail.com')
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email]) VALUES (2, N'Facundo', N'Cabral', N'facab@outlook.com')
GO
INSERT [dbo].[Cliente] ([Id], [Nombre], [Apellido], [Email]) VALUES (1002, N'Luciano', N'Gomez', N'lucianolgomez@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Cliente] OFF
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
INSERT [dbo].[TipoCambio] ([Id], [Origen], [Comprador], [Vendedor], [MonedaId]) VALUES (1, N'Oficial', CAST(1081.20 AS Decimal(18, 2)), CAST(1001.30 AS Decimal(18, 2)), 2)
GO
INSERT [dbo].[TipoCambio] ([Id], [Origen], [Comprador], [Vendedor], [MonedaId]) VALUES (2, N'Contado con Liquidación', CAST(973.55 AS Decimal(18, 2)), CAST(961.20 AS Decimal(18, 2)), 2)
GO
SET IDENTITY_INSERT [dbo].[TipoCambio] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaccion] ON 
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [Fecha], [Tipo]) VALUES (9, 1, 1, CAST(1500.00 AS Decimal(18, 2)), CAST(1.50 AS Decimal(18, 2)), CAST(N'2024-02-16T00:00:00.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [Fecha], [Tipo]) VALUES (10, 1, 1, CAST(100.00 AS Decimal(18, 2)), CAST(1515.00 AS Decimal(18, 2)), CAST(N'2024-02-16T16:29:53.537' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [Fecha], [Tipo]) VALUES (1002, 1, 2, CAST(200.00 AS Decimal(18, 2)), CAST(1515.00 AS Decimal(18, 2)), CAST(N'2024-02-16T16:29:53.537' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [Fecha], [Tipo]) VALUES (1003, 2, 2, CAST(2.00 AS Decimal(18, 2)), CAST(1515.00 AS Decimal(18, 2)), CAST(N'2024-02-16T16:29:53.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [Fecha], [Tipo]) VALUES (1004, 2, 2, CAST(1.00 AS Decimal(18, 2)), CAST(1023.00 AS Decimal(18, 2)), CAST(N'2024-02-16T16:29:53.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [Fecha], [Tipo]) VALUES (1005, 2, 1, CAST(15.00 AS Decimal(18, 2)), CAST(1500.00 AS Decimal(18, 2)), CAST(N'2024-02-16T16:29:53.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [Fecha], [Tipo]) VALUES (1006, 2, 2, CAST(10.30 AS Decimal(18, 2)), CAST(1269.33 AS Decimal(18, 2)), CAST(N'2024-02-16T16:29:53.000' AS DateTime), N'Compra')
GO
INSERT [dbo].[Transaccion] ([Id], [ClienteId], [MonedaId], [MontoOperado], [TipoCambio], [Fecha], [Tipo]) VALUES (1007, 2, 2, CAST(12.00 AS Decimal(18, 2)), CAST(1053.20 AS Decimal(18, 2)), CAST(N'2024-02-16T00:00:00.000' AS DateTime), N'Compra')
GO
SET IDENTITY_INSERT [dbo].[Transaccion] OFF
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [FK_Transaccion_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [FK_Transaccion_Cliente]
GO
ALTER TABLE [dbo].[Transaccion]  WITH CHECK ADD  CONSTRAINT [CK_Tipo] CHECK  (([Tipo]='Venta' OR [Tipo]='Compra'))
GO
ALTER TABLE [dbo].[Transaccion] CHECK CONSTRAINT [CK_Tipo]
GO
