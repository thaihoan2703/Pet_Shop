USE [QuanlyPetStore]
GO
SET IDENTITY_INSERT [dbo].[Suplier] ON 

INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo]) VALUES (1, N'Thái Hoàn', N'526 Nguyễn Văn Cừ ', N'0916491863', N'hoan@gmail.com', NULL)
INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo]) VALUES (2, N'Lan Thanh', N'69 Tân Lập ', N'0976948541', N'thanh@mail.com', NULL)
SET IDENTITY_INSERT [dbo].[Suplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [DisplayName], [Price], [IdSuplier], [BarCode], [Inventory], [image]) VALUES (1, N'Thức ăn cho chó', 120000, 1, N'123', 100, NULL)
INSERT [dbo].[Product] ([Id], [DisplayName], [Price], [IdSuplier], [BarCode], [Inventory], [image]) VALUES (2, N'Thức ăn cho mèo', 100000, 1, N'233', 100, NULL)
INSERT [dbo].[Product] ([Id], [DisplayName], [Price], [IdSuplier], [BarCode], [Inventory], [image]) VALUES (3, N'Chuồng chó', 500000, 2, N'311', 40, NULL)
INSERT [dbo].[Product] ([Id], [DisplayName], [Price], [IdSuplier], [BarCode], [Inventory], [image]) VALUES (4, N'Nệm cho mèo', 130000, 2, N'411', 50, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [IdPet]) VALUES (1, N'Hoàn Thái', N'526 NVC', N'091122333', N'adf@gmail.com', NULL, NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [IdPet]) VALUES (2, N'Tuấn Tài', N'Dĩ An', N'0916491863', NULL, NULL, NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [IdPet]) VALUES (3, N'Hoan Thai', N'Binh DUong', N'012312312', N'abc', NULL, NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [IdPet]) VALUES (5, N'Vũ Văn Tài', N'dfasdfad', N'342343', NULL, NULL, NULL)
INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [IdPet]) VALUES (8, N'Bùi Trọng Tấn', N'69 Mai Chí Thọ', N'0912347653', N'tan@yahoo.com', N'Thích mèo nhật', NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([Id], [DisplayName], [Description], [Price]) VALUES (1, N'Tỉa lông thú cưng', N'Tạo theo kiểu mẫu', 400000)
INSERT [dbo].[Service] ([Id], [DisplayName], [Description], [Price]) VALUES (2, N'Tắm rửa thú cưng', N'Sạch sẽ ', 200000)
INSERT [dbo].[Service] ([Id], [DisplayName], [Description], [Price]) VALUES (3, N'Giữ hộ thú cưng', N'Chu đáo', 100000)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([Id], [DateOutput], [TotalPrice]) VALUES (1, CAST(N'2023-10-18T03:53:56.757' AS DateTime), 120000)
INSERT [dbo].[Invoice] ([Id], [DateOutput], [TotalPrice]) VALUES (2, CAST(N'2023-10-18T03:55:42.220' AS DateTime), 230000)
INSERT [dbo].[Invoice] ([Id], [DateOutput], [TotalPrice]) VALUES (3, CAST(N'2023-10-18T03:58:29.803' AS DateTime), 500000)
SET IDENTITY_INSERT [dbo].[Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[InvoiceInfo] ON 

INSERT [dbo].[InvoiceInfo] ([Id], [IdProduct], [IdService], [IdInvoice], [IdCustomer], [Quantity], [Price], [TotalPrice], [Status]) VALUES (1, 1, NULL, 1, NULL, 1, 120000, 120000, NULL)
INSERT [dbo].[InvoiceInfo] ([Id], [IdProduct], [IdService], [IdInvoice], [IdCustomer], [Quantity], [Price], [TotalPrice], [Status]) VALUES (2, 2, NULL, 2, NULL, 1, 100000, 100000, NULL)
INSERT [dbo].[InvoiceInfo] ([Id], [IdProduct], [IdService], [IdInvoice], [IdCustomer], [Quantity], [Price], [TotalPrice], [Status]) VALUES (3, 4, NULL, 2, NULL, 1, 130000, 130000, NULL)
INSERT [dbo].[InvoiceInfo] ([Id], [IdProduct], [IdService], [IdInvoice], [IdCustomer], [Quantity], [Price], [TotalPrice], [Status]) VALUES (4, 3, NULL, 3, NULL, 1, 500000, 500000, NULL)
SET IDENTITY_INSERT [dbo].[InvoiceInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (1, N'Hoan', N'admin', N'admin', 1)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (2, N'Nam', N'user1', N'user1', 2)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (3, N'Toan', N'user2', N'user2', 2)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (4, N'Hieu', N'user3', N'user3', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
