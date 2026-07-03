USE [SecondHandDB]
GO

-- 0. 清空商品相关旧数据，重置自增
DELETE FROM dbo.orders;
DELETE FROM dbo.goods_images;
DELETE FROM dbo.goods;
DBCC CHECKIDENT ('dbo.orders', RESEED, 0);
DBCC CHECKIDENT ('dbo.goods_images', RESEED, 29);
DBCC CHECKIDENT ('dbo.goods', RESEED, 39);
GO

-- 1. goods（9 件在售商品，依赖: seller_id → users, category_id → categories）
SET IDENTITY_INSERT [dbo].[goods] ON 

INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (30, N'宿舍遮光床帐', CAST(18.00 AS Decimal(10, 2)), N'毕业出，八成新附带挂钩，夏季防蚊', N'在售', CAST(N'2026-07-03T10:44:50.200' AS DateTime), 6, 3)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (31, N'户外驱蚊喷雾', CAST(12.00 AS Decimal(10, 2)), N'全新未拆，去年军训囤多了用不完', N'在售', CAST(N'2026-07-03T10:44:50.203' AS DateTime), 6, 7)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (32, N'羽毛球一桶（5支）', CAST(30.00 AS Decimal(10, 2)), N'九五新仅打过三次，送手胶两卷', N'在售', CAST(N'2026-07-03T10:44:50.207' AS DateTime), 7, 4)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (33, N'柠檬味气泡水（整箱）', CAST(20.00 AS Decimal(10, 2)), N'快递买多了一箱，未拆封', N'在售', CAST(N'2026-07-03T10:44:50.207' AS DateTime), 5, 6)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (34, N'运动手表', CAST(120.00 AS Decimal(10, 2)), N'用了半年，心率/计步/防水，换新出旧', N'在售', CAST(N'2026-07-03T10:44:50.207' AS DateTime), 1, 5)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (35, N'全新口红（豆沙色）', CAST(39.00 AS Decimal(10, 2)), N'朋友送的色号不合适，仅试色', N'在售', CAST(N'2026-07-03T10:44:50.207' AS DateTime), 4, 7)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (36, N'动漫手办摆件', CAST(2.50 AS Decimal(10, 2)), N'小黑子懂的都懂', N'在售', CAST(N'2026-07-03T10:44:50.210' AS DateTime), 5, 6)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (37, N'美术橡皮擦套装（4块）', CAST(8.00 AS Decimal(10, 2)), N'买多了出半套', N'在售', CAST(N'2026-07-03T10:44:50.210' AS DateTime), 3, 3)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id]) VALUES (38, N'纯牛奶整箱（16盒）', CAST(35.00 AS Decimal(10, 2)), N'日期新鲜，囤太多喝不完', N'在售', CAST(N'2026-07-03T10:44:50.210' AS DateTime), 5, 4)
SET IDENTITY_INSERT [dbo].[goods] OFF
GO

-- 2. goods_images（依赖: goods_id → goods）
SET IDENTITY_INSERT [dbo].[goods_images] ON 

INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (20, 30, N'Upload_image\goods_30_21d66f0e47ff4a98aae52ab1a98eca2b.png', 1, CAST(N'2026-07-03T10:45:03.680' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (21, 31, N'Upload_image\goods_31_9bd4da56b2a040298f28a1f5a6eccdad.png', 1, CAST(N'2026-07-03T10:45:03.683' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (22, 32, N'Upload_image\goods_32_bdafdae18a3041fca74f50dcd5ad541a.png', 1, CAST(N'2026-07-03T10:45:03.683' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (23, 33, N'Upload_image\goods_33_27d31f2ee0734c06a91e86f3c66ca0a2.png', 1, CAST(N'2026-07-03T10:45:03.683' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (24, 34, N'Upload_image\goods_34_88c44574665b400d975660b23df4bd0e.png', 1, CAST(N'2026-07-03T10:45:03.683' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (25, 35, N'Upload_image\goods_35_c98e40f50f7b432398953054d2934988.png', 1, CAST(N'2026-07-03T10:45:03.683' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (26, 36, N'Upload_image\goods_36_335f53b8f934460590d4504e9381828f.png', 1, CAST(N'2026-07-03T10:45:03.687' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (27, 37, N'Upload_image\goods_37_a099d2de3d7d49088504954e3419d945.png', 1, CAST(N'2026-07-03T10:45:03.687' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (28, 38, N'Upload_image\goods_38_0a9ad2de1f884ad6b1c4a9f39bf2be36.png', 1, CAST(N'2026-07-03T10:45:03.687' AS DateTime))
SET IDENTITY_INSERT [dbo].[goods_images] OFF
GO
