USE [master]
GO
/****** Object:  Database [projectDB]    Script Date: 24/05/2023 04:55:27 ******/
CREATE DATABASE [projectDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'projectDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\projectDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'projectDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\projectDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [projectDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [projectDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [projectDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [projectDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [projectDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [projectDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [projectDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [projectDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [projectDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [projectDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [projectDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [projectDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [projectDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [projectDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [projectDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [projectDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [projectDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [projectDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [projectDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [projectDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [projectDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [projectDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [projectDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [projectDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [projectDB] SET RECOVERY FULL 
GO
ALTER DATABASE [projectDB] SET  MULTI_USER 
GO
ALTER DATABASE [projectDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [projectDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [projectDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [projectDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [projectDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [projectDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'projectDB', N'ON'
GO
ALTER DATABASE [projectDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [projectDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [projectDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 24/05/2023 04:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[adminId] [int] IDENTITY(1,1) NOT NULL,
	[fName] [varchar](100) NOT NULL,
	[lName] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[phone] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[adminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 24/05/2023 04:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fName] [varchar](100) NOT NULL,
	[lName] [varchar](100) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[password] [varchar](30) NOT NULL,
	[phone] [varchar](15) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seat]    Script Date: 24/05/2023 04:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seat](
	[SeatNo] [int] NOT NULL,
	[TrainID] [int] NOT NULL,
	[SeatType] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TrainID] ASC,
	[SeatNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 24/05/2023 04:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[TrainID] [int] NULL,
	[SeatNo] [int] NULL,
	[TripID] [int] NULL,
	[Price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Train]    Script Date: 24/05/2023 04:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Train](
	[TrainID] [int] NOT NULL,
	[Model] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[TrainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 24/05/2023 04:55:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[TripID] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](100) NOT NULL,
	[Destination] [varchar](100) NOT NULL,
	[TripDate] [datetime] NOT NULL,
	[TrainID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TripID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([adminId], [fName], [lName], [email], [password], [phone]) VALUES (1, N'Alaa', N'Jordan', N'AlaaJordan@gmail.com', N'123', N'01149220558')
INSERT [dbo].[Admin] ([adminId], [fName], [lName], [email], [password], [phone]) VALUES (2, N'Ahmed', N'Ali', N'ahmadhero11811@gmail.com', N'111', N'01149200283')
INSERT [dbo].[Admin] ([adminId], [fName], [lName], [email], [password], [phone]) VALUES (3, N'Ahmed', N'Mohamed', N'ahmad@gmail.com', N'111', N'111')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (1, N'Alan', N'Samir', N'hakoun123@gmail.com', N'123', N'332123')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (2, N'asd', N'asd', N'asd', N'asd', N'asd')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (3, N'3', N'3', N'3', N'3', N'3')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (4, N'aLOHA', N'DDS', N'ASD', N'1231', N'011')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (5, N'lkad', N'asdlk', N'asdasd@mail.com', N'332', N'123')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (6, N'3', N'3', N'3', N'3', N'3')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (7, N'asd', N'323', N'fv', N'000', N'1')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (8, N'Ahmed', N'Mohamed', N'1231@gmia', N'3332', N'2221')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (9, N'Salah', N'Eddin', N'salah@gmail.com', N'00000', N'011')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (10, N') (', N'asd', N'asd', N'asda', N'd')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (11, N'asd', N'webebe', N'123', N'123', N'123')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (13, N'asd', N'sd', N'dsd', N'23231', N'1123')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (14, N'dsa', N'asd', N'dsa', N'asd', N'das')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (15, N'nn', N'nn', N'nn', N'nn', N'nn')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (16, N'tonny', N'sdfs', N'1112311', N'vvvcv', N'dd')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (17, N'????', N'????', N'ahmadhero11811@c.com', N'Saudi', N'01149220559')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (18, N'123', N'', N'', N'', N'')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (19, N'kkk', N'kkkk', N'oooo', N'oooo', N'oooo')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (20, N'Loka', N'Modric', N'Luka@gmail.com', N'011', N'111')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (21, N'bebo', N'bebo', N'bebo', N'bebo', N'bebo')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (22, N'salah', N'el bedan', N'salahelbedan@gmail.com', N'bedan', N'salahelbedan')
INSERT [dbo].[Customer] ([id], [fName], [lName], [email], [password], [phone]) VALUES (23, N'bebo', N'bebo', N'bebo', N'bebo', N'bebo')
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (2, N'dd')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (123, N'asdcasd')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (225, N'blobo2o 2 bo2o')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (2244, N'2222')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (3454, N'ddd')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (9999, N'Blobo2o')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (12343, N'dddd')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (2225415, N'asdasd')
GO
ALTER TABLE [dbo].[Ticket] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([TrainID], [SeatNo])
REFERENCES [dbo].[Seat] ([TrainID], [SeatNo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([TripID])
REFERENCES [dbo].[Trip] ([TripID])
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
ON DELETE CASCADE
GO
USE [master]
GO
ALTER DATABASE [projectDB] SET  READ_WRITE 
GO
