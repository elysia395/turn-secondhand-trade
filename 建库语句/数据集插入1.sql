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
DBCC CHECKIDENT ('dbo.orders', RESEED, 21);
DBCC CHECKIDENT ('dbo.goods_images', RESEED, 20);
DBCC CHECKIDENT ('dbo.goods', RESEED, 30);
DBCC CHECKIDENT ('dbo.announcements', RESEED, 2);
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

INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (1, N'admin', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138000', N'广州中医药大学大学城校区行政楼', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 3, N'active', N'admin@example.com')
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (2, N'goods_admin', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138001', N'广州中医药大学大学城校区学生活动中心', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 2, N'active', N'goods_admin@example.com')
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (3, N'张三', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138002', N'广州中医药大学大学城校区1栋302', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 1, N'active', N'zhangsan@example.com')
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (4, N'李四', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138003', N'广州中医药大学大学城校区2栋405', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 1, N'active', N'lisi@example.com')
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (5, N'王五', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138004', N'广州中医药大学大学城校区3栋501', CAST(N'2026-06-12T14:49:01.000' AS DateTime), 1, N'active', N'wangwu@example.com')
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (6, N'小明', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138005', N'广州中医药大学大学城校区4栋206', CAST(N'2026-06-16T09:20:00.000' AS DateTime), 1, N'active', N'xiaoming@example.com')
INSERT [dbo].[users] ([user_id], [username], [password], [phone], [default_address], [created_time], [role_id], [status], [email]) VALUES (7, N'小红', N'$2a$11$vHF7f5mVfti3A5mdA1jonOpIS4LbwxGJXkLga2VeUNkkTBKACq2JC', N'13800138006', N'广州中医药大学大学城校区4栋308', CAST(N'2026-06-16T09:22:00.000' AS DateTime), 1, N'active', N'xiaohong@example.com')
SET IDENTITY_INSERT [dbo].[users] OFF
GO

-- 4. goods（依赖: seller_id → users, category_id → categories）
SET IDENTITY_INSERT [dbo].[goods] ON 

INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (25, N'高等数学（同济第七版）', CAST(28.00 AS Decimal(10, 2)), N'九成新，仅前两章有笔记，附课后习题答案', N'已售', CAST(N'2026-07-03T10:09:42.710' AS DateTime), 3, 3, 2, CAST(N'2026-07-03T10:20:51.073' AS DateTime))
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (26, N'LED 护眼台灯', CAST(35.00 AS Decimal(10, 2)), N'三档调光，带 USB 充电口，用了一学期', N'已售', CAST(N'2026-07-03T10:09:42.773' AS DateTime), 6, 4, 2, CAST(N'2026-07-03T10:20:51.073' AS DateTime))
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (27, N'机械键盘（青轴）', CAST(89.00 AS Decimal(10, 2)), N'87键，RGB 背光，键帽无打油', N'已售', CAST(N'2026-07-03T10:09:42.830' AS DateTime), 1, 5, 2, CAST(N'2026-07-03T10:20:51.073' AS DateTime))
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (28, N'桌面小风扇', CAST(22.00 AS Decimal(10, 2)), N'USB 供电，两档风力，静音', N'已售', CAST(N'2026-07-03T10:09:42.883' AS DateTime), 6, 6, 2, CAST(N'2026-07-03T10:20:51.073' AS DateTime))
INSERT [dbo].[goods] ([goods_id], [title], [price], [description], [status], [created_time], [category_id], [seller_id], [audit_admin_id], [audit_time]) VALUES (29, N'四级词汇闪过', CAST(15.00 AS Decimal(10, 2)), N'全新未开封，买多了出一本', N'已售', CAST(N'2026-07-03T10:09:42.947' AS DateTime), 3, 7, 2, CAST(N'2026-07-03T10:20:51.073' AS DateTime))
SET IDENTITY_INSERT [dbo].[goods] OFF
GO

-- 5. goods_images（依赖: goods_id → goods）
SET IDENTITY_INSERT [dbo].[goods_images] ON 

INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (15, 25, N'Upload_image\goods_25_d866ddc270c84d5aabf747643b824987.png', 1, CAST(N'2026-07-03T10:09:43.037' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (16, 26, N'Upload_image\goods_26_4b0d0c8e7f22492ab330e66beb96df9e.png', 1, CAST(N'2026-07-03T10:09:43.200' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (17, 27, N'Upload_image\goods_27_89a8718ee5fd4175979b91619f88a667.png', 1, CAST(N'2026-07-03T10:09:58.520' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (18, 28, N'Upload_image\goods_28_eba4d66285f349979b5e77c86ae6ab2c.png', 1, CAST(N'2026-07-03T10:09:58.643' AS DateTime))
INSERT [dbo].[goods_images] ([image_id], [goods_id], [image_url], [sort_order], [upload_time]) VALUES (19, 29, N'Upload_image\goods_29_d71eb4617529419db80f7fd1b802eca0.png', 1, CAST(N'2026-07-03T10:09:58.710' AS DateTime))
SET IDENTITY_INSERT [dbo].[goods_images] OFF
GO

-- 6. orders（依赖: goods_id → goods, buyer_id → users, seller_id → users）
SET IDENTITY_INSERT [dbo].[orders] ON 

INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (16, 25, 4, N'已完成', CAST(N'2026-07-03T10:20:51.073' AS DateTime), CAST(N'2026-07-03T12:20:51.073' AS DateTime), N'广州中医药大学大学城校区2栋405', 3, CAST(28.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (17, 26, 5, N'已完成', CAST(N'2026-07-03T10:20:51.073' AS DateTime), CAST(N'2026-07-03T12:20:51.073' AS DateTime), N'广州中医药大学大学城校区3栋501', 4, CAST(35.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (18, 27, 6, N'已完成', CAST(N'2026-07-03T10:20:51.073' AS DateTime), CAST(N'2026-07-03T12:20:51.073' AS DateTime), N'广州中医药大学大学城校区4栋206', 5, CAST(89.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (19, 28, 7, N'已完成', CAST(N'2026-07-03T10:20:51.073' AS DateTime), CAST(N'2026-07-03T12:20:51.073' AS DateTime), N'广州中医药大学大学城校区4栋308', 6, CAST(22.00 AS Decimal(10, 2)))
INSERT [dbo].[orders] ([order_id], [goods_id], [buyer_id], [order_status], [order_time], [complete_time], [shipping_address], [seller_id], [deal_price]) VALUES (20, 29, 3, N'已完成', CAST(N'2026-07-03T10:20:51.077' AS DateTime), CAST(N'2026-07-03T12:20:51.077' AS DateTime), N'广州中医药大学大学城校区1栋302', 7, CAST(15.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[orders] OFF
GO

-- 7. announcements（依赖: creator_id → users）
INSERT INTO announcements (content, creator_id) VALUES (N'欢迎使用校园二手交易系统"转一转"！技术问题请联系-学生活动中心云先生(191****2026)', 1);
GO
