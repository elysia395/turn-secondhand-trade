USE [SecondHandDB]
GO

-- 0. 清空旧数据，重置自增
DELETE FROM dbo.orders;
DELETE FROM dbo.goods_images;
DELETE FROM dbo.goods;
DELETE FROM dbo.users;
DELETE FROM dbo.categories;
DELETE FROM dbo.roles;
DBCC CHECKIDENT ('dbo.orders', RESEED, 0);
DBCC CHECKIDENT ('dbo.goods_images', RESEED, 0);
DBCC CHECKIDENT ('dbo.goods', RESEED, 0);
DBCC CHECKIDENT ('dbo.users', RESEED, 0);
DBCC CHECKIDENT ('dbo.categories', RESEED, 0);
DBCC CHECKIDENT ('dbo.roles', RESEED, 0);
GO

-- 1. roles
SET IDENTITY_INSERT [dbo].[roles] ON 

INSERT [dbo].[roles] ([role_id], [role_name], [role_desc], [is_user_manage], [is_goods_manage], [is_order_manage], [is_system_manage]) VALUES (1, N'消费用户', N'可注册、登录、发布商品、购买商品、查看自己的订单', 0, 0, 0, 0)
INSERT [dbo].[roles] ([role_id], [role_name], [role_desc], [is_user_manage], [is_goods_manage], [is_order_manage], [is_system_manage]) VALUES (2, N'商品管理员', N'仅可查看和删除所有商品', 0, 1, 0, 0)
INSERT [dbo].[roles] ([role_id], [role_name], [role_desc], [is_user_manage], [is_goods_manage], [is_order_manage], [is_system_manage]) VALUES (3, N'超级管理员', N'拥有所有管理权限', 1, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[roles] OFF
GO

-- 2. categories
SET IDENTITY_INSERT [dbo].[categories] ON 

INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (1, N'电子产品')
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (2, N'服饰鞋包')
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (3, N'教材教辅')
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (4, N'美妆护肤')
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (5, N'其他')
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (6, N'生活用品')
INSERT [dbo].[categories] ([category_id], [category_name]) VALUES (7, N'运动器材')
SET IDENTITY_INSERT [dbo].[categories] OFF
GO

-- 3. users（FK: role_id → roles）
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (1, N'admin', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138000', N'广州中医药大学大学城校区行政楼', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 3, N'active', NULL)
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (2, N'goods_admin', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138001', N'广州中医药大学大学城校区后勤楼', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 2, N'active', NULL)
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (3, N'张三', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138002', N'广州中医药大学大学城校区1栋302', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 1, N'active', NULL)
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (4, N'李四', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138003', N'广州中医药大学大学城校区2栋405', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 1, N'active', NULL)
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (5, N'王五', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138004', N'广州中医药大学大学城校区3栋501', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 1, N'active', NULL)
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (6, N'小明', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138005', N'广州中医药大学大学城校区4栋206', CAST(N'2026-06-16T09:20:00.000' AS DateTime), 1, N'active', NULL)
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (7, N'小红', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138006', N'广州中医药大学大学城校区4栋308', CAST(N'2026-06-16T09:22:00.000' AS DateTime), 1, N'active', NULL)
SET IDENTITY_INSERT [dbo].[users] OFF
GO

-- 4. goods（依赖: seller_id → users, category_id → categories）
SET IDENTITY_INSERT [dbo].[goods] ON 

INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (1, N'高等数学（第七版）上下册', CAST(35.00 AS Decimal(10, 2)), N'九成新，少量笔记，配套课后答案', N'已售', CAST(N'2026-06-12T14:50:36.000' AS DateTime), 3, 3, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (3, N'宿舍床上书桌', CAST(25.00 AS Decimal(10, 2)), N'可折叠，九成新，送防滑垫', N'已售', CAST(N'2026-06-12T14:50:36.000' AS DateTime), 6, 5, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (4, N'英语六级真题2025版', CAST(18.00 AS Decimal(10, 2)), N'全新未拆封，含听力音频', N'在售', CAST(N'2026-06-12T14:50:36.000' AS DateTime), 3, 3, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (5, N'羽毛球拍一对', CAST(50.00 AS Decimal(10, 2)), N'胜利品牌，用了半年，送3个羽毛球', N'已售', CAST(N'2026-06-12T14:50:36.000' AS DateTime), 7, 4, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (6, N'全新口红 豆沙色', CAST(69.00 AS Decimal(10, 2)), N'仅试色，包装盒齐全', N'已售', CAST(N'2026-06-16T09:25:00.000' AS DateTime), 4, 6, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (7, N'人体工学电竞椅', CAST(120.00 AS Decimal(10, 2)), N'坐了半年，无破损，可调节高度', N'已售', CAST(N'2026-06-16T09:28:00.000' AS DateTime), 6, 5, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (8, N'计算机四级全套复习资料', CAST(28.00 AS Decimal(10, 2)), N'纸质习题+网课电子讲义', N'已售', CAST(N'2026-06-16T09:30:00.000' AS DateTime), 3, 6, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (9, N'复古帆布双肩包', CAST(35.00 AS Decimal(10, 2)), N'百搭款式，容量大，无磨损', N'已下架', CAST(N'2026-06-16T09:32:00.000' AS DateTime), 2, 5, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (10, N'羽毛球专业训练球一桶', CAST(42.00 AS Decimal(10, 2)), N'一桶12只，剩余10只', N'在售', CAST(N'2026-06-16T09:35:00.000' AS DateTime), 7, 6, NULL, NULL)
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (11, N'二手平板iPad 9代', CAST(1100.00 AS Decimal(10, 2)), N'64G，电池健康86%，送充电器', N'在售', CAST(N'2026-06-16T09:38:00.000' AS DateTime), 1, 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[goods] OFF
GO

-- 5. goods_images（依赖: goods_id → goods）
SET IDENTITY_INSERT [dbo].[goods_images] ON 

INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (1, 1, N'Upload_image\goods_1.png', 1, CAST(N'2026-06-26T10:01:53.210' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (2, 3, N'Upload_image\goods_3.png', 1, CAST(N'2026-06-26T10:01:53.210' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (3, 4, N'Upload_image\goods_4.png', 1, CAST(N'2026-06-26T10:01:53.210' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (4, 5, N'Upload_image\goods_5.png', 1, CAST(N'2026-06-26T10:01:53.210' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (5, 6, N'Upload_image\goods_6.png', 1, CAST(N'2026-06-27T16:39:25.493' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (6, 7, N'Upload_image\goods_7.png', 1, CAST(N'2026-06-27T16:39:25.493' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (7, 8, N'Upload_image\goods_8.png', 1, CAST(N'2026-06-27T16:39:25.493' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (8, 9, N'Upload_image\goods_9.png', 1, CAST(N'2026-06-27T16:39:25.493' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (9, 10, N'Upload_image\goods_10.png', 1, CAST(N'2026-06-27T16:39:25.493' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (10, 11, N'Upload_image\goods_11.png', 1, CAST(N'2026-06-27T16:39:25.493' AS DateTime))
SET IDENTITY_INSERT [dbo].[goods_images] OFF
GO

-- 6. orders（依赖: goods_id → goods, buyer_id → users, seller_id → users）
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (1, 1, 3, N'已完成', CAST(N'2026-06-05T14:51:08.000' AS DateTime), NULL, N'广州中医药大学大学城校区2栋405', 3, CAST(35.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (2, 3, 5, N'待收货', CAST(N'2026-06-10T14:51:08.000' AS DateTime), NULL, N'广州中医药大学大学城校区1栋302', 5, CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (3, 5, 5, N'已完成', CAST(N'2026-06-02T14:51:08.000' AS DateTime), NULL, N'广州中医药大学大学城校区3栋501', 4, CAST(50.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (4, 6, 6, N'待付款', CAST(N'2026-06-16T10:05:00.000' AS DateTime), NULL, N'广州中医药大学大学城校区4栋206', 6, CAST(69.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (5, 7, 4, N'待收货', CAST(N'2026-06-16T10:10:00.000' AS DateTime), NULL, N'广州中医药大学大学城校区2栋405', 5, CAST(120.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (6, 8, 5, N'已完成', CAST(N'2026-06-14T16:30:00.000' AS DateTime), CAST(N'2026-06-15T09:15:00.000' AS DateTime), N'广州中医药大学大学城校区3栋501', 6, CAST(28.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (7, 9, 6, N'已退款', CAST(N'2026-06-15T11:20:00.000' AS DateTime), CAST(N'2026-06-15T14:05:00.000' AS DateTime), N'广州中医药大学大学城校区3栋502', 5, CAST(35.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[orders] OFF
GO
