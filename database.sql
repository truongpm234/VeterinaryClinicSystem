USE [VeterinaryClinicSystem]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 17-Jul-25 4:51:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[PetID] [int] NULL,
	[OwnerID] [int] NULL,
	[DoctorID] [int] NULL,
	[ServiceID] [int] NULL,
	[AppointmentDate] [datetime] NULL,
	[Status] [nvarchar](20) NULL,
	[Note] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
	[Shift] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Slug] [nvarchar](255) NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CoverImageUrl] [nvarchar](255) NULL,
	[AuthorID] [int] NULL,
	[Category] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
	[IsPublished] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CareSchedules]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CareSchedules](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[PetID] [int] NOT NULL,
	[CareType] [nvarchar](100) NOT NULL,
	[InitialDate] [date] NOT NULL,
	[NextDueDate] [date] NULL,
	[IsCompleted] [bit] NULL,
	[Note] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[DoctorID] [int] NOT NULL,
	[Specialty] [nvarchar](100) NULL,
	[Degree] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoctorSchedules]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoctorSchedules](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorID] [int] NULL,
	[WorkDate] [date] NULL,
	[Note] [nvarchar](255) NULL,
	[Shift] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentID] [int] NULL,
	[CustomerID] [int] NULL,
	[DoctorID] [int] NULL,
	[Rating] [int] NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryTransactions]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryTransactions](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[MedicationID] [int] NULL,
	[Quantity] [int] NULL,
	[Type] [nvarchar](10) NULL,
	[Note] [nvarchar](max) NULL,
	[TransactionDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalRecords]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRecords](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[PetID] [int] NULL,
	[DoctorID] [int] NULL,
	[AppointmentID] [int] NULL,
	[Diagnosis] [nvarchar](max) NULL,
	[FollowUpDate] [date] NULL,
	[CreatedAt] [datetime] NULL,
	[IsFollow] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medications]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medications](
	[MedicationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Unit] [nvarchar](50) NULL,
	[Price] [decimal](10, 2) NULL,
	[Stock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[NotificationID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[AppointmentID] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[SentAt] [datetime] NULL,
	[Type] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[NotificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pets]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pets](
	[PetID] [int] IDENTITY(1,1) NOT NULL,
	[OwnerID] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Species] [nvarchar](50) NULL,
	[Breed] [nvarchar](100) NULL,
	[Gender] [nvarchar](10) NULL,
	[BirthDate] [date] NULL,
	[Weight] [decimal](5, 2) NULL,
	[Note] [nvarchar](max) NULL,
	[CreatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[PetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrescriptionDetails]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrescriptionDetails](
	[PrescriptionID] [int] IDENTITY(1,1) NOT NULL,
	[RecordID] [int] NOT NULL,
	[MedicationID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Dosage] [nvarchar](100) NULL,
	[Instructions] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[PrescriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[ServiceID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](10, 2) NULL,
	[ServiceType] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 17-Jul-25 4:51:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[PasswordHash] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Address] [nvarchar](max) NULL,
	[AvatarUrl] [nvarchar](255) NULL,
	[RoleID] [int] NULL,
	[CreatedAt] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (1, 4, 10, 23, 2, CAST(N'2025-07-15T16:55:00.000' AS DateTime), N'Đang xử lí', NULL, CAST(N'2025-07-15T09:53:12.630' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (2, 3, 10, 23, 4, CAST(N'2025-07-09T16:54:00.000' AS DateTime), N'Đang xử lí', NULL, CAST(N'2025-07-15T09:54:33.430' AS DateTime), 1)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (3, 3, 10, 20, 4, CAST(N'2025-07-09T16:55:00.000' AS DateTime), N'Đang xử lí', NULL, CAST(N'2025-07-15T09:55:47.990' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (4, 3, 10, 21, 4, CAST(N'2025-07-14T00:00:00.000' AS DateTime), N'Đang xử lí', NULL, CAST(N'2025-07-15T10:10:49.603' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (5, 3, 10, 23, 4, CAST(N'2025-07-14T00:00:00.000' AS DateTime), N'Đang xử lí', NULL, CAST(N'2025-07-15T10:11:42.407' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (6, 3, 10, 23, 3, CAST(N'2025-07-14T00:00:00.000' AS DateTime), N'Đang xử lí', N'kkkk', CAST(N'2025-07-15T10:14:24.637' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (7, 5, 9, NULL, NULL, CAST(N'2025-07-22T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'jjjj', CAST(N'2025-07-15T14:14:27.570' AS DateTime), 1)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (8, 5, 9, 21, 4, CAST(N'2025-07-14T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'lllll', CAST(N'2025-07-15T14:30:20.010' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (9, 6, 10, 21, 4, CAST(N'2025-07-30T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'aaaa', CAST(N'2025-07-15T14:36:00.080' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (10, 6, 10, 21, 2, CAST(N'2025-07-14T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'qqq', CAST(N'2025-07-15T14:55:35.687' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (11, 4, 10, 23, 4, CAST(N'2025-07-17T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'qqq', CAST(N'2025-07-15T14:57:22.353' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (12, 4, 10, 22, 4, CAST(N'2025-07-31T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'bbbbb', CAST(N'2025-07-15T15:14:42.433' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (13, 4, 10, 22, 6, CAST(N'2025-07-15T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'uuuuu', CAST(N'2025-07-16T01:09:11.490' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (14, 6, 10, 23, 7, CAST(N'2025-07-21T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'bbbbbb', CAST(N'2025-07-16T02:23:16.063' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (15, 7, 26, NULL, NULL, CAST(N'2025-07-06T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'lllllll', CAST(N'2025-07-16T03:06:30.907' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (16, 7, 26, 20, 3, CAST(N'2025-07-17T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'yyyy', CAST(N'2025-07-16T03:10:24.680' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (17, 4, 10, 20, 4, CAST(N'2025-07-17T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'vvvv', CAST(N'2025-07-16T03:36:24.147' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (18, 6, 10, 21, 7, CAST(N'2025-07-18T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'bbbbb', CAST(N'2025-07-16T03:57:16.357' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (19, 6, 10, 22, 4, CAST(N'2025-07-18T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'nnnn', CAST(N'2025-07-16T04:00:28.703' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (20, 4, 10, 23, 4, CAST(N'2025-07-18T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'zzz', CAST(N'2025-07-16T04:02:36.093' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (21, 1, 10, 22, 2, CAST(N'2025-07-18T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'ssss', CAST(N'2025-07-16T04:09:10.567' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (22, 1, 10, 3, 1, CAST(N'2025-07-25T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'ii', CAST(N'2025-07-16T04:13:48.463' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (23, 7, 26, 21, 4, CAST(N'2025-07-18T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'oooo', CAST(N'2025-07-16T04:35:32.653' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (24, 6, 10, 21, 3, CAST(N'2025-07-18T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'yyyy', CAST(N'2025-07-16T04:38:15.433' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (25, 1, 10, 20, 2, CAST(N'2025-07-10T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'tttt', CAST(N'2025-07-16T04:40:03.553' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (26, 3, 10, 20, 4, CAST(N'2025-07-14T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'rrrrr', CAST(N'2025-07-16T04:49:51.127' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (27, 4, 10, 21, 3, CAST(N'2025-07-15T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'eeee', CAST(N'2025-07-16T04:54:33.387' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (28, 4, 10, 20, 1, CAST(N'2025-07-29T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'pppp', CAST(N'2025-07-16T04:59:29.677' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (29, 4, 10, 21, 4, CAST(N'2025-08-10T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'ooo', CAST(N'2025-07-16T05:02:52.683' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (30, 3, 10, 23, 4, CAST(N'2025-08-02T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'wwwww', CAST(N'2025-07-16T05:09:03.497' AS DateTime), 1)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (31, 4, 10, 20, 4, CAST(N'2025-08-06T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'rrrrr', CAST(N'2025-07-16T05:31:36.770' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (32, 6, 10, 21, 6, CAST(N'2025-07-31T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'qqqq', CAST(N'2025-07-16T05:40:08.760' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (33, 6, 10, 20, 4, CAST(N'2025-07-20T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'iiii', CAST(N'2025-07-16T05:43:34.090' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (34, 3, 10, 21, 3, CAST(N'2025-07-18T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'ttttt', CAST(N'2025-07-16T05:49:56.050' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (35, 6, 10, 20, 7, CAST(N'2025-07-18T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'fffff', CAST(N'2025-07-16T06:16:40.630' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (36, 6, 10, 22, 4, CAST(N'2025-07-31T00:00:00.000' AS DateTime), N'Đang xử lý', N'xxxxx', CAST(N'2025-07-16T06:28:35.940' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (37, 3, 10, 23, 3, CAST(N'2025-07-23T00:00:00.000' AS DateTime), N'Đang xử lý', N'yyyyt', CAST(N'2025-07-16T06:34:00.593' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (38, 1, 10, 20, 6, CAST(N'2025-07-31T00:00:00.000' AS DateTime), N'Đang xử lý', N'rrrrr', CAST(N'2025-07-16T07:04:32.970' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (39, 3, 10, 23, 3, CAST(N'2025-07-29T00:00:00.000' AS DateTime), N'Đang xử lý', N'hhhh', CAST(N'2025-07-16T07:05:13.710' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (40, 6, 10, 22, 6, CAST(N'2025-07-30T00:00:00.000' AS DateTime), N'Đang xử lý', N'mmmm', CAST(N'2025-07-16T07:38:53.103' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (41, 1, 10, 22, 4, CAST(N'2025-07-22T00:00:00.000' AS DateTime), N'Đang xử lý', N'cccc', CAST(N'2025-07-16T07:39:37.230' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (42, 4, 10, 22, 4, CAST(N'2025-08-01T00:00:00.000' AS DateTime), N'Đang xử lý', N'pppp', CAST(N'2025-07-16T07:53:59.217' AS DateTime), 1)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (43, 3, 10, 20, 6, CAST(N'2025-07-23T00:00:00.000' AS DateTime), N'Đang xử lý', N'ssssssss', CAST(N'2025-07-16T07:54:44.250' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (44, 3, 10, 21, 4, CAST(N'2025-08-01T00:00:00.000' AS DateTime), N'Đang xử lý', N'yyyyyy', CAST(N'2025-07-16T07:55:14.877' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (45, 1, 10, 23, 7, CAST(N'2025-07-31T00:00:00.000' AS DateTime), N'Đang xử lý', N'reeeee', CAST(N'2025-07-16T07:56:03.550' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (46, 4, 10, 23, 4, CAST(N'2025-07-26T00:00:00.000' AS DateTime), N'Đang xử lý', N'nnnnnnnn', CAST(N'2025-07-16T07:57:14.503' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (47, 8, 10, NULL, NULL, CAST(N'2025-07-19T00:00:00.000' AS DateTime), N'Đang xử lý', N'uuuuu', CAST(N'2025-07-16T08:00:31.380' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (48, 8, 10, 22, 7, CAST(N'2025-07-30T00:00:00.000' AS DateTime), N'Đang xử lý', N'ggggg', CAST(N'2025-07-16T08:01:20.110' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (49, 8, 10, 23, 6, CAST(N'2025-08-09T00:00:00.000' AS DateTime), N'Đang xử lý', N'cccccccccc', CAST(N'2025-07-16T08:02:26.717' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (50, 6, 10, 21, 1, CAST(N'2025-08-06T00:00:00.000' AS DateTime), N'Đang xử lý', N'lllllll', CAST(N'2025-07-16T08:03:04.090' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (51, 6, 10, 23, 4, CAST(N'2025-08-02T00:00:00.000' AS DateTime), N'Đang xử lý', N'mmmemememe', CAST(N'2025-07-16T08:13:59.440' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (52, 8, 10, 20, 3, CAST(N'2025-08-07T00:00:00.000' AS DateTime), N'Đang xử lý', N'yyyyy', CAST(N'2025-07-16T08:15:50.443' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (53, 6, 10, 22, 4, CAST(N'2025-08-09T00:00:00.000' AS DateTime), N'Đang xử lý', N'gggggggggggg', CAST(N'2025-07-16T08:17:01.013' AS DateTime), 5)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (54, 4, 10, 3, 6, CAST(N'2025-08-09T00:00:00.000' AS DateTime), N'Đang xử lý', N'eeee', CAST(N'2025-07-16T08:24:12.820' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (55, 6, 10, 3, 4, CAST(N'2025-07-23T00:00:00.000' AS DateTime), N'Đang xử lý', N'tttt', CAST(N'2025-07-16T08:28:05.547' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (56, 3, 10, 22, 2, CAST(N'2025-08-08T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'yyyyyyy', CAST(N'2025-07-16T08:43:20.990' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (57, 8, 10, 21, 1, CAST(N'2025-08-10T00:00:00.000' AS DateTime), N'Đang xử lý', N'rrrrrrr', CAST(N'2025-07-16T08:45:17.747' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (58, 8, 10, 19, 2, CAST(N'2025-07-15T00:00:00.000' AS DateTime), N'Đang xử lý', N'kkkkkkkk', CAST(N'2025-07-16T08:50:09.873' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (59, 3, 10, 20, 4, CAST(N'2025-07-01T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'yyyyyy', CAST(N'2025-07-16T09:00:33.433' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (60, 6, 10, 20, 4, CAST(N'2025-07-22T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'yyyyyy', CAST(N'2025-07-16T09:06:45.257' AS DateTime), 2)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (61, 4, 10, 19, 2, CAST(N'2025-07-22T00:00:00.000' AS DateTime), N'Đặt lịch thành công', N'kkllll', CAST(N'2025-07-16T09:44:23.903' AS DateTime), 3)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (62, 9, 27, 23, 3, CAST(N'2025-07-15T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'llllll', CAST(N'2025-07-16T13:09:52.160' AS DateTime), 4)
INSERT [dbo].[Appointments] ([AppointmentID], [PetID], [OwnerID], [DoctorID], [ServiceID], [AppointmentDate], [Status], [Note], [CreatedAt], [Shift]) VALUES (63, 10, 28, 20, 4, CAST(N'2025-07-15T00:00:00.000' AS DateTime), N'Từ chối hẹn', N'iiiii', CAST(N'2025-07-16T13:12:34.160' AS DateTime), 4)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogPosts] ON 

INSERT [dbo].[BlogPosts] ([PostID], [Title], [Slug], [Content], [CoverImageUrl], [AuthorID], [Category], [CreatedAt], [UpdatedAt], [IsPublished]) VALUES (1, N'5 dấu hiệu nhận biết thú cưng cần đi khám ngay', N'5-dau-hieu-thu-cung-can-kham', N'Nhiều người nuôi thú cưng thường bỏ qua các dấu hiệu nhỏ cho thấy vật nuôi có thể đang gặp vấn đề về sức khỏe. 
Dưới đây là 5 dấu hiệu quan trọng:

1. Thay đổi hành vi: Nếu thú cưng của bạn trở nên hung dữ, lờ đờ, hoặc ẩn mình nhiều hơn bình thường, có thể chúng đang bị đau hoặc căng thẳng.
2. Ăn uống bất thường: Việc ăn quá ít hoặc quá nhiều, hoặc đột ngột thay đổi thói quen ăn uống có thể là dấu hiệu của bệnh tiêu hóa hoặc vấn đề răng miệng.
3. Ho, hắt hơi kéo dài: Những triệu chứng này không đơn giản như cảm lạnh, nó có thể là dấu hiệu của các bệnh nghiêm trọng như viêm phổi hoặc bệnh truyền nhiễm.
4. Nôn mửa hoặc tiêu chảy: Nếu diễn ra nhiều lần trong ngày hoặc kéo dài hơn 24 giờ, bạn cần đưa thú cưng đi khám ngay.
5. Xuất hiện khối u dưới da: Những cục u bất thường có thể là dấu hiệu của u lành tính hoặc ung thư.

Hãy theo dõi kỹ và đưa thú cưng đi khám nếu có bất kỳ biểu hiện nào kể trên.', N'/uploads/background_avatar.png', 1, N'Sức khỏe', CAST(N'2025-06-29T19:24:45.907' AS DateTime), CAST(N'2025-07-01T13:28:17.070' AS DateTime), 1)
INSERT [dbo].[BlogPosts] ([PostID], [Title], [Slug], [Content], [CoverImageUrl], [AuthorID], [Category], [CreatedAt], [UpdatedAt], [IsPublished]) VALUES (2, N'Hướng dẫn chăm sóc lông mèo đúng cách', N'cham-soc-long-cho-meo', N'Lông là lớp bảo vệ tự nhiên của chó mèo, nhưng nếu không được chăm sóc đúng cách, thú cưng có thể gặp các vấn đề như rối lông, viêm da, bọ chét...

**Các bước chăm sóc lông cơ bản:**

- **Chải lông hàng ngày:** Giúp loại bỏ lông rụng, ngăn ngừa rối lông và kích thích tuần hoàn máu.
- **Tắm định kỳ:** Sử dụng sữa tắm chuyên dụng cho chó/mèo, không dùng sữa tắm người.
- **Cắt tỉa lông vùng nhạy cảm:** Như quanh mắt, tai, hậu môn để đảm bảo sạch sẽ.
- **Kiểm tra ký sinh trùng:** Kiểm tra ve, bọ chét thường xuyên, đặc biệt với thú cưng hay ra ngoài.

Chăm sóc lông đúng cách không chỉ giúp thú cưng đẹp hơn mà còn phòng tránh nhiều bệnh lý da liễu.', N'/uploads/background_avatar.png', 1, N'Spa & Grooming', CAST(N'2025-06-29T19:24:45.907' AS DateTime), CAST(N'2025-07-01T13:28:22.733' AS DateTime), 1)
INSERT [dbo].[BlogPosts] ([PostID], [Title], [Slug], [Content], [CoverImageUrl], [AuthorID], [Category], [CreatedAt], [UpdatedAt], [IsPublished]) VALUES (3, N'Lợi ích của việc tiêm phòng định kỳ cho thú cưng', N'tiem-phong-thu-cung', N'Việc tiêm phòng cho thú cưng là một phần quan trọng trong việc chăm sóc y tế chủ động. Các bệnh nguy hiểm như Care, Parvo, dại... có thể gây tử vong nếu không phòng ngừa kịp thời.

**Lợi ích tiêm phòng:**

- Bảo vệ thú cưng khỏi các bệnh truyền nhiễm nguy hiểm.
- Giảm nguy cơ lây nhiễm sang con người và các vật nuôi khác.
- Tiết kiệm chi phí điều trị do phòng bệnh hiệu quả hơn chữa bệnh.
- Góp phần đảm bảo sức khỏe cộng đồng và kiểm soát dịch bệnh thú y.

**Lịch tiêm phòng cơ bản:**

- Mèo con và chó con nên tiêm lần đầu khi 6–8 tuần tuổi.
- Sau đó, tiêm nhắc lại 1–2 mũi cách nhau 2–4 tuần.
- Mỗi năm tiêm nhắc định kỳ để duy trì hiệu quả bảo vệ.

Hãy liên hệ với bác sĩ thú y gần nhất để được tư vấn cụ thể theo độ tuổi và tình trạng sức khỏe của thú cưng bạn.', N'/uploads/background_avatar.png', 1, N'Tiêm phòng', CAST(N'2025-06-29T19:24:45.907' AS DateTime), CAST(N'2025-07-01T13:28:26.230' AS DateTime), 1)
INSERT [dbo].[BlogPosts] ([PostID], [Title], [Slug], [Content], [CoverImageUrl], [AuthorID], [Category], [CreatedAt], [UpdatedAt], [IsPublished]) VALUES (4, N'Lợi ích của việc tắm cho mèo hàng tháng', NULL, N'Việc tắm cho mèo hàng tháng mang lại nhiều lợi ích như loại bỏ bụi bẩn, bọ chét, và ký sinh trùng trên da và lông, giúp duy trì bộ lông khỏe mạnh, mềm mại và giảm nguy cơ mắc các bệnh về da như nấm, viêm da. Tắm rửa cũng giúp mèo cảm thấy thoải mái, thư giãn, và tăng cường mối liên kết giữa bạn và thú cưng. 
Chi tiết các lợi ích:
Loại bỏ bụi bẩn, bọ chét và ký sinh trùng:
Mèo thường xuyên tiếp xúc với môi trường bên ngoài, nên việc tắm rửa giúp loại bỏ bụi bẩn, mảng bám, bọ chét, và ký sinh trùng có thể gây hại cho sức khỏe của mèo và cả gia đình. 
Duy trì bộ lông khỏe mạnh và mềm mại:
Tắm giúp loại bỏ lông chết, giảm tình trạng rụng lông, đặc biệt là ở mèo lông dài, và giúp bộ lông luôn bóng mượt, mềm mại. 
Ngăn ngừa các bệnh về da:
Việc loại bỏ bụi bẩn, bã nhờn và ký sinh trùng giúp giảm nguy cơ mắc các bệnh về da như nấm, viêm da, lở loét. 
Giúp mèo cảm thấy thoải mái và thư giãn:
Tắm rửa giúp mèo loại bỏ cảm giác khó chịu, đặc biệt là trong thời tiết nóng bức, và tạo cảm giác sảng khoái, thư thái. 
Tăng cường mối liên kết giữa mèo và chủ:
Thời gian tắm có thể là một cơ hội tốt để bạn và mèo dành thời gian bên nhau, tăng cường sự gắn kết và hiểu biết lẫn nhau. 
Ngăn ngừa mùi hôi:
Tắm rửa giúp loại bỏ mùi hôi trên cơ thể mèo, giúp không gian sống của bạn và mèo luôn sạch sẽ và thơm tho. 
Lưu ý:
Nên chọn loại sữa tắm dành riêng cho mèo, có độ pH phù hợp để tránh gây kích ứng da. 
Tắm cho mèo với nước ấm, tránh dùng nước quá nóng hoặc quá lạnh. 
Lau khô lông mèo hoàn toàn sau khi tắm để tránh bị cảm lạnh. 
Nếu mèo không quen với việc tắm, bạn có thể bắt đầu bằng việc làm quen với nước, sau đó tăng dần tần suất tắm. ', N'/uploads/blog/e375e85a-18a4-46ea-985b-0567f8a4a447_tam_meo.jpg', NULL, N'Chăm sóc', CAST(N'2025-07-01T14:45:04.730' AS DateTime), CAST(N'2025-07-01T14:45:04.730' AS DateTime), 1)
INSERT [dbo].[BlogPosts] ([PostID], [Title], [Slug], [Content], [CoverImageUrl], [AuthorID], [Category], [CreatedAt], [UpdatedAt], [IsPublished]) VALUES (6, N'Tại sao nên tẩy giun định kì cho thú cưng?', N'tại-sao-nên-tẩy-giun-định-kì-cho-thú-cưng?', N'Việc xổ giun định kỳ cho thú cưng là rất quan trọng để bảo vệ sức khỏe của chúng và cả sức khỏe của gia đình. Giun sán có thể gây ra nhiều vấn đề sức khỏe nghiêm trọng cho thú cưng, và một số loại còn có thể lây sang người. Việc xổ giun định kỳ giúp loại bỏ giun sán, ngăn ngừa bệnh tật và đảm bảo thú cưng luôn khỏe mạnh.
Lý do cần xổ giun định kỳ cho thú cưng:
Bảo vệ sức khỏe thú cưng:
Giun sán có thể gây ra nhiều vấn đề sức khỏe cho thú cưng, bao gồm tiêu chảy, nôn mửa, suy nhược, thiếu máu, và thậm chí có thể dẫn đến tử vong nếu không được điều trị. 
Ngăn ngừa lây nhiễm cho người:
Một số loại giun sán ở thú cưng có thể lây sang người, đặc biệt là trẻ em, thông qua tiếp xúc với phân hoặc môi trường bị nhiễm bẩn. 
Giúp thú cưng phát triển tốt:
Khi không bị giun sán, thú cưng sẽ ăn ngon miệng hơn, hấp thụ dinh dưỡng tốt hơn, và phát triển khỏe mạnh hơn. 
Phát hiện sớm các vấn đề sức khỏe:
Việc tẩy giun định kỳ giúp bạn dễ dàng theo dõi sức khỏe của thú cưng và phát hiện sớm các vấn đề sức khỏe khác, như các bệnh về đường tiêu hóa. 
Thời điểm xổ giun định kỳ:
Chó con: Nên tẩy giun lần đầu tiên khi chó được 2-3 tuần tuổi và sau đó tẩy định kỳ mỗi tháng một lần cho đến khi được 6 tháng tuổi. 
Chó trưởng thành: Tẩy giun định kỳ 3-6 tháng một lần. 
Mèo con: Nên tẩy giun lần đầu tiên khi mèo được 3 tuần tuổi và sau đó tẩy định kỳ 2 tuần một lần cho đến khi được 3 tháng tuổi. 
Mèo trưởng thành: Tẩy giun định kỳ 2-3 tháng một lần. 
Việc xổ giun định kỳ là một phần quan trọng trong việc chăm sóc thú cưng. Hãy tham khảo ý kiến của bác sĩ thú y để có lịch trình tẩy giun phù hợp với loại thú cưng của bạn và đảm bảo chúng luôn khỏe mạnh. ', N'/uploads/blog/5b1fbc2f-0d11-418a-8b6a-da04201aa777_tay_giun.jpg', NULL, N'Sức khỏe', CAST(N'2025-07-01T16:13:48.740' AS DateTime), CAST(N'2025-07-01T16:13:48.740' AS DateTime), 1)
INSERT [dbo].[BlogPosts] ([PostID], [Title], [Slug], [Content], [CoverImageUrl], [AuthorID], [Category], [CreatedAt], [UpdatedAt], [IsPublished]) VALUES (8, N'Tại sao nên triệt sản thú cưng?', N'tại-sao-nên-triệt-sản-thú-cưng?', N'Việc triệt sản cho thú cưng mang lại nhiều lợi ích cho cả thú cưng và chủ nuôi. Triệt sản giúp giảm nguy cơ mắc các bệnh về đường sinh sản, kéo dài tuổi thọ, kiểm soát hành vi và ngăn chặn việc sinh sản ngoài ý muốn. 
Dưới đây là các lý do chi tiết:
Đối với thú cưng:
Giảm nguy cơ mắc bệnh:
Triệt sản giúp giảm đáng kể nguy cơ mắc các bệnh ung thư tử cung, buồng trứng, vú ở chó mèo cái và ung thư tinh hoàn, tuyến tiền liệt ở chó mèo đực. 
Kéo dài tuổi thọ:
Nghiên cứu cho thấy chó mèo được triệt sản thường sống lâu hơn so với những con không được triệt sản do giảm nguy cơ mắc các bệnh nguy hiểm. 
Kiểm soát hành vi:
Triệt sản có thể làm giảm các hành vi như đánh dấu lãnh thổ, đi lang thang, giao phối không kiểm soát và hung dữ, đặc biệt là ở chó mèo đực. 
Tránh thai ngoài ý muốn:
Triệt sản là biện pháp hiệu quả để ngăn chặn việc sinh sản không kiểm soát, giảm số lượng thú hoang và giảm gánh nặng cho các tổ chức cứu hộ động vật. 
Cải thiện sức khỏe tinh thần:
Mặc dù có thể gây ra một số thay đổi trong hành vi, nhưng triệt sản có thể giúp giảm căng thẳng liên quan đến chu kỳ động dục ở chó mèo cái, giúp chúng thoải mái hơn. 
Đối với chủ nuôi:
Giảm chi phí:
Việc triệt sản giúp giảm nguy cơ mắc các bệnh về sinh sản, từ đó giảm chi phí khám chữa bệnh cho thú cưng. 
Giảm phiền toái:
Triệt sản giúp kiểm soát hành vi của thú cưng, giảm các vấn đề như đánh dấu lãnh thổ, đi vệ sinh bừa bãi, cắn phá đồ đạc. 
Góp phần giải quyết vấn nạn thú hoang:
Triệt sản giúp giảm số lượng chó mèo hoang, giảm nguy cơ lây lan bệnh tật và các vấn đề liên quan đến chó mèo hoang. 
Thời điểm triệt sản:
Thời điểm lý tưởng để triệt sản cho chó mèo là từ 6 tháng tuổi trở lên, hoặc sau khi hoàn thành chu kỳ động dục đầu tiên (nếu là chó mèo cái).
Nên tham khảo ý kiến của bác sĩ thú y để xác định thời điểm triệt sản phù hợp nhất cho thú cưng của bạn. ', N'/uploads/blog/2e4f5191-52d6-4df2-b320-1c0457f401fa_triet_san.jpg', NULL, N'Sức khỏe', CAST(N'2025-07-01T16:27:04.047' AS DateTime), CAST(N'2025-07-01T16:27:04.050' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BlogPosts] OFF
GO
INSERT [dbo].[Doctors] ([DoctorID], [Specialty], [Degree], [Description]) VALUES (3, N'Surgery', N'PhD', N'Specialist in soft tissues surgery.')
INSERT [dbo].[Doctors] ([DoctorID], [Specialty], [Degree], [Description]) VALUES (19, N'Internal Medicine', N'MD', N'Experienced in treating chronic diseases.')
INSERT [dbo].[Doctors] ([DoctorID], [Specialty], [Degree], [Description]) VALUES (20, N'Surgery', N'PhD', N'Specialist in soft tissue surgery.')
INSERT [dbo].[Doctors] ([DoctorID], [Specialty], [Degree], [Description]) VALUES (21, N'Dermatology', N'MD', N'Focus on pet skin care.')
INSERT [dbo].[Doctors] ([DoctorID], [Specialty], [Degree], [Description]) VALUES (22, N'Vaccination', N'MD', N'Expert in preventive care.')
INSERT [dbo].[Doctors] ([DoctorID], [Specialty], [Degree], [Description]) VALUES (23, N'Dentistry', N'DDS', N'Handles all dental care for pets.')
GO
SET IDENTITY_INSERT [dbo].[DoctorSchedules] ON 

INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (1, 22, CAST(N'2025-07-22' AS Date), N'Ca 1', 1)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (2, 22, CAST(N'2025-07-15' AS Date), N'Ca 4', 4)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (3, 21, CAST(N'2025-07-14' AS Date), N'Ca 4', 4)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (4, 21, CAST(N'2025-07-30' AS Date), N'Ca 4', 4)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (5, 20, CAST(N'2025-07-17' AS Date), N'Ca 4', 4)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (6, 3, CAST(N'2025-07-25' AS Date), N'Ca 3', 3)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (7, 21, CAST(N'2025-07-18' AS Date), N'Ca 2', 2)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (8, 20, CAST(N'2025-07-29' AS Date), N'Ca 2', 2)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (9, 21, CAST(N'2025-08-10' AS Date), N'Ca 4', 4)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (10, 23, CAST(N'2025-08-02' AS Date), N'Ca 1', 1)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (11, 20, CAST(N'2025-08-06' AS Date), N'Ca 4', 4)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (12, 21, CAST(N'2025-07-31' AS Date), N'Ca 3', 3)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (13, 20, CAST(N'2025-07-20' AS Date), N'Ca 3', 3)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (14, 21, CAST(N'2025-07-18' AS Date), N'Ca 4', 4)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (15, 22, CAST(N'2025-07-18' AS Date), N'Ca 5', 5)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (16, 23, CAST(N'2025-07-18' AS Date), N'Ca 2', 2)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (17, 23, CAST(N'2025-07-17' AS Date), N'Ca 2', 2)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (18, 22, CAST(N'2025-07-31' AS Date), N'Ca 3', 3)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (19, 20, CAST(N'2025-07-18' AS Date), N'Ca 4', 4)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (20, 20, CAST(N'2025-07-22' AS Date), N'Ca 2', 2)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (21, 19, CAST(N'2025-07-22' AS Date), N'Ca 3', 3)
INSERT [dbo].[DoctorSchedules] ([ScheduleID], [DoctorID], [WorkDate], [Note], [Shift]) VALUES (22, 22, CAST(N'2025-08-08' AS Date), N'Ca 2', 2)
SET IDENTITY_INSERT [dbo].[DoctorSchedules] OFF
GO
SET IDENTITY_INSERT [dbo].[Medications] ON 

INSERT [dbo].[Medications] ([MedicationID], [Name], [Description], [Unit], [Price], [Stock]) VALUES (1, N'uiui', N'dfg', N'nyg', CAST(100.00 AS Decimal(10, 2)), 1333)
SET IDENTITY_INSERT [dbo].[Medications] OFF
GO
SET IDENTITY_INSERT [dbo].[Pets] ON 

INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (1, 10, N'Pet1', N'Cat', N'Anh lông ngắn', N'Male', CAST(N'2024-01-15' AS Date), CAST(6.00 AS Decimal(5, 2)), N'....', CAST(N'2025-07-15T10:10:55.047' AS DateTime))
INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (3, 10, N'Pet2', N'Cat', N'Anh lông dài', N'Male', CAST(N'2025-07-01' AS Date), CAST(5.00 AS Decimal(5, 2)), N'hhhhh', CAST(N'2025-07-15T16:43:42.060' AS DateTime))
INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (4, 10, N'Pet3', N'Cat', N'Egypt', N'Female', CAST(N'2025-07-14' AS Date), CAST(4.00 AS Decimal(5, 2)), N'gggg', CAST(N'2025-07-15T09:52:49.430' AS DateTime))
INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (5, 9, N'Pet4', N'Dog', N'Bull', N'Male', CAST(N'2025-07-14' AS Date), CAST(10.00 AS Decimal(5, 2)), N'jjjj', CAST(N'2025-07-15T14:14:13.430' AS DateTime))
INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (6, 10, N'Pet5', N'Dog', N'VN', N'Female', CAST(N'2025-07-14' AS Date), CAST(12.00 AS Decimal(5, 2)), N'aaaaa', CAST(N'2025-07-15T14:35:17.210' AS DateTime))
INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (7, 26, N'Pet6', N'Dog', N'Cỏ', N'Male', CAST(N'2025-07-08' AS Date), CAST(10.00 AS Decimal(5, 2)), N'mmmmm', CAST(N'2025-07-16T03:06:21.727' AS DateTime))
INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (8, 10, N'Kaka', N'Cat', N'Mướp', N'Male', CAST(N'2025-06-30' AS Date), CAST(7.00 AS Decimal(5, 2)), N'heeeee', CAST(N'2025-07-16T08:00:18.523' AS DateTime))
INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (9, 27, N'Hehe', N'chó', N'cỏ', N'cái', CAST(N'2025-07-17' AS Date), CAST(8.00 AS Decimal(5, 2)), N'jjjjjj', CAST(N'2025-07-16T13:09:37.240' AS DateTime))
INSERT [dbo].[Pets] ([PetID], [OwnerID], [Name], [Species], [Breed], [Gender], [BirthDate], [Weight], [Note], [CreatedAt]) VALUES (10, 28, N'dfgfd', N'Cat', N'dgfdf', N'Male', CAST(N'2025-06-30' AS Date), CAST(8.00 AS Decimal(5, 2)), N'456456', CAST(N'2025-07-16T13:12:19.773' AS DateTime))
SET IDENTITY_INSERT [dbo].[Pets] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Admin')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Manager')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'Doctor')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (4, N'Staff')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (5, N'Customer')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [Price], [ServiceType]) VALUES (1, N'Khám tổng quát', N'Dịch vụ khám và chăm sóc sức khỏe định kỳ và chẩn đoán tổng quát cho thú cưng.', CAST(10.00 AS Decimal(10, 2)), N'Khám bệnh')
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [Price], [ServiceType]) VALUES (2, N'Tiêm phòng', N'Tư vấn & Cung cấp các loại vắc xin phổ biến như phòng dại, care, parvo,...', CAST(100000.00 AS Decimal(10, 2)), N'Tiêm phòng')
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [Price], [ServiceType]) VALUES (3, N'Phẫu thuật', N'Thực hiện các ca phẫu thuật nhỏ và lớn như triệt sản, mổ cấp cứu', CAST(500000.00 AS Decimal(10, 2)), N'Phẫu thuật')
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [Price], [ServiceType]) VALUES (4, N'Spa & Grooming', N'Dịch vụ tắm, cắt tỉa lông, vệ sinh tai, móng cho thú cưng', CAST(200000.00 AS Decimal(10, 2)), N'Làm đẹp')
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [Price], [ServiceType]) VALUES (6, N'Tư vấn dinh dưỡng', N'Tư vấn khẩu phần ăn phù hợp cho từng giống loài', CAST(100000.00 AS Decimal(10, 2)), N'Tư vấn')
INSERT [dbo].[Services] ([ServiceID], [Name], [Description], [Price], [ServiceType]) VALUES (7, N'Điều trị nội trú', N'Dịch vụ chăm sóc thú cưng 24/24 khi điều trị tại phòng khám', CAST(700000.00 AS Decimal(10, 2)), N'Nội trú')
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (1, N'Admin', N'admin@gmail.com', N'Admin123@', N'0916965184', N'Số 1 Nguyễn Huệ, P. Bến Nghé, Q.1, TP.HCM', N'/uploads/access_denied.png', 1, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (2, N'Manager', N'manager@gmail.com', N'Manager123@', N'0983456781', N'285 Cách Mạng Tháng Tám, P.12, Q.10, TP.HCM', N'/uploads/access_denied.png', 2, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (3, N'Dr. Nguyễn Văn Anh', N'doctor@gmail.com', N'Doctor123@', N'0973456782', N'202 Lê Lai, P. Bến Thành, Q.1, TP.HCM', N'/uploads/background_avatar.png', 3, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (4, N'Staff', N'staff@gmail.com', N'Staff123@', N'0123456783', N'60-62 Bàu Cát, P.14, Q. Tân Bình, TP.HCM', N'/uploads/access_denied.png', 4, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (5, N'Nguyễn Thị B', N'customer1@gmail.com', N'Customer123@', N'0123456784', N'75 Nguyễn Thị Minh Khai, P. Bến Thành, Q.1, TP.HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (6, N'Trần Văn C', N'customer2@gmail.com', N'Customer123@', N'0123456785', N'50 Trường Sơn, P.2, Q. Tân Bình, TP.HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (7, N'Lê Thị D', N'customer3@gmail.com', N'Customer123@', N'0123456786', N'12 Phan Đăng Lưu, P.3, Q. Bình Thạnh, TP.HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (8, N'Phạm Văn E', N'customer4@gmail.com', N'Customer123@', N'0123456787', N'99 Nguyễn Gia Trí, P.25, Q. Bình Thạnh, TP.HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (9, N'Hoàng Thị F', N'customer5@gmail.com', N'Customer123@', N'0123456788', N'340 Nguyễn Văn Luông, P.12, Q.6, TP.HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-27T09:40:04.820' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (10, N'Pham Minh Truong', N'ghoul1645@gmail.com', N'123456', N'0916965184', N'Số 1 Nguyễn Huệ, P. Bến Nghé, Q.1, TP.HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-28T00:02:08.573' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (15, N'Pham Minh Truongg', N'ghoul1647@gmail.com', N'123', N'0916965184', N'123 Le Loi, HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-28T00:13:14.680' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (16, N'Hahaha', N'phamminhtruong@gmail.com', N'123456', N'0916965184', N'340 Nguyễn Văn Luông, P.12, Q.6, TP.HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-28T10:40:30.150' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (17, N'Hihi', N'hihi@gmail.com', N'123456', N'0916965184', N'99 Nguyễn Gia Trí, P.25, Q. Bình Thạnh, TP.HCM', N'/uploads/access_denied.png', 5, CAST(N'2025-06-28T10:41:24.333' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (18, N'Thế Khang', N'thekhang@gmail.com', N'123456', N'0916965184', N'256 Man Thiện', N'/uploads/access_denied.png', 5, CAST(N'2025-06-28T11:33:15.767' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (19, N'Dr. Nguyen Van A', N'nguyenvana@clinic.com', N'hashed_password1', N'0901234567', N'123 Le Loi, HCM', N'/uploads/background_avatar.png', 3, CAST(N'2025-06-29T13:58:47.317' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (20, N'Dr. Tran Thi B', N'tranthib@clinic.com', N'hashed_password2', N'0902345678', N'456 Nguyen Trai, HN', N'/uploads/background_avatar.png', 3, CAST(N'2025-06-29T13:58:47.317' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (21, N'Dr. Le Van C', N'levanc@clinic.com', N'hashed_password3', N'0903456789', N'789 Hai Ba Trung, Da Nang', N'/uploads/background_avatar.png', 3, CAST(N'2025-06-29T13:58:47.317' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (22, N'Dr. Pham Thi D', N'phamthid@clinic.com', N'hashed_password4', N'0904567890', N'321 Phan Dinh Phung, Hue', N'/uploads/background_avatar.png', 3, CAST(N'2025-06-29T13:58:47.317' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (23, N'Dr. Hoang Van E', N'hoangvane@clinic.com', N'hashed_password5', N'0905678901', N'654 Tran Hung Dao, Can Tho', N'/uploads/background_avatar.png', 3, CAST(N'2025-06-29T13:58:47.317' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (25, N'', NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2025-07-16T10:03:41.880' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (26, N'Hoàng Nong', N'long041103@gmail.com', N'123456', N'0916965184', N'256 Man Thiện, Tăng Nhơn Phú A, Thủ Đức', NULL, 5, CAST(N'2025-07-16T10:04:45.750' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (27, N'Toan', N'nguyenngoctoan30032003@gmai.com', N'123456', N'0', N'dhfghfghfghgfhfgh', NULL, 5, CAST(N'2025-07-16T20:09:01.340' AS DateTime), 1)
INSERT [dbo].[Users] ([UserID], [FullName], [Email], [PasswordHash], [PhoneNumber], [Address], [AvatarUrl], [RoleID], [CreatedAt], [IsActive]) VALUES (28, N'Nguyễn Văn A', N'truongpmse182027@fpt.edu.vn', N'123456', N'0', N'fghgfhgfhgfhg', NULL, 5, CAST(N'2025-07-16T20:11:32.400' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__BlogPost__BC7B5FB62EA49E5B]    Script Date: 17-Jul-25 4:51:37 PM ******/
ALTER TABLE [dbo].[BlogPosts] ADD UNIQUE NONCLUSTERED 
(
	[Slug] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534E1BF28FF]    Script Date: 17-Jul-25 4:51:37 PM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  DEFAULT (getdate()) FOR [UpdatedAt]
GO
ALTER TABLE [dbo].[BlogPosts] ADD  DEFAULT ((1)) FOR [IsPublished]
GO
ALTER TABLE [dbo].[CareSchedules] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Feedbacks] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[InventoryTransactions] ADD  DEFAULT (getdate()) FOR [TransactionDate]
GO
ALTER TABLE [dbo].[MedicalRecords] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT (getdate()) FOR [SentAt]
GO
ALTER TABLE [dbo].[Pets] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([PetID])
REFERENCES [dbo].[Pets] ([PetID])
GO
ALTER TABLE [dbo].[Appointments]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[CareSchedules]  WITH CHECK ADD  CONSTRAINT [FK_CareSchedules_Pets] FOREIGN KEY([PetID])
REFERENCES [dbo].[Pets] ([PetID])
GO
ALTER TABLE [dbo].[CareSchedules] CHECK CONSTRAINT [FK_CareSchedules_Pets]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[DoctorSchedules]  WITH CHECK ADD FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD FOREIGN KEY([AppointmentID])
REFERENCES [dbo].[Appointments] ([AppointmentID])
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
GO
ALTER TABLE [dbo].[InventoryTransactions]  WITH CHECK ADD FOREIGN KEY([MedicationID])
REFERENCES [dbo].[Medications] ([MedicationID])
GO
ALTER TABLE [dbo].[MedicalRecords]  WITH CHECK ADD FOREIGN KEY([AppointmentID])
REFERENCES [dbo].[Appointments] ([AppointmentID])
GO
ALTER TABLE [dbo].[MedicalRecords]  WITH CHECK ADD FOREIGN KEY([DoctorID])
REFERENCES [dbo].[Doctors] ([DoctorID])
GO
ALTER TABLE [dbo].[MedicalRecords]  WITH CHECK ADD FOREIGN KEY([PetID])
REFERENCES [dbo].[Pets] ([PetID])
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD FOREIGN KEY([AppointmentID])
REFERENCES [dbo].[Appointments] ([AppointmentID])
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Pets]  WITH CHECK ADD FOREIGN KEY([OwnerID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[PrescriptionDetails]  WITH CHECK ADD  CONSTRAINT [FK_PrescriptionDetails_MedicalRecords] FOREIGN KEY([RecordID])
REFERENCES [dbo].[MedicalRecords] ([RecordID])
GO
ALTER TABLE [dbo].[PrescriptionDetails] CHECK CONSTRAINT [FK_PrescriptionDetails_MedicalRecords]
GO
ALTER TABLE [dbo].[PrescriptionDetails]  WITH CHECK ADD  CONSTRAINT [FK_PrescriptionDetails_Medications] FOREIGN KEY([MedicationID])
REFERENCES [dbo].[Medications] ([MedicationID])
GO
ALTER TABLE [dbo].[PrescriptionDetails] CHECK CONSTRAINT [FK_PrescriptionDetails_Medications]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
