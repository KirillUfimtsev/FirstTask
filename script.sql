﻿USE [master]
GO
/****** Object:  Database [Task1_DB]    Script Date: 09.09.2023 2:06:48 ******/
CREATE DATABASE [Task1_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Task1_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Task1_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Task1_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Task1_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Task1_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Task1_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Task1_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Task1_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Task1_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Task1_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Task1_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [Task1_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Task1_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Task1_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Task1_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Task1_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Task1_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Task1_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Task1_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Task1_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Task1_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Task1_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Task1_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Task1_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Task1_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Task1_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Task1_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Task1_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Task1_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Task1_DB] SET  MULTI_USER 
GO
ALTER DATABASE [Task1_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Task1_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Task1_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Task1_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Task1_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Task1_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Task1_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [Task1_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Task1_DB]
GO
/****** Object:  Table [dbo].[Marker]    Script Date: 09.09.2023 2:06:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marker](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Marker] ON 

INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (1, 55.75393, 37.620795)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (2, 59.9409876, 30.3129961)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (3, 55.0294979678647, 82.9194831848145)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (23, 55.0301251897275, 82.9270362854004)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (24, 55.0295287142632, 82.9245901107788)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (25, 55.0863261884505, 82.9732131958008)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (26, 55.0343187150281, 83.0044555664063)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (27, 54.9413434668222, 82.9248046875)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (28, 54.9933731136735, 82.85888671875)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (29, 55.0122762789897, 82.7970886230469)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (30, 54.9902217200489, 83.0923461914063)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (31, 54.9373990803353, 83.0168151855469)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (32, 55.0028258097932, 82.9975891113281)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (33, 55.0655902873086, 82.9251480102539)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (34, 54.9563286069277, 83.2406616210938)
INSERT [dbo].[Marker] ([ID], [Latitude], [Longitude]) VALUES (35, 54.9886459304339, 83.1953430175781)
SET IDENTITY_INSERT [dbo].[Marker] OFF
GO
USE [master]
GO
ALTER DATABASE [Task1_DB] SET  READ_WRITE 
GO
