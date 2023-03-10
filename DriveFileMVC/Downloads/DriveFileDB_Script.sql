USE [master]
GO
/****** Object:  Database [DriveFile_DB]    Script Date: 12/21/2022 2:11:52 AM ******/
CREATE DATABASE [DriveFile_DB]
 
GO
USE [DriveFile_DB]
GO
/****** Object:  Table [dbo].[Tbl_Account]    Script Date: 12/21/2022 2:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[RegDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Files]    Script Date: 12/21/2022 2:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Files](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](250) NULL,
	[AccountId] [int] NOT NULL,
	[Attachment] [nvarchar](500) NULL,
	[RegDate] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Files] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Account] ON 

INSERT [dbo].[Tbl_Account] ([id], [FirstName], [LastName], [Mail], [Password], [RegDate]) VALUES (2, N'Elxan', N'Civishov', N'e@gmail.com', N'789', CAST(N'2022-12-19T03:03:33.713' AS DateTime))
INSERT [dbo].[Tbl_Account] ([id], [FirstName], [LastName], [Mail], [Password], [RegDate]) VALUES (3, N'Fuad', N'Orucov', N'f@gmail.com', N'1234', CAST(N'2022-12-19T03:05:31.883' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Tbl_Files] ON 

INSERT [dbo].[Tbl_Files] ([id], [FileName], [AccountId], [Attachment], [RegDate]) VALUES (34, N'1.png', 3, N'/Downloads/1.png', CAST(N'2022-12-21T01:49:47.787' AS DateTime))
INSERT [dbo].[Tbl_Files] ([id], [FileName], [AccountId], [Attachment], [RegDate]) VALUES (35, N'2.png', 3, N'/Downloads/2.png', CAST(N'2022-12-21T01:53:58.467' AS DateTime))
INSERT [dbo].[Tbl_Files] ([id], [FileName], [AccountId], [Attachment], [RegDate]) VALUES (36, N'1.png', 2, N'/Downloads/1.png', CAST(N'2022-12-21T02:09:26.127' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tbl_Files] OFF
GO
ALTER TABLE [dbo].[Tbl_Files]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_Files_Tbl_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Tbl_Account] ([id])
GO
ALTER TABLE [dbo].[Tbl_Files] CHECK CONSTRAINT [FK_Tbl_Files_Tbl_Account]
GO
USE [master]
GO
ALTER DATABASE [DriveFile_DB] SET  READ_WRITE 
GO
