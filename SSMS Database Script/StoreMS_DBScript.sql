USE [master]
GO
/****** Object:  Database [StoreMS]    Script Date: 30/11/2023 7:36:40 pm ******/
CREATE DATABASE [StoreMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StoreMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StoreMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StoreMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [StoreMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StoreMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreMS] SET RECOVERY FULL 
GO
ALTER DATABASE [StoreMS] SET  MULTI_USER 
GO
ALTER DATABASE [StoreMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StoreMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StoreMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'StoreMS', N'ON'
GO
ALTER DATABASE [StoreMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [StoreMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [StoreMS]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[LoyaltyPoints] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerAudit]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[LoyaltyPoints] [int] NULL,
	[OldName] [nvarchar](255) NULL,
	[OldEmail] [nvarchar](255) NULL,
	[OldLoyaltyPoints] [int] NULL,
	[AuditDateTime] [datetime] NULL,
	[Action] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExceptionLog]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](255) NULL,
	[FunctionName] [nvarchar](255) NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[LogDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiftCard]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftCard](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CardCode] [nvarchar](50) NULL,
	[Balance] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiftCardAudit]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiftCardAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CardCode] [nvarchar](50) NULL,
	[Balance] [decimal](18, 2) NULL,
	[IsActive] [bit] NULL,
	[OldCardCode] [nvarchar](50) NULL,
	[OldBalance] [decimal](18, 2) NULL,
	[OldIsActive] [bit] NULL,
	[AuditDateTime] [datetime] NULL,
	[Action] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsList] [nvarchar](max) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderAudit]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductsList] [nvarchar](max) NULL,
	[TotalAmount] [decimal](18, 2) NULL,
	[OldProductsList] [nvarchar](max) NULL,
	[OldTotalAmount] [decimal](18, 2) NULL,
	[AuditDateTime] [datetime] NULL,
	[Action] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[Category] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAudit]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Category] [nvarchar](50) NULL,
	[OldName] [nvarchar](255) NULL,
	[OldDescription] [nvarchar](max) NULL,
	[OldPrice] [decimal](18, 2) NULL,
	[OldQuantity] [int] NULL,
	[OldCategory] [nvarchar](50) NULL,
	[AuditDateTime] [datetime] NULL,
	[Action] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderID] [int] NULL,
	[GiftCardID] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[LoyaltyPrice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionAudit]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[OrderID] [int] NULL,
	[GiftCardID] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[OldCustomerID] [int] NULL,
	[OldOrderID] [int] NULL,
	[OldGiftCardID] [int] NULL,
	[OldAmount] [decimal](18, 2) NULL,
	[AuditDateTime] [datetime] NULL,
	[Action] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[Role] [nvarchar](50) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAudit]    Script Date: 30/11/2023 7:36:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAudit](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[Role] [nvarchar](50) NULL,
	[OldName] [nvarchar](255) NULL,
	[OldUsername] [nvarchar](50) NULL,
	[OldPassword] [nvarchar](255) NULL,
	[OldIsActive] [bit] NULL,
	[OldRole] [nvarchar](50) NULL,
	[AuditDateTime] [datetime] NULL,
	[Action] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name]) VALUES (2, N'Electronics')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1002, N'Food')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1003, N'Clothing')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1004, N'Home and Furniture')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1005, N'Grocery')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1006, N'Beauty and Personal Care')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1007, N'Toys and Games')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1008, N'Sports and Outdoors')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1009, N'Books and Stationery')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([ID], [Name], [Email], [LoyaltyPoints], [CreatedAt], [UpdatedAt]) VALUES (5, N'Customer1', N'customer1@gmail.com', 1000, CAST(N'2023-11-20T01:08:34.643' AS DateTime), CAST(N'2023-11-20T01:08:40.580' AS DateTime))
