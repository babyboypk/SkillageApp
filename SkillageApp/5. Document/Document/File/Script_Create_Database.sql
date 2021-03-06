USE [SkillageApp]
GO
/****** Object:  Table [dbo].[DailyPrices]    Script Date: 1/9/2019 9:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyPrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExchangeId] [int] NOT NULL,
	[StockSymbolId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[StockPriceOpen] [float] NOT NULL,
	[StockPriceHigh] [float] NOT NULL,
	[StockPriceLow] [float] NOT NULL,
	[StockPriceClose] [float] NOT NULL,
	[StockVolume] [bigint] NOT NULL,
	[StockPriceAdjClose] [float] NOT NULL,
 CONSTRAINT [PK_dbo.DailyPrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exchanges]    Script Date: 1/9/2019 9:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exchanges](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](1000) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Exchanges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockSymbols]    Script Date: 1/9/2019 9:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockSymbols](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](1000) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.StockSymbols] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[VW_DailyPrices]    Script Date: 1/9/2019 9:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create VIEW [dbo].[VW_DailyPrices] AS
SELECT dp.Id, ex.Name as Exchange, ss.Name as StockSymbol, dp.Date, 
	dp.StockPriceOpen, dp.StockPriceHigh, dp.StockPriceLow,
	dp.StockPriceClose, dp.StockVolume, dp.StockPriceAdjClose
FROM DailyPrices dp
INNER JOIN Exchanges ex on ex.Id = dp.ExchangeId
INNER JOIN StockSymbols ss on ss.Id = dp.StockSymbolId
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 1/9/2019 9:11:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DailyPrices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DailyPrices_dbo.Exchanges_ExchangeId] FOREIGN KEY([ExchangeId])
REFERENCES [dbo].[Exchanges] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DailyPrices] CHECK CONSTRAINT [FK_dbo.DailyPrices_dbo.Exchanges_ExchangeId]
GO
ALTER TABLE [dbo].[DailyPrices]  WITH CHECK ADD  CONSTRAINT [FK_dbo.DailyPrices_dbo.StockSymbols_StockSymbolId] FOREIGN KEY([StockSymbolId])
REFERENCES [dbo].[StockSymbols] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DailyPrices] CHECK CONSTRAINT [FK_dbo.DailyPrices_dbo.StockSymbols_StockSymbolId]
GO
