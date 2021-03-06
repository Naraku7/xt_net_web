USE [Users]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 22.02.2020 14:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22.02.2020 14:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Images] [varbinary](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Awards]    Script Date: 22.02.2020 14:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Awards](
	[Id_User] [int] NOT NULL,
	[Id_Award] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users_Awards]  WITH CHECK ADD  CONSTRAINT [FK_Users_Awards_Awards] FOREIGN KEY([Id_Award])
REFERENCES [dbo].[Awards] ([ID])
GO
ALTER TABLE [dbo].[Users_Awards] CHECK CONSTRAINT [FK_Users_Awards_Awards]
GO
ALTER TABLE [dbo].[Users_Awards]  WITH CHECK ADD  CONSTRAINT [FK_Users_Awards_Users] FOREIGN KEY([Id_User])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Users_Awards] CHECK CONSTRAINT [FK_Users_Awards_Users]
GO