INSERT [dbo].[Customer] ([ID], [Name], [Email], [LoyaltyPoints], [CreatedAt], [UpdatedAt]) VALUES (6, N'Umer Ghaus', N'umer@gmail.com', 2000, CAST(N'2023-11-23T04:56:51.210' AS DateTime), CAST(N'2023-11-27T23:02:18.753' AS DateTime))
INSERT [dbo].[Customer] ([ID], [Name], [Email], [LoyaltyPoints], [CreatedAt], [UpdatedAt]) VALUES (1007, N'Umer Ghaus', N'umer3@gmail.com', 3928, CAST(N'2023-11-28T01:08:45.780' AS DateTime), CAST(N'2023-11-29T20:06:04.293' AS DateTime))
INSERT [dbo].[Customer] ([ID], [Name], [Email], [LoyaltyPoints], [CreatedAt], [UpdatedAt]) VALUES (1008, N'Hamza Ali', N'hamzaali@gmail.com', 417, CAST(N'2023-11-29T20:58:35.597' AS DateTime), CAST(N'2023-11-29T20:58:35.637' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerAudit] ON 

INSERT [dbo].[CustomerAudit] ([ID], [Name], [Email], [LoyaltyPoints], [OldName], [OldEmail], [OldLoyaltyPoints], [AuditDateTime], [Action]) VALUES (1, N'Umer Ghaus', N'umer@gmail.com', 2000, N'Umer Ghaus', N'umer@gmail.com', 0, CAST(N'2023-11-27T23:02:18.757' AS DateTime), N'Update')
INSERT [dbo].[CustomerAudit] ([ID], [Name], [Email], [LoyaltyPoints], [OldName], [OldEmail], [OldLoyaltyPoints], [AuditDateTime], [Action]) VALUES (2, NULL, NULL, NULL, N'Umer', N'umer1@gmail.com', 12345, CAST(N'2023-11-27T23:02:35.750' AS DateTime), N'Delete')
INSERT [dbo].[CustomerAudit] ([ID], [Name], [Email], [LoyaltyPoints], [OldName], [OldEmail], [OldLoyaltyPoints], [AuditDateTime], [Action]) VALUES (3, N'Umer Ghaus', N'umer3@gmail.com', 6045, N'Umer Ghaus', N'umer3@gmail.com', 0, CAST(N'2023-11-28T01:08:45.800' AS DateTime), N'Update')
INSERT [dbo].[CustomerAudit] ([ID], [Name], [Email], [LoyaltyPoints], [OldName], [OldEmail], [OldLoyaltyPoints], [AuditDateTime], [Action]) VALUES (4, N'Umer Ghaus', N'umer3@gmail.com', 7045, N'Umer Ghaus', N'umer3@gmail.com', 6045, CAST(N'2023-11-28T22:33:59.073' AS DateTime), N'Update')
INSERT [dbo].[CustomerAudit] ([ID], [Name], [Email], [LoyaltyPoints], [OldName], [OldEmail], [OldLoyaltyPoints], [AuditDateTime], [Action]) VALUES (5, N'Umer Ghaus', N'umer3@gmail.com', 0, N'Umer Ghaus', N'umer3@gmail.com', 7045, CAST(N'2023-11-29T20:03:36.450' AS DateTime), N'Update')
INSERT [dbo].[CustomerAudit] ([ID], [Name], [Email], [LoyaltyPoints], [OldName], [OldEmail], [OldLoyaltyPoints], [AuditDateTime], [Action]) VALUES (6, N'Umer Ghaus', N'umer3@gmail.com', 3928, N'Umer Ghaus', N'umer3@gmail.com', 0, CAST(N'2023-11-29T20:06:04.293' AS DateTime), N'Update')
INSERT [dbo].[CustomerAudit] ([ID], [Name], [Email], [LoyaltyPoints], [OldName], [OldEmail], [OldLoyaltyPoints], [AuditDateTime], [Action]) VALUES (7, N'Hamza Ali', N'hamzaali@gmail.com', 417, N'Hamza Ali', N'hamzaali@gmail.com', 0, CAST(N'2023-11-29T20:58:35.637' AS DateTime), N'Update')
SET IDENTITY_INSERT [dbo].[CustomerAudit] OFF
GO
SET IDENTITY_INSERT [dbo].[ExceptionLog] ON 

INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1, N'ExceptionLogsPage.xaml.cs', N'LoadExceptionLogs', N'Cannot open database "StorMS" requested by the login. The login failed.
Login failed for user ''Umer_Ghaus\muham''.', CAST(N'2023-11-20T01:38:20.850' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (2, N'POS.xaml.cs', N'btnConfirmOrder_MouseDown', N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Transaction_Customer". The conflict occurred in database "StoreMS", table "dbo.Customer", column ''ID''.
The statement has been terminated.', CAST(N'2023-11-24T04:25:59.193' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (3, N'POS.xaml.cs', N'btnConfirmOrder_MouseDown', N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Transaction_Customer". The conflict occurred in database "StoreMS", table "dbo.Customer", column ''ID''.
The statement has been terminated.', CAST(N'2023-11-24T04:31:50.347' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (4, N'POS.xaml.cs', N'btnConfirmOrder_MouseDown', N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Transaction_Customer". The conflict occurred in database "StoreMS", table "dbo.Customer", column ''ID''.
The statement has been terminated.', CAST(N'2023-11-24T04:32:44.320' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (5, N'POS.xaml.cs', N'btnConfirmOrder_MouseDown', N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Transaction_Customer". The conflict occurred in database "StoreMS", table "dbo.Customer", column ''ID''.
The statement has been terminated.', CAST(N'2023-11-24T04:32:51.677' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (6, N'POS.xaml.cs', N'btnConfirmOrder_MouseDown', N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Transaction_Customer". The conflict occurred in database "StoreMS", table "dbo.Customer", column ''ID''.
The statement has been terminated.', CAST(N'2023-11-24T04:33:14.680' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1002, N'Reports.xaml.cs', N'readDataFromDatabase', N'Invalid object name ''BookInfo''.', CAST(N'2023-11-25T07:37:45.330' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1003, N'Reports.xaml.cs', N'readDataFromDatabase', N'Invalid object name ''BookInfo''.', CAST(N'2023-11-25T07:39:02.937' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1004, N'Reports.xaml.cs', N'txtSearch_TextChanged', N'Object reference not set to an instance of an object.', CAST(N'2023-11-25T07:39:08.777' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1005, N'Reports.xaml.cs', N'readDataFromDatabase', N'Invalid object name ''Product''.', CAST(N'2023-11-25T07:39:16.650' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1006, N'Reports.xaml.cs', N'readDataFromDatabase', N'Invalid object name ''BookInfo''.', CAST(N'2023-11-25T07:39:54.680' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1007, N'Reports.xaml.cs', N'txtSearch_TextChanged', N'Object reference not set to an instance of an object.', CAST(N'2023-11-25T07:39:58.420' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1008, N'Reports.xaml.cs', N'readDataFromDatabase', N'Invalid object name ''BookInfo''.', CAST(N'2023-11-25T07:46:31.243' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1009, N'Reports.xaml.cs', N'txtSearch_TextChanged', N'Object reference not set to an instance of an object.', CAST(N'2023-11-25T07:46:34.833' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1010, N'Reports.xaml.cs', N'readDataFromDatabase', N'Invalid object name ''BookInfo''.', CAST(N'2023-11-25T08:00:10.467' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1011, N'Reports.xaml.cs', N'txtSearch_TextChanged', N'Object reference not set to an instance of an object.', CAST(N'2023-11-25T08:00:13.197' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1012, N'Reports.xaml.cs', N'readDataFromDatabase', N'Invalid object name ''BookInfo''.', CAST(N'2023-11-25T08:02:09.450' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1013, N'Reports.xaml.cs', N'txtSearch_TextChanged', N'Object reference not set to an instance of an object.', CAST(N'2023-11-25T08:02:13.323' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1014, N'App.xaml.cs', N'UnhandledException', N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_UserAudit_User". The conflict occurred in database "StoreMS", table "dbo.User", column ''ID''.
The statement has been terminated.', CAST(N'2023-11-25T08:12:19.960' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1015, N'Reports.xaml.cs', N'readDataFromDatabase', N'ExecuteReader: CommandText property has not been initialized', CAST(N'2023-11-26T22:30:20.377' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1016, N'Reports.xaml.cs', N'txtSearch_TextChanged', N'Object reference not set to an instance of an object.', CAST(N'2023-11-26T22:30:29.553' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1017, N'Reports.xaml.cs', N'readDataFromDatabase', N'ExecuteReader: CommandText property has not been initialized', CAST(N'2023-11-27T00:40:17.543' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1018, N'Reports.xaml.cs', N'txtSearch_TextChanged', N'Object reference not set to an instance of an object.', CAST(N'2023-11-27T00:40:22.487' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1019, N'Reports.xaml.cs', N'readDataFromDatabase', N'ExecuteReader: CommandText property has not been initialized', CAST(N'2023-11-27T00:41:40.980' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1020, N'Reports.xaml.cs', N'readDataFromDatabase', N'ExecuteReader: CommandText property has not been initialized', CAST(N'2023-11-27T00:42:14.060' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1021, N'Reports.xaml.cs', N'readDataFromDatabase', N'ExecuteReader: CommandText property has not been initialized', CAST(N'2023-11-27T00:42:26.463' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1022, N'Reports.xaml.cs', N'readDataFromDatabase', N'ExecuteReader: CommandText property has not been initialized', CAST(N'2023-11-27T00:45:32.557' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1023, N'App.xaml.cs', N'UnhandledException', N'Cannot insert explicit value for identity column in table ''ProductAudit'' when IDENTITY_INSERT is set to OFF.
The statement has been terminated.', CAST(N'2023-11-27T22:41:20.897' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1024, N'App.xaml.cs', N'UnhandledException', N'Cannot insert explicit value for identity column in table ''ProductAudit'' when IDENTITY_INSERT is set to OFF.
The statement has been terminated.', CAST(N'2023-11-27T22:49:00.383' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1025, N'App.xaml.cs', N'UnhandledException', N'''The invocation of the constructor on type ''StoreMS.Pages.Admin.Dashboard'' that matches the specified binding constraints threw an exception.'' Line number ''7'' and line position ''7''.', CAST(N'2023-11-29T20:58:53.433' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1026, N'App.xaml.cs', N'UnhandledException', N'''The invocation of the constructor on type ''StoreMS.Pages.Admin.Dashboard'' that matches the specified binding constraints threw an exception.'' Line number ''7'' and line position ''7''.', CAST(N'2023-11-29T22:28:17.993' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1027, N'App.xaml.cs', N'UnhandledException', N'''Set connectionId threw an exception.'' Line number ''7'' and line position ''7''.', CAST(N'2023-11-29T22:30:30.210' AS DateTime))
INSERT [dbo].[ExceptionLog] ([ID], [ClassName], [FunctionName], [ErrorMessage], [LogDate]) VALUES (1028, N'App.xaml.cs', N'UnhandledException', N'''Set connectionId threw an exception.'' Line number ''7'' and line position ''7''.', CAST(N'2023-11-29T22:32:43.833' AS DateTime))
SET IDENTITY_INSERT [dbo].[ExceptionLog] OFF
GO
SET IDENTITY_INSERT [dbo].[GiftCard] ON 

INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (21, N'30KV0BL26Z7P', CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-20T01:23:35.210' AS DateTime), CAST(N'2023-11-20T01:23:35.210' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (22, N'GPRA8AR35VZ7', CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-20T01:23:35.210' AS DateTime), CAST(N'2023-11-20T01:23:35.210' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (23, N'TEXPGAX44SSP', CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-20T01:23:35.220' AS DateTime), CAST(N'2023-11-20T01:23:35.220' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (24, N'NSFW8ENNZBUE', CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-20T01:23:35.240' AS DateTime), CAST(N'2023-11-20T01:23:35.240' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (26, N'D6SQOCZOX4EE', CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-20T01:23:35.270' AS DateTime), CAST(N'2023-11-20T01:23:35.270' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (27, N'7L9XGGP7SNG3', CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-20T01:23:35.283' AS DateTime), CAST(N'2023-11-20T01:23:35.283' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (28, N'KAGCOGW8SJ8L', CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-20T01:23:35.300' AS DateTime), CAST(N'2023-11-20T01:23:35.300' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (29, N'EOXJGKLRM2AB', CAST(100.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-20T01:23:35.317' AS DateTime), CAST(N'2023-11-20T01:23:35.317' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (30, N'RD4YOJSSMZ3S', CAST(100.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-20T01:23:35.330' AS DateTime), CAST(N'2023-11-20T01:23:35.330' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (31, N'T3YJM8AS56YC', CAST(5500.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-23T05:04:08.157' AS DateTime), CAST(N'2023-11-23T05:04:08.157' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (32, N'6S4YU8GT42RU', CAST(5500.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-23T05:04:08.160' AS DateTime), CAST(N'2023-11-23T05:04:08.160' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (33, N'1ZE6HJAZAF39', CAST(10000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-24T07:18:53.690' AS DateTime), CAST(N'2023-11-24T07:18:53.690' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (34, N'822SHM6J4VXH', CAST(10000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-24T07:18:53.700' AS DateTime), CAST(N'2023-11-24T07:18:53.700' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (1031, N'773234JKSRII', CAST(10000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-25T06:40:24.677' AS DateTime), CAST(N'2023-11-25T06:40:24.677' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (1032, N'EBSP37F4M7CQ', CAST(10000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-25T06:40:24.683' AS DateTime), CAST(N'2023-11-25T06:40:24.683' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (1033, N'O38V2QLABDOF', CAST(5000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-27T14:16:15.513' AS DateTime), CAST(N'2023-11-27T14:16:15.513' AS DateTime))
INSERT [dbo].[GiftCard] ([ID], [CardCode], [Balance], [IsActive], [CreatedAt], [UpdatedAt]) VALUES (1034, N'WIX8EDS8GNXO', CAST(5000.00 AS Decimal(18, 2)), 0, CAST(N'2023-11-29T20:04:17.663' AS DateTime), CAST(N'2023-11-29T20:04:30.097' AS DateTime))
SET IDENTITY_INSERT [dbo].[GiftCard] OFF
GO
SET IDENTITY_INSERT [dbo].[GiftCardAudit] ON 

INSERT [dbo].[GiftCardAudit] ([ID], [CardCode], [Balance], [IsActive], [OldCardCode], [OldBalance], [OldIsActive], [AuditDateTime], [Action]) VALUES (1, N'WIX8EDS8GNXO', CAST(5000.00 AS Decimal(18, 2)), 0, N'WIX8EDS8GNXO', CAST(5000.00 AS Decimal(18, 2)), 1, CAST(N'2023-11-29T20:04:30.097' AS DateTime), N'Update')
SET IDENTITY_INSERT [dbo].[GiftCardAudit] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [ProductsList], [TotalAmount], [CreatedAt], [UpdatedAt]) VALUES (26, N'Casio Calculator-1500.00-1', CAST(1500.00 AS Decimal(18, 2)), CAST(N'2023-11-24T07:28:06.667' AS DateTime), CAST(N'2023-11-24T07:28:06.667' AS DateTime))
INSERT [dbo].[Order] ([ID], [ProductsList], [TotalAmount], [CreatedAt], [UpdatedAt]) VALUES (1003, N'Lenovo Laptop-25000.00-1', CAST(25000.00 AS Decimal(18, 2)), CAST(N'2023-11-26T23:48:04.493' AS DateTime), CAST(N'2023-11-26T23:48:04.493' AS DateTime))
INSERT [dbo].[Order] ([ID], [ProductsList], [TotalAmount], [CreatedAt], [UpdatedAt]) VALUES (1004, N'Casio Calculator-1500.00-2', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-27T00:16:40.517' AS DateTime), CAST(N'2023-11-27T00:16:40.517' AS DateTime))
INSERT [dbo].[Order] ([ID], [ProductsList], [TotalAmount], [CreatedAt], [UpdatedAt]) VALUES (1007, N'Casio Calculator-1500.00-1', CAST(1500.00 AS Decimal(18, 2)), CAST(N'2023-11-28T01:08:45.773' AS DateTime), CAST(N'2023-11-28T01:08:45.773' AS DateTime))
INSERT [dbo].[Order] ([ID], [ProductsList], [TotalAmount], [CreatedAt], [UpdatedAt]) VALUES (1008, N'Casio Calculator-1500.00-2;Washing Machine-27000.00-1', CAST(30000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T20:06:04.260' AS DateTime), CAST(N'2023-11-29T20:06:04.260' AS DateTime))
INSERT [dbo].[Order] ([ID], [ProductsList], [TotalAmount], [CreatedAt], [UpdatedAt]) VALUES (1009, N'Men''s Casual Shirt-390.99-2;Living Room Sofa-4990.99-1;Skin Care Kit-790.99-3;Bestseller Book Collection-150.99-2;Board Game Set-240.99-2;Gourmet Chocolate Box-249.75-2;Snack Variety Pack-749.75-3;International Snack Box-1124.75-2', CAST(13928.15 AS Decimal(18, 2)), CAST(N'2023-11-29T20:58:35.580' AS DateTime), CAST(N'2023-11-29T20:58:35.580' AS DateTime))
INSERT [dbo].[Order] ([ID], [ProductsList], [TotalAmount], [CreatedAt], [UpdatedAt]) VALUES (1010, N'Living Room Sofa-14999.99-1;Skin Care Kit-1999.00-1;Board Game Set-540.99-2;Science Experiment Kit-990.99-2;Outdoor Sports Equipment-5490.99-2', CAST(31044.93 AS Decimal(18, 2)), CAST(N'2023-11-29T21:54:12.200' AS DateTime), CAST(N'2023-11-29T21:54:12.200' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderAudit] ON 

INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (1, NULL, NULL, N'Lenovo Laptop-100000.00-4;Casio Calculator-1500.00-12;Lenovo Laptop-100000.00-1;HP Laptop-100000.00-1;Casio Calculator-1500.00-1;Lenovo Laptop-100000.00-1;Casio Calculator-1500.00-1;HP Laptop-100000.00-1;Casio Calculator-1500.00-1;Lenovo Laptop-100000.00-1;Casio Calculator-1500.00-1', CAST(924000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (2, NULL, NULL, N'Lenovo Laptop-100000.00-1;Casio Calculator-1500.00-2;HP Laptop-100000.00-1;Lenovo Laptop-100000.00-2', CAST(403000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (3, NULL, NULL, N'Casio Calculator-1500.00-2', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (4, NULL, NULL, N'Casio Calculator-1500.00-2', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (5, NULL, NULL, N'Casio Calculator-1500.00-2', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (6, NULL, NULL, N'Lenovo Laptop-100000.00-1', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (7, NULL, NULL, N'Casio Calculator-1500.00-2', CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (8, NULL, NULL, N'Casio Calculator-1500.00-3;Lenovo Laptop-100000.00-12', CAST(1204500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (9, NULL, NULL, N'HP Laptop-100000.00-1;Lenovo Laptop-100000.00-2', CAST(300000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (10, NULL, NULL, N'Lenovo Laptop-100000.00-1', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (11, NULL, NULL, N'Lenovo Laptop-100000.00-1', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (12, NULL, NULL, N'Casio Calculator-1500.00-1', CAST(1500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (13, NULL, NULL, N'Casio Calculator-1500.00-1', CAST(1500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (14, NULL, NULL, N'Lenovo Laptop-100000.00-1;HP Laptop-100000.00-1', CAST(200000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (15, NULL, NULL, N'Lenovo Laptop-100000.00-1', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (16, NULL, NULL, N'Casio Calculator-1500.00-2;Lenovo Laptop-100000.00-1', CAST(103000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (17, NULL, NULL, N'Lenovo Laptop-100000.00-1;HP Laptop-100000.00-2', CAST(300000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (18, NULL, NULL, N'Lenovo Laptop-100000.00-1', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (19, NULL, NULL, N'Lenovo Laptop-100000.00-1', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (20, NULL, NULL, N'Lenovo Laptop-100000.00-1;HP Laptop-100000.00-1', CAST(200000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (21, NULL, NULL, N'Lenovo Laptop-100000.00-1;HP Laptop-100000.00-1', CAST(200000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (22, NULL, NULL, N'Lenovo Laptop-100000.00-1;HP Laptop-100000.00-1', CAST(200000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (23, NULL, NULL, N'Lenovo Laptop-100000.00-1;Casio Calculator-1500.00-2', CAST(103000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (24, NULL, NULL, N'Lenovo Laptop-100000.00-1;Casio Calculator-1500.00-2', CAST(103000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (25, NULL, NULL, N'HP Laptop-100000.00-1;Casio Calculator-1500.00-1', CAST(101500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:39.453' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (26, NULL, NULL, N'HP Laptop-100000.00-1;Casio Calculator-1500.00-2', CAST(103000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:41:48.307' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (27, NULL, NULL, N'Lenovo Laptop-100000.00-1;Casio Calculator-1500.00-3', CAST(104500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:41:52.620' AS DateTime), N'Delete')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (28, N'Lenovo Laptop-25000.00-1', CAST(25000.00 AS Decimal(18, 2)), N'Lenovo Laptop-100000.00-1', CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:44:20.900' AS DateTime), N'Update')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (29, N'Casio Calculator-1500.00-1', CAST(201500.00 AS Decimal(18, 2)), N'Casio Calculator-1500.00-1;HP Laptop-100000.00-2', CAST(201500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:44:38.793' AS DateTime), N'Update')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (30, N'Casio Calculator-1500.00-1', CAST(1500.00 AS Decimal(18, 2)), N'Casio Calculator-1500.00-1', CAST(201500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:44:45.770' AS DateTime), N'Update')
INSERT [dbo].[OrderAudit] ([ID], [ProductsList], [TotalAmount], [OldProductsList], [OldTotalAmount], [AuditDateTime], [Action]) VALUES (31, N'Casio Calculator-1500.00-2;Washing Machine-27000.00-1', CAST(30000.00 AS Decimal(18, 2)), N'Casio Calculator-1500.00-2;Washing Machine-70000.00-2', CAST(143000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:45:21.900' AS DateTime), N'Update')
SET IDENTITY_INSERT [dbo].[OrderAudit] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (2, N'Lenovo Laptop', N'Lenovo V14 G3', CAST(25000.00 AS Decimal(18, 2)), 123, CAST(N'2023-11-19T04:41:40.517' AS DateTime), CAST(N'2023-11-29T21:47:24.490' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1014, N'Smartphone X', N'High-end smartphone with advanced features', CAST(7990.99 AS Decimal(18, 2)), 130, CAST(N'2023-11-29T20:23:31.470' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1015, N'Men''s Casual Shirt', N'Comfortable and stylish shirt for men', CAST(390.99 AS Decimal(18, 2)), 178, CAST(N'2023-11-29T20:23:31.470' AS DateTime), CAST(N'2023-11-29T20:56:23.563' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1016, N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(14999.99 AS Decimal(18, 2)), 88, CAST(N'2023-11-29T20:23:31.470' AS DateTime), CAST(N'2023-11-29T21:53:27.687' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1017, N'Fresh Produce Bundle', N'Assorted fruits and vegetables', CAST(290.99 AS Decimal(18, 2)), 280, CAST(N'2023-11-29T20:23:31.470' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1018, N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(1999.00 AS Decimal(18, 2)), 106, CAST(N'2023-11-29T20:23:31.470' AS DateTime), CAST(N'2023-11-29T21:53:45.047' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1019, N'Board Game Set', N'Family-friendly board games for all ages', CAST(540.99 AS Decimal(18, 2)), 116, CAST(N'2023-11-29T20:23:31.470' AS DateTime), CAST(N'2023-11-29T21:53:51.887' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1020, N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(5490.99 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:23:31.470' AS DateTime), CAST(N'2023-11-29T21:54:08.370' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1021, N'Bestseller Book Collection', N'Popular books from various genres', CAST(449.99 AS Decimal(18, 2)), 128, CAST(N'2023-11-29T20:23:31.470' AS DateTime), CAST(N'2023-11-29T21:52:18.983' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1022, N'Ultra Thin Laptop', N'Slim and lightweight laptop for on-the-go use', CAST(22499.75 AS Decimal(18, 2)), 110, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1023, N'Men''s Formal Shirt', N'Classic formal shirt for professional occasions', CAST(1249.75 AS Decimal(18, 2)), 160, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1024, N'Coffee Table with Storage', N'Functional coffee table with built-in storage', CAST(3749.75 AS Decimal(18, 2)), 105, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1025, N'Organic Food Basket', N'Selection of organic and healthy food items', CAST(1749.75 AS Decimal(18, 2)), 200, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1026, N'Luxury Skincare Set', N'Premium skincare products for a spa-like experience', CAST(3249.75 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1027, N'Chess and Checkers Set', N'Classic board games for strategic minds', CAST(499.75 AS Decimal(18, 2)), 115, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1028, N'Hiking Backpack', N'Durable backpack for outdoor adventures', CAST(1999.75 AS Decimal(18, 2)), 100, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1029, N'Coloring Book Collection', N'Various coloring books for relaxation', CAST(224.75 AS Decimal(18, 2)), 140, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1030, N'4K Gaming Console', N'Gaming console for a high-definition gaming experience', CAST(12499.75 AS Decimal(18, 2)), 90, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1031, N'Women''s Summer Dress', N'Light and breezy dress for summer occasions', CAST(874.75 AS Decimal(18, 2)), 140, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1032, N'Modern Bedside Table', N'Contemporary bedside table for your bedroom', CAST(2249.75 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1033, N'Snack Variety Pack', N'Assortment of tasty snacks for any craving', CAST(749.75 AS Decimal(18, 2)), 167, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:58:07.700' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1034, N'Men''s Cologne Set', N'Fragrance set for a sophisticated scent', CAST(1874.75 AS Decimal(18, 2)), 102, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1035, N'Educational Toy Bundle', N'Toys that stimulate learning and creativity', CAST(749.75 AS Decimal(18, 2)), 120, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1036, N'Cycling Gear Kit', N'Equipment for cycling enthusiasts', CAST(3749.75 AS Decimal(18, 2)), 92, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1037, N'Art Supplies Set', N'Complete set of art materials for aspiring artists', CAST(999.75 AS Decimal(18, 2)), 130, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1038, N'Smart Home Security System', N'Protect your home with the latest security technology', CAST(7499.75 AS Decimal(18, 2)), 88, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1039, N'Women''s Winter Boots', N'Stylish and warm boots for cold weather', CAST(1749.75 AS Decimal(18, 2)), 110, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1040, N'Convertible Sofa Bed', N'Versatile sofa that transforms into a bed', CAST(13749.75 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1041, N'BBQ Essentials Kit', N'Everything you need for a perfect BBQ', CAST(1999.75 AS Decimal(18, 2)), 105, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1042, N'Luxury Bathrobe Set', N'Soft and luxurious bathrobes for a spa-like experience', CAST(2499.75 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1043, N'Building Blocks Set', N'Creative building blocks for hours of fun', CAST(449.75 AS Decimal(18, 2)), 125, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1044, N'Camping Tent', N'Spacious tent for a comfortable camping experience', CAST(3999.75 AS Decimal(18, 2)), 88, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1045, N'Calligraphy Pen Set', N'Professional calligraphy pens for elegant writing', CAST(374.75 AS Decimal(18, 2)), 135, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1046, N'Smart Fitness Tracker', N'Track your fitness goals with the latest technology', CAST(1999.75 AS Decimal(18, 2)), 100, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1047, N'Men''s Swim Shorts', N'Stylish swim shorts for a day at the beach', CAST(749.75 AS Decimal(18, 2)), 120, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1048, N'Round Dining Table', N'Circular dining table for a modern touch', CAST(7499.75 AS Decimal(18, 2)), 92, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1049, N'International Snack Box', N'Explore snacks from around the world', CAST(1124.75 AS Decimal(18, 2)), 148, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:58:18.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1050, N'Anti-Aging Skincare Set', N'Revitalize your skin with anti-aging products', CAST(2999.75 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1051, N'Science Experiment Kit', N'Educational kit for young scientists', CAST(990.99 AS Decimal(18, 2)), 108, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T21:53:58.830' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1052, N'Climbing Gear Set', N'Equipment for climbing enthusiasts', CAST(4749.75 AS Decimal(18, 2)), 90, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1053, N'Writing Journal Collection', N'Assorted writing journals for self-reflection', CAST(324.75 AS Decimal(18, 2)), 145, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1054, N'Wireless Noise-Canceling Headphones', N'Immersive audio experience with noise-canceling technology', CAST(3749.75 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1055, N'Women''s Active Leggings', N'Comfortable leggings for an active lifestyle', CAST(874.75 AS Decimal(18, 2)), 130, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1056, N'Sectional Sofa Set', N'Modular sofa set for customizable seating', CAST(22499.75 AS Decimal(18, 2)), 88, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1057, N'Healthy Snack Pack', N'Nutritious snacks for a guilt-free treat', CAST(499.75 AS Decimal(18, 2)), 160, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1058, N'Men''s Shaving Kit', N'Complete shaving kit for a smooth experience', CAST(1374.75 AS Decimal(18, 2)), 100, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1059, N'Educational Puzzle Set', N'Puzzles that enhance cognitive skills', CAST(424.75 AS Decimal(18, 2)), 115, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1060, N'Cycling Helmet', N'Safety first with a high-quality cycling helmet', CAST(999.75 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1061, N'Adult Coloring Book Collection', N'Therapeutic coloring books for adults', CAST(249.75 AS Decimal(18, 2)), 155, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1062, N'Wireless Charging Pad', N'Convenient wireless charging for your devices', CAST(749.75 AS Decimal(18, 2)), 105, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1063, N'Men''s Casual Sneakers', N'Stylish and comfortable sneakers for everyday wear', CAST(449.75 AS Decimal(18, 2)), 120, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1064, N'Console Table', N'Versatile table for entryways or living rooms', CAST(799.75 AS Decimal(18, 2)), 100, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1065, N'Gourmet Chocolate Box', N'Indulge in a selection of premium chocolates', CAST(249.75 AS Decimal(18, 2)), 138, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:57:53.543' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1066, N'Hair Care Essentials Kit', N'Complete kit for healthy and beautiful hair', CAST(649.75 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1067, N'Wooden Building Blocks', N'Classic wooden blocks for creative play', CAST(199.75 AS Decimal(18, 2)), 110, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1068, N'Camping Cookware Set', N'Compact cookware for camping enthusiasts', CAST(699.75 AS Decimal(18, 2)), 92, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1069, N'Classic Literature Collection', N'Timeless literary works for book enthusiasts', CAST(149.75 AS Decimal(18, 2)), 130, CAST(N'2023-11-29T20:23:39.070' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1070, N'Wireless Mouse', N'Ergonomic wireless mouse for efficient navigation', CAST(499.80 AS Decimal(18, 2)), 130, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1071, N'Women''s Casual T-Shirt', N'Comfortable and stylish casual t-shirt', CAST(299.80 AS Decimal(18, 2)), 180, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1072, N'Study Desk', N'Durable study desk for productive work sessions', CAST(1799.80 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1073, N'Fresh Fruit Basket', N'Assortment of fresh and juicy fruits', CAST(799.80 AS Decimal(18, 2)), 160, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1074, N'Scented Candle Set', N'Aromatic scented candles for a relaxing ambiance', CAST(399.80 AS Decimal(18, 2)), 110, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1075, N'Remote Control Car', N'Fun remote control car for kids and adults', CAST(599.80 AS Decimal(18, 2)), 105, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1076, N'Yoga Mat', N'High-quality yoga mat for fitness enthusiasts', CAST(399.80 AS Decimal(18, 2)), 120, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1077, N'Notebook Bundle', N'Set of stylish and functional notebooks', CAST(259.80 AS Decimal(18, 2)), 140, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1078, N'Bluetooth Earbuds', N'Wireless Bluetooth earbuds for on-the-go music', CAST(1199.80 AS Decimal(18, 2)), 100, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1079, N'Men''s Denim Jeans', N'Classic denim jeans for a casual look', CAST(899.80 AS Decimal(18, 2)), 115, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1080, N'Standing Desk Converter', N'Transform your desk into a standing workspace', CAST(2599.80 AS Decimal(18, 2)), 90, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1081, N'Dried Fruit Mix', N'Delicious mix of dried fruits for a healthy snack', CAST(499.80 AS Decimal(18, 2)), 150, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1082, N'Aromatherapy Diffuser', N'Create a soothing atmosphere with aromatherapy', CAST(699.80 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1083, N'Puzzle Mat Set', N'Interlocking puzzle mats for a safe play area', CAST(399.80 AS Decimal(18, 2)), 130, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1084, N'Camping Sleeping Bag', N'Warm and comfortable sleeping bag for camping', CAST(1399.80 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1085, N'Writing Pen Collection', N'Variety of high-quality writing pens', CAST(179.80 AS Decimal(18, 2)), 155, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1086, N'Smart Thermostat', N'Control your home''s temperature with a smart thermostat', CAST(1599.80 AS Decimal(18, 2)), 92, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1087, N'Women''s Athleisure Set', N'Stylish athleisure set for active lifestyles', CAST(1099.80 AS Decimal(18, 2)), 110, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1088, N'Bookshelf', N'Sturdy and stylish bookshelf for organizing your books', CAST(2399.80 AS Decimal(18, 2)), 88, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1089, N'Gourmet Coffee Set', N'Selection of premium coffee beans and blends', CAST(799.80 AS Decimal(18, 2)), 105, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1090, N'Facial Mask Collection', N'Assortment of facial masks for skincare', CAST(599.80 AS Decimal(18, 2)), 100, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1091, N'Board Game Collection', N'Various board games for family entertainment', CAST(999.80 AS Decimal(18, 2)), 110, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1092, N'Camping Lantern', N'Portable lantern for camping and outdoor activities', CAST(299.80 AS Decimal(18, 2)), 120, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1093, N'Artists Sketchbook', N'High-quality sketchbook for artistic creations', CAST(199.80 AS Decimal(18, 2)), 140, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1094, N'Wireless Keyboard', N'Convenient wireless keyboard for efficient typing', CAST(699.80 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1095, N'Men''s Hooded Sweatshirt', N'Comfortable hooded sweatshirt for a casual style', CAST(599.80 AS Decimal(18, 2)), 105, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1096, N'Lounge Chair', N'Cozy lounge chair for relaxation and comfort', CAST(2999.80 AS Decimal(18, 2)), 92, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1097, N'Organic Tea Set', N'Selection of organic teas for a soothing experience', CAST(399.80 AS Decimal(18, 2)), 125, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1098, N'Makeup Brush Set', N'Complete set of high-quality makeup brushes', CAST(899.80 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1099, N'Educational Board Game', N'Interactive board game for learning and fun', CAST(499.80 AS Decimal(18, 2)), 105, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1100, N'Camping Cooking Set', N'Compact cooking set for camping adventures', CAST(1199.80 AS Decimal(18, 2)), 90, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1101, N'Reading Glasses Set', N'Stylish and practical set of reading glasses', CAST(299.80 AS Decimal(18, 2)), 135, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1102, N'Portable Bluetooth Speaker', N'Wireless speaker for music on the go', CAST(999.80 AS Decimal(18, 2)), 100, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1103, N'Women''s Cozy Sweater', N'Warm and cozy sweater for chilly days', CAST(799.80 AS Decimal(18, 2)), 120, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1104, N'Coffee Maker', N'Convenient coffee maker for brewing your favorite blend', CAST(1799.80 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1105, N'Nut and Seed Mix', N'Healthy mix of nuts and seeds for snacking', CAST(259.80 AS Decimal(18, 2)), 130, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1106, N'Skincare Gift Set', N'Luxurious skincare gift set for pampering', CAST(1299.80 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1107, N'Educational Puzzle Mat', N'Educational puzzle mat for children''s play areas', CAST(599.80 AS Decimal(18, 2)), 110, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1108, N'Climbing Harness', N'Safety harness for rock climbing and mountaineering', CAST(1999.80 AS Decimal(18, 2)), 90, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1109, N'Classic Novels Collection', N'Collection of classic novels for avid readers', CAST(399.80 AS Decimal(18, 2)), 145, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1110, N'Fitness Resistance Bands Set', N'Versatile resistance bands for home workouts', CAST(699.80 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1111, N'Wireless Charging Dock', N'Charging dock for wireless charging of multiple devices', CAST(1599.80 AS Decimal(18, 2)), 130, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Electronics')
GO
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1112, N'Men''s Business Casual Shoes', N'Stylish and comfortable business casual shoes', CAST(999.80 AS Decimal(18, 2)), 95, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Clothing')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1113, N'Console Gaming Chair', N'Comfortable gaming chair for console gamers', CAST(2999.80 AS Decimal(18, 2)), 105, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Home and Furniture')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1114, N'Gourmet Snack Assortment', N'Assortment of gourmet snacks for indulgence', CAST(599.80 AS Decimal(18, 2)), 98, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Grocery')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1115, N'Facial Cleansing Brush', N'Gentle facial cleansing brush for skincare', CAST(399.80 AS Decimal(18, 2)), 120, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Beauty and Personal Care')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1116, N'Educational Building Blocks', N'Educational building blocks for early childhood development', CAST(899.80 AS Decimal(18, 2)), 92, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Toys and Games')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1117, N'Camping Backpack', N'Durable backpack for camping and hiking', CAST(1499.80 AS Decimal(18, 2)), 100, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Sports and Outdoors')
INSERT [dbo].[Product] ([ID], [Name], [Description], [Price], [Quantity], [CreatedAt], [UpdatedAt], [Category]) VALUES (1118, N'Laptop Backpack', N'Protective backpack designed for laptops', CAST(699.80 AS Decimal(18, 2)), 135, CAST(N'2023-11-29T20:28:04.750' AS DateTime), CAST(N'2023-11-29T20:28:55.367' AS DateTime), N'Books and Stationery')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductAudit] ON 

INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (1, N'Baseus USB-C to USB-C cable', N'Baseus-USB-C to USB-C cable', CAST(1000.00 AS Decimal(18, 2)), 150, N'Electronics', N'Baseus USB-C to USB-C cable', N'Baseus:USB-C to USB-C cable', CAST(1000.00 AS Decimal(18, 2)), 150, N'Electronics', CAST(N'2023-11-27T22:57:13.183' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (2, NULL, NULL, NULL, NULL, NULL, N'Baseus USB-C to USB-C cable', N'Baseus-USB-C to USB-C cable', CAST(1000.00 AS Decimal(18, 2)), 150, N'Electronics', CAST(N'2023-11-27T22:58:30.740' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (3, N'HP Laptop', N'This is HP Pavilion x-360.', CAST(100000.00 AS Decimal(18, 2)), 127, N'Electronics', N'HP Laptop', N'This is HP Pavilion x-360.', CAST(100000.00 AS Decimal(18, 2)), 117, N'Electronics', CAST(N'2023-11-27T23:16:15.200' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (4, N'Casio Calculator', N'Original Casio Scientific Calculator', CAST(1500.00 AS Decimal(18, 2)), 44, N'Electronics', N'Casio Calculator', N'Original Casio Scientific Calculator', CAST(1500.00 AS Decimal(18, 2)), 45, N'Electronics', CAST(N'2023-11-28T01:08:19.353' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (5, N'HP Laptop', N'This is HP Pavilion x-360.', CAST(100000.00 AS Decimal(18, 2)), 125, N'Electronics', N'HP Laptop', N'This is HP Pavilion x-360.', CAST(100000.00 AS Decimal(18, 2)), 127, N'Electronics', CAST(N'2023-11-28T01:08:29.460' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (6, N'Washing Machine', N'Haier 12kg Washing Maching', CAST(70000.00 AS Decimal(18, 2)), 98, N'Electronics', N'Washing Machine', N'Haier 12kg Washing Maching', CAST(70000.00 AS Decimal(18, 2)), 100, N'Electronics', CAST(N'2023-11-28T23:46:39.917' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (7, N'Washing Machine', N'Haier 12kg Washing Maching', CAST(70000.00 AS Decimal(18, 2)), 100, N'Electronics', N'Washing Machine', N'Haier 12kg Washing Maching', CAST(70000.00 AS Decimal(18, 2)), 98, N'Electronics', CAST(N'2023-11-28T23:46:43.860' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (8, N'Casio Calculator', N'Original Casio Scientific Calculator', CAST(1500.00 AS Decimal(18, 2)), 42, N'Electronics', N'Casio Calculator', N'Original Casio Scientific Calculator', CAST(1500.00 AS Decimal(18, 2)), 44, N'Electronics', CAST(N'2023-11-29T20:01:47.523' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (9, N'Washing Machine', N'Haier 12kg Washing Maching', CAST(70000.00 AS Decimal(18, 2)), 98, N'Electronics', N'Washing Machine', N'Haier 12kg Washing Maching', CAST(70000.00 AS Decimal(18, 2)), 100, N'Electronics', CAST(N'2023-11-29T20:01:59.913' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (10, NULL, NULL, NULL, NULL, NULL, N'Bestseller Book Collection', N'Popular books from various genres', CAST(15.99 AS Decimal(18, 2)), 50, N'Books and Stationery', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (11, NULL, NULL, NULL, NULL, NULL, N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(149.99 AS Decimal(18, 2)), 20, N'Sports and Outdoors', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (12, NULL, NULL, NULL, NULL, NULL, N'Board Game Set', N'Family-friendly board games for all ages', CAST(24.99 AS Decimal(18, 2)), 40, N'Toys and Games', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (13, NULL, NULL, NULL, NULL, NULL, N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(79.99 AS Decimal(18, 2)), 30, N'Beauty and Personal Care', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (14, NULL, NULL, NULL, NULL, NULL, N'Fresh Produce Bundle', N'Assorted fruits and vegetables', CAST(29.99 AS Decimal(18, 2)), 200, N'Grocery', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (15, NULL, NULL, NULL, NULL, NULL, N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(499.99 AS Decimal(18, 2)), 10, N'Home and Furniture', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (16, NULL, NULL, NULL, NULL, NULL, N'Men''s Casual Shirt', N'Comfortable and stylish shirt for men', CAST(39.99 AS Decimal(18, 2)), 100, N'Clothing', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (17, NULL, NULL, NULL, NULL, NULL, N'Smartphone X', N'High-end smartphone with advanced features', CAST(799.99 AS Decimal(18, 2)), 50, N'Electronics', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (18, NULL, NULL, NULL, NULL, NULL, N'Washing Machine', N'Haier 12kg Washing Maching', CAST(70000.00 AS Decimal(18, 2)), 98, N'Electronics', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (19, NULL, NULL, NULL, NULL, NULL, N'HP Laptop', N'This is HP Pavilion x-360.', CAST(100000.00 AS Decimal(18, 2)), 125, N'Electronics', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (20, NULL, NULL, NULL, NULL, NULL, N'Casio Calculator', N'Original Casio Scientific Calculator', CAST(1500.00 AS Decimal(18, 2)), 42, N'Electronics', CAST(N'2023-11-29T20:18:56.770' AS DateTime), N'Delete')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (21, N'Laptop Backpack', N'Protective backpack designed for laptops', CAST(699.80 AS Decimal(18, 2)), 135, N'Books and Stationery', N'Laptop Backpack', N'Protective backpack designed for laptops', CAST(699.80 AS Decimal(18, 2)), 55, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (22, N'Camping Backpack', N'Durable backpack for camping and hiking', CAST(1499.80 AS Decimal(18, 2)), 100, N'Sports and Outdoors', N'Camping Backpack', N'Durable backpack for camping and hiking', CAST(1499.80 AS Decimal(18, 2)), 20, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (23, N'Educational Building Blocks', N'Educational building blocks for early childhood development', CAST(899.80 AS Decimal(18, 2)), 92, N'Toys and Games', N'Educational Building Blocks', N'Educational building blocks for early childhood development', CAST(899.80 AS Decimal(18, 2)), 12, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (24, N'Facial Cleansing Brush', N'Gentle facial cleansing brush for skincare', CAST(399.80 AS Decimal(18, 2)), 120, N'Beauty and Personal Care', N'Facial Cleansing Brush', N'Gentle facial cleansing brush for skincare', CAST(399.80 AS Decimal(18, 2)), 40, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (25, N'Gourmet Snack Assortment', N'Assortment of gourmet snacks for indulgence', CAST(599.80 AS Decimal(18, 2)), 98, N'Grocery', N'Gourmet Snack Assortment', N'Assortment of gourmet snacks for indulgence', CAST(599.80 AS Decimal(18, 2)), 18, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (26, N'Console Gaming Chair', N'Comfortable gaming chair for console gamers', CAST(2999.80 AS Decimal(18, 2)), 105, N'Home and Furniture', N'Console Gaming Chair', N'Comfortable gaming chair for console gamers', CAST(2999.80 AS Decimal(18, 2)), 25, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (27, N'Men''s Business Casual Shoes', N'Stylish and comfortable business casual shoes', CAST(999.80 AS Decimal(18, 2)), 95, N'Clothing', N'Men''s Business Casual Shoes', N'Stylish and comfortable business casual shoes', CAST(999.80 AS Decimal(18, 2)), 15, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (28, N'Wireless Charging Dock', N'Charging dock for wireless charging of multiple devices', CAST(1599.80 AS Decimal(18, 2)), 130, N'Electronics', N'Wireless Charging Dock', N'Charging dock for wireless charging of multiple devices', CAST(1599.80 AS Decimal(18, 2)), 50, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (29, N'Fitness Resistance Bands Set', N'Versatile resistance bands for home workouts', CAST(699.80 AS Decimal(18, 2)), 98, N'Sports and Outdoors', N'Fitness Resistance Bands Set', N'Versatile resistance bands for home workouts', CAST(699.80 AS Decimal(18, 2)), 18, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (30, N'Classic Novels Collection', N'Collection of classic novels for avid readers', CAST(399.80 AS Decimal(18, 2)), 145, N'Books and Stationery', N'Classic Novels Collection', N'Collection of classic novels for avid readers', CAST(399.80 AS Decimal(18, 2)), 65, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (31, N'Climbing Harness', N'Safety harness for rock climbing and mountaineering', CAST(1999.80 AS Decimal(18, 2)), 90, N'Sports and Outdoors', N'Climbing Harness', N'Safety harness for rock climbing and mountaineering', CAST(1999.80 AS Decimal(18, 2)), 10, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (32, N'Educational Puzzle Mat', N'Educational puzzle mat for children''s play areas', CAST(599.80 AS Decimal(18, 2)), 110, N'Toys and Games', N'Educational Puzzle Mat', N'Educational puzzle mat for children''s play areas', CAST(599.80 AS Decimal(18, 2)), 30, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (33, N'Skincare Gift Set', N'Luxurious skincare gift set for pampering', CAST(1299.80 AS Decimal(18, 2)), 95, N'Beauty and Personal Care', N'Skincare Gift Set', N'Luxurious skincare gift set for pampering', CAST(1299.80 AS Decimal(18, 2)), 15, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (34, N'Nut and Seed Mix', N'Healthy mix of nuts and seeds for snacking', CAST(259.80 AS Decimal(18, 2)), 130, N'Grocery', N'Nut and Seed Mix', N'Healthy mix of nuts and seeds for snacking', CAST(259.80 AS Decimal(18, 2)), 50, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (35, N'Coffee Maker', N'Convenient coffee maker for brewing your favorite blend', CAST(1799.80 AS Decimal(18, 2)), 98, N'Home and Furniture', N'Coffee Maker', N'Convenient coffee maker for brewing your favorite blend', CAST(1799.80 AS Decimal(18, 2)), 18, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (36, N'Women''s Cozy Sweater', N'Warm and cozy sweater for chilly days', CAST(799.80 AS Decimal(18, 2)), 120, N'Clothing', N'Women''s Cozy Sweater', N'Warm and cozy sweater for chilly days', CAST(799.80 AS Decimal(18, 2)), 40, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (37, N'Portable Bluetooth Speaker', N'Wireless speaker for music on the go', CAST(999.80 AS Decimal(18, 2)), 100, N'Electronics', N'Portable Bluetooth Speaker', N'Wireless speaker for music on the go', CAST(999.80 AS Decimal(18, 2)), 20, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (38, N'Reading Glasses Set', N'Stylish and practical set of reading glasses', CAST(299.80 AS Decimal(18, 2)), 135, N'Books and Stationery', N'Reading Glasses Set', N'Stylish and practical set of reading glasses', CAST(299.80 AS Decimal(18, 2)), 55, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (39, N'Camping Cooking Set', N'Compact cooking set for camping adventures', CAST(1199.80 AS Decimal(18, 2)), 90, N'Sports and Outdoors', N'Camping Cooking Set', N'Compact cooking set for camping adventures', CAST(1199.80 AS Decimal(18, 2)), 10, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (40, N'Educational Board Game', N'Interactive board game for learning and fun', CAST(499.80 AS Decimal(18, 2)), 105, N'Toys and Games', N'Educational Board Game', N'Interactive board game for learning and fun', CAST(499.80 AS Decimal(18, 2)), 25, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (41, N'Makeup Brush Set', N'Complete set of high-quality makeup brushes', CAST(899.80 AS Decimal(18, 2)), 95, N'Beauty and Personal Care', N'Makeup Brush Set', N'Complete set of high-quality makeup brushes', CAST(899.80 AS Decimal(18, 2)), 15, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (42, N'Organic Tea Set', N'Selection of organic teas for a soothing experience', CAST(399.80 AS Decimal(18, 2)), 125, N'Grocery', N'Organic Tea Set', N'Selection of organic teas for a soothing experience', CAST(399.80 AS Decimal(18, 2)), 45, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (43, N'Lounge Chair', N'Cozy lounge chair for relaxation and comfort', CAST(2999.80 AS Decimal(18, 2)), 92, N'Home and Furniture', N'Lounge Chair', N'Cozy lounge chair for relaxation and comfort', CAST(2999.80 AS Decimal(18, 2)), 12, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (44, N'Men''s Hooded Sweatshirt', N'Comfortable hooded sweatshirt for a casual style', CAST(599.80 AS Decimal(18, 2)), 105, N'Clothing', N'Men''s Hooded Sweatshirt', N'Comfortable hooded sweatshirt for a casual style', CAST(599.80 AS Decimal(18, 2)), 25, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (45, N'Wireless Keyboard', N'Convenient wireless keyboard for efficient typing', CAST(699.80 AS Decimal(18, 2)), 98, N'Electronics', N'Wireless Keyboard', N'Convenient wireless keyboard for efficient typing', CAST(699.80 AS Decimal(18, 2)), 18, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (46, N'Artists Sketchbook', N'High-quality sketchbook for artistic creations', CAST(199.80 AS Decimal(18, 2)), 140, N'Books and Stationery', N'Artists Sketchbook', N'High-quality sketchbook for artistic creations', CAST(199.80 AS Decimal(18, 2)), 60, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (47, N'Camping Lantern', N'Portable lantern for camping and outdoor activities', CAST(299.80 AS Decimal(18, 2)), 120, N'Sports and Outdoors', N'Camping Lantern', N'Portable lantern for camping and outdoor activities', CAST(299.80 AS Decimal(18, 2)), 40, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (48, N'Board Game Collection', N'Various board games for family entertainment', CAST(999.80 AS Decimal(18, 2)), 110, N'Toys and Games', N'Board Game Collection', N'Various board games for family entertainment', CAST(999.80 AS Decimal(18, 2)), 30, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (49, N'Facial Mask Collection', N'Assortment of facial masks for skincare', CAST(599.80 AS Decimal(18, 2)), 100, N'Beauty and Personal Care', N'Facial Mask Collection', N'Assortment of facial masks for skincare', CAST(599.80 AS Decimal(18, 2)), 20, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (50, N'Gourmet Coffee Set', N'Selection of premium coffee beans and blends', CAST(799.80 AS Decimal(18, 2)), 105, N'Grocery', N'Gourmet Coffee Set', N'Selection of premium coffee beans and blends', CAST(799.80 AS Decimal(18, 2)), 25, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (51, N'Bookshelf', N'Sturdy and stylish bookshelf for organizing your books', CAST(2399.80 AS Decimal(18, 2)), 88, N'Home and Furniture', N'Bookshelf', N'Sturdy and stylish bookshelf for organizing your books', CAST(2399.80 AS Decimal(18, 2)), 8, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (52, N'Women''s Athleisure Set', N'Stylish athleisure set for active lifestyles', CAST(1099.80 AS Decimal(18, 2)), 110, N'Clothing', N'Women''s Athleisure Set', N'Stylish athleisure set for active lifestyles', CAST(1099.80 AS Decimal(18, 2)), 30, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (53, N'Smart Thermostat', N'Control your home''s temperature with a smart thermostat', CAST(1599.80 AS Decimal(18, 2)), 92, N'Electronics', N'Smart Thermostat', N'Control your home''s temperature with a smart thermostat', CAST(1599.80 AS Decimal(18, 2)), 12, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (54, N'Writing Pen Collection', N'Variety of high-quality writing pens', CAST(179.80 AS Decimal(18, 2)), 155, N'Books and Stationery', N'Writing Pen Collection', N'Variety of high-quality writing pens', CAST(179.80 AS Decimal(18, 2)), 75, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (55, N'Camping Sleeping Bag', N'Warm and comfortable sleeping bag for camping', CAST(1399.80 AS Decimal(18, 2)), 95, N'Sports and Outdoors', N'Camping Sleeping Bag', N'Warm and comfortable sleeping bag for camping', CAST(1399.80 AS Decimal(18, 2)), 15, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (56, N'Puzzle Mat Set', N'Interlocking puzzle mats for a safe play area', CAST(399.80 AS Decimal(18, 2)), 130, N'Toys and Games', N'Puzzle Mat Set', N'Interlocking puzzle mats for a safe play area', CAST(399.80 AS Decimal(18, 2)), 50, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (57, N'Aromatherapy Diffuser', N'Create a soothing atmosphere with aromatherapy', CAST(699.80 AS Decimal(18, 2)), 98, N'Beauty and Personal Care', N'Aromatherapy Diffuser', N'Create a soothing atmosphere with aromatherapy', CAST(699.80 AS Decimal(18, 2)), 18, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (58, N'Dried Fruit Mix', N'Delicious mix of dried fruits for a healthy snack', CAST(499.80 AS Decimal(18, 2)), 150, N'Grocery', N'Dried Fruit Mix', N'Delicious mix of dried fruits for a healthy snack', CAST(499.80 AS Decimal(18, 2)), 70, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (59, N'Standing Desk Converter', N'Transform your desk into a standing workspace', CAST(2599.80 AS Decimal(18, 2)), 90, N'Home and Furniture', N'Standing Desk Converter', N'Transform your desk into a standing workspace', CAST(2599.80 AS Decimal(18, 2)), 10, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (60, N'Men''s Denim Jeans', N'Classic denim jeans for a casual look', CAST(899.80 AS Decimal(18, 2)), 115, N'Clothing', N'Men''s Denim Jeans', N'Classic denim jeans for a casual look', CAST(899.80 AS Decimal(18, 2)), 35, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (61, N'Bluetooth Earbuds', N'Wireless Bluetooth earbuds for on-the-go music', CAST(1199.80 AS Decimal(18, 2)), 100, N'Electronics', N'Bluetooth Earbuds', N'Wireless Bluetooth earbuds for on-the-go music', CAST(1199.80 AS Decimal(18, 2)), 20, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (62, N'Notebook Bundle', N'Set of stylish and functional notebooks', CAST(259.80 AS Decimal(18, 2)), 140, N'Books and Stationery', N'Notebook Bundle', N'Set of stylish and functional notebooks', CAST(259.80 AS Decimal(18, 2)), 60, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (63, N'Yoga Mat', N'High-quality yoga mat for fitness enthusiasts', CAST(399.80 AS Decimal(18, 2)), 120, N'Sports and Outdoors', N'Yoga Mat', N'High-quality yoga mat for fitness enthusiasts', CAST(399.80 AS Decimal(18, 2)), 40, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (64, N'Remote Control Car', N'Fun remote control car for kids and adults', CAST(599.80 AS Decimal(18, 2)), 105, N'Toys and Games', N'Remote Control Car', N'Fun remote control car for kids and adults', CAST(599.80 AS Decimal(18, 2)), 25, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (65, N'Scented Candle Set', N'Aromatic scented candles for a relaxing ambiance', CAST(399.80 AS Decimal(18, 2)), 110, N'Home and Furniture', N'Scented Candle Set', N'Aromatic scented candles for a relaxing ambiance', CAST(399.80 AS Decimal(18, 2)), 30, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (66, N'Fresh Fruit Basket', N'Assortment of fresh and juicy fruits', CAST(799.80 AS Decimal(18, 2)), 160, N'Grocery', N'Fresh Fruit Basket', N'Assortment of fresh and juicy fruits', CAST(799.80 AS Decimal(18, 2)), 80, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (67, N'Study Desk', N'Durable study desk for productive work sessions', CAST(1799.80 AS Decimal(18, 2)), 95, N'Home and Furniture', N'Study Desk', N'Durable study desk for productive work sessions', CAST(1799.80 AS Decimal(18, 2)), 15, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (68, N'Women''s Casual T-Shirt', N'Comfortable and stylish casual t-shirt', CAST(299.80 AS Decimal(18, 2)), 180, N'Clothing', N'Women''s Casual T-Shirt', N'Comfortable and stylish casual t-shirt', CAST(299.80 AS Decimal(18, 2)), 100, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (69, N'Wireless Mouse', N'Ergonomic wireless mouse for efficient navigation', CAST(499.80 AS Decimal(18, 2)), 130, N'Electronics', N'Wireless Mouse', N'Ergonomic wireless mouse for efficient navigation', CAST(499.80 AS Decimal(18, 2)), 50, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (70, N'Classic Literature Collection', N'Timeless literary works for book enthusiasts', CAST(149.75 AS Decimal(18, 2)), 130, N'Books and Stationery', N'Classic Literature Collection', N'Timeless literary works for book enthusiasts', CAST(149.75 AS Decimal(18, 2)), 50, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (71, N'Camping Cookware Set', N'Compact cookware for camping enthusiasts', CAST(699.75 AS Decimal(18, 2)), 92, N'Sports and Outdoors', N'Camping Cookware Set', N'Compact cookware for camping enthusiasts', CAST(699.75 AS Decimal(18, 2)), 12, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (72, N'Wooden Building Blocks', N'Classic wooden blocks for creative play', CAST(199.75 AS Decimal(18, 2)), 110, N'Toys and Games', N'Wooden Building Blocks', N'Classic wooden blocks for creative play', CAST(199.75 AS Decimal(18, 2)), 30, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (73, N'Hair Care Essentials Kit', N'Complete kit for healthy and beautiful hair', CAST(649.75 AS Decimal(18, 2)), 95, N'Beauty and Personal Care', N'Hair Care Essentials Kit', N'Complete kit for healthy and beautiful hair', CAST(649.75 AS Decimal(18, 2)), 15, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (74, N'Gourmet Chocolate Box', N'Indulge in a selection of premium chocolates', CAST(249.75 AS Decimal(18, 2)), 140, N'Grocery', N'Gourmet Chocolate Box', N'Indulge in a selection of premium chocolates', CAST(249.75 AS Decimal(18, 2)), 60, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (75, N'Console Table', N'Versatile table for entryways or living rooms', CAST(799.75 AS Decimal(18, 2)), 100, N'Home and Furniture', N'Console Table', N'Versatile table for entryways or living rooms', CAST(799.75 AS Decimal(18, 2)), 20, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (76, N'Men''s Casual Sneakers', N'Stylish and comfortable sneakers for everyday wear', CAST(449.75 AS Decimal(18, 2)), 120, N'Clothing', N'Men''s Casual Sneakers', N'Stylish and comfortable sneakers for everyday wear', CAST(449.75 AS Decimal(18, 2)), 40, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (77, N'Wireless Charging Pad', N'Convenient wireless charging for your devices', CAST(749.75 AS Decimal(18, 2)), 105, N'Electronics', N'Wireless Charging Pad', N'Convenient wireless charging for your devices', CAST(749.75 AS Decimal(18, 2)), 25, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (78, N'Adult Coloring Book Collection', N'Therapeutic coloring books for adults', CAST(249.75 AS Decimal(18, 2)), 155, N'Books and Stationery', N'Adult Coloring Book Collection', N'Therapeutic coloring books for adults', CAST(249.75 AS Decimal(18, 2)), 75, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (79, N'Cycling Helmet', N'Safety first with a high-quality cycling helmet', CAST(999.75 AS Decimal(18, 2)), 95, N'Sports and Outdoors', N'Cycling Helmet', N'Safety first with a high-quality cycling helmet', CAST(999.75 AS Decimal(18, 2)), 15, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (80, N'Educational Puzzle Set', N'Puzzles that enhance cognitive skills', CAST(424.75 AS Decimal(18, 2)), 115, N'Toys and Games', N'Educational Puzzle Set', N'Puzzles that enhance cognitive skills', CAST(424.75 AS Decimal(18, 2)), 35, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (81, N'Men''s Shaving Kit', N'Complete shaving kit for a smooth experience', CAST(1374.75 AS Decimal(18, 2)), 100, N'Beauty and Personal Care', N'Men''s Shaving Kit', N'Complete shaving kit for a smooth experience', CAST(1374.75 AS Decimal(18, 2)), 20, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (82, N'Healthy Snack Pack', N'Nutritious snacks for a guilt-free treat', CAST(499.75 AS Decimal(18, 2)), 160, N'Grocery', N'Healthy Snack Pack', N'Nutritious snacks for a guilt-free treat', CAST(499.75 AS Decimal(18, 2)), 80, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (83, N'Sectional Sofa Set', N'Modular sofa set for customizable seating', CAST(22499.75 AS Decimal(18, 2)), 88, N'Home and Furniture', N'Sectional Sofa Set', N'Modular sofa set for customizable seating', CAST(22499.75 AS Decimal(18, 2)), 8, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (84, N'Women''s Active Leggings', N'Comfortable leggings for an active lifestyle', CAST(874.75 AS Decimal(18, 2)), 130, N'Clothing', N'Women''s Active Leggings', N'Comfortable leggings for an active lifestyle', CAST(874.75 AS Decimal(18, 2)), 50, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (85, N'Wireless Noise-Canceling Headphones', N'Immersive audio experience with noise-canceling technology', CAST(3749.75 AS Decimal(18, 2)), 98, N'Electronics', N'Wireless Noise-Canceling Headphones', N'Immersive audio experience with noise-canceling technology', CAST(3749.75 AS Decimal(18, 2)), 18, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (86, N'Writing Journal Collection', N'Assorted writing journals for self-reflection', CAST(324.75 AS Decimal(18, 2)), 145, N'Books and Stationery', N'Writing Journal Collection', N'Assorted writing journals for self-reflection', CAST(324.75 AS Decimal(18, 2)), 65, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (87, N'Climbing Gear Set', N'Equipment for climbing enthusiasts', CAST(4749.75 AS Decimal(18, 2)), 90, N'Sports and Outdoors', N'Climbing Gear Set', N'Equipment for climbing enthusiasts', CAST(4749.75 AS Decimal(18, 2)), 10, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (88, N'Science Experiment Kit', N'Educational kit for young scientists', CAST(624.75 AS Decimal(18, 2)), 110, N'Toys and Games', N'Science Experiment Kit', N'Educational kit for young scientists', CAST(624.75 AS Decimal(18, 2)), 30, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (89, N'Anti-Aging Skincare Set', N'Revitalize your skin with anti-aging products', CAST(2999.75 AS Decimal(18, 2)), 95, N'Beauty and Personal Care', N'Anti-Aging Skincare Set', N'Revitalize your skin with anti-aging products', CAST(2999.75 AS Decimal(18, 2)), 15, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (90, N'International Snack Box', N'Explore snacks from around the world', CAST(1124.75 AS Decimal(18, 2)), 150, N'Grocery', N'International Snack Box', N'Explore snacks from around the world', CAST(1124.75 AS Decimal(18, 2)), 70, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (91, N'Round Dining Table', N'Circular dining table for a modern touch', CAST(7499.75 AS Decimal(18, 2)), 92, N'Home and Furniture', N'Round Dining Table', N'Circular dining table for a modern touch', CAST(7499.75 AS Decimal(18, 2)), 12, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (92, N'Men''s Swim Shorts', N'Stylish swim shorts for a day at the beach', CAST(749.75 AS Decimal(18, 2)), 120, N'Clothing', N'Men''s Swim Shorts', N'Stylish swim shorts for a day at the beach', CAST(749.75 AS Decimal(18, 2)), 40, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (93, N'Smart Fitness Tracker', N'Track your fitness goals with the latest technology', CAST(1999.75 AS Decimal(18, 2)), 100, N'Electronics', N'Smart Fitness Tracker', N'Track your fitness goals with the latest technology', CAST(1999.75 AS Decimal(18, 2)), 20, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (94, N'Calligraphy Pen Set', N'Professional calligraphy pens for elegant writing', CAST(374.75 AS Decimal(18, 2)), 135, N'Books and Stationery', N'Calligraphy Pen Set', N'Professional calligraphy pens for elegant writing', CAST(374.75 AS Decimal(18, 2)), 55, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (95, N'Camping Tent', N'Spacious tent for a comfortable camping experience', CAST(3999.75 AS Decimal(18, 2)), 88, N'Sports and Outdoors', N'Camping Tent', N'Spacious tent for a comfortable camping experience', CAST(3999.75 AS Decimal(18, 2)), 8, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (96, N'Building Blocks Set', N'Creative building blocks for hours of fun', CAST(449.75 AS Decimal(18, 2)), 125, N'Toys and Games', N'Building Blocks Set', N'Creative building blocks for hours of fun', CAST(449.75 AS Decimal(18, 2)), 45, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (97, N'Luxury Bathrobe Set', N'Soft and luxurious bathrobes for a spa-like experience', CAST(2499.75 AS Decimal(18, 2)), 98, N'Beauty and Personal Care', N'Luxury Bathrobe Set', N'Soft and luxurious bathrobes for a spa-like experience', CAST(2499.75 AS Decimal(18, 2)), 18, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (98, N'BBQ Essentials Kit', N'Everything you need for a perfect BBQ', CAST(1999.75 AS Decimal(18, 2)), 105, N'Grocery', N'BBQ Essentials Kit', N'Everything you need for a perfect BBQ', CAST(1999.75 AS Decimal(18, 2)), 25, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (99, N'Convertible Sofa Bed', N'Versatile sofa that transforms into a bed', CAST(13749.75 AS Decimal(18, 2)), 95, N'Home and Furniture', N'Convertible Sofa Bed', N'Versatile sofa that transforms into a bed', CAST(13749.75 AS Decimal(18, 2)), 15, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
GO
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (100, N'Women''s Winter Boots', N'Stylish and warm boots for cold weather', CAST(1749.75 AS Decimal(18, 2)), 110, N'Clothing', N'Women''s Winter Boots', N'Stylish and warm boots for cold weather', CAST(1749.75 AS Decimal(18, 2)), 30, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (101, N'Smart Home Security System', N'Protect your home with the latest security technology', CAST(7499.75 AS Decimal(18, 2)), 88, N'Electronics', N'Smart Home Security System', N'Protect your home with the latest security technology', CAST(7499.75 AS Decimal(18, 2)), 8, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (102, N'Art Supplies Set', N'Complete set of art materials for aspiring artists', CAST(999.75 AS Decimal(18, 2)), 130, N'Books and Stationery', N'Art Supplies Set', N'Complete set of art materials for aspiring artists', CAST(999.75 AS Decimal(18, 2)), 50, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (103, N'Cycling Gear Kit', N'Equipment for cycling enthusiasts', CAST(3749.75 AS Decimal(18, 2)), 92, N'Sports and Outdoors', N'Cycling Gear Kit', N'Equipment for cycling enthusiasts', CAST(3749.75 AS Decimal(18, 2)), 12, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (104, N'Educational Toy Bundle', N'Toys that stimulate learning and creativity', CAST(749.75 AS Decimal(18, 2)), 120, N'Toys and Games', N'Educational Toy Bundle', N'Toys that stimulate learning and creativity', CAST(749.75 AS Decimal(18, 2)), 40, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (105, N'Men''s Cologne Set', N'Fragrance set for a sophisticated scent', CAST(1874.75 AS Decimal(18, 2)), 102, N'Beauty and Personal Care', N'Men''s Cologne Set', N'Fragrance set for a sophisticated scent', CAST(1874.75 AS Decimal(18, 2)), 22, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (106, N'Snack Variety Pack', N'Assortment of tasty snacks for any craving', CAST(749.75 AS Decimal(18, 2)), 170, N'Grocery', N'Snack Variety Pack', N'Assortment of tasty snacks for any craving', CAST(749.75 AS Decimal(18, 2)), 90, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (107, N'Modern Bedside Table', N'Contemporary bedside table for your bedroom', CAST(2249.75 AS Decimal(18, 2)), 98, N'Home and Furniture', N'Modern Bedside Table', N'Contemporary bedside table for your bedroom', CAST(2249.75 AS Decimal(18, 2)), 18, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (108, N'Women''s Summer Dress', N'Light and breezy dress for summer occasions', CAST(874.75 AS Decimal(18, 2)), 140, N'Clothing', N'Women''s Summer Dress', N'Light and breezy dress for summer occasions', CAST(874.75 AS Decimal(18, 2)), 60, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (109, N'4K Gaming Console', N'Gaming console for a high-definition gaming experience', CAST(12499.75 AS Decimal(18, 2)), 90, N'Electronics', N'4K Gaming Console', N'Gaming console for a high-definition gaming experience', CAST(12499.75 AS Decimal(18, 2)), 10, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (110, N'Coloring Book Collection', N'Various coloring books for relaxation', CAST(224.75 AS Decimal(18, 2)), 140, N'Books and Stationery', N'Coloring Book Collection', N'Various coloring books for relaxation', CAST(224.75 AS Decimal(18, 2)), 60, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (111, N'Hiking Backpack', N'Durable backpack for outdoor adventures', CAST(1999.75 AS Decimal(18, 2)), 100, N'Sports and Outdoors', N'Hiking Backpack', N'Durable backpack for outdoor adventures', CAST(1999.75 AS Decimal(18, 2)), 20, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (112, N'Chess and Checkers Set', N'Classic board games for strategic minds', CAST(499.75 AS Decimal(18, 2)), 115, N'Toys and Games', N'Chess and Checkers Set', N'Classic board games for strategic minds', CAST(499.75 AS Decimal(18, 2)), 35, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (113, N'Luxury Skincare Set', N'Premium skincare products for a spa-like experience', CAST(3249.75 AS Decimal(18, 2)), 95, N'Beauty and Personal Care', N'Luxury Skincare Set', N'Premium skincare products for a spa-like experience', CAST(3249.75 AS Decimal(18, 2)), 15, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (114, N'Organic Food Basket', N'Selection of organic and healthy food items', CAST(1749.75 AS Decimal(18, 2)), 200, N'Grocery', N'Organic Food Basket', N'Selection of organic and healthy food items', CAST(1749.75 AS Decimal(18, 2)), 120, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (115, N'Coffee Table with Storage', N'Functional coffee table with built-in storage', CAST(3749.75 AS Decimal(18, 2)), 105, N'Home and Furniture', N'Coffee Table with Storage', N'Functional coffee table with built-in storage', CAST(3749.75 AS Decimal(18, 2)), 25, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (116, N'Men''s Formal Shirt', N'Classic formal shirt for professional occasions', CAST(1249.75 AS Decimal(18, 2)), 160, N'Clothing', N'Men''s Formal Shirt', N'Classic formal shirt for professional occasions', CAST(1249.75 AS Decimal(18, 2)), 80, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (117, N'Ultra Thin Laptop', N'Slim and lightweight laptop for on-the-go use', CAST(22499.75 AS Decimal(18, 2)), 110, N'Electronics', N'Ultra Thin Laptop', N'Slim and lightweight laptop for on-the-go use', CAST(22499.75 AS Decimal(18, 2)), 30, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (118, N'Bestseller Book Collection', N'Popular books from various genres', CAST(150.99 AS Decimal(18, 2)), 130, N'Books and Stationery', N'Bestseller Book Collection', N'Popular books from various genres', CAST(150.99 AS Decimal(18, 2)), 50, N'Books and Stationery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (119, N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(1490.99 AS Decimal(18, 2)), 100, N'Sports and Outdoors', N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(1490.99 AS Decimal(18, 2)), 20, N'Sports and Outdoors', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (120, N'Board Game Set', N'Family-friendly board games for all ages', CAST(240.99 AS Decimal(18, 2)), 120, N'Toys and Games', N'Board Game Set', N'Family-friendly board games for all ages', CAST(240.99 AS Decimal(18, 2)), 40, N'Toys and Games', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (121, N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(790.99 AS Decimal(18, 2)), 110, N'Beauty and Personal Care', N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(790.99 AS Decimal(18, 2)), 30, N'Beauty and Personal Care', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (122, N'Fresh Produce Bundle', N'Assorted fruits and vegetables', CAST(290.99 AS Decimal(18, 2)), 280, N'Grocery', N'Fresh Produce Bundle', N'Assorted fruits and vegetables', CAST(290.99 AS Decimal(18, 2)), 200, N'Grocery', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (123, N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(4990.99 AS Decimal(18, 2)), 90, N'Home and Furniture', N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(4990.99 AS Decimal(18, 2)), 10, N'Home and Furniture', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (124, N'Men''s Casual Shirt', N'Comfortable and stylish shirt for men', CAST(390.99 AS Decimal(18, 2)), 180, N'Clothing', N'Men''s Casual Shirt', N'Comfortable and stylish shirt for men', CAST(390.99 AS Decimal(18, 2)), 100, N'Clothing', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (125, N'Smartphone X', N'High-end smartphone with advanced features', CAST(7990.99 AS Decimal(18, 2)), 130, N'Electronics', N'Smartphone X', N'High-end smartphone with advanced features', CAST(7990.99 AS Decimal(18, 2)), 50, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (126, N'Lenovo Laptop', N'Lenovo V14 G3', CAST(100000.00 AS Decimal(18, 2)), 123, N'Electronics', N'Lenovo Laptop', N'Lenovo V14 G3', CAST(100000.00 AS Decimal(18, 2)), 43, N'Electronics', CAST(N'2023-11-29T20:28:55.360' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (127, N'Men''s Casual Shirt', N'Comfortable and stylish shirt for men', CAST(390.99 AS Decimal(18, 2)), 178, N'Clothing', N'Men''s Casual Shirt', N'Comfortable and stylish shirt for men', CAST(390.99 AS Decimal(18, 2)), 180, N'Clothing', CAST(N'2023-11-29T20:56:23.563' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (128, N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(4990.99 AS Decimal(18, 2)), 89, N'Home and Furniture', N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(4990.99 AS Decimal(18, 2)), 90, N'Home and Furniture', CAST(N'2023-11-29T20:56:39.470' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (129, N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(790.99 AS Decimal(18, 2)), 107, N'Beauty and Personal Care', N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(790.99 AS Decimal(18, 2)), 110, N'Beauty and Personal Care', CAST(N'2023-11-29T20:56:53.640' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (130, N'Bestseller Book Collection', N'Popular books from various genres', CAST(150.99 AS Decimal(18, 2)), 128, N'Books and Stationery', N'Bestseller Book Collection', N'Popular books from various genres', CAST(150.99 AS Decimal(18, 2)), 130, N'Books and Stationery', CAST(N'2023-11-29T20:57:08.090' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (131, N'Board Game Set', N'Family-friendly board games for all ages', CAST(240.99 AS Decimal(18, 2)), 118, N'Toys and Games', N'Board Game Set', N'Family-friendly board games for all ages', CAST(240.99 AS Decimal(18, 2)), 120, N'Toys and Games', CAST(N'2023-11-29T20:57:23.477' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (132, N'Gourmet Chocolate Box', N'Indulge in a selection of premium chocolates', CAST(249.75 AS Decimal(18, 2)), 138, N'Grocery', N'Gourmet Chocolate Box', N'Indulge in a selection of premium chocolates', CAST(249.75 AS Decimal(18, 2)), 140, N'Grocery', CAST(N'2023-11-29T20:57:53.543' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (133, N'Snack Variety Pack', N'Assortment of tasty snacks for any craving', CAST(749.75 AS Decimal(18, 2)), 167, N'Grocery', N'Snack Variety Pack', N'Assortment of tasty snacks for any craving', CAST(749.75 AS Decimal(18, 2)), 170, N'Grocery', CAST(N'2023-11-29T20:58:07.700' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (134, N'International Snack Box', N'Explore snacks from around the world', CAST(1124.75 AS Decimal(18, 2)), 148, N'Grocery', N'International Snack Box', N'Explore snacks from around the world', CAST(1124.75 AS Decimal(18, 2)), 150, N'Grocery', CAST(N'2023-11-29T20:58:18.367' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (135, N'Lenovo Laptop', N'Lenovo V14 G3', CAST(25000.00 AS Decimal(18, 2)), 123, N'Electronics', N'Lenovo Laptop', N'Lenovo V14 G3', CAST(100000.00 AS Decimal(18, 2)), 123, N'Electronics', CAST(N'2023-11-29T21:47:24.490' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (136, N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(14999.99 AS Decimal(18, 2)), 89, N'Home and Furniture', N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(4990.99 AS Decimal(18, 2)), 89, N'Home and Furniture', CAST(N'2023-11-29T21:50:41.260' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (137, N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(1999.00 AS Decimal(18, 2)), 107, N'Beauty and Personal Care', N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(790.99 AS Decimal(18, 2)), 107, N'Beauty and Personal Care', CAST(N'2023-11-29T21:51:18.203' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (138, N'Board Game Set', N'Family-friendly board games for all ages', CAST(540.99 AS Decimal(18, 2)), 118, N'Toys and Games', N'Board Game Set', N'Family-friendly board games for all ages', CAST(240.99 AS Decimal(18, 2)), 118, N'Toys and Games', CAST(N'2023-11-29T21:51:33.457' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (139, N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(5490.99 AS Decimal(18, 2)), 100, N'Sports and Outdoors', N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(1490.99 AS Decimal(18, 2)), 100, N'Sports and Outdoors', CAST(N'2023-11-29T21:51:52.967' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (140, N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(5490.99 AS Decimal(18, 2)), 100, N'Sports and Outdoors', N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(5490.99 AS Decimal(18, 2)), 100, N'Sports and Outdoors', CAST(N'2023-11-29T21:52:00.137' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (141, N'Bestseller Book Collection', N'Popular books from various genres', CAST(449.99 AS Decimal(18, 2)), 128, N'Books and Stationery', N'Bestseller Book Collection', N'Popular books from various genres', CAST(150.99 AS Decimal(18, 2)), 128, N'Books and Stationery', CAST(N'2023-11-29T21:52:18.980' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (142, N'Science Experiment Kit', N'Educational kit for young scientists', CAST(990.99 AS Decimal(18, 2)), 110, N'Toys and Games', N'Science Experiment Kit', N'Educational kit for young scientists', CAST(624.75 AS Decimal(18, 2)), 110, N'Toys and Games', CAST(N'2023-11-29T21:52:49.090' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (143, N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(14999.99 AS Decimal(18, 2)), 88, N'Home and Furniture', N'Living Room Sofa', N'Modern and comfortable sofa for your living room', CAST(14999.99 AS Decimal(18, 2)), 89, N'Home and Furniture', CAST(N'2023-11-29T21:53:27.687' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (144, N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(1999.00 AS Decimal(18, 2)), 106, N'Beauty and Personal Care', N'Skin Care Kit', N'Complete skincare routine for radiant skin', CAST(1999.00 AS Decimal(18, 2)), 107, N'Beauty and Personal Care', CAST(N'2023-11-29T21:53:45.047' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (145, N'Board Game Set', N'Family-friendly board games for all ages', CAST(540.99 AS Decimal(18, 2)), 116, N'Toys and Games', N'Board Game Set', N'Family-friendly board games for all ages', CAST(540.99 AS Decimal(18, 2)), 118, N'Toys and Games', CAST(N'2023-11-29T21:53:51.887' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (146, N'Science Experiment Kit', N'Educational kit for young scientists', CAST(990.99 AS Decimal(18, 2)), 108, N'Toys and Games', N'Science Experiment Kit', N'Educational kit for young scientists', CAST(990.99 AS Decimal(18, 2)), 110, N'Toys and Games', CAST(N'2023-11-29T21:53:58.830' AS DateTime), N'Update')
INSERT [dbo].[ProductAudit] ([ID], [Name], [Description], [Price], [Quantity], [Category], [OldName], [OldDescription], [OldPrice], [OldQuantity], [OldCategory], [AuditDateTime], [Action]) VALUES (147, N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(5490.99 AS Decimal(18, 2)), 98, N'Sports and Outdoors', N'Outdoor Sports Equipment', N'Gear for various outdoor sports activities', CAST(5490.99 AS Decimal(18, 2)), 100, N'Sports and Outdoors', CAST(N'2023-11-29T21:54:08.370' AS DateTime), N'Update')
SET IDENTITY_INSERT [dbo].[ProductAudit] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON 

INSERT [dbo].[Transaction] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [CreatedAt], [UpdatedAt], [LoyaltyPrice]) VALUES (27, NULL, 26, NULL, CAST(1500.00 AS Decimal(18, 2)), CAST(N'2023-11-24T07:28:06.707' AS DateTime), CAST(N'2023-11-24T07:28:06.707' AS DateTime), NULL)
INSERT [dbo].[Transaction] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [CreatedAt], [UpdatedAt], [LoyaltyPrice]) VALUES (1003, NULL, 1003, NULL, CAST(25000.00 AS Decimal(18, 2)), CAST(N'2023-11-26T23:48:04.500' AS DateTime), CAST(N'2023-11-26T23:48:04.500' AS DateTime), NULL)
INSERT [dbo].[Transaction] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [CreatedAt], [UpdatedAt], [LoyaltyPrice]) VALUES (1004, NULL, 1004, NULL, CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-27T00:16:40.530' AS DateTime), CAST(N'2023-11-27T00:16:40.530' AS DateTime), NULL)
INSERT [dbo].[Transaction] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [CreatedAt], [UpdatedAt], [LoyaltyPrice]) VALUES (1007, 1007, 1007, NULL, CAST(1500.00 AS Decimal(18, 2)), CAST(N'2023-11-28T01:08:45.790' AS DateTime), CAST(N'2023-11-28T01:08:45.790' AS DateTime), NULL)
INSERT [dbo].[Transaction] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [CreatedAt], [UpdatedAt], [LoyaltyPrice]) VALUES (1008, 1007, 1008, 1034, CAST(17955.00 AS Decimal(18, 2)), CAST(N'2023-11-29T20:06:04.283' AS DateTime), CAST(N'2023-11-29T20:06:04.283' AS DateTime), 7045)
INSERT [dbo].[Transaction] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [CreatedAt], [UpdatedAt], [LoyaltyPrice]) VALUES (1009, 1008, 1009, NULL, CAST(13928.15 AS Decimal(18, 2)), CAST(N'2023-11-29T20:58:35.613' AS DateTime), CAST(N'2023-11-29T20:58:35.613' AS DateTime), NULL)
INSERT [dbo].[Transaction] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [CreatedAt], [UpdatedAt], [LoyaltyPrice]) VALUES (1010, NULL, 1010, NULL, CAST(31044.93 AS Decimal(18, 2)), CAST(N'2023-11-29T21:54:12.230' AS DateTime), CAST(N'2023-11-29T21:54:12.230' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Transaction] OFF
GO
SET IDENTITY_INSERT [dbo].[TransactionAudit] ON 

INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (1, NULL, NULL, NULL, NULL, 6, 25, 33, CAST(859000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (2, NULL, NULL, NULL, NULL, 6, 24, 34, CAST(388000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (3, NULL, NULL, NULL, NULL, NULL, 23, NULL, CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (4, NULL, NULL, NULL, NULL, NULL, 22, NULL, CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (5, NULL, NULL, NULL, NULL, NULL, 21, NULL, CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (6, NULL, NULL, NULL, NULL, NULL, 20, NULL, CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (7, NULL, NULL, NULL, NULL, NULL, 19, NULL, CAST(3000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (8, NULL, NULL, NULL, NULL, NULL, 18, NULL, CAST(1204500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (9, NULL, NULL, NULL, NULL, NULL, 17, NULL, CAST(300000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (10, NULL, NULL, NULL, NULL, NULL, 16, NULL, CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (11, NULL, NULL, NULL, NULL, NULL, 15, NULL, CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (12, NULL, NULL, NULL, NULL, NULL, 14, NULL, CAST(1500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (13, NULL, NULL, NULL, NULL, NULL, 13, NULL, CAST(1500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (14, NULL, NULL, NULL, NULL, NULL, 12, NULL, CAST(200000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (15, NULL, NULL, NULL, NULL, 6, 11, 30, CAST(97900.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (16, NULL, NULL, NULL, NULL, NULL, 10, 32, CAST(95500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (17, NULL, NULL, NULL, NULL, NULL, 9, NULL, CAST(300000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (18, NULL, NULL, NULL, NULL, NULL, 3, NULL, CAST(1000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:39:31.980' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (19, NULL, NULL, NULL, NULL, 6, 1005, 1032, CAST(93000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:41:19.810' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (20, NULL, NULL, NULL, NULL, 6, 1006, 1033, CAST(94500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:41:24.187' AS DateTime), N'Delete')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (21, NULL, 1003, NULL, CAST(25000.00 AS Decimal(18, 2)), NULL, 1003, NULL, CAST(100000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:45:57.587' AS DateTime), N'Update')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (22, 1007, 1008, 1034, CAST(30000.00 AS Decimal(18, 2)), 1007, 1008, 1034, CAST(130955.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:46:20.923' AS DateTime), N'Update')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (23, 1007, 1007, NULL, CAST(1500.00 AS Decimal(18, 2)), 1007, 1007, NULL, CAST(201500.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:46:34.450' AS DateTime), N'Update')
INSERT [dbo].[TransactionAudit] ([ID], [CustomerID], [OrderID], [GiftCardID], [Amount], [OldCustomerID], [OldOrderID], [OldGiftCardID], [OldAmount], [AuditDateTime], [Action]) VALUES (24, 1007, 1008, 1034, CAST(17955.00 AS Decimal(18, 2)), 1007, 1008, 1034, CAST(30000.00 AS Decimal(18, 2)), CAST(N'2023-11-29T21:49:08.410' AS DateTime), N'Update')
SET IDENTITY_INSERT [dbo].[TransactionAudit] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Name], [Username], [Password], [IsActive], [Role], [CreatedAt], [UpdatedAt]) VALUES (1005, N'NewTestUser', N'cashier', N'1234', 1, N'Cashier', CAST(N'2023-11-27T00:27:59.533' AS DateTime), CAST(N'2023-11-27T23:13:36.893' AS DateTime))
INSERT [dbo].[User] ([ID], [Name], [Username], [Password], [IsActive], [Role], [CreatedAt], [UpdatedAt]) VALUES (1007, N'TestUser2', N'testuser', N'1234', 1, N'Cashier', CAST(N'2023-11-28T23:15:54.377' AS DateTime), CAST(N'2023-11-28T23:15:54.377' AS DateTime))
INSERT [dbo].[User] ([ID], [Name], [Username], [Password], [IsActive], [Role], [CreatedAt], [UpdatedAt]) VALUES (1008, N'Test Admin', N'adminuser', N'12345678', 1, N'Admin', CAST(N'2023-11-30T19:32:40.760' AS DateTime), CAST(N'2023-11-30T19:32:40.760' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAudit] ON 

INSERT [dbo].[UserAudit] ([ID], [Name], [Username], [Password], [IsActive], [Role], [OldName], [OldUsername], [OldPassword], [OldIsActive], [OldRole], [AuditDateTime], [Action]) VALUES (1, N'NewTestUser', N'cashier', N'1234', 1, N'Cashier', N'Test User 2', N'cashier', N'1234', 1, N'Cashier', CAST(N'2023-11-27T23:13:36.893' AS DateTime), N'Update')
INSERT [dbo].[UserAudit] ([ID], [Name], [Username], [Password], [IsActive], [Role], [OldName], [OldUsername], [OldPassword], [OldIsActive], [OldRole], [AuditDateTime], [Action]) VALUES (2, NULL, NULL, NULL, NULL, NULL, N'', N'Enter the Username', N'Enter the Password', 1, N'Admin', CAST(N'2023-11-28T22:59:28.153' AS DateTime), N'Delete')
INSERT [dbo].[UserAudit] ([ID], [Name], [Username], [Password], [IsActive], [Role], [OldName], [OldUsername], [OldPassword], [OldIsActive], [OldRole], [AuditDateTime], [Action]) VALUES (3, NULL, NULL, NULL, NULL, NULL, N'Umer Ghaus', N'Umer', N'1234', 1, N'Admin', CAST(N'2023-11-30T19:32:48.133' AS DateTime), N'Delete')
SET IDENTITY_INSERT [dbo].[UserAudit] OFF
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Customer]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_GiftCard] FOREIGN KEY([GiftCardID])
REFERENCES [dbo].[GiftCard] ([ID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_GiftCard]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Order]
GO
/****** Object:  StoredProcedure [dbo].[GetTodaySales]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTodaySales]
AS
BEGIN
    SELECT    
    Sum(CAST(SUBSTRING(VALUE, CHARINDEX('-', VALUE, CHARINDEX('-', VALUE) + 1) + 1, LEN(VALUE)) AS INT)) TodaySales
FROM
    [Order] O
    CROSS APPLY STRING_SPLIT(O.ProductsList, ';') S
    JOIN Product P ON TRIM(SUBSTRING(VALUE, 1, CHARINDEX('-', VALUE) - 1)) = P.Name
WHERE CAST(O.CreatedAt AS DATE) = CAST(GETDATE() AS DATE);
END;
GO
/****** Object:  StoredProcedure [dbo].[ReadCategoryData]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReadCategoryData]
AS
BEGIN
    WITH CategorySales AS (
    SELECT  
        C.Name AS CategoryName,
        SUM(CAST(SUBSTRING(VALUE, CHARINDEX('-', VALUE) + 1, CHARINDEX('-', VALUE, CHARINDEX('-', VALUE) + 1) - CHARINDEX('-', VALUE) - 1) AS DECIMAL(18, 2)) * 
            CAST(SUBSTRING(VALUE, CHARINDEX('-', VALUE, CHARINDEX('-', VALUE) + 1) + 1, LEN(VALUE)) AS INT)) AS TotalSales
    FROM
        [Order] O
        CROSS APPLY STRING_SPLIT(O.ProductsList, ';') S
        JOIN Product P ON TRIM(SUBSTRING(VALUE, 1, CHARINDEX('-', VALUE) - 1)) = P.Name
        JOIN Category C ON P.Category = C.Name
    GROUP BY
        C.Name
)

SELECT
    [CategoryName] AS Category,
    SUM(TotalSales) AS TotalSales,
    (SUM(TotalSales) / (SELECT SUM(TotalSales) FROM CategorySales)) * 100 AS SalesPercentage
FROM
    CategorySales
GROUP BY
    CategoryName;
END;
GO
/****** Object:  Trigger [dbo].[tr_Customer_Delete]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create an AFTER DELETE trigger for Customer
CREATE TRIGGER [dbo].[tr_Customer_Delete]
ON [dbo].[Customer]
AFTER DELETE
AS
BEGIN
    INSERT INTO CustomerAudit (Name, Email, LoyaltyPoints, OldName, OldEmail, OldLoyaltyPoints, AuditDateTime, [Action])
    SELECT
        NULL,
        NULL,
        NULL,
        Name,
        Email,
        LoyaltyPoints,
        GETDATE(),
        'Delete'
    FROM
        DELETED;
END;
GO
ALTER TABLE [dbo].[Customer] ENABLE TRIGGER [tr_Customer_Delete]
GO
/****** Object:  Trigger [dbo].[tr_Customer_Update]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create an AFTER UPDATE trigger for Customer
CREATE TRIGGER [dbo].[tr_Customer_Update]
ON [dbo].[Customer]
AFTER UPDATE
AS
BEGIN
    INSERT INTO CustomerAudit (Name, Email, LoyaltyPoints, OldName, OldEmail, OldLoyaltyPoints, AuditDateTime, [Action])
    SELECT
        COALESCE(INSERTED.Name, DELETED.Name),
        COALESCE(INSERTED.Email, DELETED.Email),
        COALESCE(INSERTED.LoyaltyPoints, DELETED.LoyaltyPoints),
        DELETED.Name AS OldName,
        DELETED.Email AS OldEmail,
        DELETED.LoyaltyPoints AS OldLoyaltyPoints,
        GETDATE(),
        'Update'
    FROM
        INSERTED
    LEFT JOIN
        DELETED ON INSERTED.ID = DELETED.ID;

	-- Update UpdatedAt column in table
    UPDATE [Customer]
    SET UpdatedAt = GETDATE()
    WHERE ID IN (SELECT ID FROM INSERTED);
END;
GO
ALTER TABLE [dbo].[Customer] ENABLE TRIGGER [tr_Customer_Update]
GO
/****** Object:  Trigger [dbo].[tr_GiftCard_Delete]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create an AFTER DELETE trigger for GiftCard
CREATE TRIGGER [dbo].[tr_GiftCard_Delete]
ON [dbo].[GiftCard]
AFTER DELETE
AS
BEGIN
    INSERT INTO GiftCardAudit (CardCode, Balance, IsActive, OldCardCode, OldBalance, OldIsActive, AuditDateTime, [Action])
    SELECT
        NULL,
        NULL,
        NULL,
        CardCode,
        Balance,
        IsActive,
        GETDATE(),
        'Delete'
    FROM
        DELETED;
END;
GO
ALTER TABLE [dbo].[GiftCard] ENABLE TRIGGER [tr_GiftCard_Delete]
GO
/****** Object:  Trigger [dbo].[tr_GiftCard_Update]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_GiftCard_Update]
ON [dbo].[GiftCard]
AFTER UPDATE
AS
BEGIN
    INSERT INTO GiftCardAudit (CardCode, Balance, IsActive, OldCardCode, OldBalance, OldIsActive, AuditDateTime, [Action])
    SELECT
        COALESCE(INSERTED.CardCode, DELETED.CardCode),
        COALESCE(INSERTED.Balance, DELETED.Balance),
        COALESCE(INSERTED.IsActive, DELETED.IsActive),
        DELETED.CardCode AS OldCardCode,
        DELETED.Balance AS OldBalance,
        DELETED.IsActive AS OldIsActive,
        GETDATE(),
        'Update'
    FROM
        INSERTED
    LEFT JOIN
        DELETED ON INSERTED.ID = DELETED.ID;

	UPDATE [GiftCard]
    SET UpdatedAt = GETDATE()
    WHERE ID IN (SELECT ID FROM INSERTED);
END;
GO
ALTER TABLE [dbo].[GiftCard] ENABLE TRIGGER [tr_GiftCard_Update]
GO
/****** Object:  Trigger [dbo].[tr_Order_Delete]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create an AFTER DELETE trigger for Order
CREATE TRIGGER [dbo].[tr_Order_Delete]
ON [dbo].[Order]
AFTER DELETE
AS
BEGIN
    INSERT INTO OrderAudit (ProductsList, TotalAmount, OldProductsList, OldTotalAmount, AuditDateTime, [Action])
    SELECT
        NULL,
        NULL,
        ProductsList,
        TotalAmount,
        GETDATE(),
        'Delete'
    FROM
        DELETED;
END;
GO
ALTER TABLE [dbo].[Order] ENABLE TRIGGER [tr_Order_Delete]
GO
/****** Object:  Trigger [dbo].[tr_Order_Update]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create an AFTER UPDATE trigger for Order
CREATE TRIGGER [dbo].[tr_Order_Update]
ON [dbo].[Order]
AFTER UPDATE
AS
BEGIN
    INSERT INTO OrderAudit (ProductsList, TotalAmount, OldProductsList, OldTotalAmount, AuditDateTime, [Action])
    SELECT
        COALESCE(INSERTED.ProductsList, DELETED.ProductsList),
        COALESCE(INSERTED.TotalAmount, DELETED.TotalAmount),
        DELETED.ProductsList AS OldProductsList,
        DELETED.TotalAmount AS OldTotalAmount,
        GETDATE(),
        'Update'
    FROM
        INSERTED
    LEFT JOIN
        DELETED ON INSERTED.ID = DELETED.ID;
END;
GO
ALTER TABLE [dbo].[Order] ENABLE TRIGGER [tr_Order_Update]
GO
/****** Object:  Trigger [dbo].[tr_Product_Delete]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_Product_Delete]
ON [dbo].[Product]
AFTER DELETE
AS
BEGIN
    INSERT INTO ProductAudit (Name, Description, Price, Quantity, Category, OldName, OldDescription, OldPrice, OldQuantity, OldCategory, AuditDateTime, [Action])
    SELECT        
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        Name,
        Description,
        Price,
        Quantity,
        Category,
        GETDATE(),
		'Delete'
    FROM
        DELETED;
END;
GO
ALTER TABLE [dbo].[Product] ENABLE TRIGGER [tr_Product_Delete]
GO
/****** Object:  Trigger [dbo].[tr_Product_Update]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_Product_Update]
ON [dbo].[Product]
AFTER UPDATE
AS
BEGIN
    INSERT INTO ProductAudit (Name, Description, Price, Quantity, Category, OldName, OldDescription, OldPrice, OldQuantity, OldCategory, AuditDateTime, [Action])
    SELECT
        COALESCE(INSERTED.Name, DELETED.Name),
        COALESCE(INSERTED.Description, DELETED.Description),
        COALESCE(INSERTED.Price, DELETED.Price),
        COALESCE(INSERTED.Quantity, DELETED.Quantity),
        COALESCE(INSERTED.Category, DELETED.Category),
        DELETED.Name AS OldName,
        DELETED.Description AS OldDescription,
        DELETED.Price AS OldPrice,
        DELETED.Quantity AS OldQuantity,
        DELETED.Category AS OldCategory,
        GETDATE(),
		'Update'
    FROM
        INSERTED
    LEFT JOIN
        DELETED ON INSERTED.ID = DELETED.ID;

	-- Update UpdatedAt column in table
    UPDATE [Product]
    SET UpdatedAt = GETDATE()
    WHERE ID IN (SELECT ID FROM INSERTED);
END;
GO
ALTER TABLE [dbo].[Product] ENABLE TRIGGER [tr_Product_Update]
GO
/****** Object:  Trigger [dbo].[tr_Transaction_Delete]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create an AFTER DELETE trigger for Transaction
CREATE TRIGGER [dbo].[tr_Transaction_Delete]
ON [dbo].[Transaction]
AFTER DELETE
AS
BEGIN
    INSERT INTO TransactionAudit (CustomerID, OrderID, GiftCardID, Amount, OldCustomerID, OldOrderID, OldGiftCardID, OldAmount, AuditDateTime, [Action])
    SELECT
        NULL,
        NULL,
        NULL,
        NULL,
        CustomerID,
        OrderID,
        GiftCardID,
        Amount,
        GETDATE(),
        'Delete'
    FROM
        DELETED;
END;
GO
ALTER TABLE [dbo].[Transaction] ENABLE TRIGGER [tr_Transaction_Delete]
GO
/****** Object:  Trigger [dbo].[tr_Transaction_Update]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_Transaction_Update]
ON [dbo].[Transaction]
AFTER UPDATE
AS
BEGIN
    INSERT INTO TransactionAudit (CustomerID, OrderID, GiftCardID, Amount, OldCustomerID, OldOrderID, OldGiftCardID, OldAmount, AuditDateTime, [Action])
    SELECT
        COALESCE(INSERTED.CustomerID, DELETED.CustomerID),
        COALESCE(INSERTED.OrderID, DELETED.OrderID),
        COALESCE(INSERTED.GiftCardID, DELETED.GiftCardID),
        COALESCE(INSERTED.Amount, DELETED.Amount),
        DELETED.CustomerID AS OldCustomerID,
        DELETED.OrderID AS OldOrderID,
        DELETED.GiftCardID AS OldGiftCardID,
        DELETED.Amount AS OldAmount,
        GETDATE(),
        'Update'
    FROM
        INSERTED
    LEFT JOIN
        DELETED ON INSERTED.ID = DELETED.ID;
END;
GO
ALTER TABLE [dbo].[Transaction] ENABLE TRIGGER [tr_Transaction_Update]
GO
/****** Object:  Trigger [dbo].[tr_User_Delete]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Create an AFTER DELETE trigger for User
CREATE TRIGGER [dbo].[tr_User_Delete]
ON [dbo].[User]
AFTER DELETE
AS
BEGIN
    INSERT INTO UserAudit (Name, Username, Password, IsActive, Role, OldName, OldUsername, OldPassword, OldIsActive, OldRole, AuditDateTime, [Action])
    SELECT
        NULL,
        NULL,
        NULL,
        NULL,
        NULL,
        Name,
        Username,
        Password,
        IsActive,
        Role,
        GETDATE(),
        'Delete'
    FROM
        DELETED;
END;
GO
ALTER TABLE [dbo].[User] ENABLE TRIGGER [tr_User_Delete]
GO
/****** Object:  Trigger [dbo].[tr_User_Update]    Script Date: 30/11/2023 7:36:41 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[tr_User_Update]
ON [dbo].[User]
AFTER UPDATE
AS
BEGIN
    INSERT INTO UserAudit (Name, Username, Password, IsActive, Role, OldName, OldUsername, OldPassword, OldIsActive, OldRole, AuditDateTime, [Action])
    SELECT
        COALESCE(INSERTED.Name, DELETED.Name),
        COALESCE(INSERTED.Username, DELETED.Username),
        COALESCE(INSERTED.Password, DELETED.Password),
        COALESCE(INSERTED.IsActive, DELETED.IsActive),
        COALESCE(INSERTED.Role, DELETED.Role),
        DELETED.Name AS OldName,
        DELETED.Username AS OldUsername,
        DELETED.Password AS OldPassword,
        DELETED.IsActive AS OldIsActive,
        DELETED.Role AS OldRole,
        GETDATE(),
        'Update'
    FROM
        INSERTED
    LEFT JOIN
        DELETED ON INSERTED.ID = DELETED.ID;

	-- Update UpdatedAt column in User table
    UPDATE [User]
    SET UpdatedAt = GETDATE()
    WHERE ID IN (SELECT ID FROM INSERTED);
END;
GO
ALTER TABLE [dbo].[User] ENABLE TRIGGER [tr_User_Update]
GO
USE [master]
GO
ALTER DATABASE [StoreMS] SET  READ_WRITE 
GO
