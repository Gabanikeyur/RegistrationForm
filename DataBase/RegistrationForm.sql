USE [master]
GO
/****** Object:  Database [RegistrationForm]    Script Date: 14-09-2024 16:28:17 ******/
CREATE DATABASE [RegistrationForm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RegistrationForm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\RegistrationForm.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RegistrationForm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\RegistrationForm_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [RegistrationForm] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RegistrationForm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RegistrationForm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RegistrationForm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RegistrationForm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RegistrationForm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RegistrationForm] SET ARITHABORT OFF 
GO
ALTER DATABASE [RegistrationForm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RegistrationForm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RegistrationForm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RegistrationForm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RegistrationForm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RegistrationForm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RegistrationForm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RegistrationForm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RegistrationForm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RegistrationForm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RegistrationForm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RegistrationForm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RegistrationForm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RegistrationForm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RegistrationForm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RegistrationForm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RegistrationForm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RegistrationForm] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RegistrationForm] SET  MULTI_USER 
GO
ALTER DATABASE [RegistrationForm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RegistrationForm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RegistrationForm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RegistrationForm] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RegistrationForm] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RegistrationForm] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RegistrationForm] SET QUERY_STORE = ON
GO
ALTER DATABASE [RegistrationForm] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RegistrationForm]
GO
/****** Object:  Table [dbo].[tblCity]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StateId] [int] NULL,
	[City_Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblState]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblState](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State_Name] [varchar](50) NULL,
 CONSTRAINT [PK_tblState] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUserRegistration]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](70) NULL,
	[Phone] [varchar](15) NULL,
	[Address] [varchar](250) NULL,
	[StateId] [int] NULL,
	[CityId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tblCity]  WITH CHECK ADD FOREIGN KEY([StateId])
REFERENCES [dbo].[tblState] ([Id])
GO
ALTER TABLE [dbo].[tblUserRegistration]  WITH CHECK ADD  CONSTRAINT [FK_UserCity] FOREIGN KEY([CityId])
REFERENCES [dbo].[tblCity] ([Id])
GO
ALTER TABLE [dbo].[tblUserRegistration] CHECK CONSTRAINT [FK_UserCity]
GO
ALTER TABLE [dbo].[tblUserRegistration]  WITH CHECK ADD  CONSTRAINT [FK_UserState] FOREIGN KEY([StateId])
REFERENCES [dbo].[tblState] ([Id])
GO
ALTER TABLE [dbo].[tblUserRegistration] CHECK CONSTRAINT [FK_UserState]
GO
/****** Object:  StoredProcedure [dbo].[spAddNewUser]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spAddNewUser]
(
@Name varchar(100),
@Email varchar(70),
@Phone varchar(15),
@Address varchar(250),
@StateId int,
@CityId int
)
as
begin
	insert into tblUserRegistration(Name,Email,Phone,Address,StateId,CityId) 
	values(@Name,@Email,@Phone,@Address,@StateId,@CityId)
end
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spDeleteUser]
(
@Id int
)
as
begin
	delete from tblUserRegistration where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[spGetCity]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetCity]
(@Id int)
as 
begin
	Select * from tblCity Where StateId = @Id
end
GO
/****** Object:  StoredProcedure [dbo].[spGetState]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spGetState]
as
begin
	select * from tblState
end
GO
/****** Object:  StoredProcedure [dbo].[spGetUser]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUser]
as 
begin
select * from tblUserRegistration
end
GO
/****** Object:  StoredProcedure [dbo].[spGetUserById]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spGetUserById]
(
@Id int
)
as
begin
	Select * from tblUserRegistration where Id=@Id
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdateUser]    Script Date: 14-09-2024 16:28:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[spUpdateUser](
@Id int,
@Name varchar(100),
@Email varchar(70),
@Phone varchar(15),
@Address varchar(250),
@StateId int,
@CityId int
)
as
begin
	update tblUserRegistration
	set Name=@Name,Email=@Email,Phone=@Phone,Address=@Address,StateId=@StateId,CityId=@CityId
	Where Id=@Id
end
GO
USE [master]
GO
ALTER DATABASE [RegistrationForm] SET  READ_WRITE 
GO
