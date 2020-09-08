USE [Demo]
GO
/****** Object:  FullTextCatalog [ctlg_Shipement]    Script Date: 9/7/2020 1:14:03 AM ******/
CREATE FULLTEXT CATALOG [ctlg_Shipement] WITH ACCENT_SENSITIVITY = ON
GO
/****** Object:  Table [dbo].[Carriers]    Script Date: 9/7/2020 1:14:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carriers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Scac] [nvarchar](max) NULL,
	[Mc] [nvarchar](max) NULL,
	[Dot] [nvarchar](max) NULL,
	[Fein] [nvarchar](max) NULL,
 CONSTRAINT [PK_Carriers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipments]    Script Date: 9/7/2020 1:14:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarrierId] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL,
	[OriginCountry] [nvarchar](max) NULL,
	[OriginState] [nvarchar](max) NULL,
	[OriginCity] [nvarchar](max) NULL,
	[DestinationCountry] [nvarchar](max) NULL,
	[DestinationState] [nvarchar](max) NULL,
	[DestinationCity] [nvarchar](max) NULL,
	[PickupDate] [nvarchar](max) NULL,
	[DeliveryDate] [nvarchar](max) NULL,
	[Status] [nvarchar](max) NULL,
	[Rate] [nvarchar](max) NULL,
 CONSTRAINT [PK_Shipments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
