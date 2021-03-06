USE [master]
/****** Object:  Database [assadara_ssms]    Script Date: 23/11/2018 10:50:01 PM ******/
CREATE DATABASE [assadara_ssms]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ssms', FILENAME = N'G:\4-Developer.Work\SQLServerDBs\SSMSDB\assadara_ssms.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ssms_log', FILENAME = N'G:\4-Developer.Work\SQLServerDBs\SSMSDB\assadara_ssms.ldf' , SIZE = 39296KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE Arabic_100_CI_AS
GO
ALTER DATABASE [assadara_ssms] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [assadara_ssms].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [assadara_ssms] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [assadara_ssms] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [assadara_ssms] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [assadara_ssms] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [assadara_ssms] SET ARITHABORT OFF 
GO
ALTER DATABASE [assadara_ssms] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [assadara_ssms] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [assadara_ssms] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [assadara_ssms] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [assadara_ssms] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [assadara_ssms] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [assadara_ssms] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [assadara_ssms] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [assadara_ssms] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [assadara_ssms] SET  DISABLE_BROKER 
GO
ALTER DATABASE [assadara_ssms] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [assadara_ssms] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [assadara_ssms] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [assadara_ssms] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [assadara_ssms] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [assadara_ssms] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [assadara_ssms] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [assadara_ssms] SET RECOVERY FULL 
GO
ALTER DATABASE [assadara_ssms] SET  MULTI_USER 
GO
ALTER DATABASE [assadara_ssms] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [assadara_ssms] SET DB_CHAINING OFF 
GO
ALTER DATABASE [assadara_ssms] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [assadara_ssms] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [assadara_ssms] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [assadara_ssms] SET QUERY_STORE = OFF
GO
USE [assadara_ssms]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
/****** Object:  Table [dbo].[academicSemesters]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[academicSemesters](
	[semesterId] [tinyint] NOT NULL,
	[yearId] [tinyint] NULL,
	[semesterNameAr] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[semesterNameEn] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[semesterStartDateG] [date] NULL,
	[semesterStartDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[semesterEndDateG] [date] NULL,
	[semesterEndDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_AcademicSemesters] PRIMARY KEY CLUSTERED 
(
	[semesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[academicSemesters] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[academicWeeks]    Script Date: 23/11/2018 10:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[academicWeeks](
	[weekId] [smallint] NOT NULL,
	[semesterId] [tinyint] NULL,
	[weekNameAr] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[weekNameEn] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[weekStartDateG] [date] NULL,
	[weekStartDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WeekEndDateG] [date] NULL,
	[WeekEndDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_academicWeeks] PRIMARY KEY CLUSTERED 
(
	[weekId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[academicWeeks] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[academicYears]    Script Date: 23/11/2018 10:50:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[academicYears](
	[yearId] [tinyint] NOT NULL,
	[yearNameG] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[yearNameH] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[yearStartDateG] [date] NULL,
	[yearStartDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[yearEndDateG] [date] NULL,
	[yearEndDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_academicYears] PRIMARY KEY CLUSTERED 
(
	[yearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[academicYears] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[accountStatus]    Script Date: 23/11/2018 10:50:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountStatus](
	[statusId] [tinyint] NOT NULL,
	[statusAr] [nvarchar](20) COLLATE Arabic_100_CI_AS NULL,
	[statusEn] [nvarchar](20) COLLATE Arabic_100_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_accountStatus] PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[accountStatus] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[actions]    Script Date: 23/11/2018 10:50:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[actions](
	[actionId] [smallint] NOT NULL,
	[actionNameAr] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[actionNameEn] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[actionUrl] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_actions] PRIMARY KEY CLUSTERED 
(
	[actionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[actions] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[behavioralViolations]    Script Date: 23/11/2018 10:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[behavioralViolations](
	[violationId] [smallint] NOT NULL,
	[violationNameAr] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[violationNameEn] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[categoryId] [tinyint] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_behavioralViolations_1] PRIMARY KEY CLUSTERED 
(
	[violationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[behavioralViolations] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[branches]    Script Date: 23/11/2018 10:50:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branches](
	[branchId] [tinyint] NOT NULL,
	[branchNameAr] [nvarchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[branchNameEn] [nvarchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[schoolId] [tinyint] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_sections] PRIMARY KEY CLUSTERED 
(
	[branchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[branches] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[classesStudents]    Script Date: 23/11/2018 10:50:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classesStudents](
	[classStudentId] [int] NOT NULL,
	[studentId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[yearId] [tinyint] NULL,
	[classroomId] [smallint] NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_studentsEdu] PRIMARY KEY CLUSTERED 
(
	[classStudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[classesStudents] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[classrooms]    Script Date: 23/11/2018 10:50:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classrooms](
	[classroomId] [smallint] NOT NULL,
	[gradeId] [tinyint] NULL,
	[classNameAr] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[classNameEn] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_classes] PRIMARY KEY CLUSTERED 
(
	[classroomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[classrooms] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[countries]    Script Date: 23/11/2018 10:50:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[countries](
	[countryId] [tinyint] NOT NULL,
	[countryAr] [nvarchar](50) COLLATE Arabic_100_CI_AS NOT NULL,
	[countryEn] [nvarchar](50) COLLATE Arabic_100_CI_AS NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_countries] PRIMARY KEY CLUSTERED 
(
	[countryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[countries] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[departments]    Script Date: 23/11/2018 10:50:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[departmentId] [tinyint] NOT NULL,
	[departmentNameAr] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[departmentNameEn] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[departments] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[docTypes]    Script Date: 23/11/2018 10:50:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[docTypes](
	[docTypeId] [tinyint] NOT NULL,
	[docTypeAr] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[docTypeEn] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_docTypes] PRIMARY KEY CLUSTERED 
(
	[docTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[docTypes] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[employees]    Script Date: 23/11/2018 10:50:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[empId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[fNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[fNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gender] [bit] NULL,
	[IdType] [tinyint] NULL,
	[IdIssuePlace] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IdExpireDateG] [date] NULL,
	[idExpireDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[countryId] [tinyint] NULL,
	[mobile] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mobile2] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[phone] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[birthDateG] [date] NULL,
	[birthDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[birthPlace] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[maritalStatus] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[religion] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[passportNum] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[passpoerExpireDateG] [date] NULL,
	[passpoerExpireDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[addressKsa] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[addressHome] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[certificateDegree] [tinyint] NULL,
	[certificateName] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[certificateDate] [nchar](7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[certificateGrade] [tinyint] NULL,
	[certificateMajor] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativeName] [nvarchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativeAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativeMobile] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativePhone] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[poBox] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[poCode] [nvarchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[hasDrivingLicense] [bit] NULL,
	[isHandicapped] [bit] NULL,
	[specialNeeds] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_employees] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[employees] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[employeesActions]    Script Date: 23/11/2018 10:50:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeesActions](
	[empJobId] [int] NOT NULL,
	[actionId] [smallint] NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_employeesActions] PRIMARY KEY CLUSTERED 
(
	[empJobId] ASC,
	[actionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[employeesActions] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[employeesFinance]    Script Date: 23/11/2018 10:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeesFinance](
	[empId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[bankName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[bankAccount] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[bankIban] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[basicSalary] [smallmoney] NULL,
	[housingAllowance] [smallmoney] NULL,
	[experienceAllowance] [smallmoney] NULL,
	[transportAllowance] [smallmoney] NULL,
	[otherAllowance] [smallmoney] NULL,
	[totalSalary] [smallmoney] NULL,
	[loans] [smallmoney] NULL,
	[debts] [smallmoney] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_employeesFinance] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[employeesFinance] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[employeesHR]    Script Date: 23/11/2018 10:50:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeesHR](
	[empId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[jobInId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[contractType] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[socialSecuritySubscription] [bit] NULL,
	[socialSecurityNum] [int] NULL,
	[ceoApproval] [smalldatetime] NULL,
	[SalahiaNum] [int] NULL,
	[SalahiaDateG] [date] NULL,
	[SalahiaDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[wrokStartDateG] [date] NULL,
	[workStartDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[noorRegistered] [bit] NULL,
	[workStatus] [tinyint] NULL,
	[hrNotes] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_EmployeesHr] PRIMARY KEY CLUSTERED 
(
	[empId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[employeesHR] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[employeesJobs]    Script Date: 23/11/2018 10:50:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employeesJobs](
	[empJobId] [int] NOT NULL,
	[empId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[jobId] [smallint] NOT NULL,
	[branchId] [tinyint] NULL,
	[departmentId] [tinyint] NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_employeesPositions] PRIMARY KEY CLUSTERED 
(
	[empJobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[employeesJobs] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[grades]    Script Date: 23/11/2018 10:50:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[grades](
	[gradeId] [tinyint] NOT NULL,
	[stageId] [tinyint] NULL,
	[gradeNameAr] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gradeNameEn] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_grades] PRIMARY KEY CLUSTERED 
(
	[gradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[grades] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[gradesSubjects]    Script Date: 23/11/2018 10:50:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gradesSubjects](
	[gradeSubjectId] [smallint] NOT NULL,
	[gradeId] [tinyint] NOT NULL,
	[subjectId] [tinyint] NOT NULL,
	[periodsCount] [tinyint] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_gradesSubjects] PRIMARY KEY CLUSTERED 
(
	[gradeSubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[gradesSubjects] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[jobs]    Script Date: 23/11/2018 10:50:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jobs](
	[jobId] [smallint] NOT NULL,
	[jobNameAr] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[jobNameEn] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[jobDescription] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_positions] PRIMARY KEY CLUSTERED 
(
	[jobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[jobs] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[jobsActions]    Script Date: 23/11/2018 10:50:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jobsActions](
	[jobId] [smallint] NOT NULL,
	[actionId] [smallint] NOT NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_jobsActions] PRIMARY KEY CLUSTERED 
(
	[jobId] ASC,
	[actionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[jobsActions] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[lessons]    Script Date: 23/11/2018 10:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lessons](
	[lessonId] [int] NOT NULL,
	[gradeSubjectId] [smallint] NULL,
	[semesterId] [tinyint] NULL,
	[lessonTitle] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lessonObjectives] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_syllabusOutlines] PRIMARY KEY CLUSTERED 
(
	[lessonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[lessons] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[lessonsFiles]    Script Date: 23/11/2018 10:50:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lessonsFiles](
	[lessonFileId] [int] NOT NULL,
	[lessonId] [int] NULL,
	[docTypeId] [tinyint] NULL,
	[filePath] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[createdBy] [int] NULL,
	[createdAt] [smalldatetime] NULL,
	[isExternalLink] [bit] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_syllabusFiles] PRIMARY KEY CLUSTERED 
(
	[lessonFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[lessonsFiles] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[majors]    Script Date: 23/11/2018 10:50:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[majors](
	[majorId] [tinyint] NOT NULL,
	[majorNameAr] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[majorNameEn] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_majors] PRIMARY KEY CLUSTERED 
(
	[majorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[majors] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[parents]    Script Date: 23/11/2018 10:50:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[parents](
	[parentId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[fNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[fNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IdType] [tinyint] NULL,
	[IdIssuePlace] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IdExpireDateG] [date] NULL,
	[idExpireDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mobile1] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mobile2] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[countryId] [tinyint] NULL,
	[phone] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[houseNum] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[street] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[district] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cityId] [tinyint] NULL,
	[job] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[workAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[workPhone] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativeName] [nvarchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativeMobile] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativePhone] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativeAddress] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[relativeRelation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_parents] PRIMARY KEY CLUSTERED 
(
	[parentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[parents] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[periods]    Script Date: 23/11/2018 10:50:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periods](
	[periodId] [int] NOT NULL,
	[semesterId] [tinyint] NULL,
	[classeroomId] [smallint] NULL,
	[gradeSubjectId] [smallint] NULL,
	[empJobId] [int] NULL,
	[schoolDayEventId] [smallint] NULL,
	[periodDate] [date] NULL,
	[startTime] [time](7) NULL,
	[endTime] [time](7) NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_periods] PRIMARY KEY CLUSTERED 
(
	[periodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[periods] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[periodsDetails]    Script Date: 23/11/2018 10:50:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periodsDetails](
	[periodDetailId] [bigint] NOT NULL,
	[periodId] [int] NULL,
	[studentId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[attandanceTime] [time](7) NULL,
	[leaveTime] [time](7) NULL,
	[isEalryExit] [bit] NULL,
	[homeworkRate] [tinyint] NULL,
	[participationsCount] [tinyint] NULL,
	[participationsQuality] [tinyint] NULL,
	[notes] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_periodsDetails] PRIMARY KEY CLUSTERED 
(
	[periodDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[periodsDetails] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[periodsFiles]    Script Date: 23/11/2018 10:50:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[periodsFiles](
	[periodFileId] [int] NOT NULL,
	[docTypeId] [tinyint] NULL,
	[weekPlanId] [smallint] NULL,
	[filePath] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[createdBy] [int] NULL,
	[createdAt] [smalldatetime] NULL,
	[isExternalLink] [bit] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_lessonsFiles] PRIMARY KEY CLUSTERED 
(
	[periodFileId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[periodsFiles] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[refreshTokens]    Script Date: 23/11/2018 10:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[refreshTokens](
	[tokenId] [int] IDENTITY(1,1) NOT NULL,
	[token] [char](44) COLLATE Arabic_100_CI_AS NULL,
	[deviceInfo] [varchar](max) COLLATE Arabic_100_CI_AS NOT NULL,
	[userId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_refreshTokens] PRIMARY KEY CLUSTERED 
(
	[tokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[refreshTokens] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[remedialProcedures]    Script Date: 23/11/2018 10:50:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[remedialProcedures](
	[procedureId] [smallint] NOT NULL,
	[procedureNameAr] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[procedureNameEn] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[categoryId] [tinyint] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_remedialProcedures] PRIMARY KEY CLUSTERED 
(
	[procedureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[remedialProcedures] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[schoolDayEvents]    Script Date: 23/11/2018 10:50:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schoolDayEvents](
	[schoolDayEventId] [smallint] NOT NULL,
	[dayId] [tinyint] NULL,
	[stageId] [tinyint] NULL,
	[eventNameAr] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[eventNameEn] [nvarchar](50) COLLATE Arabic_100_CI_AS NULL,
	[startTime] [time](0) NULL,
	[endTime] [time](0) NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_schoolDayEvents] PRIMARY KEY CLUSTERED 
(
	[schoolDayEventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[schoolDayEvents] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[schools]    Script Date: 23/11/2018 10:50:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schools](
	[schoolID] [tinyint] NOT NULL,
	[schoolNameAr] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[schoolNameEn] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[startDate] [date] NULL,
	[address] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[comNum] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isActive] [bit] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_schools] PRIMARY KEY CLUSTERED 
(
	[schoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[schools] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[stages]    Script Date: 23/11/2018 10:50:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stages](
	[stageId] [tinyint] NOT NULL,
	[branchId] [tinyint] NULL,
	[stageNameAr] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[stageNameEn] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_stages] PRIMARY KEY CLUSTERED 
(
	[stageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[stages] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[students]    Script Date: 23/11/2018 10:50:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[studentId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[parentId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[fNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lNameAr] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[fNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lNameEn] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gender] [bit] NULL,
	[IdType] [tinyint] NULL,
	[IdIssuePlace] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IdExpireDateG] [date] NULL,
	[idExpireDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mobile] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[mobileMother] [nvarchar](15) COLLATE Arabic_100_CI_AS NULL,
	[email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[birthDateG] [date] NULL,
	[birthDateH] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[birthPlace] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[specialNeeds] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[previousSchool] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[countryId] [tinyint] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_students] PRIMARY KEY CLUSTERED 
(
	[studentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[students] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[studentsProcedures]    Script Date: 23/11/2018 10:50:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[studentsProcedures](
	[studentProcedureId] [int] NOT NULL,
	[studentViolationId] [int] NULL,
	[empJobId] [int] NULL,
	[procedureId] [smallint] NULL,
	[procedureDate] [smalldatetime] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_studentsProcedures] PRIMARY KEY CLUSTERED 
(
	[studentProcedureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[studentsProcedures] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[studentsViolations]    Script Date: 23/11/2018 10:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[studentsViolations](
	[studentViolationId] [int] NOT NULL,
	[studentId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[violationId] [smallint] NULL,
	[empJobId] [int] NULL,
	[violationDate] [smalldatetime] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_studentsViolations] PRIMARY KEY CLUSTERED 
(
	[studentViolationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[studentsViolations] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[subjects]    Script Date: 23/11/2018 10:50:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subjects](
	[subjectId] [tinyint] NOT NULL,
	[majorId] [tinyint] NULL,
	[subjectNameAr] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[subjectNameEn] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[shortNameAr] [nvarchar](5) COLLATE Arabic_100_CI_AS NULL,
	[shortNameEn] [nvarchar](5) COLLATE Arabic_100_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_subjects] PRIMARY KEY CLUSTERED 
(
	[subjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[subjects] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[teachersEdu]    Script Date: 23/11/2018 10:50:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teachersEdu](
	[empJobId] [int] NOT NULL,
	[gradeSubjectId] [smallint] NOT NULL,
	[classroomIds] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_teachersEdu] PRIMARY KEY CLUSTERED 
(
	[empJobId] ASC,
	[gradeSubjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[teachersEdu] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[teachersQuorums]    Script Date: 23/11/2018 10:50:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teachersQuorums](
	[teacherQuorumId] [int] NOT NULL,
	[empJobId] [int] NULL,
	[semesterId] [tinyint] NULL,
	[periodsQuorum] [tinyint] NULL,
	[substituteQuorum] [tinyint] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_teachersQuorums] PRIMARY KEY CLUSTERED 
(
	[teacherQuorumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[teachersQuorums] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[timeTables]    Script Date: 23/11/2018 10:50:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timeTables](
	[timeTableId] [int] NOT NULL,
	[classroomId] [smallint] NOT NULL,
	[schoolDayEventId] [smallint] NOT NULL,
	[gradeSubjectId] [smallint] NULL,
	[empJobId] [int] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_timeTable_1] PRIMARY KEY CLUSTERED 
(
	[timeTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[timeTables] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[users]    Script Date: 23/11/2018 10:50:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[userId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[passwordHash] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[passwordSalt] [varchar](50) COLLATE Arabic_100_CI_AS NULL,
	[userTypeId] [tinyint] NULL,
	[subscribeDate] [smalldatetime] NULL,
	[lastActive] [datetime] NULL,
	[accountStatusId] [tinyint] NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[users] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[usersDocs]    Script Date: 23/11/2018 10:50:49 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usersDocs](
	[userDocId] [int] NOT NULL,
	[userId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[docTypeId] [tinyint] NOT NULL,
	[filePath] [nvarchar](15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_usersDocs] PRIMARY KEY CLUSTERED 
(
	[userDocId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[usersDocs] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[userTypes]    Script Date: 23/11/2018 10:50:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userTypes](
	[userTypeId] [tinyint] NOT NULL,
	[userTypeName] [nvarchar](25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_userTypes] PRIMARY KEY CLUSTERED 
(
	[userTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[userTypes] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[verificationCodes]    Script Date: 23/11/2018 10:50:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[verificationCodes](
	[codeId] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](10) COLLATE Arabic_100_CI_AS NOT NULL,
	[sentTime] [smalldatetime] NOT NULL,
	[codeTypeId] [tinyint] NULL,
	[userId] [char](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_verificationCodes] PRIMARY KEY CLUSTERED 
(
	[codeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[verificationCodes] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[verificationCodeTypes]    Script Date: 23/11/2018 10:50:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[verificationCodeTypes](
	[codeTypeId] [tinyint] NOT NULL,
	[codeType] [varchar](25) COLLATE Arabic_100_CI_AS NOT NULL,
	[description] [varchar](max) COLLATE Arabic_100_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_verificationCodeTypes] PRIMARY KEY CLUSTERED 
(
	[codeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[verificationCodeTypes] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[weeksPlans]    Script Date: 23/11/2018 10:50:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[weeksPlans](
	[weekPlanId] [smallint] NOT NULL,
	[weekId] [smallint] NULL,
	[timeTableId] [int] NOT NULL,
	[date] [date] NULL,
	[lessonId] [int] NULL,
	[homework] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[quiz] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_weeksPlans] PRIMARY KEY CLUSTERED 
(
	[weekPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[weeksPlans] TO  SCHEMA OWNER 
GO
INSERT [dbo].[academicSemesters] ([semesterId], [yearId], [semesterNameAr], [semesterNameEn], [semesterStartDateG], [semesterStartDateH], [semesterEndDateG], [semesterEndDateH], [isDeleted]) VALUES (1, 1, N'الفصل الدراسي الأول', N'First Term', CAST(N'2017-09-17' AS Date), N'1438/12/26', CAST(N'2018-01-13' AS Date), N'1439/04/26', NULL)
INSERT [dbo].[academicSemesters] ([semesterId], [yearId], [semesterNameAr], [semesterNameEn], [semesterStartDateG], [semesterStartDateH], [semesterEndDateG], [semesterEndDateH], [isDeleted]) VALUES (2, 1, N'الفصل الدراسي الثاني', N'Second Term', CAST(N'2018-01-21' AS Date), N'1439/05/04', CAST(N'2018-05-15' AS Date), N'1439/08/29', NULL)
INSERT [dbo].[academicWeeks] ([weekId], [semesterId], [weekNameAr], [weekNameEn], [weekStartDateG], [weekStartDateH], [WeekEndDateG], [WeekEndDateH], [isDeleted]) VALUES (1, 1, N'الأسبوع الأول', N'Week 1', CAST(N'2017-09-17' AS Date), N'1438-12-26', CAST(N'2017-09-23' AS Date), N'1440-01-03', NULL)
INSERT [dbo].[academicWeeks] ([weekId], [semesterId], [weekNameAr], [weekNameEn], [weekStartDateG], [weekStartDateH], [WeekEndDateG], [WeekEndDateH], [isDeleted]) VALUES (2, 1, N'الأسبوع الثاني', N'Week 2', CAST(N'2017-09-24' AS Date), N'1440-01-04', CAST(N'2017-09-30' AS Date), N'1440-01-10', NULL)
INSERT [dbo].[academicWeeks] ([weekId], [semesterId], [weekNameAr], [weekNameEn], [weekStartDateG], [weekStartDateH], [WeekEndDateG], [WeekEndDateH], [isDeleted]) VALUES (3, 1, N'الأسبوع الثالث', N'Week 3', CAST(N'2017-10-01' AS Date), N'1440-01-11', CAST(N'2017-10-07' AS Date), N'1440-01-17', NULL)
INSERT [dbo].[academicWeeks] ([weekId], [semesterId], [weekNameAr], [weekNameEn], [weekStartDateG], [weekStartDateH], [WeekEndDateG], [WeekEndDateH], [isDeleted]) VALUES (4, 1, N'الأسبوع الرابع', N'Week 4', CAST(N'2017-10-08' AS Date), N'1440-01-18', CAST(N'2017-10-14' AS Date), N'1440-01-24', NULL)
INSERT [dbo].[academicWeeks] ([weekId], [semesterId], [weekNameAr], [weekNameEn], [weekStartDateG], [weekStartDateH], [WeekEndDateG], [WeekEndDateH], [isDeleted]) VALUES (5, 1, N'الأسبوع الخامس', N'Week 5', CAST(N'2017-10-15' AS Date), N'1440-01-25', CAST(N'2017-10-21' AS Date), N'1440-02-01', NULL)
INSERT [dbo].[academicYears] ([yearId], [yearNameG], [yearNameH], [yearStartDateG], [yearStartDateH], [yearEndDateG], [yearEndDateH], [isDeleted]) VALUES (1, N'2017-2018', N'1438-1439', CAST(N'2017-09-17' AS Date), N'1438/12/26', CAST(N'2018-05-15' AS Date), N'1439-08-29', NULL)
INSERT [dbo].[academicYears] ([yearId], [yearNameG], [yearNameH], [yearStartDateG], [yearStartDateH], [yearEndDateG], [yearEndDateH], [isDeleted]) VALUES (2, N'2018-2019', N'1439-1440', CAST(N'2018-09-02' AS Date), N'1439-12-21', CAST(N'2019-05-02' AS Date), N'1440-08-26', NULL)
INSERT [dbo].[accountStatus] ([statusId], [statusAr], [statusEn], [isDeleted]) VALUES (1, N'انتظار', N'Pending', NULL)
INSERT [dbo].[accountStatus] ([statusId], [statusAr], [statusEn], [isDeleted]) VALUES (2, N'مفعل', N'Enabled', NULL)
INSERT [dbo].[accountStatus] ([statusId], [statusAr], [statusEn], [isDeleted]) VALUES (3, N'مغلق', N'Closed', NULL)
INSERT [dbo].[accountStatus] ([statusId], [statusAr], [statusEn], [isDeleted]) VALUES (4, N'إيقاف مؤقت', N'Paused', NULL)
INSERT [dbo].[branches] ([branchId], [branchNameAr], [branchNameEn], [schoolId], [isDeleted]) VALUES (1, N'بنين', N'Boys', 1, NULL)
INSERT [dbo].[branches] ([branchId], [branchNameAr], [branchNameEn], [schoolId], [isDeleted]) VALUES (2, N'بنات', N'Girls', 1, NULL)
INSERT [dbo].[branches] ([branchId], [branchNameAr], [branchNameEn], [schoolId], [isDeleted]) VALUES (3, N'بنين', N'Boys', 2, NULL)
INSERT [dbo].[branches] ([branchId], [branchNameAr], [branchNameEn], [schoolId], [isDeleted]) VALUES (4, N'ينات', N'Girls', 2, NULL)
INSERT [dbo].[countries] ([countryId], [countryAr], [countryEn], [isDeleted]) VALUES (1, N'السعودية', N'Saudi Arabia', NULL)
INSERT [dbo].[countries] ([countryId], [countryAr], [countryEn], [isDeleted]) VALUES (2, N'مصر', N'Egypt', NULL)
INSERT [dbo].[countries] ([countryId], [countryAr], [countryEn], [isDeleted]) VALUES (3, N'سوريا', N'Syria', NULL)
INSERT [dbo].[countries] ([countryId], [countryAr], [countryEn], [isDeleted]) VALUES (4, N'الأردن', N'Jordan', NULL)
INSERT [dbo].[departments] ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted]) VALUES (1, N'الروضة', N'Kindergarten', NULL)
INSERT [dbo].[departments] ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted]) VALUES (2, N'الإبتدائي', N'Primary', NULL)
INSERT [dbo].[departments] ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted]) VALUES (3, N'المتوسط', N'Intermediate', NULL)
INSERT [dbo].[departments] ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted]) VALUES (4, N'الثانوي', N'Secondary', NULL)
INSERT [dbo].[departments] ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted]) VALUES (5, N'الموارد البشرية', N'Human Resources', NULL)
INSERT [dbo].[departments] ([departmentId], [departmentNameAr], [departmentNameEn], [isDeleted]) VALUES (6, N'المالية', N'Finance', NULL)
INSERT [dbo].[docTypes] ([docTypeId], [docTypeAr], [docTypeEn], [isDeleted]) VALUES (1, N'هوية وطنية', N'National ID', NULL)
INSERT [dbo].[docTypes] ([docTypeId], [docTypeAr], [docTypeEn], [isDeleted]) VALUES (2, N'هوية مقيم', N'Residency Permit', NULL)
INSERT [dbo].[docTypes] ([docTypeId], [docTypeAr], [docTypeEn], [isDeleted]) VALUES (3, N'جواز سفر', N'Passport', NULL)
INSERT [dbo].[docTypes] ([docTypeId], [docTypeAr], [docTypeEn], [isDeleted]) VALUES (4, N'شهادة ميلاد', N'Birth Certificate', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (1, 1, N'الروضة 1', N'Kindergarten 1', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (2, 1, N'الروضة 2', N'Kindergarten 2', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (3, 1, N'الروضة 3', N'Kindergarten 3', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (4, 2, N'أول ابتدائي', N'Grade 1', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (5, 2, N'ثاني ابتدائي', N'Grade 2', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (6, 2, N'ثالث ابتدائي', N'Grade 3', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (7, 2, N'رابع ابتدائي', N'Grade 4', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (8, 2, N'خامس ابتدائي', N'Grade 5', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (9, 2, N'سادس ابتدائي', N'Grade 6', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (10, 3, N'أول متوسط', N'Grade 7', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (11, 3, N'ثاني متوسط', N'Grade 8', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (12, 3, N'ثالث متوسط', N'Grade 9', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (13, 4, N'أول ثانوي', N'Grade 10', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (14, 4, N'ثاني ثانوي', N'Grade 11', NULL)
INSERT [dbo].[grades] ([gradeId], [stageId], [gradeNameAr], [gradeNameEn], [isDeleted]) VALUES (15, 4, N'ثالث ثانوي', N'Grade 12', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (1, N'معلم', N'Teacher', N'teaches at least one subject', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (2, N'مدير مرحلة', N'Principal', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (3, N'وكيل مرحلة', N'Vice Principal', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (4, N'مرشد طلابي', N'', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (5, N'مراقب طلابي', N'', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (6, N'رائد نشاط', N'', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (7, N'سكرتير', N'Secretary', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (8, N'مشرف تربوي', N'Academic Supervisor', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (9, N'المشرف العام', N'CEO', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (10, N'مدير مالي', N'Financial Manager', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (11, N'محاسب', N'Accountant', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (12, N'مسؤول قبول وتسجيل', N'Admission official', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (13, N'أمين صندوق', N'Teller', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (14, N'مسؤول مشتريات', N'Purchsing official', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (15, N'مسؤول عهدة', N'Custody official', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (16, N'مدير إداري', N'HR Manager', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (17, N'مسؤول موارد بشرية', N'HR official', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (18, N'مسؤول صيانة', N'Maintenance official', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (19, N'مسؤول نقل وحركة', N'Transport official', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (20, N'سائق', N'Driver', N'', NULL)
INSERT [dbo].[jobs] ([jobId], [jobNameAr], [jobNameEn], [jobDescription], [isDeleted]) VALUES (21, N'عامل', N'Worker', N'', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (1, N'الإسلاميات', N'Islamics', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (2, N'اللغة العربية', N'Arabic', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (3, N'الرياضيات', N'Mathematics', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (4, N'العلوم', N'Science', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (5, N'اللغة الإنجليزية', N'English', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (6, N'الاجتماعيات', N'Social Studies', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (7, N'الحاسب الآلي', N'Computer Science', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (8, N'التربية البدنية', N'Physical Education', NULL)
INSERT [dbo].[majors] ([majorId], [majorNameAr], [majorNameEn], [isDeleted]) VALUES (9, N'التربية الفنية', N'Arts', NULL)
INSERT [dbo].[parents] ([parentId], [fNameAr], [mNameAr], [gNameAr], [lNameAr], [fNameEn], [mNameEn], [gNameEn], [lNameEn], [IdType], [IdIssuePlace], [IdExpireDateG], [idExpireDateH], [mobile1], [mobile2], [countryId], [phone], [email], [houseNum], [street], [district], [cityId], [job], [workAddress], [workPhone], [relativeName], [relativeMobile], [relativePhone], [relativeAddress], [relativeRelation], [isDeleted]) VALUES (N'1133557799', N'محمد', N'حسن', N'عبد اللطيف', N'البشري', N'Ramy', NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'ahmady09@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[parents] ([parentId], [fNameAr], [mNameAr], [gNameAr], [lNameAr], [fNameEn], [mNameEn], [gNameEn], [lNameEn], [IdType], [IdIssuePlace], [IdExpireDateG], [idExpireDateH], [mobile1], [mobile2], [countryId], [phone], [email], [houseNum], [street], [district], [cityId], [job], [workAddress], [workPhone], [relativeName], [relativeMobile], [relativePhone], [relativeAddress], [relativeRelation], [isDeleted]) VALUES (N'5566556655', N'أحمد', N'حسين', N'عبد الحميد', N'الاسيوطي', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'entity.email', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[refreshTokens] ON 

INSERT [dbo].[refreshTokens] ([tokenId], [token], [deviceInfo], [userId], [isDeleted]) VALUES (4, N'SfxKDCSpkxin9r+ynRV2QMqCDiOhOqK+lMafN8P98WU=', N'Other|Windows 10|Chrome', N'5566556655', 0)
INSERT [dbo].[refreshTokens] ([tokenId], [token], [deviceInfo], [userId], [isDeleted]) VALUES (5, N'ZsIKOtPMYVHPhNzo8e9p1yhdaOt+BdndrKx0PQNUUCk=', N'Other|Windows 10|Chrome', N'1133557799', 0)
INSERT [dbo].[refreshTokens] ([tokenId], [token], [deviceInfo], [userId], [isDeleted]) VALUES (6, N'hMGyAoudswZHyWWAaXVTn6SaIlda+0fKGyBZAgfSwUA=', N'Other|Other|Other', N'5566556655', 0)
INSERT [dbo].[refreshTokens] ([tokenId], [token], [deviceInfo], [userId], [isDeleted]) VALUES (7, N'pGoJJW8H0UCNlgqexLwRuXzJnfxPeMGDn/cVWz5FBPs=', N'Other|Other|Other', N'1122112211', 0)
INSERT [dbo].[refreshTokens] ([tokenId], [token], [deviceInfo], [userId], [isDeleted]) VALUES (8, N'95zPIVboP279at82f1svVWYMdNp9XgUVQh6lANZQ82g=', N'Other|Other|Other', N'1133557799', 0)
SET IDENTITY_INSERT [dbo].[refreshTokens] OFF
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (1, 1, 2, N'الطابور', N'Assembly', CAST(N'06:30:00' AS Time), CAST(N'06:45:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (2, 1, 2, N'الحصة الأولى', N'Period 1', CAST(N'06:45:00' AS Time), CAST(N'07:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (3, 1, 2, N'الحصة الثانية', N'Period 2', CAST(N'07:30:00' AS Time), CAST(N'08:15:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (4, 1, 2, N'الحصة الثالثة', N'Period 3', CAST(N'08:15:00' AS Time), CAST(N'09:00:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (5, 1, 2, N'الفسحة', N'Break', CAST(N'09:00:00' AS Time), CAST(N'09:15:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (6, 1, 2, N'الحصة الرابعة', N'Period 4', CAST(N'09:15:00' AS Time), CAST(N'10:00:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (7, 1, 2, N'الحصة الخامسة', N'Period 5', CAST(N'10:00:00' AS Time), CAST(N'10:45:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (8, 1, 2, N'الحصة السادسة', N'Period 6', CAST(N'10:45:00' AS Time), CAST(N'11:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (9, 1, 2, N'الحصة السابعة', N'Period 7', CAST(N'11:30:00' AS Time), CAST(N'12:10:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (10, 1, 2, N'الصلاة', N'Prayer', CAST(N'12:10:00' AS Time), CAST(N'12:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (11, 1, 2, N'الحصة الثامنة', N'Period 8', CAST(N'12:30:00' AS Time), CAST(N'01:10:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (12, 2, 2, N'الطابور', N'Assembly', CAST(N'06:30:00' AS Time), CAST(N'06:45:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (13, 2, 2, N'الحصة الأولى', N'Period 1', CAST(N'06:45:00' AS Time), CAST(N'07:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (14, 2, 2, N'الحصة الثانية', N'Period 2', CAST(N'07:30:00' AS Time), CAST(N'08:15:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (15, 2, 2, N'الحصة الثالثة', N'Period 3', CAST(N'08:15:00' AS Time), CAST(N'09:00:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (16, 2, 2, N'الفسحة', N'Break', CAST(N'09:00:00' AS Time), CAST(N'09:15:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (17, 2, 2, N'الحصة الرابعة', N'Period 4', CAST(N'09:15:00' AS Time), CAST(N'10:00:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (18, 2, 2, N'الحصة الخامسة', N'Period 5', CAST(N'10:00:00' AS Time), CAST(N'10:45:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (19, 2, 2, N'الحصة السادسة', N'Period 6', CAST(N'10:45:00' AS Time), CAST(N'11:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (20, 2, 2, N'الحصة السابعة', N'Period 7', CAST(N'11:30:00' AS Time), CAST(N'12:10:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (21, 2, 2, N'الصلاة', N'Prayer', CAST(N'12:10:00' AS Time), CAST(N'12:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (22, 2, 2, N'الحصة الثامنة', N'Period 8', CAST(N'12:30:00' AS Time), CAST(N'01:10:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (23, 3, 2, N'الطابور', N'Assembly', CAST(N'06:30:00' AS Time), CAST(N'06:45:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (24, 3, 2, N'الحصة الأولى', N'Period 1', CAST(N'06:45:00' AS Time), CAST(N'07:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (25, 3, 2, N'الحصة الثانية', N'Period 2', CAST(N'07:30:00' AS Time), CAST(N'08:15:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (26, 3, 2, N'الحصة الثالثة', N'Period 3', CAST(N'08:15:00' AS Time), CAST(N'09:00:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (27, 3, 2, N'الفسحة', N'Break', CAST(N'09:00:00' AS Time), CAST(N'09:15:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (28, 3, 2, N'الحصة الرابعة', N'Period 4', CAST(N'09:15:00' AS Time), CAST(N'10:00:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (29, 3, 2, N'الحصة الخامسة', N'Period 5', CAST(N'10:00:00' AS Time), CAST(N'10:45:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (30, 3, 2, N'الحصة السادسة', N'Period 6', CAST(N'10:45:00' AS Time), CAST(N'11:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (31, 3, 2, N'الحصة السابعة', N'Period 7', CAST(N'11:30:00' AS Time), CAST(N'12:10:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (32, 3, 2, N'الصلاة', N'Prayer', CAST(N'12:10:00' AS Time), CAST(N'12:30:00' AS Time), NULL)
INSERT [dbo].[schoolDayEvents] ([schoolDayEventId], [dayId], [stageId], [eventNameAr], [eventNameEn], [startTime], [endTime], [isDeleted]) VALUES (33, 3, 2, N'الحصة الثامنة', N'Period 8', CAST(N'12:30:00' AS Time), CAST(N'01:10:00' AS Time), NULL)
INSERT [dbo].[schools] ([schoolID], [schoolNameAr], [schoolNameEn], [startDate], [address], [comNum], [isActive], [isDeleted]) VALUES (1, N'السمو', N'Assumou', CAST(N'2000-09-25' AS Date), N'المروج-ش شهداء بدر', N'11258', 1, NULL)
INSERT [dbo].[schools] ([schoolID], [schoolNameAr], [schoolNameEn], [startDate], [address], [comNum], [isActive], [isDeleted]) VALUES (2, N'الصدراة', N'Assadarah', CAST(N'2013-10-15' AS Date), N'ش عثمان بن عفان', N'25488', 0, NULL)
INSERT [dbo].[stages] ([stageId], [branchId], [stageNameAr], [stageNameEn], [isDeleted]) VALUES (1, 2, N'الروضة', N'Kindergarten', NULL)
INSERT [dbo].[stages] ([stageId], [branchId], [stageNameAr], [stageNameEn], [isDeleted]) VALUES (2, 1, N'الإبتدائي', N'Primary', NULL)
INSERT [dbo].[stages] ([stageId], [branchId], [stageNameAr], [stageNameEn], [isDeleted]) VALUES (3, 1, N'المتوسط', N'Intermediate', NULL)
INSERT [dbo].[stages] ([stageId], [branchId], [stageNameAr], [stageNameEn], [isDeleted]) VALUES (4, 1, N'الثانوي', N'Secondary', NULL)
INSERT [dbo].[stages] ([stageId], [branchId], [stageNameAr], [stageNameEn], [isDeleted]) VALUES (5, 2, N'الإبتدائي', N'Primary', NULL)
INSERT [dbo].[stages] ([stageId], [branchId], [stageNameAr], [stageNameEn], [isDeleted]) VALUES (6, 2, N'المتوسط', N'Intermediate', NULL)
INSERT [dbo].[stages] ([stageId], [branchId], [stageNameAr], [stageNameEn], [isDeleted]) VALUES (7, 2, N'الثانوي', N'Secondary', NULL)
INSERT [dbo].[subjects] ([subjectId], [majorId], [subjectNameAr], [subjectNameEn], [shortNameAr], [shortNameEn], [isDeleted]) VALUES (1, 1, N'القرآن', N'Quran', N'قرآن', N'Quran', NULL)
INSERT [dbo].[subjects] ([subjectId], [majorId], [subjectNameAr], [subjectNameEn], [shortNameAr], [shortNameEn], [isDeleted]) VALUES (2, 1, N'الحديث', N'Hadith', N'حديث', N'Had', NULL)
INSERT [dbo].[subjects] ([subjectId], [majorId], [subjectNameAr], [subjectNameEn], [shortNameAr], [shortNameEn], [isDeleted]) VALUES (3, 1, N'الفقه', N'Fiqh', N'فقه', N'Fiqh', NULL)
INSERT [dbo].[subjects] ([subjectId], [majorId], [subjectNameAr], [subjectNameEn], [shortNameAr], [shortNameEn], [isDeleted]) VALUES (4, 1, N'التوحيد', N'Tawheed', N'توحيد', N'Tawh', NULL)
INSERT [dbo].[subjects] ([subjectId], [majorId], [subjectNameAr], [subjectNameEn], [shortNameAr], [shortNameEn], [isDeleted]) VALUES (5, 2, N'اللغة العربية', N'Arabic', N'عربي', N'Ar', NULL)
INSERT [dbo].[users] ([userId], [passwordHash], [passwordSalt], [userTypeId], [subscribeDate], [lastActive], [accountStatusId], [isDeleted]) VALUES (N'1122112211', N'dUQMMafBaLIAqOCVc8UMF/2PbbdmCsjfwlA6C/WlrAs=', N'f9M34MKR4Vm6UYEk2PR/XvzMulYkwTqqChRC5FEaJlw=', 3, CAST(N'2018-11-08T22:04:00' AS SmallDateTime), CAST(N'2018-11-08T22:03:49.010' AS DateTime), 2, 0)
INSERT [dbo].[users] ([userId], [passwordHash], [passwordSalt], [userTypeId], [subscribeDate], [lastActive], [accountStatusId], [isDeleted]) VALUES (N'1133557799', N'KpfOkUqAyYwS4EaGilBpLq118o1+BCtD0ZKu3n47fEk=', N'4g/UJqUQWR05eKdAk2dBQzDgp/0Hef8H8UMV7yodLzQ=', 1, CAST(N'2018-11-10T18:57:00' AS SmallDateTime), CAST(N'2018-11-10T18:57:18.330' AS DateTime), 1, 0)
INSERT [dbo].[users] ([userId], [passwordHash], [passwordSalt], [userTypeId], [subscribeDate], [lastActive], [accountStatusId], [isDeleted]) VALUES (N'2233223322', N'01c/sDaFmkks2RuE4VQqJgXdad+VhfRPZtEBS2dge8I=', N'Iij/G5QiL7Q1npYS3xs7DI7b4LCd8ySB/1J8f+FYDHs=', 2, CAST(N'2018-11-08T22:03:00' AS SmallDateTime), CAST(N'2018-11-08T22:03:05.050' AS DateTime), 2, 0)
INSERT [dbo].[users] ([userId], [passwordHash], [passwordSalt], [userTypeId], [subscribeDate], [lastActive], [accountStatusId], [isDeleted]) VALUES (N'3344334433', N'YwyNCmYmTABbp8lgMin8k1DNO9gMLGrgAXbZlTXkixo=', N'ZS9o5bEWwQHdBHQqOREhsp0m64t8hmhSItBm2WDDnac=', 3, CAST(N'2018-11-09T22:41:00' AS SmallDateTime), CAST(N'2018-11-09T22:41:04.883' AS DateTime), 1, 0)
INSERT [dbo].[users] ([userId], [passwordHash], [passwordSalt], [userTypeId], [subscribeDate], [lastActive], [accountStatusId], [isDeleted]) VALUES (N'4455445544', N'rjdmYQgONP++Q98eSk21n/1j9zf+NsgabLwuEEeMPuw=', N'/08BHuOHsZe6SQXaYdfgqPC0LN9fU6Ds5OQaE019Ghc=', 2, CAST(N'2018-11-08T22:03:00' AS SmallDateTime), CAST(N'2018-11-08T22:03:26.567' AS DateTime), 1, 0)
INSERT [dbo].[users] ([userId], [passwordHash], [passwordSalt], [userTypeId], [subscribeDate], [lastActive], [accountStatusId], [isDeleted]) VALUES (N'5566556655', N'lQ9O2LWesp6CWfsUNwcu1RoVlCx732WBFctswKOWGY8=', N'bsVV5wWeJ9qTl3UT2JKRL6Rqdh+DkDMuRMz3IALPatc=', 3, CAST(N'2018-11-09T22:53:00' AS SmallDateTime), CAST(N'2018-11-09T22:52:55.197' AS DateTime), 1, 0)
INSERT [dbo].[users] ([userId], [passwordHash], [passwordSalt], [userTypeId], [subscribeDate], [lastActive], [accountStatusId], [isDeleted]) VALUES (N'7788778877', N'hq/jKoS8Z/IcAomn36LAucQWx1T3v8DKM2KXHl+eoD4=', N'eCLEuLYnF1B+AZerVVFRKHlYMQhAB2fW9rQhWA5FIBc=', 1, CAST(N'2018-11-08T22:02:00' AS SmallDateTime), CAST(N'2018-11-08T22:01:55.193' AS DateTime), 1, 0)
INSERT [dbo].[users] ([userId], [passwordHash], [passwordSalt], [userTypeId], [subscribeDate], [lastActive], [accountStatusId], [isDeleted]) VALUES (N'8899889988', N'QGnFZ6wnKlziDUMCdakXPMJTGQmh7IscQj32+S7TXR4=', N'tCzJhP4PsBae1ZHQiRNDIs68UqEu3wKt85wIoR/41XI=', 3, CAST(N'2018-11-08T22:04:00' AS SmallDateTime), CAST(N'2018-11-08T22:04:12.833' AS DateTime), 1, 0)
INSERT [dbo].[userTypes] ([userTypeId], [userTypeName], [isDeleted]) VALUES (1, N'employee', NULL)
INSERT [dbo].[userTypes] ([userTypeId], [userTypeName], [isDeleted]) VALUES (2, N'student', NULL)
INSERT [dbo].[userTypes] ([userTypeId], [userTypeName], [isDeleted]) VALUES (3, N'parent', NULL)
SET IDENTITY_INSERT [dbo].[verificationCodes] ON 

INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (1, N'123456', CAST(N'2018-11-16T21:25:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (2, N'371929', CAST(N'2018-11-17T00:42:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (3, N'793656', CAST(N'2018-11-17T00:47:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (4, N'327706', CAST(N'2018-11-17T00:54:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (5, N'540305', CAST(N'2018-11-17T00:55:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (6, N'807820', CAST(N'2018-11-17T00:56:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (7, N'810804', CAST(N'2018-11-17T01:01:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (8, N'629748', CAST(N'2018-11-17T01:10:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (9, N'291653', CAST(N'2018-11-17T01:12:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (10, N'151713', CAST(N'2018-11-17T01:17:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (11, N'378980', CAST(N'2018-11-17T01:18:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (12, N'141390', CAST(N'2018-11-17T01:25:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (13, N'877470', CAST(N'2018-11-17T01:27:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (14, N'746381', CAST(N'2018-11-17T01:29:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (15, N'717121', CAST(N'2018-11-17T01:36:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (16, N'773898', CAST(N'2018-11-17T01:38:00' AS SmallDateTime), 1, N'1133557799', 0)
INSERT [dbo].[verificationCodes] ([codeId], [code], [sentTime], [codeTypeId], [userId], [isDeleted]) VALUES (17, N'546903', CAST(N'2018-11-17T01:53:00' AS SmallDateTime), 1, N'1133557799', 0)
SET IDENTITY_INSERT [dbo].[verificationCodes] OFF
INSERT [dbo].[verificationCodeTypes] ([codeTypeId], [codeType], [description], [isDeleted]) VALUES (1, N'FORGET_PASSWORD', N'', 0)
/****** Object:  Index [ucGradeSubject]    Script Date: 23/11/2018 10:51:23 PM ******/
ALTER TABLE [dbo].[gradesSubjects] ADD  CONSTRAINT [ucGradeSubject] UNIQUE NONCLUSTERED 
(
	[gradeId] ASC,
	[subjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[employees] ADD  CONSTRAINT [DF_employees_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[lessonsFiles] ADD  CONSTRAINT [DF_syllabusFiles_isExternalLink]  DEFAULT ((0)) FOR [isExternalLink]
GO
ALTER TABLE [dbo].[parents] ADD  CONSTRAINT [DF_parents_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[periodsFiles] ADD  CONSTRAINT [DF_lessonsFiles_isExternalLink]  DEFAULT ((0)) FOR [isExternalLink]
GO
ALTER TABLE [dbo].[students] ADD  CONSTRAINT [DF_students_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_subscribeDate]  DEFAULT (dateadd(hour,(2),getutcdate())) FOR [subscribeDate]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_isDeleted]  DEFAULT ((0)) FOR [isDeleted]
GO
ALTER TABLE [dbo].[academicSemesters]  WITH CHECK ADD  CONSTRAINT [FK_academicSemesters_academicYears] FOREIGN KEY([yearId])
REFERENCES [dbo].[academicYears] ([yearId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[academicSemesters] CHECK CONSTRAINT [FK_academicSemesters_academicYears]
GO
ALTER TABLE [dbo].[academicWeeks]  WITH CHECK ADD  CONSTRAINT [FK_academicWeeks_academicSemesters] FOREIGN KEY([semesterId])
REFERENCES [dbo].[academicSemesters] ([semesterId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[academicWeeks] CHECK CONSTRAINT [FK_academicWeeks_academicSemesters]
GO
ALTER TABLE [dbo].[branches]  WITH CHECK ADD  CONSTRAINT [FK_branches_schools] FOREIGN KEY([schoolId])
REFERENCES [dbo].[schools] ([schoolID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[branches] CHECK CONSTRAINT [FK_branches_schools]
GO
ALTER TABLE [dbo].[classesStudents]  WITH CHECK ADD  CONSTRAINT [FK_classesStudents_academicYears] FOREIGN KEY([yearId])
REFERENCES [dbo].[academicYears] ([yearId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[classesStudents] CHECK CONSTRAINT [FK_classesStudents_academicYears]
GO
ALTER TABLE [dbo].[classesStudents]  WITH CHECK ADD  CONSTRAINT [FK_classesStudents_classrooms] FOREIGN KEY([classroomId])
REFERENCES [dbo].[classrooms] ([classroomId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[classesStudents] CHECK CONSTRAINT [FK_classesStudents_classrooms]
GO
ALTER TABLE [dbo].[classesStudents]  WITH CHECK ADD  CONSTRAINT [FK_classesStudents_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([studentId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[classesStudents] CHECK CONSTRAINT [FK_classesStudents_students]
GO
ALTER TABLE [dbo].[classrooms]  WITH CHECK ADD  CONSTRAINT [FK_classrooms_grades] FOREIGN KEY([gradeId])
REFERENCES [dbo].[grades] ([gradeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[classrooms] CHECK CONSTRAINT [FK_classrooms_grades]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_countries] FOREIGN KEY([countryId])
REFERENCES [dbo].[countries] ([countryId])
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_countries]
GO
ALTER TABLE [dbo].[employees]  WITH CHECK ADD  CONSTRAINT [FK_employees_users] FOREIGN KEY([empId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employees] CHECK CONSTRAINT [FK_employees_users]
GO
ALTER TABLE [dbo].[employeesActions]  WITH CHECK ADD  CONSTRAINT [FK_employeesActions_actions] FOREIGN KEY([actionId])
REFERENCES [dbo].[actions] ([actionId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employeesActions] CHECK CONSTRAINT [FK_employeesActions_actions]
GO
ALTER TABLE [dbo].[employeesActions]  WITH CHECK ADD  CONSTRAINT [FK_employeesActions_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employeesActions] CHECK CONSTRAINT [FK_employeesActions_employeesJobs]
GO
ALTER TABLE [dbo].[employeesFinance]  WITH CHECK ADD  CONSTRAINT [FK_employeesFinance_employees] FOREIGN KEY([empId])
REFERENCES [dbo].[employees] ([empId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employeesFinance] CHECK CONSTRAINT [FK_employeesFinance_employees]
GO
ALTER TABLE [dbo].[employeesHR]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesHR_employees] FOREIGN KEY([empId])
REFERENCES [dbo].[employees] ([empId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employeesHR] CHECK CONSTRAINT [FK_EmployeesHR_employees]
GO
ALTER TABLE [dbo].[employeesJobs]  WITH CHECK ADD  CONSTRAINT [FK_employeesJobs_departments] FOREIGN KEY([departmentId])
REFERENCES [dbo].[departments] ([departmentId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employeesJobs] CHECK CONSTRAINT [FK_employeesJobs_departments]
GO
ALTER TABLE [dbo].[employeesJobs]  WITH CHECK ADD  CONSTRAINT [FK_employeesJobs_employees] FOREIGN KEY([empId])
REFERENCES [dbo].[employees] ([empId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employeesJobs] CHECK CONSTRAINT [FK_employeesJobs_employees]
GO
ALTER TABLE [dbo].[employeesJobs]  WITH CHECK ADD  CONSTRAINT [FK_employeesJobs_jobs] FOREIGN KEY([jobId])
REFERENCES [dbo].[jobs] ([jobId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[employeesJobs] CHECK CONSTRAINT [FK_employeesJobs_jobs]
GO
ALTER TABLE [dbo].[grades]  WITH CHECK ADD  CONSTRAINT [FK_grades_stages] FOREIGN KEY([stageId])
REFERENCES [dbo].[stages] ([stageId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[grades] CHECK CONSTRAINT [FK_grades_stages]
GO
ALTER TABLE [dbo].[gradesSubjects]  WITH CHECK ADD  CONSTRAINT [FK_gradesSubjects_grades] FOREIGN KEY([gradeId])
REFERENCES [dbo].[grades] ([gradeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[gradesSubjects] CHECK CONSTRAINT [FK_gradesSubjects_grades]
GO
ALTER TABLE [dbo].[gradesSubjects]  WITH CHECK ADD  CONSTRAINT [FK_gradesSubjects_subjects] FOREIGN KEY([subjectId])
REFERENCES [dbo].[subjects] ([subjectId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[gradesSubjects] CHECK CONSTRAINT [FK_gradesSubjects_subjects]
GO
ALTER TABLE [dbo].[jobsActions]  WITH CHECK ADD  CONSTRAINT [FK_jobsActions_actions] FOREIGN KEY([actionId])
REFERENCES [dbo].[actions] ([actionId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[jobsActions] CHECK CONSTRAINT [FK_jobsActions_actions]
GO
ALTER TABLE [dbo].[jobsActions]  WITH CHECK ADD  CONSTRAINT [FK_jobsActions_jobs] FOREIGN KEY([jobId])
REFERENCES [dbo].[jobs] ([jobId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[jobsActions] CHECK CONSTRAINT [FK_jobsActions_jobs]
GO
ALTER TABLE [dbo].[lessonsFiles]  WITH CHECK ADD  CONSTRAINT [FK_lessonsFiles_docTypes] FOREIGN KEY([docTypeId])
REFERENCES [dbo].[docTypes] ([docTypeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[lessonsFiles] CHECK CONSTRAINT [FK_lessonsFiles_docTypes]
GO
ALTER TABLE [dbo].[lessonsFiles]  WITH CHECK ADD  CONSTRAINT [FK_lessonsFiles_lessons] FOREIGN KEY([lessonId])
REFERENCES [dbo].[lessons] ([lessonId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[lessonsFiles] CHECK CONSTRAINT [FK_lessonsFiles_lessons]
GO
ALTER TABLE [dbo].[parents]  WITH CHECK ADD  CONSTRAINT [FK_parents_countries] FOREIGN KEY([countryId])
REFERENCES [dbo].[countries] ([countryId])
GO
ALTER TABLE [dbo].[parents] CHECK CONSTRAINT [FK_parents_countries]
GO
ALTER TABLE [dbo].[parents]  WITH CHECK ADD  CONSTRAINT [FK_parents_users] FOREIGN KEY([parentId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[parents] CHECK CONSTRAINT [FK_parents_users]
GO
ALTER TABLE [dbo].[periods]  WITH CHECK ADD  CONSTRAINT [FK_periods_academicSemesters] FOREIGN KEY([semesterId])
REFERENCES [dbo].[academicSemesters] ([semesterId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[periods] CHECK CONSTRAINT [FK_periods_academicSemesters]
GO
ALTER TABLE [dbo].[periods]  WITH CHECK ADD  CONSTRAINT [FK_periods_classrooms] FOREIGN KEY([classeroomId])
REFERENCES [dbo].[classrooms] ([classroomId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[periods] CHECK CONSTRAINT [FK_periods_classrooms]
GO
ALTER TABLE [dbo].[periods]  WITH CHECK ADD  CONSTRAINT [FK_periods_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[periods] CHECK CONSTRAINT [FK_periods_employeesJobs]
GO
ALTER TABLE [dbo].[periods]  WITH CHECK ADD  CONSTRAINT [FK_periods_gradesSubjects] FOREIGN KEY([gradeSubjectId])
REFERENCES [dbo].[gradesSubjects] ([gradeSubjectId])
GO
ALTER TABLE [dbo].[periods] CHECK CONSTRAINT [FK_periods_gradesSubjects]
GO
ALTER TABLE [dbo].[periods]  WITH CHECK ADD  CONSTRAINT [FK_periods_schoolDayEvents] FOREIGN KEY([schoolDayEventId])
REFERENCES [dbo].[schoolDayEvents] ([schoolDayEventId])
GO
ALTER TABLE [dbo].[periods] CHECK CONSTRAINT [FK_periods_schoolDayEvents]
GO
ALTER TABLE [dbo].[periodsDetails]  WITH CHECK ADD  CONSTRAINT [FK_periodsDetails_periods] FOREIGN KEY([periodId])
REFERENCES [dbo].[periods] ([periodId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[periodsDetails] CHECK CONSTRAINT [FK_periodsDetails_periods]
GO
ALTER TABLE [dbo].[periodsDetails]  WITH CHECK ADD  CONSTRAINT [FK_periodsDetails_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([studentId])
GO
ALTER TABLE [dbo].[periodsDetails] CHECK CONSTRAINT [FK_periodsDetails_students]
GO
ALTER TABLE [dbo].[periodsFiles]  WITH CHECK ADD  CONSTRAINT [FK_periodsFiles_docTypes] FOREIGN KEY([docTypeId])
REFERENCES [dbo].[docTypes] ([docTypeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[periodsFiles] CHECK CONSTRAINT [FK_periodsFiles_docTypes]
GO
ALTER TABLE [dbo].[periodsFiles]  WITH CHECK ADD  CONSTRAINT [FK_periodsFiles_weeksPlans] FOREIGN KEY([weekPlanId])
REFERENCES [dbo].[weeksPlans] ([weekPlanId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[periodsFiles] CHECK CONSTRAINT [FK_periodsFiles_weeksPlans]
GO
ALTER TABLE [dbo].[refreshTokens]  WITH CHECK ADD  CONSTRAINT [FK_users_refreshTokens] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[refreshTokens] CHECK CONSTRAINT [FK_users_refreshTokens]
GO
ALTER TABLE [dbo].[schoolDayEvents]  WITH CHECK ADD  CONSTRAINT [FK_schoolDayEvents_stages] FOREIGN KEY([stageId])
REFERENCES [dbo].[stages] ([stageId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[schoolDayEvents] CHECK CONSTRAINT [FK_schoolDayEvents_stages]
GO
ALTER TABLE [dbo].[stages]  WITH CHECK ADD  CONSTRAINT [FK_stages_branches] FOREIGN KEY([branchId])
REFERENCES [dbo].[branches] ([branchId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[stages] CHECK CONSTRAINT [FK_stages_branches]
GO
ALTER TABLE [dbo].[students]  WITH CHECK ADD  CONSTRAINT [FK_students_countries] FOREIGN KEY([countryId])
REFERENCES [dbo].[countries] ([countryId])
GO
ALTER TABLE [dbo].[students] CHECK CONSTRAINT [FK_students_countries]
GO
ALTER TABLE [dbo].[students]  WITH CHECK ADD  CONSTRAINT [FK_students_parents] FOREIGN KEY([parentId])
REFERENCES [dbo].[parents] ([parentId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[students] CHECK CONSTRAINT [FK_students_parents]
GO
ALTER TABLE [dbo].[students]  WITH CHECK ADD  CONSTRAINT [FK_students_users] FOREIGN KEY([studentId])
REFERENCES [dbo].[users] ([userId])
GO
ALTER TABLE [dbo].[students] CHECK CONSTRAINT [FK_students_users]
GO
ALTER TABLE [dbo].[studentsProcedures]  WITH CHECK ADD  CONSTRAINT [FK_studentsProcedures_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
GO
ALTER TABLE [dbo].[studentsProcedures] CHECK CONSTRAINT [FK_studentsProcedures_employeesJobs]
GO
ALTER TABLE [dbo].[studentsProcedures]  WITH CHECK ADD  CONSTRAINT [FK_studentsProcedures_remedialProcedures] FOREIGN KEY([procedureId])
REFERENCES [dbo].[remedialProcedures] ([procedureId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[studentsProcedures] CHECK CONSTRAINT [FK_studentsProcedures_remedialProcedures]
GO
ALTER TABLE [dbo].[studentsProcedures]  WITH CHECK ADD  CONSTRAINT [FK_studentsProcedures_studentsViolations] FOREIGN KEY([studentViolationId])
REFERENCES [dbo].[studentsViolations] ([studentViolationId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[studentsProcedures] CHECK CONSTRAINT [FK_studentsProcedures_studentsViolations]
GO
ALTER TABLE [dbo].[studentsViolations]  WITH CHECK ADD  CONSTRAINT [FK_studentsViolations_behavioralViolations] FOREIGN KEY([violationId])
REFERENCES [dbo].[behavioralViolations] ([violationId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[studentsViolations] CHECK CONSTRAINT [FK_studentsViolations_behavioralViolations]
GO
ALTER TABLE [dbo].[studentsViolations]  WITH CHECK ADD  CONSTRAINT [FK_studentsViolations_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
GO
ALTER TABLE [dbo].[studentsViolations] CHECK CONSTRAINT [FK_studentsViolations_employeesJobs]
GO
ALTER TABLE [dbo].[studentsViolations]  WITH CHECK ADD  CONSTRAINT [FK_studentsViolations_students] FOREIGN KEY([studentId])
REFERENCES [dbo].[students] ([studentId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[studentsViolations] CHECK CONSTRAINT [FK_studentsViolations_students]
GO
ALTER TABLE [dbo].[subjects]  WITH CHECK ADD  CONSTRAINT [FK_subjects_majors] FOREIGN KEY([majorId])
REFERENCES [dbo].[majors] ([majorId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[subjects] CHECK CONSTRAINT [FK_subjects_majors]
GO
ALTER TABLE [dbo].[teachersEdu]  WITH CHECK ADD  CONSTRAINT [FK_teachersEdu_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[teachersEdu] CHECK CONSTRAINT [FK_teachersEdu_employeesJobs]
GO
ALTER TABLE [dbo].[teachersEdu]  WITH CHECK ADD  CONSTRAINT [FK_teachersEdu_gradesSubjects] FOREIGN KEY([gradeSubjectId])
REFERENCES [dbo].[gradesSubjects] ([gradeSubjectId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[teachersEdu] CHECK CONSTRAINT [FK_teachersEdu_gradesSubjects]
GO
ALTER TABLE [dbo].[teachersQuorums]  WITH CHECK ADD  CONSTRAINT [FK_teachersQuorums_academicSemesters] FOREIGN KEY([semesterId])
REFERENCES [dbo].[academicSemesters] ([semesterId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[teachersQuorums] CHECK CONSTRAINT [FK_teachersQuorums_academicSemesters]
GO
ALTER TABLE [dbo].[teachersQuorums]  WITH CHECK ADD  CONSTRAINT [FK_teachersQuorums_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[teachersQuorums] CHECK CONSTRAINT [FK_teachersQuorums_employeesJobs]
GO
ALTER TABLE [dbo].[timeTables]  WITH CHECK ADD  CONSTRAINT [FK_timeTable_employeesJobs] FOREIGN KEY([empJobId])
REFERENCES [dbo].[employeesJobs] ([empJobId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[timeTables] CHECK CONSTRAINT [FK_timeTable_employeesJobs]
GO
ALTER TABLE [dbo].[timeTables]  WITH CHECK ADD  CONSTRAINT [FK_timeTable_gradesSubjects] FOREIGN KEY([gradeSubjectId])
REFERENCES [dbo].[gradesSubjects] ([gradeSubjectId])
GO
ALTER TABLE [dbo].[timeTables] CHECK CONSTRAINT [FK_timeTable_gradesSubjects]
GO
ALTER TABLE [dbo].[timeTables]  WITH CHECK ADD  CONSTRAINT [FK_timeTable_schoolDayEvents] FOREIGN KEY([schoolDayEventId])
REFERENCES [dbo].[schoolDayEvents] ([schoolDayEventId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[timeTables] CHECK CONSTRAINT [FK_timeTable_schoolDayEvents]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_accountStatus] FOREIGN KEY([accountStatusId])
REFERENCES [dbo].[accountStatus] ([statusId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_accountStatus]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_userTypes] FOREIGN KEY([userTypeId])
REFERENCES [dbo].[userTypes] ([userTypeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_userTypes]
GO
ALTER TABLE [dbo].[usersDocs]  WITH CHECK ADD  CONSTRAINT [FK_usersDocs_docTypes] FOREIGN KEY([docTypeId])
REFERENCES [dbo].[docTypes] ([docTypeId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[usersDocs] CHECK CONSTRAINT [FK_usersDocs_docTypes]
GO
ALTER TABLE [dbo].[usersDocs]  WITH CHECK ADD  CONSTRAINT [FK_usersDocs_users] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[usersDocs] CHECK CONSTRAINT [FK_usersDocs_users]
GO
ALTER TABLE [dbo].[verificationCodes]  WITH CHECK ADD  CONSTRAINT [FK_users_verificationCodes] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[verificationCodes] CHECK CONSTRAINT [FK_users_verificationCodes]
GO
ALTER TABLE [dbo].[verificationCodes]  WITH CHECK ADD  CONSTRAINT [FK_verificationCodeTypes_verificationCodes] FOREIGN KEY([codeTypeId])
REFERENCES [dbo].[verificationCodeTypes] ([codeTypeId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[verificationCodes] CHECK CONSTRAINT [FK_verificationCodeTypes_verificationCodes]
GO
ALTER TABLE [dbo].[weeksPlans]  WITH CHECK ADD  CONSTRAINT [FK_weeksPlans_academicWeeks] FOREIGN KEY([weekId])
REFERENCES [dbo].[academicWeeks] ([weekId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[weeksPlans] CHECK CONSTRAINT [FK_weeksPlans_academicWeeks]
GO
ALTER TABLE [dbo].[weeksPlans]  WITH CHECK ADD  CONSTRAINT [FK_weeksPlans_lessons] FOREIGN KEY([lessonId])
REFERENCES [dbo].[lessons] ([lessonId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[weeksPlans] CHECK CONSTRAINT [FK_weeksPlans_lessons]
GO
ALTER TABLE [dbo].[weeksPlans]  WITH CHECK ADD  CONSTRAINT [FK_weeksPlans_timeTable] FOREIGN KEY([timeTableId])
REFERENCES [dbo].[timeTables] ([timeTableId])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[weeksPlans] CHECK CONSTRAINT [FK_weeksPlans_timeTable]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_AcademicCalenders]
AS
SELECT dbo.academicYears.yearId, dbo.academicYears.yearNameG, dbo.academicYears.yearNameH, dbo.academicSemesters.semesterId, dbo.academicSemesters.semesterNameAr, dbo.academicSemesters.semesterNameEn, dbo.academicWeeks.weekId, 
             dbo.academicWeeks.weekNameAr, dbo.academicWeeks.weekNameEn
FROM   dbo.academicWeeks INNER JOIN
             dbo.academicSemesters ON dbo.academicWeeks.semesterId = dbo.academicSemesters.semesterId INNER JOIN
             dbo.academicYears ON dbo.academicSemesters.yearId = dbo.academicYears.yearId
GO
ALTER AUTHORIZATION ON [dbo].[v_AcademicCalenders] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_BaseEduData]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_BaseEduData]
AS
SELECT dbo.schools.schoolID, dbo.schools.schoolNameAr, dbo.schools.schoolNameEn, dbo.branches.branchId, dbo.branches.branchNameAr, dbo.branches.branchNameEn, dbo.stages.stageId, dbo.stages.stageNameAr, dbo.stages.stageNameEn, dbo.grades.gradeId, 
             dbo.grades.gradeNameAr, dbo.grades.gradeNameEn
FROM   dbo.schools INNER JOIN
             dbo.branches ON dbo.schools.schoolID = dbo.branches.schoolId INNER JOIN
             dbo.stages ON dbo.branches.branchId = dbo.stages.branchId INNER JOIN
             dbo.grades ON dbo.stages.stageId = dbo.grades.stageId
GO
ALTER AUTHORIZATION ON [dbo].[v_BaseEduData] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_ClassroomsData]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_ClassroomsData]
AS
SELECT dbo.schools.schoolID, dbo.schools.schoolNameAr, dbo.schools.schoolNameEn, dbo.branches.branchId, dbo.branches.branchNameAr, dbo.branches.branchNameEn, dbo.stages.stageId, dbo.stages.stageNameAr, dbo.stages.stageNameEn, dbo.grades.gradeId, 
             dbo.grades.gradeNameAr, dbo.grades.gradeNameEn, dbo.classrooms.classroomId, dbo.classrooms.classNameAr, dbo.classrooms.classNameEn
FROM   dbo.schools INNER JOIN
             dbo.branches ON dbo.schools.schoolID = dbo.branches.schoolId INNER JOIN
             dbo.stages ON dbo.branches.branchId = dbo.stages.branchId INNER JOIN
             dbo.grades ON dbo.stages.stageId = dbo.grades.stageId INNER JOIN
             dbo.classrooms ON dbo.grades.gradeId = dbo.classrooms.gradeId
GO
ALTER AUTHORIZATION ON [dbo].[v_ClassroomsData] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_EmpActions]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  View [dbo].[v_EmployeesFullNameAr]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_EmployeesFullNameAr]
AS
SELECT empId, fNameAr + ' ' + mNameAr + ' ' + gNameAr + ' ' + lNameAr AS empNameAr
FROM   dbo.employees
GO
ALTER AUTHORIZATION ON [dbo].[v_EmployeesFullNameAr] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_EmployeesFullNameEn]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_EmployeesFullNameEn]
AS
SELECT empId, fNameEn + ' ' + mNameEn + ' ' + gNameEn + ' ' + lNameEn AS empNameEn
FROM   dbo.employees
GO
ALTER AUTHORIZATION ON [dbo].[v_EmployeesFullNameEn] TO  SCHEMA OWNER 
GO
CREATE VIEW [dbo].[v_EmployeesActions]
AS
SELECT        dbo.actions.actionId, dbo.actions.actionNameAr, dbo.actions.actionNameEn, dbo.actions.actionUrl, dbo.jobs.jobId, dbo.jobs.jobNameAr, dbo.jobs.jobNameEn, dbo.jobs.jobDescription, dbo.employeesJobs.empJobId, 
                         dbo.employees.empId, dbo.v_EmployeesFullNameEn.empNameEn, dbo.v_EmployeesFullNameAr.empNameAr
FROM            dbo.actions INNER JOIN
                         dbo.jobsActions ON dbo.actions.actionId = dbo.jobsActions.actionId INNER JOIN
                         dbo.jobs ON dbo.jobsActions.jobId = dbo.jobs.jobId INNER JOIN
                         dbo.employeesJobs ON dbo.jobs.jobId = dbo.employeesJobs.jobId INNER JOIN
                         dbo.employeesActions ON dbo.actions.actionId = dbo.employeesActions.actionId AND dbo.employeesJobs.empJobId = dbo.employeesActions.empJobId INNER JOIN
                         dbo.employees ON dbo.employeesJobs.empId = dbo.employees.empId INNER JOIN
                         dbo.v_EmployeesFullNameAr ON dbo.employees.empId = dbo.v_EmployeesFullNameAr.empId INNER JOIN
                         dbo.v_EmployeesFullNameEn ON dbo.employees.empId = dbo.v_EmployeesFullNameEn.empId
GO
ALTER AUTHORIZATION ON [dbo].[v_EmployeesActions] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_EmpoyeesJobsData]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_EmpoyeesJobsData]
AS
SELECT        dbo.employeesJobs.empJobId, dbo.employees.gender, dbo.employees.mobile, dbo.employees.email, dbo.employees.birthDateG, dbo.employees.addressKsa, dbo.employees.empId, dbo.branches.branchNameAr, 
                         dbo.branches.branchId, dbo.branches.branchNameEn, dbo.departments.departmentId, dbo.departments.departmentNameAr, dbo.departments.departmentNameEn, dbo.jobs.jobId, dbo.jobs.jobNameAr, dbo.jobs.jobNameEn, 
                         dbo.schools.schoolID, dbo.schools.schoolNameAr, dbo.schools.schoolNameEn, dbo.users.userId, dbo.userTypes.userTypeId, dbo.userTypes.userTypeName, dbo.accountStatus.statusAr, dbo.accountStatus.statusEn, 
                         dbo.v_EmployeesFullNameAr.empNameAr, dbo.v_EmployeesFullNameEn.empNameEn
FROM            dbo.employeesJobs INNER JOIN
                         dbo.employees ON dbo.employeesJobs.empId = dbo.employees.empId INNER JOIN
                         dbo.departments ON dbo.employeesJobs.departmentId = dbo.departments.departmentId INNER JOIN
                         dbo.branches ON dbo.employeesJobs.branchId = dbo.branches.branchId INNER JOIN
                         dbo.jobs ON dbo.employeesJobs.jobId = dbo.jobs.jobId INNER JOIN
                         dbo.schools ON dbo.branches.schoolId = dbo.schools.schoolID INNER JOIN
                         dbo.users ON dbo.employees.empId = dbo.users.userId INNER JOIN
                         dbo.userTypes ON dbo.users.userTypeId = dbo.userTypes.userTypeId INNER JOIN
                         dbo.accountStatus ON dbo.users.accountStatusId = dbo.accountStatus.statusId INNER JOIN
                         dbo.v_EmployeesFullNameAr ON dbo.employees.empId = dbo.v_EmployeesFullNameAr.empId INNER JOIN
                         dbo.v_EmployeesFullNameEn ON dbo.employees.empId = dbo.v_EmployeesFullNameEn.empId
GO
ALTER AUTHORIZATION ON [dbo].[v_EmpoyeesJobsData] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_ParentsFullNameAr]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_ParentsFullNameAr]
AS
SELECT parentId, fNameAr + ' ' + mNameAr + ' ' + gNameAr + ' ' + lNameAr AS parentNameAr
FROM   dbo.parents
GO
ALTER AUTHORIZATION ON [dbo].[v_ParentsFullNameAr] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_ParentsFullNameEn]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_ParentsFullNameEn]
AS
SELECT parentId, fNameEn + ' ' + mNameEn + ' ' + gNameEn + ' ' + lNameEn AS parentNameEn
FROM   dbo.parents
GO
ALTER AUTHORIZATION ON [dbo].[v_ParentsFullNameEn] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_StudentsFullNameAr]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_StudentsFullNameAr]
AS
SELECT studentId, fNameAr + ' ' + mNameAr + ' ' + gNameAr + ' ' + lNameAr AS studentNameAr
FROM   dbo.students
GO
ALTER AUTHORIZATION ON [dbo].[v_StudentsFullNameAr] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_StudentsFullNameEn]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_StudentsFullNameEn]
AS
SELECT studentId, fNameEn + ' ' + mNameEn + ' ' + gNameEn + ' ' + lNameEn AS studentNameEn
FROM   dbo.students
GO
ALTER AUTHORIZATION ON [dbo].[v_StudentsFullNameEn] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_StudentsEduData]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_StudentsEduData]
AS
SELECT        dbo.v_StudentsFullNameAr.studentId, dbo.v_StudentsFullNameAr.studentNameAr, dbo.v_StudentsFullNameEn.studentNameEn, dbo.schools.schoolID, dbo.schools.schoolNameAr, dbo.schools.schoolNameEn, 
                         dbo.branches.branchId, dbo.branches.branchNameAr, dbo.branches.branchNameEn, dbo.stages.stageId, dbo.stages.stageNameAr, dbo.stages.stageNameEn, dbo.grades.gradeId, dbo.grades.gradeNameAr, 
                         dbo.grades.gradeNameEn, dbo.classrooms.classroomId, dbo.classrooms.classNameAr, dbo.classrooms.classNameEn, dbo.classesStudents.classStudentId, dbo.classesStudents.startDate, dbo.classesStudents.endDate, 
                         dbo.academicYears.yearId, dbo.academicYears.yearNameG, dbo.academicYears.yearNameH, dbo.academicYears.yearStartDateG, dbo.academicYears.yearStartDateH, dbo.academicYears.yearEndDateG, 
                         dbo.academicYears.yearEndDateH
FROM            dbo.classesStudents INNER JOIN
                         dbo.branches INNER JOIN
                         dbo.schools ON dbo.branches.schoolId = dbo.schools.schoolID INNER JOIN
                         dbo.grades INNER JOIN
                         dbo.classrooms ON dbo.grades.gradeId = dbo.classrooms.gradeId INNER JOIN
                         dbo.stages ON dbo.grades.stageId = dbo.stages.stageId ON dbo.branches.branchId = dbo.stages.branchId ON dbo.classesStudents.classroomId = dbo.classrooms.classroomId INNER JOIN
                         dbo.academicYears ON dbo.classesStudents.yearId = dbo.academicYears.yearId CROSS JOIN
                         dbo.v_StudentsFullNameAr CROSS JOIN
                         dbo.v_StudentsFullNameEn
GO
ALTER AUTHORIZATION ON [dbo].[v_StudentsEduData] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_StudentsViolationsData]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_StudentsViolationsData]
AS
SELECT        dbo.v_StudentsEduData.studentId, dbo.v_StudentsEduData.studentNameAr, dbo.v_StudentsEduData.studentNameEn, dbo.v_StudentsEduData.schoolNameAr, dbo.v_StudentsEduData.schoolNameEn, 
                         dbo.v_StudentsEduData.branchNameAr, dbo.v_StudentsEduData.branchNameEn, dbo.v_StudentsEduData.stageNameAr, dbo.v_StudentsEduData.stageNameEn, dbo.v_StudentsEduData.gradeNameAr, 
                         dbo.v_StudentsEduData.gradeNameEn, dbo.v_StudentsEduData.classNameAr, dbo.v_StudentsEduData.classNameEn, dbo.behavioralViolations.violationId, dbo.behavioralViolations.violationNameAr, 
                         dbo.behavioralViolations.violationNameEn, dbo.behavioralViolations.categoryId, dbo.studentsViolations.violationDate, dbo.studentsViolations.studentViolationId
FROM            dbo.studentsViolations INNER JOIN
                         dbo.behavioralViolations ON dbo.studentsViolations.violationId = dbo.behavioralViolations.violationId INNER JOIN
                         dbo.v_StudentsEduData ON dbo.v_StudentsEduData.studentId = dbo.studentsViolations.studentId
GO
ALTER AUTHORIZATION ON [dbo].[v_StudentsViolationsData] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_ProceduresOnStudentsData]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_ProceduresOnStudentsData]
AS
SELECT        dbo.v_StudentsViolationsData.studentId, dbo.v_StudentsViolationsData.studentNameAr, dbo.v_StudentsViolationsData.studentNameEn, dbo.v_StudentsViolationsData.schoolNameAr, 
                         dbo.v_StudentsViolationsData.schoolNameEn, dbo.v_StudentsViolationsData.branchNameAr, dbo.v_StudentsViolationsData.branchNameEn, dbo.v_StudentsViolationsData.stageNameAr, 
                         dbo.v_StudentsViolationsData.stageNameEn, dbo.v_StudentsViolationsData.gradeNameAr, dbo.v_StudentsViolationsData.gradeNameEn, dbo.v_StudentsViolationsData.classNameAr, 
                         dbo.v_StudentsViolationsData.classNameEn, dbo.v_StudentsViolationsData.violationId, dbo.v_StudentsViolationsData.violationNameAr, dbo.v_StudentsViolationsData.violationNameEn, 
                         dbo.v_StudentsViolationsData.categoryId, dbo.v_StudentsViolationsData.violationDate, dbo.v_StudentsViolationsData.studentViolationId, dbo.remedialProcedures.procedureId, dbo.remedialProcedures.procedureNameAr, 
                         dbo.remedialProcedures.procedureNameEn, dbo.remedialProcedures.categoryId AS ProcedureCategoryId, dbo.studentsProcedures.procedureDate, dbo.v_EmpoyeesJobsData.empJobId, dbo.v_EmpoyeesJobsData.empNameAr, 
                         dbo.v_EmpoyeesJobsData.empNameEn, dbo.v_EmpoyeesJobsData.jobId, dbo.v_EmpoyeesJobsData.jobNameAr, dbo.v_EmpoyeesJobsData.jobNameEn
FROM            dbo.studentsProcedures INNER JOIN
                         dbo.remedialProcedures ON dbo.studentsProcedures.procedureId = dbo.remedialProcedures.procedureId INNER JOIN
                         dbo.v_StudentsViolationsData ON dbo.studentsProcedures.studentViolationId = dbo.v_StudentsViolationsData.studentViolationId INNER JOIN
                         dbo.v_EmpoyeesJobsData ON dbo.studentsProcedures.empJobId = dbo.v_EmpoyeesJobsData.empJobId
GO
ALTER AUTHORIZATION ON [dbo].[v_ProceduresOnStudentsData] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_TeacherEduData]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_TeachersEduData]
AS
SELECT        dbo.users.userId, dbo.accountStatus.statusId, dbo.accountStatus.statusAr, dbo.accountStatus.statusEn, dbo.employeesJobs.empJobId, dbo.schools.schoolID, dbo.schools.schoolNameAr, dbo.schools.schoolNameEn, 
                         dbo.branches.branchId, dbo.branches.branchNameAr, dbo.branches.branchNameEn, dbo.stages.stageId, dbo.stages.stageNameAr, dbo.stages.stageNameEn, dbo.grades.gradeId, dbo.grades.gradeNameAr, 
                         dbo.grades.gradeNameEn, dbo.majors.majorId, dbo.majors.majorNameAr, dbo.majors.majorNameEn, dbo.teachersEdu.classroomIds, dbo.teachersQuorums.periodsQuorum, dbo.teachersQuorums.substituteQuorum, 
                         dbo.academicSemesters.semesterId, dbo.academicSemesters.semesterNameAr, dbo.academicSemesters.semesterNameEn, dbo.academicYears.yearId, dbo.academicYears.yearNameG, dbo.academicYears.yearNameH, 
                         dbo.gradesSubjects.gradeSubjectId, dbo.subjects.subjectId, dbo.subjects.subjectNameAr, dbo.subjects.subjectNameEn
FROM            dbo.branches INNER JOIN
                         dbo.schools ON dbo.branches.schoolId = dbo.schools.schoolID INNER JOIN
                         dbo.stages ON dbo.branches.branchId = dbo.stages.branchId INNER JOIN
                         dbo.grades ON dbo.stages.stageId = dbo.grades.stageId INNER JOIN
                         dbo.gradesSubjects ON dbo.grades.gradeId = dbo.gradesSubjects.gradeId INNER JOIN
                         dbo.teachersEdu ON dbo.gradesSubjects.gradeSubjectId = dbo.teachersEdu.gradeSubjectId INNER JOIN
                         dbo.users INNER JOIN
                         dbo.employees ON dbo.users.userId = dbo.employees.empId INNER JOIN
                         dbo.employeesJobs ON dbo.employees.empId = dbo.employeesJobs.empId ON dbo.teachersEdu.empJobId = dbo.employeesJobs.empJobId INNER JOIN
                         dbo.teachersQuorums ON dbo.employeesJobs.empJobId = dbo.teachersQuorums.empJobId INNER JOIN
                         dbo.academicSemesters ON dbo.teachersQuorums.semesterId = dbo.academicSemesters.semesterId INNER JOIN
                         dbo.academicYears ON dbo.academicSemesters.yearId = dbo.academicYears.yearId INNER JOIN
                         dbo.subjects ON dbo.gradesSubjects.subjectId = dbo.subjects.subjectId INNER JOIN
                         dbo.majors ON dbo.subjects.majorId = dbo.majors.majorId INNER JOIN
                         dbo.accountStatus ON dbo.users.accountStatusId = dbo.accountStatus.statusId
GO
ALTER AUTHORIZATION ON [dbo].[v_TeachersEduData] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_TimeTable]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_TimeTables]
AS
SELECT        dbo.schoolDayEvents.dayId, dbo.v_ClassroomsData.classNameAr, dbo.v_ClassroomsData.classNameEn, dbo.schoolDayEvents.eventNameAr, dbo.schoolDayEvents.eventNameEn, dbo.schoolDayEvents.startTime, 
                         dbo.schoolDayEvents.endTime, dbo.subjects.subjectNameAr, dbo.subjects.subjectNameEn, dbo.timeTables.timeTableId
FROM            dbo.timeTables INNER JOIN
                         dbo.schoolDayEvents ON dbo.timeTables.schoolDayEventId = dbo.schoolDayEvents.schoolDayEventId INNER JOIN
                         dbo.gradesSubjects ON dbo.timeTables.gradeSubjectId = dbo.gradesSubjects.gradeSubjectId INNER JOIN
                         dbo.subjects ON dbo.gradesSubjects.subjectId = dbo.subjects.subjectId INNER JOIN
                         dbo.employeesJobs ON dbo.timeTables.empJobId = dbo.employeesJobs.empJobId INNER JOIN
                         dbo.v_ClassroomsData ON dbo.v_ClassroomsData.classroomId = dbo.timeTables.classroomId
GO
ALTER AUTHORIZATION ON [dbo].[v_TimeTables] TO  SCHEMA OWNER 
GO
/****** Object:  View [dbo].[v_WeeksPlans]    Script Date: 23/11/2018 10:50:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_WeeksPlans]
AS
SELECT dbo.weeksPlans.weekPlanId, dbo.v_AcademicCalenders.yearId, dbo.v_AcademicCalenders.yearNameG, dbo.v_AcademicCalenders.yearNameH, dbo.v_AcademicCalenders.semesterId, dbo.v_AcademicCalenders.semesterNameAr, dbo.v_AcademicCalenders.semesterNameEn, 
             dbo.v_AcademicCalenders.weekId, dbo.v_AcademicCalenders.weekNameAr, dbo.v_AcademicCalenders.weekNameEn, dbo.v_TimeTables.dayId, dbo.v_TimeTables.classNameAr, dbo.v_TimeTables.classNameEn, dbo.v_TimeTables.subjectNameAr, dbo.v_TimeTables.subjectNameEn, 
             dbo.weeksPlans.date, dbo.weeksPlans.lessonId, dbo.weeksPlans.homework, dbo.weeksPlans.quiz, dbo.v_TimeTables.timeTableId, dbo.lessons.lessonTitle, dbo.lessons.lessonObjectives
FROM   dbo.weeksPlans INNER JOIN
             dbo.v_AcademicCalenders ON dbo.weeksPlans.weekId = dbo.v_AcademicCalenders.weekId INNER JOIN
             dbo.v_TimeTables ON dbo.v_TimeTables.timeTableId = dbo.weeksPlans.timeTableId INNER JOIN
             dbo.lessons ON dbo.weeksPlans.lessonId = dbo.lessons.lessonId
GO
ALTER AUTHORIZATION ON [dbo].[v_WeeksPlans] TO  SCHEMA OWNER 
GO

-- Alter database
USE [master]
GO
ALTER DATABASE [assadara_ssms] SET  READ_WRITE 
GO
ALTER DATABASE assadara_ssms SET ENABLE_BROKER with rollback immediate