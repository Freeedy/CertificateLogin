USE [master]
GO
/****** Object:  Database [CertificateLoginDb]    Script Date: 29.12.2020 15:29:29 ******/
CREATE DATABASE [CertificateLoginDb] ON  PRIMARY 
( NAME = N'CertificateLoginDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\CertificateLoginDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CertificateLoginDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\CertificateLoginDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CertificateLoginDb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CertificateLoginDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CertificateLoginDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CertificateLoginDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CertificateLoginDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CertificateLoginDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CertificateLoginDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CertificateLoginDb] SET RECOVERY FULL 
GO
ALTER DATABASE [CertificateLoginDb] SET  MULTI_USER 
GO
ALTER DATABASE [CertificateLoginDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CertificateLoginDb] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CertificateLoginDb', N'ON'
GO
USE [CertificateLoginDb]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[SubOrganizationId] [int] NOT NULL,
	[Url] [varchar](255) NOT NULL,
	[CallbackUrl] [varchar](500) NOT NULL,
	[Minutues] [int] NOT NULL,
	[SecretKey] [varchar](max) NOT NULL,
	[Algorithm] [varchar](max) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerStatuses]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerStatuses](
	[Id] [tinyint] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_CustomerStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[FullName] [nvarchar](1000) NOT NULL,
	[Voen] [char](10) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationStatuses]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationStatuses](
	[Id] [tinyint] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_OrganizationStatuses'] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubOrganizations]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubOrganizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[FullName] [nvarchar](1000) NOT NULL,
	[Sun] [char](11) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_SubOrganizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubOrganizationStatuses]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubOrganizationStatuses](
	[Id] [tinyint] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_SubOrganizationStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[Pin] [char](7) NOT NULL,
	[FullName] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserStatuses]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserStatuses](
	[Id] [tinyint] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [StatusId], [SubOrganizationId], [Url], [CallbackUrl], [Minutues], [SecretKey], [Algorithm], [Description], [AddedDate]) VALUES (1, 1, 1, N'http://e-imza.az/', N'http://e-imza.az/', 60, N'OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==', N'http://www.w3.org/2001/04/xmldsig-more#hmac-sha256', N'http://e-imza.az/', CAST(N'2020-12-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customers] OFF
INSERT [dbo].[CustomerStatuses] ([Id], [Name], [Description]) VALUES (1, N'ACTIVE', N'Active customer')
INSERT [dbo].[CustomerStatuses] ([Id], [Name], [Description]) VALUES (2, N'BLOCKED', N'Blocked customer')
SET IDENTITY_INSERT [dbo].[Organizations] ON 

INSERT [dbo].[Organizations] ([Id], [StatusId], [FullName], [Voen], [Description], [AddedDate]) VALUES (1, 1, N'MHM', N'9900037691', N'MHM', CAST(N'2020-12-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Organizations] OFF
INSERT [dbo].[OrganizationStatuses] ([Id], [Name], [Description]) VALUES (1, N'ACTIVE', N'Active organization')
INSERT [dbo].[OrganizationStatuses] ([Id], [Name], [Description]) VALUES (2, N'BLOCKED', N'Blocked organization')
SET IDENTITY_INSERT [dbo].[SubOrganizations] ON 

INSERT [dbo].[SubOrganizations] ([Id], [StatusId], [OrganizationId], [FullName], [Sun], [Description], [AddedDate]) VALUES (1, 1, 1, N'SXM', N'19910002080', N'SXM', CAST(N'2020-12-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[SubOrganizations] OFF
INSERT [dbo].[SubOrganizationStatuses] ([Id], [Name], [Description]) VALUES (1, N'ACTIVE', N'Active sub organization')
INSERT [dbo].[SubOrganizationStatuses] ([Id], [Name], [Description]) VALUES (2, N'BLOCKED', N'Blocked sub organization')
INSERT [dbo].[UserStatuses] ([Id], [Name], [Description]) VALUES (1, N'ACTIVE', N'Active user')
INSERT [dbo].[UserStatuses] ([Id], [Name], [Description]) VALUES (2, N'BLOCKED', N'Blocked user')
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Customers_Url]    Script Date: 29.12.2020 15:29:30 ******/
ALTER TABLE [dbo].[Customers] ADD  CONSTRAINT [UC_Customers_Url] UNIQUE NONCLUSTERED 
(
	[Url] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Organizations_Voen]    Script Date: 29.12.2020 15:29:30 ******/
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [UC_Organizations_Voen] UNIQUE NONCLUSTERED 
(
	[Voen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_SubOrganizations_Sun]    Script Date: 29.12.2020 15:29:30 ******/
ALTER TABLE [dbo].[SubOrganizations] ADD  CONSTRAINT [UC_SubOrganizations_Sun] UNIQUE NONCLUSTERED 
(
	[Sun] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Users_Pin]    Script Date: 29.12.2020 15:29:30 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UC_Users_Pin] UNIQUE NONCLUSTERED 
(
	[Pin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerStatuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[CustomerStatuses] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_CustomerStatuses]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_SubOrganizations] FOREIGN KEY([SubOrganizationId])
REFERENCES [dbo].[SubOrganizations] ([Id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_SubOrganizations]
GO
ALTER TABLE [dbo].[Organizations]  WITH CHECK ADD  CONSTRAINT [FK_Organizations_OrganizationStatuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[OrganizationStatuses] ([Id])
GO
ALTER TABLE [dbo].[Organizations] CHECK CONSTRAINT [FK_Organizations_OrganizationStatuses]
GO
ALTER TABLE [dbo].[SubOrganizations]  WITH CHECK ADD  CONSTRAINT [FK_SubOrganizations_Organizations] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[Organizations] ([Id])
GO
ALTER TABLE [dbo].[SubOrganizations] CHECK CONSTRAINT [FK_SubOrganizations_Organizations]
GO
ALTER TABLE [dbo].[SubOrganizations]  WITH CHECK ADD  CONSTRAINT [FK_SubOrganizations_SubOrganizationStatuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[SubOrganizationStatuses] ([Id])
GO
ALTER TABLE [dbo].[SubOrganizations] CHECK CONSTRAINT [FK_SubOrganizations_SubOrganizationStatuses]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserStatuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[UserStatuses] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserStatuses]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerByUrl]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerByUrl]
	@url varchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
	 Customers.Id AS Id
    ,Customers.StatusId AS CustomerStatusId
    ,SubOrganizations.StatusId AS SubOrganizationStatusId
    ,Organizations.StatusId AS OrganizationStatusId
    ,Customers.SubOrganizationId AS SubOrganizationId
    ,SubOrganizations.OrganizationId AS OrganizationId
    ,Customers.Url AS Url
    ,Customers.CallbackUrl AS CallbackUrl
    ,Customers.Minutues AS Minutues
    ,Customers.SecretKey AS SecretKey
    ,Customers.Algorithm AS Algorithm
    ,Customers.Description AS Description
    ,Customers.AddedDate AS AddedDate
	FROM [CertificateLoginDb].[dbo].[Customers] as Customers
	INNER JOIN [dbo].[SubOrganizations] AS SubOrganizations ON SubOrganizations.Id = Customers.SubOrganizationId
	INNER JOIN [dbo].[Organizations] AS Organizations ON SubOrganizations.OrganizationId = Organizations.Id
	WHERE Url = @url
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerStatusById]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetCustomerStatusById] 
	@statusId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 1
	 CustomerStatuses.Id AS Id
	,CustomerStatuses.Name AS Name
	,CustomerStatuses.Description AS Description
	FROM [dbo].[CustomerStatuses] AS CustomerStatuses
	WHERE CustomerStatuses.Id = @statusId
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerStatusByIdCount]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetCustomerStatusByIdCount] 
	@statusId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 COUNT(CustomerStatuses.Id)
	FROM [dbo].[CustomerStatuses] AS CustomerStatuses
	WHERE CustomerStatuses.Id = @statusId
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerStatuses]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetCustomerStatuses] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 CustomerStatuses.Id AS Id
	,CustomerStatuses.Name AS Name
	,CustomerStatuses.Description AS Description
	FROM [dbo].[CustomerStatuses] AS CustomerStatuses
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerStatusesCount]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCustomerStatusesCount] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
	 COUNT(CustomerStatuses.Id)
	FROM [dbo].[CustomerStatuses] AS CustomerStatuses
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrganizationStatusById]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetOrganizationStatusById] 
	@statusId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 1
	 OrganizationStatuses.Id AS Id
	,OrganizationStatuses.Name AS Name
	,OrganizationStatuses.Description AS Description
	FROM [dbo].[OrganizationStatuses] AS OrganizationStatuses
	WHERE OrganizationStatuses.Id = @statusId
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrganizationStatusByIdCount]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetOrganizationStatusByIdCount] 
	@statusId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 COUNT(OrganizationStatuses.Id)
	FROM [dbo].[OrganizationStatuses] AS OrganizationStatuses
	WHERE OrganizationStatuses.Id = @statusId
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrganizationStatuses]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetOrganizationStatuses] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 OrganizationStatuses.Id AS Id
	,OrganizationStatuses.Name AS Name
	,OrganizationStatuses.Description AS Description
	FROM [dbo].[OrganizationStatuses] AS OrganizationStatuses
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrganizationStatusesCount]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetOrganizationStatusesCount] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
	 COUNT(OrganizationStatuses.Id)
	FROM [dbo].[OrganizationStatuses] AS OrganizationStatuses
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubOrganizationStatusById]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetSubOrganizationStatusById] 
	@statusId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 1
	 SubOrganizationStatuses.Id AS Id
	,SubOrganizationStatuses.Name AS Name
	,SubOrganizationStatuses.Description AS Description
	FROM [dbo].[SubOrganizationStatuses] AS SubOrganizationStatuses
	WHERE SubOrganizationStatuses.Id = @statusId
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubOrganizationStatusByIdCount]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetSubOrganizationStatusByIdCount] 
	@statusId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 COUNT(SubOrganizationStatuses.Id)
	FROM [dbo].[SubOrganizationStatuses] AS SubOrganizationStatuses
	WHERE SubOrganizationStatuses.Id = @statusId
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubOrganizationStatuses]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetSubOrganizationStatuses] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 SubOrganizationStatuses.Id AS Id
	,SubOrganizationStatuses.Name AS Name
	,SubOrganizationStatuses.Description AS Description
	FROM [dbo].[SubOrganizationStatuses] AS SubOrganizationStatuses
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubOrganizationStatusesCount]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetSubOrganizationStatusesCount] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
	 COUNT(SubOrganizationStatuses.Id)
	FROM [dbo].[SubOrganizationStatuses] AS SubOrganizationStatuses
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserStatusById]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetUserStatusById] 
	@statusId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP 1
	 UserStatuses.Id AS Id
	,UserStatuses.Name AS Name
	,UserStatuses.Description AS Description
	FROM [dbo].[UserStatuses] AS UserStatuses
	WHERE UserStatuses.Id = @statusId
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserStatusByIdCount]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetUserStatusByIdCount] 
	@statusId tinyint
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 COUNT(UserStatuses.Id)
	FROM [dbo].[UserStatuses] AS UserStatuses
	WHERE UserStatuses.Id = @statusId
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserStatuses]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetUserStatuses] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	 UserStatuses.Id AS Id
	,UserStatuses.Name AS Name
	,UserStatuses.Description AS Description
	FROM [dbo].[UserStatuses] AS UserStatuses
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserStatusesCount]    Script Date: 29.12.2020 15:29:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[GetUserStatusesCount] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
	 COUNT(UserStatuses.Id)
	FROM [dbo].[UserStatuses] AS UserStatuses
END
GO
USE [master]
GO
ALTER DATABASE [CertificateLoginDb] SET  READ_WRITE 
GO
