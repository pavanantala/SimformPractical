USE [master]
GO
/****** Object:  Database [SimformPractical]    Script Date: 06-Feb-20 10:28:18 AM ******/
CREATE DATABASE [SimformPractical]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SimformPractical', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SimformPractical.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SimformPractical_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SimformPractical_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SimformPractical] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SimformPractical].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SimformPractical] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SimformPractical] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SimformPractical] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SimformPractical] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SimformPractical] SET ARITHABORT OFF 
GO
ALTER DATABASE [SimformPractical] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SimformPractical] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SimformPractical] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SimformPractical] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SimformPractical] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SimformPractical] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SimformPractical] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SimformPractical] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SimformPractical] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SimformPractical] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SimformPractical] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SimformPractical] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SimformPractical] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SimformPractical] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SimformPractical] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SimformPractical] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SimformPractical] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SimformPractical] SET RECOVERY FULL 
GO
ALTER DATABASE [SimformPractical] SET  MULTI_USER 
GO
ALTER DATABASE [SimformPractical] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SimformPractical] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SimformPractical] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SimformPractical] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SimformPractical] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SimformPractical', N'ON'
GO
ALTER DATABASE [SimformPractical] SET QUERY_STORE = OFF
GO
USE [SimformPractical]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[JoiningDate] [datetime] NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeToProject]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeToProject](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [int] NULL,
	[ProjectId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[Cost] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [JoiningDate], [Salary]) VALUES (1, N'Test', N'test123', CAST(N'2020-02-05T03:38:30.000' AS DateTime), CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [JoiningDate], [Salary]) VALUES (5, N'test1', N'test1', CAST(N'2020-02-26T00:00:00.000' AS DateTime), CAST(100000.00 AS Decimal(18, 2)))
INSERT [dbo].[Employee] ([Id], [FirstName], [LastName], [JoiningDate], [Salary]) VALUES (6, N'Test 2', N'Test 2', CAST(N'2020-02-19T00:00:00.000' AS DateTime), CAST(50000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeToProject] ON 

INSERT [dbo].[EmployeeToProject] ([Id], [EmpId], [ProjectId]) VALUES (4, 1, 3)
INSERT [dbo].[EmployeeToProject] ([Id], [EmpId], [ProjectId]) VALUES (5, 5, 4)
SET IDENTITY_INSERT [dbo].[EmployeeToProject] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Name], [Cost]) VALUES (3, N'sdaf', CAST(50.00 AS Decimal(18, 2)))
INSERT [dbo].[Project] ([Id], [Name], [Cost]) VALUES (4, N'test1', CAST(50.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Project] OFF
ALTER TABLE [dbo].[EmployeeToProject]  WITH CHECK ADD FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[EmployeeToProject]  WITH CHECK ADD FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[AddEditEmployee]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROC [dbo].[AddEditEmployee] 
 @Id int=0
,@FirstName varchar(50)
,@LastName varchar(50)
,@JoiningDate datetime
,@Salary decimal(18,2)
AS
BEGIN
	IF EXISTS(select 1 from Employee where Id = @Id )
		BEGIN
			UPDATE 
				Employee 
			SET
				 FirstName    = @FirstName
				,LastName	  = @LastName
				,JoiningDate  = @JoiningDate
				,Salary		  = @Salary
			WHERE
				Id = @Id

			Select 'Successfully Updated' as result
		END
	ELSE
		BEGIN
			INSERT INTO Employee
				(
				 FirstName
				,LastName
				,JoiningDate
				,Salary
				)
				values
				(
				 @FirstName
				,@LastName
				,@JoiningDate
				,@Salary
				)
			--SELECT SCOPE_IDENTITY() as result
			SELECT 'Successfully Created' as result
		END
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeById]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROC [dbo].[DeleteEmployeeById] 
 @Id int
AS
BEGIN
	IF EXISTS(select 1 from Employee where Id = @Id )
		BEGIN
			DELETE
				Employee
			WHERE
				Id = @Id

			Select 'Success' as result
		END
	ELSE
		BEGIN
			SELECT '' as result
		END
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmployeeToProjectById]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROC [dbo].[DeleteEmployeeToProjectById]   
 @Id int  
AS  
BEGIN  
 IF EXISTS(select 1 from EmployeeToProject where Id = @Id )  
  BEGIN  
   DELETE  
    EmployeeToProject  
   WHERE  
    Id = @Id  
  
   Select 'Success' as result  
  END  
 ELSE  
  BEGIN  
   SELECT '' as result  
  END  
END  
GO
/****** Object:  StoredProcedure [dbo].[DeleteProjectById]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROC [dbo].[DeleteProjectById]   
 @Id int  
AS  
BEGIN  
 IF EXISTS(select 1 from Project where Id = @Id )  
  BEGIN  
   DELETE  
    Project  
   WHERE  
    Id = @Id  
  
   Select 'Success' as result  
  END  
 ELSE  
  BEGIN  
   SELECT '' as result  
  END  
END  
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeById]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROC [dbo].[GetEmployeeById] 
	@Id int
AS
BEGIN

IF EXISTS(select 1 from Employee where Id = @Id )
	BEGIN
		SELECT 
			Id
			,FirstName
			,LastName
			,JoiningDate
			,Salary
		FROM
			Employee
		WHERE 
			Id = @Id
	END
ELSE
	BEGIN
		SELECT 0
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetProjectAssignListToEmployee]    Script Date: 06-Feb-20 10:28:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetProjectAssignListToEmployee]  
@EmployeeName varchar(50)=''  
,@ProjectName varchar(50)=''  
,@JoiningDate datetime =null  
AS  
BEGIN  
 SELECT 
 EP.Id
 ,EP.EmpId
 ,EP.ProjectId   
  ,P.[Name]  
  ,P.Cost  
  ,(E.FirstName + + E.LastName) as FullName  
  ,FORMAT(E.JoiningDate,'dd-MMM-yyyy') AS JoiningDateString
 FROM   
  EmployeeToProject EP  
  INNER JOIN Employee E on EP.EmpId = E.Id  
  INNER JOIN Project P on EP.ProjectId = P.Id  
 where  
  (ISNULL(@EmployeeName, '') = '' or (E.FirstName+' '+E.LastName) like '%'+@EmployeeName+'%')    
  AND  
  (ISNULL(@ProjectName, '') = '' or P.[Name] like '%'+@ProjectName+'%')  
  AND  
  (ISNULL(@JoiningDate, '') = '' or convert(varchar(10),E.JoiningDate,103) = convert(varchar(10),@JoiningDate,103))  
END
GO
USE [master]
GO
ALTER DATABASE [SimformPractical] SET  READ_WRITE 
GO
