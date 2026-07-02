IF DB_ID(N'SecondHandDB') IS NULL
    CREATE DATABASE [SecondHandDB];
GO

USE [SecondHandDB]
GO
/****** 对象:  User [TeamUser]    脚本日期: 2026/6/26 10:20:34 ******/
CREATE USER [TeamUser] FOR LOGIN [TeamUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [TeamUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [TeamUser]
GO
/****** 对象:  Table [dbo].[goods]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[goods](
	[goods_id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[price] [decimal](10, 2) NOT NULL,
	[description] [nvarchar](max) NULL,
	[status] [nvarchar](10) NOT NULL,
	[created_time] [datetime] NOT NULL DEFAULT (getdate()),
	[category_id] [int] NOT NULL,
	[seller_id] [int] NOT NULL,
	[audit_admin_id] [int] NULL,
	[audit_time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[goods_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[orders]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[goods_id] [int] NOT NULL,
	[buyer_id] [int] NOT NULL,
	[order_status] [nvarchar](10) NOT NULL,
	[order_time] [datetime] NOT NULL DEFAULT (getdate()),
	[complete_time] [datetime] NULL,
	[shipping_address] [nvarchar](200) NOT NULL,
	[seller_id] [int] NOT NULL,
	[deal_price] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[announcements]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[announcements](
	[announce_id] [int] IDENTITY(1,1) NOT NULL,
	[content] [nvarchar](max) NOT NULL,
	[creator_id] [int] NOT NULL,
	[created_time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[announce_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[announcements] ADD DEFAULT (getdate()) FOR [created_time]
GO
/****** 对象:  Table [dbo].[users]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](30) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](11) NULL,
	[default_address] [nvarchar](200) NULL,
	[created_time] [datetime] NOT NULL,
	[role_id] [int] NOT NULL,
	[status] [nvarchar](20) NOT NULL,
	[email] [nvarchar](100) NULL,
 CONSTRAINT [PK__users__B9BE370FE6604083] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  View [dbo].[订单详情视图]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 创建视图
CREATE VIEW [dbo].[订单详情视图] AS
SELECT 
    o.order_id,
    g.title AS 商品名称,
    buyer.username AS 买家,
    seller.username AS 卖家,
    o.order_status,
    o.shipping_address
FROM orders o
JOIN goods g ON o.goods_id = g.goods_id
JOIN users buyer ON o.buyer_id = buyer.user_id
JOIN users seller ON g.seller_id = seller.user_id;
GO
/****** 对象:  Table [dbo].[categories]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_name] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  View [dbo].[v_OnSale_Goods]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_OnSale_Goods]
AS
SELECT g.goods_id, g.title, g.price, c.category_name, u.username AS 发布人, g.created_time
FROM goods g
JOIN categories c ON g.category_id = c.category_id
JOIN users u ON g.seller_id = u.user_id
WHERE g.status = '在售';
GO
/****** 对象:  Table [dbo].[goods_images]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[goods_images](
	[image_id] [int] IDENTITY(1,1) NOT NULL,
	[goods_id] [int] NOT NULL,
	[image_url] [nvarchar](512) NOT NULL,
	[sort_order] [int] NOT NULL,
	[upload_time] [datetime] NOT NULL,
 CONSTRAINT [PK__goods_im__DC9AC955C5B6A6B0] PRIMARY KEY CLUSTERED 
(
	[image_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 对象:  Table [dbo].[roles]    脚本日期: 2026/6/26 10:20:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [nvarchar](20) NOT NULL,
	[role_desc] [nvarchar](200) NULL,
	[is_user_manage] [bit] NOT NULL,
	[is_goods_manage] [bit] NOT NULL,
	[is_order_manage] [bit] NOT NULL,
	[is_system_manage] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
GO
GO
GO
GO
GO
GO
SET ANSI_PADDING ON
GO
/****** 对象:  Index [UQ__categori__5189E255DFB43DBF]    脚本日期: 2026/6/26 10:20:34 ******/
ALTER TABLE [dbo].[categories] ADD UNIQUE NONCLUSTERED 
(
	[category_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** 对象:  Index [UQ__orders__40BA22389D1ABE60]    脚本日期: 2026/6/26 10:20:34 ******/
ALTER TABLE [dbo].[orders] ADD UNIQUE NONCLUSTERED 
(
	[goods_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** 对象:  Index [UQ__users__F3DBC5724A7EDBE9]    脚本日期: 2026/6/26 10:20:34 ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [UQ__users__F3DBC5724A7EDBE9] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[goods] ADD  CONSTRAINT [DF_goods_status]  DEFAULT ('待审核') FOR [status]
GO
ALTER TABLE [dbo].[goods_images] ADD  CONSTRAINT [DF__goods_ima__sort___76619304]  DEFAULT ((1)) FOR [sort_order]
GO
ALTER TABLE [dbo].[goods_images] ADD  CONSTRAINT [DF__goods_ima__uploa__7755B73D]  DEFAULT (getdate()) FOR [upload_time]
GO
ALTER TABLE [dbo].[roles] ADD  DEFAULT ((0)) FOR [is_user_manage]
GO
ALTER TABLE [dbo].[roles] ADD  DEFAULT ((0)) FOR [is_goods_manage]
GO
ALTER TABLE [dbo].[roles] ADD  DEFAULT ((0)) FOR [is_order_manage]
GO
ALTER TABLE [dbo].[roles] ADD  DEFAULT ((0)) FOR [is_system_manage]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF__users__created_t__3864608B]  DEFAULT (getdate()) FOR [created_time]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_status]  DEFAULT (N'active') FOR [status]
GO
ALTER TABLE [dbo].[goods]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[categories] ([category_id])
GO
ALTER TABLE [dbo].[goods]  WITH CHECK ADD  CONSTRAINT [FK__goods__seller_id__3D2915A8] FOREIGN KEY([seller_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[goods] CHECK CONSTRAINT [FK__goods__seller_id__3D2915A8]
GO
ALTER TABLE [dbo].[goods]  WITH CHECK ADD  CONSTRAINT [FK_goods_audit_admin] FOREIGN KEY([audit_admin_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[goods] CHECK CONSTRAINT [FK_goods_audit_admin]
GO
ALTER TABLE [dbo].[goods_images]  WITH CHECK ADD  CONSTRAINT [FK_goods_images_goods] FOREIGN KEY([goods_id])
REFERENCES [dbo].[goods] ([goods_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[goods_images] CHECK CONSTRAINT [FK_goods_images_goods]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK__orders__buyer_id__41EDCAC5] FOREIGN KEY([buyer_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK__orders__buyer_id__41EDCAC5]
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD FOREIGN KEY([goods_id])
REFERENCES [dbo].[goods] ([goods_id])
GO
ALTER TABLE [dbo].[orders]  WITH CHECK ADD  CONSTRAINT [FK_orders_seller] FOREIGN KEY([seller_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[orders] CHECK CONSTRAINT [FK_orders_seller]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK__users__role_id__395884C4] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([role_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK__users__role_id__395884C4]
GO

