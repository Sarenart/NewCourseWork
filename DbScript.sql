USE [master]
GO
/****** Object:  Database [SupplyDb]    Script Date: 28.12.2020 10:41:55 ******/
CREATE DATABASE [SupplyDb] ON  PRIMARY 
( NAME = N'Supply', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SupplyDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Supply_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SupplyDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
USE [SupplyDb]
GO
/****** Object:  Table [dbo].[Commodity]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[CommodityTypeRef]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[Provider]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[ProviderSupplyStock]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[Supply]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[SupplyLine]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[SupplyStatusRef]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[Warehouse]    Script Date: 28.12.2020 10:41:55 ******/
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
/****** Object:  Table [dbo].[WarehouseLine]    Script Date: 28.12.2020 10:41:55 ******/
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
SET IDENTITY_INSERT [dbo].[CommodityTypeRef] ON 

INSERT [dbo].[CommodityTypeRef] ([Id], [Type]) VALUES (1, N'Кальян')
INSERT [dbo].[CommodityTypeRef] ([Id], [Type]) VALUES (2, N'Табак')
SET IDENTITY_INSERT [dbo].[CommodityTypeRef] OFF
SET IDENTITY_INSERT [dbo].[Provider] ON 

INSERT [dbo].[Provider] ([Id], [FamilyName], [Initials], [CompanyName], [PossibleDeliveryDate]) VALUES (1, N'Громыко', N'А. Б.', N'ОАО "Calyan Logistics"', CAST(N'2021-01-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Provider] ([Id], [FamilyName], [Initials], [CompanyName], [PossibleDeliveryDate]) VALUES (2, N'Бандурин', N'Б. Г.', N'ЗАО "Вертекс"', CAST(N'2021-01-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Provider] ([Id], [FamilyName], [Initials], [CompanyName], [PossibleDeliveryDate]) VALUES (3, N'Симонов', N'Г. В.', N'ОАО "ТабакТранс"', CAST(N'2021-01-16T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Provider] OFF
SET IDENTITY_INSERT [dbo].[ProviderSupplyStock] ON 

INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (10, 7, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (11, 8, 1, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (12, 10, 1, CAST(400 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (14, 23, 1, CAST(575 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (17, 24, 1, CAST(325 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (18, 17, 1, CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (19, 22, 1, CAST(2700 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (20, 20, 1, CAST(3600 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (21, 15, 1, CAST(475 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (22, 28, 1, CAST(275 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (23, 31, 1, CAST(600 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (24, 13, 1, CAST(5350 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (25, 25, 1, CAST(390 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (26, 30, 1, CAST(470 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (27, 7, 2, CAST(320 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (28, 8, 2, CAST(270 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (29, 9, 2, CAST(320 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (30, 10, 2, CAST(380 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (31, 11, 2, CAST(3500 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (32, 13, 2, CAST(5500 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (33, 15, 2, CAST(520 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (34, 16, 2, CAST(475 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (35, 17, 2, CAST(2300 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (36, 18, 2, CAST(3800 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (37, 19, 2, CAST(4900 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (38, 21, 2, CAST(5900 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (39, 25, 2, CAST(500 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (40, 26, 2, CAST(500 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (41, 29, 2, CAST(650 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (42, 31, 2, CAST(560 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (43, 9, 3, CAST(300 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (44, 11, 3, CAST(3700 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (45, 14, 3, CAST(4100 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (46, 16, 3, CAST(420 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (47, 18, 3, CAST(3500 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (48, 19, 3, CAST(5100 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (49, 20, 3, CAST(3700 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (50, 21, 3, CAST(5750 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (51, 22, 3, CAST(3200 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (52, 23, 3, CAST(600 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (53, 25, 3, CAST(400 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (54, 26, 3, CAST(535 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (55, 28, 3, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (56, 29, 3, CAST(680 AS Decimal(18, 0)))
INSERT [dbo].[ProviderSupplyStock] ([Id], [CommodityId], [ProviderId], [Cost]) VALUES (57, 30, 3, CAST(475 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[ProviderSupplyStock] OFF
SET IDENTITY_INSERT [dbo].[Supply] ON 

INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (1, 1, 1, 3, 3, CAST(350 AS Decimal(18, 0)), CAST(N'2020-12-19T21:28:23.173' AS DateTime), CAST(N'2020-12-19T23:02:10.483' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (3, 1, 1, 3, NULL, CAST(540 AS Decimal(18, 0)), CAST(N'2020-12-12T00:00:00.000' AS DateTime), NULL, CAST(N'2020-12-12T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (4, 1, 3, 3, NULL, CAST(2000 AS Decimal(18, 0)), CAST(N'2020-12-19T23:09:01.240' AS DateTime), NULL, CAST(N'2020-12-30T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (5, 1, 3, 3, NULL, CAST(250 AS Decimal(18, 0)), CAST(N'2020-12-22T02:26:16.520' AS DateTime), NULL, CAST(N'2020-12-30T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (7, 1, 3, 2, 2, CAST(4175 AS Decimal(18, 0)), CAST(N'2020-12-23T00:06:59.850' AS DateTime), CAST(N'2020-12-23T00:07:26.983' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (9, 1, 2, 2, 3, CAST(4300 AS Decimal(18, 0)), CAST(N'2020-12-23T12:16:57.183' AS DateTime), CAST(N'2020-12-25T22:39:55.327' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (10, 1, 1, 2, 3, CAST(5225 AS Decimal(18, 0)), CAST(N'2020-12-23T12:17:45.517' AS DateTime), CAST(N'2020-12-26T17:59:22.620' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (11, 1, 3, 2, 3, CAST(5325 AS Decimal(18, 0)), CAST(N'2020-12-23T12:19:06.700' AS DateTime), CAST(N'2020-12-28T09:54:06.340' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (13, 1, 2, 3, 3, CAST(4950 AS Decimal(18, 0)), CAST(N'2020-12-25T22:15:34.797' AS DateTime), CAST(N'2020-12-27T02:27:46.283' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (14, 1, 1, 3, 3, CAST(1350 AS Decimal(18, 0)), CAST(N'2020-12-26T17:18:59.167' AS DateTime), CAST(N'2020-12-27T03:38:01.570' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (15, 1, 2, 3, NULL, CAST(7200 AS Decimal(18, 0)), CAST(N'2020-12-26T17:20:37.843' AS DateTime), NULL, CAST(N'2020-12-30T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (16, 3, 2, 3, 3, CAST(9800 AS Decimal(18, 0)), CAST(N'2020-12-27T03:19:58.723' AS DateTime), CAST(N'2020-12-27T03:33:02.447' AS DateTime), CAST(N'2021-01-26T19:59:52.307' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (17, 2, 1, 3, NULL, CAST(1280 AS Decimal(18, 0)), CAST(N'2020-12-27T03:27:21.427' AS DateTime), NULL, CAST(N'2021-01-31T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (18, 3, 1, 3, NULL, CAST(5000 AS Decimal(18, 0)), CAST(N'2020-12-27T03:28:40.717' AS DateTime), NULL, CAST(N'2021-01-26T19:59:52.307' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (19, 3, 2, 3, 3, CAST(1500 AS Decimal(18, 0)), CAST(N'2020-12-27T03:29:05.247' AS DateTime), CAST(N'2020-12-27T03:37:28.280' AS DateTime), CAST(N'2021-01-26T19:59:52.307' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (20, 3, 3, 3, NULL, CAST(3700 AS Decimal(18, 0)), CAST(N'2020-12-27T03:29:25.283' AS DateTime), NULL, CAST(N'2021-01-26T19:59:52.307' AS DateTime), 4)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (21, 1, 1, 3, 3, CAST(250 AS Decimal(18, 0)), CAST(N'2020-12-27T03:30:12.893' AS DateTime), CAST(N'2020-12-27T11:25:26.087' AS DateTime), CAST(N'2020-12-31T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (22, 2, 3, 3, 3, CAST(1680 AS Decimal(18, 0)), CAST(N'2020-12-27T11:11:36.607' AS DateTime), CAST(N'2020-12-27T11:12:17.520' AS DateTime), CAST(N'2021-01-31T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (23, 3, 3, 3, NULL, CAST(1200 AS Decimal(18, 0)), CAST(N'2020-12-27T11:13:51.897' AS DateTime), NULL, CAST(N'2021-01-26T19:59:52.307' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (24, 3, 3, 3, 3, CAST(750 AS Decimal(18, 0)), CAST(N'2020-12-27T11:16:42.563' AS DateTime), CAST(N'2020-12-27T11:17:18.233' AS DateTime), CAST(N'2021-01-26T19:59:52.307' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (25, 2, 2, 3, NULL, CAST(11260 AS Decimal(18, 0)), CAST(N'2020-12-27T11:43:13.173' AS DateTime), NULL, CAST(N'2021-01-31T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (26, 3, 2, 3, NULL, CAST(2910 AS Decimal(18, 0)), CAST(N'2020-12-27T12:05:20.373' AS DateTime), NULL, CAST(N'2021-01-26T19:59:52.307' AS DateTime), 3)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (27, 1, 1, 3, NULL, CAST(1800 AS Decimal(18, 0)), CAST(N'2020-12-27T12:06:43.683' AS DateTime), NULL, CAST(N'2020-12-31T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (28, 1, 1, 3, 3, CAST(4700 AS Decimal(18, 0)), CAST(N'2020-12-27T12:07:15.803' AS DateTime), CAST(N'2020-12-27T12:07:52.387' AS DateTime), CAST(N'2020-12-31T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (29, 2, 1, 3, NULL, CAST(10900 AS Decimal(18, 0)), CAST(N'2020-12-27T12:46:02.600' AS DateTime), NULL, CAST(N'2021-01-31T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (30, 1, 2, 3, 3, CAST(3625 AS Decimal(18, 0)), CAST(N'2020-12-27T17:32:57.153' AS DateTime), CAST(N'2020-12-28T00:00:36.177' AS DateTime), CAST(N'2020-12-31T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (31, 2, 1, 3, 3, CAST(14520 AS Decimal(18, 0)), CAST(N'2020-12-27T22:43:37.610' AS DateTime), CAST(N'2020-12-27T22:44:54.733' AS DateTime), CAST(N'2021-01-31T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (32, 2, 2, 3, NULL, CAST(3850 AS Decimal(18, 0)), CAST(N'2020-12-28T00:00:13.263' AS DateTime), NULL, CAST(N'2021-01-31T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (33, 1, 1, 3, 3, CAST(10700 AS Decimal(18, 0)), CAST(N'2020-12-28T00:10:01.567' AS DateTime), CAST(N'2020-12-28T00:10:39.587' AS DateTime), CAST(N'2021-01-06T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (34, 2, 3, 3, NULL, CAST(1350 AS Decimal(18, 0)), CAST(N'2020-12-28T00:20:04.370' AS DateTime), NULL, CAST(N'2020-12-31T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (35, 1, 3, 3, 2, CAST(11050 AS Decimal(18, 0)), CAST(N'2020-12-28T02:25:43.607' AS DateTime), CAST(N'2020-12-28T02:27:29.673' AS DateTime), CAST(N'2021-01-06T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (36, 2, 3, 3, 3, CAST(1330 AS Decimal(18, 0)), CAST(N'2020-12-28T09:41:48.340' AS DateTime), CAST(N'2020-12-28T09:42:29.177' AS DateTime), CAST(N'2021-01-14T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Supply] ([Id], [ProviderId], [WarehouseId], [ApplicantId], [ArrangerId], [Cost], [ApplicationDate], [ArrangementDate], [DeliveryDate], [StatusId]) VALUES (37, 2, 3, 3, NULL, CAST(16500 AS Decimal(18, 0)), CAST(N'2020-12-28T09:52:49.630' AS DateTime), NULL, CAST(N'2021-01-14T00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Supply] OFF
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
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (34, 14, 7, 1, CAST(350 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (35, 14, 8, 4, CAST(1000 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (36, 15, 20, 2, CAST(7200 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (37, 16, 14, 2, CAST(8200 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (38, 16, 25, 4, CAST(1600 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (39, 17, 7, 1, CAST(320 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (40, 17, 9, 3, CAST(960 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (41, 18, 9, 3, CAST(900 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (42, 18, 14, 1, CAST(4100 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (43, 19, 9, 5, CAST(1500 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (44, 20, 11, 1, CAST(3700 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (45, 21, 8, 1, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (46, 22, 31, 3, CAST(1680 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (47, 23, 9, 4, CAST(1200 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (48, 24, 28, 3, CAST(750 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (49, 25, 11, 3, CAST(10500 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (50, 25, 10, 2, CAST(760 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (51, 26, 28, 3, CAST(750 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (52, 26, 29, 2, CAST(1360 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (53, 26, 25, 2, CAST(800 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (54, 27, 30, 3, CAST(1410 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (55, 27, 25, 1, CAST(390 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (56, 28, 30, 10, CAST(4700 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (57, 29, 10, 5, CAST(1900 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (58, 29, 11, 1, CAST(3500 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (59, 29, 13, 1, CAST(5500 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (60, 30, 10, 5, CAST(2000 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (61, 30, 24, 5, CAST(1625 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (62, 31, 15, 1, CAST(520 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (63, 31, 11, 4, CAST(14000 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (64, 32, 8, 5, CAST(1350 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (65, 32, 25, 5, CAST(2500 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (66, 33, 13, 2, CAST(10700 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (67, 34, 8, 5, CAST(1350 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (68, 35, 8, 1, CAST(250 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (69, 35, 20, 3, CAST(10800 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (70, 36, 8, 3, CAST(810 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (71, 36, 15, 1, CAST(520 AS Decimal(18, 0)))
INSERT [dbo].[SupplyLine] ([Id], [SupplyId], [CommodityId], [Quantity], [Cost]) VALUES (72, 37, 13, 3, CAST(16500 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[SupplyLine] OFF
SET IDENTITY_INSERT [dbo].[SupplyStatusRef] ON 

INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (1, N'Заявка создана')
INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (2, N'Поставка оформлена')
INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (3, N'Ожидание поставки')
INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (4, N'Заявка отклонена')
INSERT [dbo].[SupplyStatusRef] ([Id], [Status]) VALUES (5, N'Поставка отменена')
SET IDENTITY_INSERT [dbo].[SupplyStatusRef] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Login], [Password], [FirName], [FamName]) VALUES (2, N'MarMiz', N'IpGelenj1999', N'Мария', N'Мизеровская')
INSERT [dbo].[User] ([Id], [Login], [Password], [FirName], [FamName]) VALUES (3, N'Tatiyana', N'TatMur2409qw', N'Татьяна ', N'Иванова')
INSERT [dbo].[User] ([Id], [Login], [Password], [FirName], [FamName]) VALUES (4, N'GEnEsIs', N'GSbigbee7712', N'Георгий', N'Симонов')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[Warehouse] ON 

INSERT [dbo].[Warehouse] ([Id], [Address]) VALUES (1, N'Улица Голубева, д. 3')
INSERT [dbo].[Warehouse] ([Id], [Address]) VALUES (2, N'Улица Шошина, д.24')
INSERT [dbo].[Warehouse] ([Id], [Address]) VALUES (3, N'Улица Ермака, д.34')
SET IDENTITY_INSERT [dbo].[Warehouse] OFF
SET IDENTITY_INSERT [dbo].[WarehouseLine] ON 

INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (1, 7, 1, CAST(400 AS Decimal(18, 0)), 32)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (2, 8, 1, CAST(350 AS Decimal(18, 0)), 30)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (3, 10, 1, CAST(500 AS Decimal(18, 0)), 15)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (5, 13, 1, CAST(4300 AS Decimal(18, 0)), 7)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (7, 15, 1, CAST(3800 AS Decimal(18, 0)), 5)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (9, 8, 2, CAST(400 AS Decimal(18, 0)), 17)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (10, 10, 2, CAST(550 AS Decimal(18, 0)), 16)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (11, 14, 2, CAST(4500 AS Decimal(18, 0)), 6)
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
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (24, 7, 2, CAST(400 AS Decimal(18, 0)), 28)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (26, 23, 3, CAST(650 AS Decimal(18, 0)), 27)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (27, 20, 3, CAST(4320 AS Decimal(18, 0)), 5)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (28, 22, 2, CAST(3240 AS Decimal(18, 0)), 2)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (29, 20, 1, CAST(4320 AS Decimal(18, 0)), 1)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (30, 24, 1, CAST(390 AS Decimal(18, 0)), 5)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (31, 25, 2, CAST(480 AS Decimal(18, 0)), 4)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (32, 9, 2, CAST(360 AS Decimal(18, 0)), 5)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (33, 31, 3, CAST(672 AS Decimal(18, 0)), 3)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (34, 28, 3, CAST(300 AS Decimal(18, 0)), 3)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (35, 30, 1, CAST(564 AS Decimal(18, 0)), 10)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (36, 11, 1, CAST(4200 AS Decimal(18, 0)), 4)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (37, 24, 2, CAST(390 AS Decimal(18, 0)), 5)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (38, 8, 3, CAST(300 AS Decimal(18, 0)), 4)
INSERT [dbo].[WarehouseLine] ([Id], [CommodityId], [WarehouseId], [PerUnitCost], [Quantity]) VALUES (39, 15, 3, CAST(624 AS Decimal(18, 0)), 1)
SET IDENTITY_INSERT [dbo].[WarehouseLine] OFF
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
