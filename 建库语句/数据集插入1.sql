USE [SecondHandDB]
GO

-- 0. 清空旧数据，重置自增
DELETE FROM dbo.orders;
DELETE FROM dbo.goods_images;
DELETE FROM dbo.goods;
DELETE FROM dbo.announcements;
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

-- 4. orders（依赖: goods_id → goods, buyer_id → users, seller_id → users）
SET IDENTITY_INSERT [dbo].[orders] OFF
GO

-- 7. announcements（依赖: creator_id → users）
INSERT INTO announcements (content, creator_id) VALUES (N'欢迎使用校园二手交易系统"转一转"！技术问题请联系-学生活动中心云先生(191****2026)', 1);
GO
