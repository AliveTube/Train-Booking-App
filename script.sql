USE [projectDB]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 5/23/2023 9:07:58 PM ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 5/23/2023 9:07:58 PM ******/
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
/****** Object:  Table [dbo].[Seat]    Script Date: 5/23/2023 9:07:58 PM ******/
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
	[SeatNo] ASC,
	[TrainID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 5/23/2023 9:07:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[TicketID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[TrainID] [int] NOT NULL,
	[SeatNo] [int] NOT NULL,
	[TripID] [int] NULL,
	[Price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Train]    Script Date: 5/23/2023 9:07:58 PM ******/
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
/****** Object:  Table [dbo].[Trip]    Script Date: 5/23/2023 9:07:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[TripID] [int] IDENTITY(1,1) NOT NULL,
	[Source] [varchar](100) NOT NULL,
	[Destination] [varchar](100) NOT NULL,
	[TripDate] [datetime] NOT NULL,
	[Train] [int] NOT NULL,
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
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (1, 2, N'2xc')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (1, 225, N'55d')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (1, 3454, N'ddd')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (1, 9999, N'55')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (2, 2, N'cdd')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (2, 225, N'66d')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (2, 3454, N'xxx')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (2, 9999, N'dd')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (3, 2, N'34')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (3, 225, N'663d')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (3, 3454, N'ccc')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (3, 9999, N'cc')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (4, 2, N'ddd')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (4, 225, N'88ds')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (4, 3454, N'vvv')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (5, 2, N'2233')
INSERT [dbo].[Seat] ([SeatNo], [TrainID], [SeatType]) VALUES (6, 2, N'5555')
GO
SET IDENTITY_INSERT [dbo].[Ticket] ON 

INSERT [dbo].[Ticket] ([TicketID], [CustomerID], [TrainID], [SeatNo], [TripID], [Price]) VALUES (5, 2, 9999, 1, 7, 25)
INSERT [dbo].[Ticket] ([TicketID], [CustomerID], [TrainID], [SeatNo], [TripID], [Price]) VALUES (6, 2, 9999, 2, 7, 25)
INSERT [dbo].[Ticket] ([TicketID], [CustomerID], [TrainID], [SeatNo], [TripID], [Price]) VALUES (7, 2, 9999, 3, 7, 25)
SET IDENTITY_INSERT [dbo].[Ticket] OFF
GO
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (2, N'dd')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (123, N'asdcasd')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (225, N'blobo2o 2 bo2o')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (2244, N'2222')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (3454, N'ddd')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (9999, N'Blobo2o')
INSERT [dbo].[Train] ([TrainID], [Model]) VALUES (12343, N'dddd')
GO
SET IDENTITY_INSERT [dbo].[Trip] ON 

INSERT [dbo].[Trip] ([TripID], [Source], [Destination], [TripDate], [Train]) VALUES (7, N'Aswan', N'Tanta', CAST(N'2023-05-25T21:30:00.000' AS DateTime), 9999)
SET IDENTITY_INSERT [dbo].[Trip] OFF
GO
ALTER TABLE [dbo].[Ticket] ADD  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD FOREIGN KEY([TrainID])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [alan] FOREIGN KEY([TripID])
REFERENCES [dbo].[Trip] ([TripID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [alan]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([id])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([TripID])
REFERENCES [dbo].[Trip] ([TripID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([TripID])
REFERENCES [dbo].[Trip] ([TripID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD FOREIGN KEY([TripID])
REFERENCES [dbo].[Trip] ([TripID])
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_TICKET_SEAT] FOREIGN KEY([SeatNo], [TrainID])
REFERENCES [dbo].[Seat] ([SeatNo], [TrainID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_TICKET_SEAT]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [alan_gamed_awy] FOREIGN KEY([Train])
REFERENCES [dbo].[Train] ([TrainID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [alan_gamed_awy]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD FOREIGN KEY([Train])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD FOREIGN KEY([Train])
REFERENCES [dbo].[Train] ([TrainID])
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD FOREIGN KEY([Train])
REFERENCES [dbo].[Train] ([TrainID])
GO
