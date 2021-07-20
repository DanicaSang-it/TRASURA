USE [dbTrasura]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 13/07/2021 9:02:18 pm ******/
DROP TABLE [dbo].[tbl_user]
GO
/****** Object:  Table [dbo].[tbl_Schedule]    Script Date: 13/07/2021 9:02:18 pm ******/
DROP TABLE [dbo].[tbl_Schedule]
GO
/****** Object:  StoredProcedure [dbo].[Register]    Script Date: 13/07/2021 9:02:18 pm ******/
DROP PROCEDURE [dbo].[Register]
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 13/07/2021 9:02:18 pm ******/
DROP PROCEDURE [dbo].[Login]
GO
USE [master]
GO
/****** Object:  Database [dbTrasura]    Script Date: 13/07/2021 9:02:18 pm ******/
DROP DATABASE [dbTrasura]
GO
/****** Object:  Database [dbTrasura]    Script Date: 13/07/2021 9:02:18 pm ******/
CREATE DATABASE [dbTrasura]
GO
USE [dbTrasura]
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 13/07/2021 9:02:18 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Login]
@Username VARCHAR(255),
@Password VARCHAR(255)
AS
BEGIN
	DECLARE @isExist INT = (SELECT COUNT(*) FROM tbl_user WHERE Username = @Username AND Password = @Password)
	IF @isExist >= 1
	BEGIN
	SELECT *, CONVERT(BIT, 1) isValid FROM tbl_user WHERE Username = @Username AND Password = @Password
		
	END
	ELSE
	BEGIN
		SELECT CONVERT(BIT, 0) isValid
	END
END

GO
/****** Object:  StoredProcedure [dbo].[Register]    Script Date: 13/07/2021 9:02:18 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Register]
@Username VARCHAR(255),
@Password VARCHAR(255),
@Email VARCHAR(255),
@Fname VARCHAR(255),
@Mn VARCHAR(255),
@Lname VARCHAR(255),
@Gender VARCHAR(255),
@Bday DATETIME
AS
BEGIN
	DECLARE @isExist INT = (SELECT COUNT(*) FROM tbl_user WHERE Username = @Username)
	IF @isExist >= 1
	BEGIN
		SELECT CONVERT(BIT, 0) isValid
	END
	ELSE
	BEGIN
		INSERT INTO tbl_user (Username,Password,Email,Fname,mn,Lname,Gender,Bday)
		VALUES
		(@Username,@Password,@Email,@Fname,@mn,@Lname,@Gender,@Bday)
		SELECT CONVERT(BIT, 1) isValid
	END
END

GO
/****** Object:  Table [dbo].[tbl_Bin]    Script Date: 13/07/2021 9:02:18 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Bin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BinID] [varchar](50) NULL,
	[MaxCapacity] [int] NULL,
	[CurrentCapacity] [int] NULL,
	[Location] [varchar](255) NULL,
	[CollectorPhone] [varchar](50) NULL,
	[DeploymentDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Remarks]    Script Date: 13/07/2021 9:02:18 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Remarks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Remarks] [varchar](max) NULL,
	[encBy] [int] NULL,
	[encDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Schedule]    Script Date: 13/07/2021 9:02:18 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Schedule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Schedule] [varchar](255) NULL,
	[Description] [varchar](max) NULL,
	[encBy] [int] NULL,
	[encDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 13/07/2021 9:02:18 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NULL,
	[Password] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Fname] [varchar](255) NULL,
	[Mn] [varchar](255) NULL,
	[Lname] [varchar](255) NULL,
	[Gender] [varchar](255) NULL,
	[Bday] [datetime] NULL,
	[isAdmin] [bit] NULL,
	[encDate] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tbl_Bin] ADD  DEFAULT ((100)) FOR [MaxCapacity]
GO
ALTER TABLE [dbo].[tbl_Bin] ADD  DEFAULT ((0)) FOR [CurrentCapacity]
GO
ALTER TABLE [dbo].[tbl_Remarks] ADD  DEFAULT (getdate()) FOR [encDate]
GO
ALTER TABLE [dbo].[tbl_Schedule] ADD  CONSTRAINT [DF__tbl_Sched__encDa__117F9D94]  DEFAULT (getdate()) FOR [encDate]
GO
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [DF_tbl_user_isAdmin]  DEFAULT ((0)) FOR [isAdmin]
GO
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [DF__tbl_user__encDat__0F975522]  DEFAULT (getdate()) FOR [encDate]
GO
USE [master]
GO
ALTER DATABASE [dbTrasura] SET  READ_WRITE 
GO
