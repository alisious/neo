USE [master]
GO
/****** Object:  Database [KseoContext]    Script Date: 2014-11-06 23:15:29 ******/
CREATE DATABASE [KseoContext]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KseoContext', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\KseoContext.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KseoContext_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\KseoContext_log.ldf' , SIZE = 4672KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KseoContext] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KseoContext].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KseoContext] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KseoContext] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KseoContext] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KseoContext] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KseoContext] SET ARITHABORT OFF 
GO
ALTER DATABASE [KseoContext] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KseoContext] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [KseoContext] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KseoContext] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KseoContext] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KseoContext] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KseoContext] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KseoContext] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KseoContext] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KseoContext] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KseoContext] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KseoContext] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KseoContext] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KseoContext] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KseoContext] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KseoContext] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KseoContext] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KseoContext] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KseoContext] SET RECOVERY FULL 
GO
ALTER DATABASE [KseoContext] SET  MULTI_USER 
GO
ALTER DATABASE [KseoContext] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KseoContext] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KseoContext] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KseoContext] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [KseoContext]
GO
/****** Object:  Schema [Common]    Script Date: 2014-11-06 23:15:30 ******/
CREATE SCHEMA [Common]
GO
/****** Object:  Schema [Cooperation]    Script Date: 2014-11-06 23:15:30 ******/
CREATE SCHEMA [Cooperation]
GO
/****** Object:  Schema [Issue]    Script Date: 2014-11-06 23:15:30 ******/
CREATE SCHEMA [Issue]
GO
/****** Object:  Schema [Person]    Script Date: 2014-11-06 23:15:30 ******/
CREATE SCHEMA [Person]
GO
/****** Object:  Schema [Reservation]    Script Date: 2014-11-06 23:15:30 ******/
CREATE SCHEMA [Reservation]
GO
/****** Object:  Schema [Verification]    Script Date: 2014-11-06 23:15:30 ******/
CREATE SCHEMA [Verification]
GO
/****** Object:  Table [Common].[Employee]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Common].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Rank_Id] [int] NULL,
	[Organization_Id] [int] NOT NULL,
	[OrganizationalUnit_Id] [int] NULL,
	[Position_Id] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Common].[Operator]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Common].[Operator](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Rank_Id] [int] NULL,
	[Postion_Id] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Common].[Organization]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Common].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Common].[OrganizationalUnit]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Common].[OrganizationalUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[MasterUnit_Id] [int] NULL,
	[Organization_Id] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_OrganizationalUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Common].[Position]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Common].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Postion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Common].[Rank]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Common].[Rank](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group_Id] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Rank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Cooperation].[Category]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cooperation].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group_Id] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Cooperation].[ConductingOfficer]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cooperation].[ConductingOfficer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [nvarchar](10) NOT NULL,
	[EndDate] [nvarchar](10) NULL,
	[Employee_Id] [int] NOT NULL,
	[ConductingUnit_Id] [int] NOT NULL,
 CONSTRAINT [PK_ConductingOfficer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Cooperation].[ConductingUnit]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cooperation].[ConductingUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [nvarchar](10) NOT NULL,
	[EndDate] [nvarchar](10) NULL,
	[OrganizationalUnit_Id] [int] NOT NULL,
	[Cooperation_Id] [int] NOT NULL,
 CONSTRAINT [PK_ConductingUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Cooperation].[Cooperation]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Cooperation].[Cooperation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNum] [nvarchar](50) NOT NULL,
	[StartDate] [varchar](10) NOT NULL,
	[Notes] [ntext] NULL,
	[EndDate] [varchar](10) NULL,
	[EndReason_Id] [int] NULL,
	[RankGroup_Id] [int] NOT NULL,
	[ObtainingBase_Id] [int] NOT NULL,
	[Person_Id] [int] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[Creator_Id] [int] NOT NULL,
	[RegEndTime] [datetime] NULL,
	[RegEndOperator_Id] [int] NULL,
 CONSTRAINT [PK_Cooperation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Cooperation].[CooperationEndReason]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cooperation].[CooperationEndReason](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group_Id] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_EndReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Cooperation].[Interaction]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cooperation].[Interaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Id] [int] NOT NULL,
	[StartDate] [nvarchar](10) NOT NULL,
	[EndDate] [nvarchar](10) NULL,
	[Cooperation_Id] [int] NOT NULL,
 CONSTRAINT [PK_Interaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Cooperation].[ObtainingBase]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cooperation].[ObtainingBase](
	[Id] [int] NOT NULL,
	[Group_Id] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ObtainingBase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Cooperation].[PersonAlias]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cooperation].[PersonAlias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AliasName] [nvarchar](50) NOT NULL,
	[ValidFromDate] [nvarchar](10) NOT NULL,
	[ValidToDate] [nvarchar](10) NULL,
	[CooperationId] [int] NOT NULL,
 CONSTRAINT [PK_PersonAlias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Cooperation].[Suspension]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Cooperation].[Suspension](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [nvarchar](10) NOT NULL,
	[EndDate] [nvarchar](10) NULL,
	[Cooperation_Id] [int] NOT NULL,
 CONSTRAINT [PK_Suspension] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Issue].[Activity]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Issue].[Activity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNum] [nvarchar](50) NOT NULL,
	[StartDate] [nvarchar](10) NOT NULL,
	[EndDate] [nvarchar](10) NULL,
	[AcivityType_Id] [int] NOT NULL,
	[Issue_Id] [int] NOT NULL,
	[Notes] [ntext] NULL,
	[CreationTime] [datetime] NOT NULL,
	[Creator_Id] [int] NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Issue].[ActivityType]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Issue].[ActivityType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group_Id] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ActivityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Issue].[InvolvedPerson]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Issue].[InvolvedPerson](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [nvarchar](10) NOT NULL,
	[EndDate] [nvarchar](10) NULL,
	[Notes] [ntext] NULL,
	[InvolveType_Id] [int] NOT NULL,
	[Issue_Id] [int] NOT NULL,
	[Person_Id] [int] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[Creator_Id] [int] NOT NULL,
 CONSTRAINT [PK_InvolvedPerson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Issue].[InvolveType]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Issue].[InvolveType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group_Id] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_InvolvingType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Issue].[Issue]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Issue].[Issue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegNum] [nvarchar](50) NULL,
	[StartDate] [nvarchar](10) NOT NULL,
	[EndDate] [nvarchar](10) NULL,
	[Notes] [ntext] NULL,
	[CreationTime] [datetime] NOT NULL,
	[Creator_Id] [int] NOT NULL,
 CONSTRAINT [PK_Case] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Issue].[IssueCharakteristic]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Issue].[IssueCharakteristic](
	[Issue_Id] [int] NOT NULL,
	[IssueType_Id] [int] NOT NULL,
 CONSTRAINT [PK_IssueCharakteristics] PRIMARY KEY CLUSTERED 
(
	[Issue_Id] ASC,
	[IssueType_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Issue].[IssueType]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Issue].[IssueType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Group_Id] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_IssueType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Citizenship]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Citizenship](
	[PersonId] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_PersonCitizenships] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC,
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Country]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Country](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Person].[Person]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Person].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PESEL] [nvarchar](11) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL CONSTRAINT [DF_People_secondName]  DEFAULT (''),
	[BirthDate] [nvarchar](50) NULL,
	[BirthPlace] [nvarchar](100) NULL,
	[FatherName] [nvarchar](50) NULL,
	[MotherName] [nvarchar](50) NULL,
	[MotherMaidenName] [nvarchar](50) NULL,
	[NationalityId] [int] NULL,
	[Sex] [nvarchar](1) NULL,
	[HasPESEL] [bit] NOT NULL CONSTRAINT [DF_Person_HasPesel]  DEFAULT ((1)),
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Reservation].[Prolongation]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reservation].[Prolongation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EndDate] [date] NOT NULL,
	[ConductingOfficer_Id] [int] NOT NULL,
	[ConductingUnit_Id] [int] NOT NULL,
	[Reservation_Id] [int] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[Creator_Id] [int] NOT NULL,
 CONSTRAINT [PK_ReservationProlongations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Reservation].[Purpose]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reservation].[Purpose](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ReservationPurposes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Reservation].[Reservation]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reservation].[Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[TerminationDate] [date] NULL,
	[Notes] [ntext] NULL,
	[Person_Id] [int] NULL,
	[ConductingOfficer_Id] [int] NOT NULL,
	[ConductingUnit_Id] [int] NULL,
	[ReservationPurpose_Id] [int] NOT NULL,
	[EndReason_Id] [int] NULL,
	[Terminator_Id] [int] NULL,
	[CreationTime] [datetime] NOT NULL,
	[Creator_Id] [int] NOT NULL,
 CONSTRAINT [PK_Reservations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [Reservation].[ReservationEndReason]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reservation].[ReservationEndReason](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TerminationReasons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Verification].[Question]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Verification].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocNum] [nvarchar](50) NULL,
	[Form_Id] [int] NOT NULL,
	[Reason_Id] [int] NOT NULL,
	[AskerOrganization_Id] [int] NOT NULL,
	[AskerUnit_Id] [int] NULL,
	[Asker] [nvarchar](50) NULL,
	[AskerRank_Id] [int] NULL,
	[SignerPosition_Id] [int] NULL,
	[Signer] [nvarchar](50) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Verification].[QuestionForm]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Verification].[QuestionForm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_QuestionForm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Verification].[QuestionReason]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Verification].[QuestionReason](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[DisplayOrder] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_QuestionReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Verification].[Verification]    Script Date: 2014-11-06 23:15:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Verification].[Verification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Person_Id] [int] NOT NULL,
	[Question_Id] [int] NOT NULL,
	[ResultsNote] [ntext] NULL,
	[IsRegistered] [bit] NOT NULL,
	[Notes] [ntext] NULL,
	[Creator_Id] [int] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Verification.Verifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [INX_People_Unique_Pesel]    Script Date: 2014-11-06 23:15:30 ******/
