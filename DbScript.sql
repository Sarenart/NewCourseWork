USE [master]
GO
/****** Object:  Database [SupplyDb]    Script Date: 25.12.2020 22:47:18 ******/
CREATE DATABASE [SupplyDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Supply', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SupplyDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Supply_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SupplyDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SupplyDb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SupplyDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SupplyDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SupplyDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SupplyDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SupplyDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SupplyDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SupplyDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SupplyDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SupplyDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SupplyDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SupplyDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SupplyDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SupplyDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SupplyDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SupplyDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SupplyDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SupplyDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SupplyDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SupplyDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SupplyDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SupplyDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SupplyDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SupplyDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SupplyDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SupplyDb] SET  MULTI_USER 
GO
ALTER DATABASE [SupplyDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SupplyDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SupplyDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SupplyDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SupplyDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SupplyDb] SET QUERY_STORE = OFF
GO
USE [SupplyDb]
GO
/****** Object:  Table [dbo].[Commodity]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commodity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CommodityType] [int] NOT NULL,
 CONSTRAINT [PK_Commodity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommodityTypeRef]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommodityTypeRef](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CommodityTypeRef] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provider]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FamilyName] [varchar](50) NOT NULL,
	[Initials] [varchar](10) NOT NULL,
	[CompanyName] [varchar](50) NOT NULL,
	[PossibleDeliveryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProviderSupplyStock]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProviderSupplyStock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommodityId] [int] NOT NULL,
	[ProviderId] [int] NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_ProviderSupplyStock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supply]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProviderId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[ApplicantId] [int] NOT NULL,
	[ArrangerId] [int] NULL,
	[Cost] [decimal](18, 0) NOT NULL,
	[ApplicationDate] [datetime] NOT NULL,
	[ArrangementDate] [datetime] NULL,
	[DeliveryDate] [datetime] NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_Supply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplyLine]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplyLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplyId] [int] NOT NULL,
	[CommodityId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_SupplyLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplyStatusRef]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplyStatusRef](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SupplyStatusRef] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirName] [varchar](50) NOT NULL,
	[FamName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Warehouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WarehouseLine]    Script Date: 25.12.2020 22:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseLine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommodityId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[PerUnitCost] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_WarehouseLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Commodity] ON 

INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (7, N'Chabacco', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (8, N'BlackBurn', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (9, N'Spectrum', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (10, N'Duft', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (11, N'BigMax', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (13, N'AlphaHookah', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (14, N'SkySeven', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (15, N'AmyDeluxe', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (16, N'DSH', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (17, N'NeoLux', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (18, N'Marcos', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (19, N'MattPear', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (20, N'CWP', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (21, N'Don', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (22, N'Ottivana', 1)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (23, N'B3', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (24, N'Tabu', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (25, N'SarkoZy', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (26, N'Satyr', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (28, N'WTO', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (29, N'Zomo', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (30, N'Element', 2)
INSERT [dbo].[Commodity] ([Id], [Name], [CommodityType]) VALUES (31, N'Virginia', 2)
SET IDENTITY_INSERT [dbo].[Commodity] OFF
GO
SET IDENTITY_INSERT [dbo].[CommodityTypeRef] ON 

INSERT [dbo].[CommodityTypeRef] ([Id], [Type]) VALUES (1, N'Кальян')
INSERT [dbo].[CommodityTypeRef] ([Id], [Type]) VALUES (2, N'Табак')
SET IDENTITY_INSERT [dbo].[CommodityTypeRef] OFF
GO
SET IDENTITY_INSERT [dbo].[Provider] ON 

INSERT [dbo].[Provider] ([Id], [FamilyName], [Initials], [CompanyName], [PossibleDeliveryDate]) VALUES (1, N'Громыко', N'А. Б.', N'ОАО "Calyan Logistics"', CAST(N'2020-12-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Provider] ([Id], [FamilyName], [Initials], [CompanyName], [PossibleDeliveryDate]) VALUES (2, N'Бандурин', N'Б. Г.', N'ЗАО "Вертекс"', CAST(N'2020-12-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Provider] ([Id], [FamilyName], [Initials], [CompanyName], [PossibleDeliveryDate]) VALUES (3, N'Симонов', N'Г. В.', N'ОАО "ТабакТранс"', CAST(N'2020-12-23T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Provider] OFF
GO
SET IDENTITY_INSERT [dbo].[ProviderSupplyStock] ON 

INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (10, 7, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (11, 8, 1, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (12, 10, 1, CAST(400 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (14, 23, 1, CAST(575 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (17, 24, 1, CAST(325 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (18, 17, 1, CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (19, 22, 1, CAST(2700 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (20, 20, 1, CAST(3600 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[ProviderSupplyStock] OFF
GO
SET IDENTITY_INSERT [dbo].[Supply] ON 

INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (1, 1, 1, 3, 3, CAST(350 AS Decimal(18, 0)), CAST(N'2020-12-19T21:28:23.173' AS DateTime), CAST(N'2020-12-19T23:02:10.483' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (3, 1, 1, 3, NULL, CAST(540 AS Decimal(18, 0)), CAST(N'2020-12-12T00:00:00.000' AS DateTime), NULL, CAST(N'2020-12-12T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (4, 1, 3, 3, NULL, CAST(2000 AS Decimal(18, 0)), CAST(N'2020-12-19T23:09:01.240' AS DateTime), NULL, CAST(N'2020-12-30T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (5, 1, 3, 3, NULL, CAST(250 AS Decimal(18, 0)), CAST(N'2020-12-22T02:26:16.520' AS DateTime), NULL, CAST(N'2020-12-30T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (7, 1, 3, 2, 2, CAST(4175 AS Decimal(18, 0)), CAST(N'2020-12-23T00:06:59.850' AS DateTime), CAST(N'2020-12-23T00:07:26.983' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (9, 1, 2, 2, 3, CAST(4300 AS Decimal(18, 0)), CAST(N'2020-12-23T12:16:57.183' AS DateTime), CAST(N'2020-12-25T22:39:55.327' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (10, 1, 1, 2, NULL, CAST(5225 AS Decimal(18, 0)), CAST(N'2020-12-23T12:17:45.517' AS DateTime), NULL, CAST(N'2020-12-30T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (11, 1, 3, 2, NULL, CAST(5325 AS Decimal(18, 0)), CAST(N'2020-12-23T12:19:06.700' AS DateTime), NULL, CAST(N'2020-12-30T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (13, 1, 2, 3, NULL, CAST(4950 AS Decimal(18, 0)), CAST(N'2020-12-25T22:15:34.797' AS DateTime), NULL, CAST(N'2020-12-30T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Supply] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplyLine] ON 

INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (12, 1, 7, 3, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (13, 4, 17, 1, CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (14, 5, 8, 3, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (19, 7, 20, 1, CAST(3600 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (20, 7, 23, 3, CAST(1725 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (23, 9, 22, 1, CAST(2700 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (24, 9, 10, 4, CAST(1600 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (25, 10, 20, 1, CAST(3600 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (26, 10, 24, 5, CAST(1625 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (27, 11, 23, 3, CAST(1725 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (28, 11, 20, 1, CAST(3600 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (31, 13, 7, 3, CAST(1050 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (32, 13, 10, 3, CAST(1200 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (33, 13, 22, 1, CAST(2700 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[SupplyLine] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplyStatusRef] ON 

INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (1, N'Заявка создана')
INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (2, N'Поставка оформлена')
INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (3, N'Ожидание поставки')
INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (4, N'Заявка отклонена')
INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (5, N'Поставка отменена')
SET IDENTITY_INSERT [dbo].[SupplyStatusRef] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [Password], [FirName], [FamName]) VALUES (2, N'MarMiz', N'IpGelenj1999', N'Мария', N'Мизеровская')
INSERT [dbo].[User] ([Id], [Login], [Password], [FirName], [FamName]) VALUES (3, N'Tatiyana', N'TatMur2409qw', N'Татьяна ', N'Иванова')
INSERT [dbo].[User] ([Id], [Login], [Password], [FirName], [FamName]) VALUES (4, N'GEnEsIs', N'GSbigbee7712', N'Георгий', N'Симонов')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Warehouse] ON 

INSERT [dbo].[Warehouse] ([Id], [Address]) VALUES (1, N'Улица Голубева, д. 3')
INSERT [dbo].[Warehouse] ([Id], [Address]) VALUES (2, N'Улица Шошина, д.24')
INSERT [dbo].[Warehouse] ([Id], [Address]) VALUES (3, N'Улица Ермака, д.34')
SET IDENTITY_INSERT [dbo].[Warehouse] OFF
GO
SET IDENTITY_INSERT [dbo].[WarehouseLine] ON 

INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (1, 7, 1, CAST(400 AS Decimal(18, 0)), 31)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (2, 8, 1, CAST(350 AS Decimal(18, 0)), 25)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (3, 10, 1, CAST(500 AS Decimal(18, 0)), 15)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (5, 13, 1, CAST(4300 AS Decimal(18, 0)), 5)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (7, 15, 1, CAST(3800 AS Decimal(18, 0)), 4)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (9, 8, 2, CAST(400 AS Decimal(18, 0)), 17)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (10, 10, 2, CAST(550 AS Decimal(18, 0)), 8)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (11, 14, 2, CAST(4500 AS Decimal(18, 0)), 4)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (12, 11, 3, CAST(3300 AS Decimal(18, 0)), 7)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (13, 9, 3, CAST(300 AS Decimal(18, 0)), 11)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (14, 17, 1, CAST(2900 AS Decimal(18, 0)), 6)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (15, 22, 1, CAST(3400 AS Decimal(18, 0)), 0)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (16, 26, 1, CAST(400 AS Decimal(18, 0)), 13)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (17, 29, 1, CAST(600 AS Decimal(18, 0)), 9)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (18, 31, 1, CAST(525 AS Decimal(18, 0)), 11)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (19, 21, 2, CAST(5500 AS Decimal(18, 0)), 7)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (20, 20, 2, CAST(4600 AS Decimal(18, 0)), 8)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (21, 17, 2, CAST(3100 AS Decimal(18, 0)), 2)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (22, 28, 2, CAST(250 AS Decimal(18, 0)), 15)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (23, 29, 2, CAST(550 AS Decimal(18, 0)), 13)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (24, 7, 2, CAST(400 AS Decimal(18, 0)), 25)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (26, 23, 3, CAST(650 AS Decimal(18, 0)), 24)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (27, 20, 3, CAST(4320 AS Decimal(18, 0)), 1)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (28, 22, 2, CAST(3240 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[WarehouseLine] OFF
GO
ALTER TABLE [dbo].[Commodity]  WITH CHECK ADD  CONSTRAINT [FK_Commodity_CommodityTypeRef] FOREIGN KEY([CommodityType])
REFERENCES [dbo].[CommodityTypeRef] ([Id])
GO
ALTER TABLE [dbo].[Commodity] CHECK CONSTRAINT [FK_Commodity_CommodityTypeRef]
GO
ALTER TABLE [dbo].[ProviderSupplyStock]  WITH CHECK ADD  CONSTRAINT [FK_ProviderSupplyStock_Commodity] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO
ALTER TABLE [dbo].[ProviderSupplyStock] CHECK CONSTRAINT [FK_ProviderSupplyStock_Commodity]
GO
ALTER TABLE [dbo].[ProviderSupplyStock]  WITH CHECK ADD  CONSTRAINT [FK_ProviderSupplyStock_Provider] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Provider] ([Id])
GO
ALTER TABLE [dbo].[ProviderSupplyStock] CHECK CONSTRAINT [FK_ProviderSupplyStock_Provider]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Provider] FOREIGN KEY([ProviderId])
REFERENCES [dbo].[Provider] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Provider]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_SupplyStatusRef] FOREIGN KEY([StatusId])
REFERENCES [dbo].[SupplyStatusRef] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_SupplyStatusRef]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_User] FOREIGN KEY([ApplicantId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_User]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_User1] FOREIGN KEY([ArrangerId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_User1]
GO
ALTER TABLE [dbo].[Supply]  WITH CHECK ADD  CONSTRAINT [FK_Supply_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[Supply] CHECK CONSTRAINT [FK_Supply_Warehouse]
GO
ALTER TABLE [dbo].[SupplyLine]  WITH CHECK ADD  CONSTRAINT [FK_SupplyLine_Commodity] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO
ALTER TABLE [dbo].[SupplyLine] CHECK CONSTRAINT [FK_SupplyLine_Commodity]
GO
ALTER TABLE [dbo].[SupplyLine]  WITH CHECK ADD  CONSTRAINT [FK_SupplyLine_Supply] FOREIGN KEY([SupplyId])
REFERENCES [dbo].[Supply] ([Id])
GO
ALTER TABLE [dbo].[SupplyLine] CHECK CONSTRAINT [FK_SupplyLine_Supply]
GO
ALTER TABLE [dbo].[WarehouseLine]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseLine_Commodity] FOREIGN KEY([CommodityId])
REFERENCES [dbo].[Commodity] ([Id])
GO
ALTER TABLE [dbo].[WarehouseLine] CHECK CONSTRAINT [FK_WarehouseLine_Commodity]
GO
ALTER TABLE [dbo].[WarehouseLine]  WITH CHECK ADD  CONSTRAINT [FK_WarehouseLine_Warehouse] FOREIGN KEY([WarehouseId])
REFERENCES [dbo].[Warehouse] ([Id])
GO
ALTER TABLE [dbo].[WarehouseLine] CHECK CONSTRAINT [FK_WarehouseLine_Warehouse]
GO
USE [master]
GO
ALTER DATABASE [SupplyDb] SET  READ_WRITE 
GO
