USE [master]
GO
/****** Object:  Database [Test11234]    Script Date: 21.01.2025 12:38:04 ******/
CREATE DATABASE [Test11234]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Test11234', FILENAME = N'C:\SQL2022\MSSQL16.MSSQLSERVER\MSSQL\DATA\Test11234.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Test11234_log', FILENAME = N'C:\SQL2022\MSSQL16.MSSQLSERVER\MSSQL\DATA\Test11234_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Test11234] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Test11234].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Test11234] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Test11234] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Test11234] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Test11234] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Test11234] SET ARITHABORT OFF 
GO
ALTER DATABASE [Test11234] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Test11234] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Test11234] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Test11234] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Test11234] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Test11234] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Test11234] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Test11234] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Test11234] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Test11234] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Test11234] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Test11234] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Test11234] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Test11234] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Test11234] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Test11234] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Test11234] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Test11234] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Test11234] SET  MULTI_USER 
GO
ALTER DATABASE [Test11234] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Test11234] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Test11234] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Test11234] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Test11234] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Test11234] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Test11234] SET QUERY_STORE = ON
GO
ALTER DATABASE [Test11234] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Test11234]
GO
/****** Object:  Table [dbo].[Absences]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absences](
	[AbsenceID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[SubstituteID] [int] NULL,
	[Reason] [nvarchar](max) NULL,
 CONSTRAINT [PK_Absences] PRIMARY KEY CLUSTERED 
(
	[AbsenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendars]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendars](
	[CalendarID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[CalendarTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Calendars] PRIMARY KEY CLUSTERED 
(
	[CalendarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalendarTypes]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarTypes](
	[CalendarTypeID] [int] IDENTITY(1,1) NOT NULL,
	[CalendarTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CalendarTypes] PRIMARY KEY CLUSTERED 
(
	[CalendarTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Canditates]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Canditates](
	[Candidate] [int] IDENTITY(1,1) NOT NULL,
	[FirtsName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[ApplicationDate] [date] NOT NULL,
	[Field] [nvarchar](100) NOT NULL,
	[Resume] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Canditates] PRIMARY KEY CLUSTERED 
(
	[Candidate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Document_id] [int] NOT NULL,
	[Text] [nvarchar](100) NOT NULL,
	[Date_created] [datetime] NOT NULL,
	[Date_updated] [datetime] NOT NULL,
	[AuthorID] [int] NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ManagerID] [int] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Date_created] [datetime] NOT NULL,
	[Date_updated] [datetime] NOT NULL,
	[Category] [nvarchar](100) NOT NULL,
	[Has_comments] [bit] NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MobilePhone] [nvarchar](20) NULL,
	[BirthDate] [date] NULL,
	[DepartmentID] [int] NULL,
	[PositionID] [int] NULL,
	[SupervisorID] [int] NULL,
	[AssistantID] [int] NULL,
	[WorkPhone] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Office] [nvarchar](10) NOT NULL,
	[AdditionalInfo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[CalendarID] [int] NOT NULL,
	[EventName] [nvarchar](100) NOT NULL,
	[EventTypeID] [int] NOT NULL,
	[EventStatusID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[ResponsiblePersons] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventStatuses]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventStatuses](
	[EventStatusID] [int] IDENTITY(1,1) NOT NULL,
	[EventStatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EventStatuses] PRIMARY KEY CLUSTERED 
(
	[EventStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventTypes]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTypes](
	[EventTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EventTypes] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[MaterialID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialName] [nvarchar](100) NOT NULL,
	[ApprovalDate] [date] NOT NULL,
	[ModificationDate] [date] NOT NULL,
	[MaterialStatusID] [int] NOT NULL,
	[MaterialTypeID] [int] NOT NULL,
	[Domain] [nvarchar](100) NOT NULL,
	[Author] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[MaterialID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialStatuses]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialStatuses](
	[MaterialStatusID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialStatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MaterialStatuses] PRIMARY KEY CLUSTERED 
(
	[MaterialStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialTypes]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialTypes](
	[MaterialTypeID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MaterialTypes] PRIMARY KEY CLUSTERED 
(
	[MaterialTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[PositionID] [int] IDENTITY(1,1) NOT NULL,
	[PositionName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[PositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingClasses12]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingClasses12](
	[TrainingID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[MaterialID] [int] NULL,
	[TrainingDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_TrainingClasses12] PRIMARY KEY CLUSTERED 
(
	[TrainingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 21.01.2025 12:38:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Absences]  WITH CHECK ADD  CONSTRAINT [FK_Absences_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Absences] CHECK CONSTRAINT [FK_Absences_Employees]
GO
ALTER TABLE [dbo].[Calendars]  WITH CHECK ADD  CONSTRAINT [FK_Calendars_CalendarTypes] FOREIGN KEY([CalendarTypeID])
REFERENCES [dbo].[CalendarTypes] ([CalendarTypeID])
GO
ALTER TABLE [dbo].[Calendars] CHECK CONSTRAINT [FK_Calendars_CalendarTypes]
GO
ALTER TABLE [dbo].[Calendars]  WITH CHECK ADD  CONSTRAINT [FK_Calendars_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Calendars] CHECK CONSTRAINT [FK_Calendars_Departments]
GO
ALTER TABLE [dbo].[Calendars]  WITH CHECK ADD  CONSTRAINT [FK_Calendars_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Calendars] CHECK CONSTRAINT [FK_Calendars_Employees]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Documents] FOREIGN KEY([ID])
REFERENCES [dbo].[Documents] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Documents]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Employees] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Employees]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Employees] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Employees]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Departments] ([DepartmentID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([SupervisorID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees1] FOREIGN KEY([AssistantID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees1]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Positions] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Positions] ([PositionID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Positions]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Calendars] FOREIGN KEY([CalendarID])
REFERENCES [dbo].[Calendars] ([CalendarID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Calendars]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventStatuses] FOREIGN KEY([EventStatusID])
REFERENCES [dbo].[EventStatuses] ([EventStatusID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventStatuses]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventTypes] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventTypes] ([EventTypeID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventTypes]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_MaterialStatuses] FOREIGN KEY([MaterialStatusID])
REFERENCES [dbo].[MaterialStatuses] ([MaterialStatusID])
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_MaterialStatuses]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_MaterialTypes] FOREIGN KEY([MaterialTypeID])
REFERENCES [dbo].[MaterialTypes] ([MaterialTypeID])
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_MaterialTypes]
GO
ALTER TABLE [dbo].[TrainingClasses12]  WITH CHECK ADD  CONSTRAINT [FK_TrainingClasses12_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[TrainingClasses12] CHECK CONSTRAINT [FK_TrainingClasses12_Events]
GO
ALTER TABLE [dbo].[TrainingClasses12]  WITH CHECK ADD  CONSTRAINT [FK_TrainingClasses12_Materials] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Materials] ([MaterialID])
GO
ALTER TABLE [dbo].[TrainingClasses12] CHECK CONSTRAINT [FK_TrainingClasses12_Materials]
GO
USE [master]
GO
ALTER DATABASE [Test11234] SET  READ_WRITE 
GO
