USE [master]
GO
/****** Object:  Database [StoreManagementDB]    Script Date: 21/10/2023 1:05:28 pm ******/
CREATE DATABASE [StoreManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StoreManagementDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StoreManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StoreManagementDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [StoreManagementDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreManagementDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [StoreManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreManagementDB] SET RECOVERY FULL 
GO
ALTER DATABASE [StoreManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [StoreManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreManagementDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoreManagementDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StoreManagementDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'StoreManagementDB', N'ON'
GO
ALTER DATABASE [StoreManagementDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [StoreManagementDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StoreManagementDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExceptionLog]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLog](
	[ExceptionLogID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](50) NULL,
	[FunctionName] [varchar](50) NULL,
	[ErrorMessage] [varchar](max) NULL,
	[LogDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ExceptionLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiftCard]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftCard](
	[GiftCardID] [int] IDENTITY(1,1) NOT NULL,
	[CardCode] [varchar](20) NULL,
	[Balance] [decimal](10, 2) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[GiftCardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[CardCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiftCardAudit]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftCardAudit](
	[GiftCardAuditID] [int] IDENTITY(1,1) NOT NULL,
	[GiftCardID] [int] NULL,
	[CardCode] [varchar](20) NULL,
	[Balance] [decimal](10, 2) NULL,
	[IsActive] [bit] NULL,
	[OldValues] [xml] NULL,
	[NewValues] [xml] NULL,
	[ActionType] [varchar](10) NULL,
	[AuditDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[GiftCardAuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoyaltyProgram]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoyaltyProgram](
	[LoyaltyProgramID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[Points] [int] NULL,
	[RewardsRedeemed] [int] NULL,
	[Status] [varchar](20) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[LoyaltyProgramID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[LoyaltyProgramID] [int] NULL,
	[TotalAmount] [decimal](10, 2) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderAudit]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderAudit](
	[OrderAuditID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[CustomerID] [int] NULL,
	[LoyaltyProgramID] [int] NULL,
	[TotalAmount] [decimal](10, 2) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
	[OldValues] [xml] NULL,
	[NewValues] [xml] NULL,
	[ActionType] [varchar](10) NULL,
	[AuditDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderAuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](255) NULL,
	[Price] [decimal](10, 2) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAudit]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAudit](
	[ProductAuditID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[Name] [varchar](100) NULL,
	[Description] [varchar](255) NULL,
	[Price] [decimal](10, 2) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
	[OldValues] [xml] NULL,
	[NewValues] [xml] NULL,
	[ActionType] [varchar](10) NULL,
	[AuditDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductAuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderID] [int] NULL,
	[GiftCardID] [int] NULL,
	[LoyaltyProgramID] [int] NULL,
	[TransactionDate] [datetime] NULL,
	[Amount] [decimal](10, 2) NULL,
	[TransactionType] [varchar](20) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](255) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAudit]    Script Date: 21/10/2023 1:05:29 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAudit](
	[UserAuditID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](255) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Active] [bit] NULL,
	[OldValues] [xml] NULL,
	[NewValues] [xml] NULL,
	[ActionType] [varchar](10) NULL,
	[AuditDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserAuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[GiftCardAudit]  WITH CHECK ADD FOREIGN KEY([GiftCardID])
REFERENCES [dbo].[GiftCard] ([GiftCardID])
GO
ALTER TABLE [dbo].[LoyaltyProgram]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([LoyaltyProgramID])
REFERENCES [dbo].[LoyaltyProgram] ([LoyaltyProgramID])
GO
ALTER TABLE [dbo].[OrderAudit]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[OrderAudit]  WITH CHECK ADD FOREIGN KEY([LoyaltyProgramID])
REFERENCES [dbo].[LoyaltyProgram] ([LoyaltyProgramID])
GO
ALTER TABLE [dbo].[OrderAudit]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[ProductAudit]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([GiftCardID])
REFERENCES [dbo].[GiftCard] ([GiftCardID])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([LoyaltyProgramID])
REFERENCES [dbo].[LoyaltyProgram] ([LoyaltyProgramID])
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[UserAudit]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
USE [master]
GO
ALTER DATABASE [StoreManagementDB] SET  READ_WRITE 
GO
