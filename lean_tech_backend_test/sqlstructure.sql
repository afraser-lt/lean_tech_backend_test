USE [Test]
GO
/****** Object:  Table [dbo].[Bols]    Script Date: 8/31/2020 10:26:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bols](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Po] [nvarchar](max) NULL,
	[SpecialInstruction] [nvarchar](max) NULL,
	[ItemsDesciptions] [nvarchar](max) NULL,
	[PackaginTypeId] [int] NULL,
	[ReceiverId] [int] NULL,
	[ShipmentId] [int] NULL,
 CONSTRAINT [PK_Bols] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 8/31/2020 10:26:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Scac] [nvarchar](max) NULL,
	[Mc] [bigint] NOT NULL,
	[Dot] [bigint] NOT NULL,
	[Fein] [bigint] NOT NULL,
	[Rate] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Carriers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerOrders]    Script Date: 8/31/2020 10:26:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NULL,
	[BolsId] [int] NULL,
 CONSTRAINT [PK_CustomerOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/31/2020 10:26:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 8/31/2020 10:26:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](max) NULL,
	[Packages] [int] NOT NULL,
	[Weight] [decimal](18, 2) NOT NULL,
	[Pallet] [bit] NOT NULL,
	[Slip] [bit] NOT NULL,
	[ShippperInfo] [nvarchar](max) NULL,
	[CustomerOrdersId] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackaginTypes]    Script Date: 8/31/2020 10:26:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackaginTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Heigth] [decimal](18, 2) NOT NULL,
	[Width] [decimal](18, 2) NOT NULL,
	[Length] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_PackaginTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receivers]    Script Date: 8/31/2020 10:26:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receivers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Receivers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipments]    Script Date: 8/31/2020 10:26:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[OriginCountry] [nvarchar](max) NULL,
	[OriginState] [nvarchar](max) NULL,
	[OriginCity] [nvarchar](max) NULL,
	[DestinationCountry] [nvarchar](max) NULL,
	[DestinationState] [nvarchar](max) NULL,
	[DestinationCity] [nvarchar](max) NULL,
	[PickupDate] [datetime2](7) NOT NULL,
	[DeliveryDate] [datetime2](7) NOT NULL,
	[Status] [nvarchar](max) NULL,
	[CarrierId] [int] NULL,
 CONSTRAINT [PK_Shipments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bols]  WITH CHECK ADD  CONSTRAINT [FK_Bols_PackaginTypes_PackaginTypeId] FOREIGN KEY([PackaginTypeId])
REFERENCES [dbo].[PackaginTypes] ([Id])
GO
ALTER TABLE [dbo].[Bols] CHECK CONSTRAINT [FK_Bols_PackaginTypes_PackaginTypeId]
GO
ALTER TABLE [dbo].[Bols]  WITH CHECK ADD  CONSTRAINT [FK_Bols_Receivers_ReceiverId] FOREIGN KEY([ReceiverId])
REFERENCES [dbo].[Receivers] ([Id])
GO
ALTER TABLE [dbo].[Bols] CHECK CONSTRAINT [FK_Bols_Receivers_ReceiverId]
GO
ALTER TABLE [dbo].[Bols]  WITH CHECK ADD  CONSTRAINT [FK_Bols_Shipments_ShipmentId] FOREIGN KEY([ShipmentId])
REFERENCES [dbo].[Shipments] ([Id])
GO
ALTER TABLE [dbo].[Bols] CHECK CONSTRAINT [FK_Bols_Shipments_ShipmentId]
GO
ALTER TABLE [dbo].[CustomerOrders]  WITH CHECK ADD  CONSTRAINT [FK_CustomerOrders_Bols_BolsId] FOREIGN KEY([BolsId])
REFERENCES [dbo].[Bols] ([Id])
GO
ALTER TABLE [dbo].[CustomerOrders] CHECK CONSTRAINT [FK_CustomerOrders_Bols_BolsId]
GO
ALTER TABLE [dbo].[CustomerOrders]  WITH CHECK ADD  CONSTRAINT [FK_CustomerOrders_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[CustomerOrders] CHECK CONSTRAINT [FK_CustomerOrders_Customers_CustomerId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_CustomerOrders_CustomerOrdersId] FOREIGN KEY([CustomerOrdersId])
REFERENCES [dbo].[CustomerOrders] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_CustomerOrders_CustomerOrdersId]
GO
ALTER TABLE [dbo].[Shipments]  WITH CHECK ADD  CONSTRAINT [FK_Shipments_Carriers_CarrierId] FOREIGN KEY([CarrierId])
REFERENCES [dbo].[Carriers] ([Id])
GO
ALTER TABLE [dbo].[Shipments] CHECK CONSTRAINT [FK_Shipments_Carriers_CarrierId]
GO