CREATE UNIQUE NONCLUSTERED INDEX [INX_People_Unique_Pesel] ON [Person].[Person]
(
	[PESEL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Common].[Operator] ADD  CONSTRAINT [DF_Users_RankTittle_Id]  DEFAULT ((1)) FOR [Rank_Id]
GO
ALTER TABLE [Common].[Organization] ADD  CONSTRAINT [DF_Organization_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Common].[Organization] ADD  CONSTRAINT [DF_Organization_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Common].[OrganizationalUnit] ADD  CONSTRAINT [DF_OrganizationalUnits_displayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Common].[OrganizationalUnit] ADD  CONSTRAINT [DF_OrganizationalUnits_active]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Common].[Position] ADD  CONSTRAINT [DF_Postion_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Common].[Position] ADD  CONSTRAINT [DF_Postion_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Common].[Rank] ADD  CONSTRAINT [DF_Rank_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Common].[Rank] ADD  CONSTRAINT [DF_Rank_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Cooperation].[Category] ADD  CONSTRAINT [DF_Category_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Cooperation].[Category] ADD  CONSTRAINT [DF_Category_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Cooperation].[Cooperation] ADD  CONSTRAINT [DF_Cooperation_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO
ALTER TABLE [Cooperation].[CooperationEndReason] ADD  CONSTRAINT [DF_EndReason_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Cooperation].[CooperationEndReason] ADD  CONSTRAINT [DF_EndReason_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Cooperation].[ObtainingBase] ADD  CONSTRAINT [DF_ObtainingBase_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Cooperation].[ObtainingBase] ADD  CONSTRAINT [DF_ObtainingBase_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Issue].[Activity] ADD  CONSTRAINT [DF_Activity_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO
ALTER TABLE [Issue].[ActivityType] ADD  CONSTRAINT [DF_ActivityType_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Issue].[ActivityType] ADD  CONSTRAINT [DF_ActivityType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Issue].[InvolvedPerson] ADD  CONSTRAINT [DF_InvolvedPerson_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO
ALTER TABLE [Issue].[InvolveType] ADD  CONSTRAINT [DF_InvolvingType_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Issue].[InvolveType] ADD  CONSTRAINT [DF_InvolvingType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Issue].[Issue] ADD  CONSTRAINT [DF_Case_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO
ALTER TABLE [Issue].[IssueType] ADD  CONSTRAINT [DF_IssueType_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Issue].[IssueType] ADD  CONSTRAINT [DF_IssueType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Person].[Country] ADD  CONSTRAINT [DF_Countries_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Person].[Country] ADD  CONSTRAINT [DF_Countries_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Reservation].[Prolongation] ADD  CONSTRAINT [DF_ReservationProlongations_creationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO
ALTER TABLE [Reservation].[Purpose] ADD  CONSTRAINT [DF_ReservationPurposes_displayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Reservation].[Purpose] ADD  CONSTRAINT [DF_ReservationPurposes_active]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Reservation].[Reservation] ADD  CONSTRAINT [DF_Reservations_creationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO
ALTER TABLE [Reservation].[ReservationEndReason] ADD  CONSTRAINT [DF_TerminationReasons_displayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Reservation].[ReservationEndReason] ADD  CONSTRAINT [DF_TerminationReasons_active]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Verification].[QuestionForm] ADD  CONSTRAINT [DF_QuestionForm_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Verification].[QuestionForm] ADD  CONSTRAINT [DF_QuestionForm_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Verification].[QuestionReason] ADD  CONSTRAINT [DF_QuestionReason_DisplayOrder]  DEFAULT ((0)) FOR [DisplayOrder]
GO
ALTER TABLE [Verification].[QuestionReason] ADD  CONSTRAINT [DF_QuestionReason_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Common].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_OrganizationalUnit] FOREIGN KEY([OrganizationalUnit_Id])
REFERENCES [Common].[OrganizationalUnit] ([Id])
GO
ALTER TABLE [Common].[Employee] CHECK CONSTRAINT [FK_Employee_OrganizationalUnit]
GO
ALTER TABLE [Common].[Operator]  WITH CHECK ADD  CONSTRAINT [FK_Operator_Postion] FOREIGN KEY([Postion_Id])
REFERENCES [Common].[Position] ([Id])
GO
ALTER TABLE [Common].[Operator] CHECK CONSTRAINT [FK_Operator_Postion]
GO
ALTER TABLE [Common].[Operator]  WITH CHECK ADD  CONSTRAINT [FK_Operator_Rank] FOREIGN KEY([Rank_Id])
REFERENCES [Common].[Rank] ([Id])
GO
ALTER TABLE [Common].[Operator] CHECK CONSTRAINT [FK_Operator_Rank]
GO
ALTER TABLE [Common].[OrganizationalUnit]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationalUnit_Organization] FOREIGN KEY([Organization_Id])
REFERENCES [Common].[Organization] ([Id])
GO
ALTER TABLE [Common].[OrganizationalUnit] CHECK CONSTRAINT [FK_OrganizationalUnit_Organization]
GO
ALTER TABLE [Person].[Citizenship]  WITH CHECK ADD  CONSTRAINT [FK_PersonCitizenships_Countries] FOREIGN KEY([CountryId])
REFERENCES [Person].[Country] ([Id])
GO
ALTER TABLE [Person].[Citizenship] CHECK CONSTRAINT [FK_PersonCitizenships_Countries]
GO
ALTER TABLE [Person].[Citizenship]  WITH CHECK ADD  CONSTRAINT [FK_PersonCitizenships_Persons] FOREIGN KEY([PersonId])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Person].[Citizenship] CHECK CONSTRAINT [FK_PersonCitizenships_Persons]
GO
ALTER TABLE [Person].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Countries] FOREIGN KEY([NationalityId])
REFERENCES [Person].[Country] ([Id])
GO
ALTER TABLE [Person].[Person] CHECK CONSTRAINT [FK_Persons_Countries]
GO
ALTER TABLE [Reservation].[Prolongation]  WITH CHECK ADD  CONSTRAINT [FK_Prolongation_Employee] FOREIGN KEY([ConductingOfficer_Id])
REFERENCES [Common].[Employee] ([Id])
GO
ALTER TABLE [Reservation].[Prolongation] CHECK CONSTRAINT [FK_Prolongation_Employee]
GO
ALTER TABLE [Reservation].[Prolongation]  WITH CHECK ADD  CONSTRAINT [FK_Prolongation_OrganizationalUnit] FOREIGN KEY([ConductingUnit_Id])
REFERENCES [Common].[OrganizationalUnit] ([Id])
GO
ALTER TABLE [Reservation].[Prolongation] CHECK CONSTRAINT [FK_Prolongation_OrganizationalUnit]
GO
ALTER TABLE [Reservation].[Prolongation]  WITH CHECK ADD  CONSTRAINT [FK_ReservationProlongations_Reservations] FOREIGN KEY([Reservation_Id])
REFERENCES [Reservation].[Reservation] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Reservation].[Prolongation] CHECK CONSTRAINT [FK_ReservationProlongations_Reservations]
GO
ALTER TABLE [Reservation].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Employee] FOREIGN KEY([ConductingOfficer_Id])
REFERENCES [Common].[Employee] ([Id])
GO
ALTER TABLE [Reservation].[Reservation] CHECK CONSTRAINT [FK_Reservation_Employee]
GO
ALTER TABLE [Reservation].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Operator] FOREIGN KEY([Terminator_Id])
REFERENCES [Common].[Operator] ([Id])
GO
ALTER TABLE [Reservation].[Reservation] CHECK CONSTRAINT [FK_Reservation_Operator]
GO
ALTER TABLE [Reservation].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_OrganizationalUnits] FOREIGN KEY([ConductingUnit_Id])
REFERENCES [Common].[OrganizationalUnit] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Reservation].[Reservation] CHECK CONSTRAINT [FK_Reservations_OrganizationalUnits]
GO
ALTER TABLE [Reservation].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_People] FOREIGN KEY([Person_Id])
REFERENCES [Person].[Person] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [Reservation].[Reservation] CHECK CONSTRAINT [FK_Reservations_People]
GO
ALTER TABLE [Reservation].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_ReservationPurposes] FOREIGN KEY([ReservationPurpose_Id])
REFERENCES [Reservation].[Purpose] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Reservation].[Reservation] CHECK CONSTRAINT [FK_Reservations_ReservationPurposes]
GO
ALTER TABLE [Reservation].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_ReservationTerminationReasons] FOREIGN KEY([EndReason_Id])
REFERENCES [Reservation].[ReservationEndReason] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Reservation].[Reservation] CHECK CONSTRAINT [FK_Reservations_ReservationTerminationReasons]
GO
ALTER TABLE [Reservation].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Users] FOREIGN KEY([Creator_Id])
REFERENCES [Common].[Operator] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Reservation].[Reservation] CHECK CONSTRAINT [FK_Reservations_Users]
GO
ALTER TABLE [Reservation].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservations_Users1] FOREIGN KEY([Terminator_Id])
REFERENCES [Common].[Operator] ([Id])
GO
ALTER TABLE [Reservation].[Reservation] CHECK CONSTRAINT [FK_Reservations_Users1]
GO
ALTER TABLE [Verification].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Organization] FOREIGN KEY([AskerOrganization_Id])
REFERENCES [Common].[Organization] ([Id])
GO
ALTER TABLE [Verification].[Question] CHECK CONSTRAINT [FK_Question_Organization]
GO
ALTER TABLE [Verification].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_OrganizationalUnit] FOREIGN KEY([AskerUnit_Id])
REFERENCES [Common].[OrganizationalUnit] ([Id])
GO
ALTER TABLE [Verification].[Question] CHECK CONSTRAINT [FK_Question_OrganizationalUnit]
GO
ALTER TABLE [Verification].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Postion] FOREIGN KEY([SignerPosition_Id])
REFERENCES [Common].[Position] ([Id])
GO
ALTER TABLE [Verification].[Question] CHECK CONSTRAINT [FK_Question_Postion]
GO
ALTER TABLE [Verification].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionForm] FOREIGN KEY([Form_Id])
REFERENCES [Verification].[QuestionForm] ([Id])
GO
ALTER TABLE [Verification].[Question] CHECK CONSTRAINT [FK_Question_QuestionForm]
GO
ALTER TABLE [Verification].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_QuestionReason] FOREIGN KEY([Reason_Id])
REFERENCES [Verification].[QuestionReason] ([Id])
GO
ALTER TABLE [Verification].[Question] CHECK CONSTRAINT [FK_Question_QuestionReason]
GO
ALTER TABLE [Verification].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Rank] FOREIGN KEY([AskerRank_Id])
REFERENCES [Common].[Rank] ([Id])
GO
ALTER TABLE [Verification].[Question] CHECK CONSTRAINT [FK_Question_Rank]
GO
ALTER TABLE [Verification].[Verification]  WITH CHECK ADD  CONSTRAINT [FK_Verification_Operator] FOREIGN KEY([Creator_Id])
REFERENCES [Common].[Operator] ([Id])
GO
ALTER TABLE [Verification].[Verification] CHECK CONSTRAINT [FK_Verification_Operator]
GO
ALTER TABLE [Verification].[Verification]  WITH CHECK ADD  CONSTRAINT [FK_Verification_Person] FOREIGN KEY([Id])
REFERENCES [Person].[Person] ([Id])
GO
ALTER TABLE [Verification].[Verification] CHECK CONSTRAINT [FK_Verification_Person]
GO
ALTER TABLE [Verification].[Verification]  WITH CHECK ADD  CONSTRAINT [FK_Verification_Question] FOREIGN KEY([Question_Id])
REFERENCES [Verification].[Question] ([Id])
GO
ALTER TABLE [Verification].[Verification] CHECK CONSTRAINT [FK_Verification_Question]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stanowisko służbowe' , @level0type=N'SCHEMA',@level0name=N'Common', @level1type=N'TABLE',@level1name=N'Employee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Rodzaj współpracy' , @level0type=N'SCHEMA',@level0name=N'Cooperation', @level1type=N'TABLE',@level1name=N'Interaction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Płeć' , @level0type=N'SCHEMA',@level0name=N'Person', @level1type=N'TABLE',@level1name=N'Person', @level2type=N'COLUMN',@level2name=N'Sex'
GO
USE [master]
GO
ALTER DATABASE [KseoContext] SET  READ_WRITE 
GO
