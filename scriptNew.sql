USE [master]
GO
/****** Object:  Database [flowershop]    Script Date: 20.05.2024 11:41:42 ******/
CREATE DATABASE [flowershop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'flowershop', FILENAME = N'C:\Users\10210813\flowershop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'flowershop_log', FILENAME = N'C:\Users\10210813\flowershop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [flowershop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [flowershop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [flowershop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [flowershop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [flowershop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [flowershop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [flowershop] SET ARITHABORT OFF 
GO
ALTER DATABASE [flowershop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [flowershop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [flowershop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [flowershop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [flowershop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [flowershop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [flowershop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [flowershop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [flowershop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [flowershop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [flowershop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [flowershop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [flowershop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [flowershop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [flowershop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [flowershop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [flowershop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [flowershop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [flowershop] SET  MULTI_USER 
GO
ALTER DATABASE [flowershop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [flowershop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [flowershop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [flowershop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [flowershop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [flowershop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [flowershop] SET QUERY_STORE = OFF
GO
USE [flowershop]
GO
/****** Object:  Table [dbo].[basket]    Script Date: 20.05.2024 11:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[basket](
	[idbasket] [int] NOT NULL,
	[idgood] [int] NULL,
	[iduser] [int] NULL,
	[quantity] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 20.05.2024 11:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[idcategory] [int] NOT NULL,
	[name] [nvarchar](250) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[idcategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[goods]    Script Date: 20.05.2024 11:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[goods](
	[idgood] [int] NOT NULL,
	[name] [nvarchar](250) NULL,
	[description] [nvarchar](250) NULL,
	[price] [int] NULL,
	[image] [nvarchar](250) NULL,
	[idcategory] [int] NULL,
 CONSTRAINT [PK_goods] PRIMARY KEY CLUSTERED 
(
	[idgood] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 20.05.2024 11:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[idorder] [int] NOT NULL,
	[idbasket] [int] NULL,
	[iduser] [int] NULL,
	[orderdate] [date] NULL,
	[orderstatus] [int] NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[idorder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 20.05.2024 11:41:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[iduser] [int] NOT NULL,
	[staff] [int] NULL,
	[login] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[phonenumber] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[surname] [nvarchar](50) NULL,
	[patronymic] [nvarchar](50) NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[iduser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[category] ([idcategory], [name]) VALUES (1, N'Цветы')
INSERT [dbo].[category] ([idcategory], [name]) VALUES (2, N'Украшения к цветам')
GO
INSERT [dbo].[goods] ([idgood], [name], [description], [price], [image], [idcategory]) VALUES (1, N'Воздушный Шарик', N'летает', 500, N'ballon.jpg', 2)
INSERT [dbo].[goods] ([idgood], [name], [description], [price], [image], [idcategory]) VALUES (2, N'Розы', N'розы красные ароматные свежие', 1250, N'roza.png', 1)
GO
ALTER TABLE [dbo].[basket]  WITH CHECK ADD  CONSTRAINT [FK_basket_goods1] FOREIGN KEY([idgood])
REFERENCES [dbo].[goods] ([idgood])
GO
ALTER TABLE [dbo].[basket] CHECK CONSTRAINT [FK_basket_goods1]
GO
ALTER TABLE [dbo].[basket]  WITH CHECK ADD  CONSTRAINT [FK_basket_orders] FOREIGN KEY([idbasket])
REFERENCES [dbo].[orders] ([idorder])
GO
ALTER TABLE [dbo].[basket] CHECK CONSTRAINT [FK_basket_orders]
GO
ALTER TABLE [dbo].[basket]  WITH CHECK ADD  CONSTRAINT [FK_basket_users] FOREIGN KEY([iduser])
REFERENCES [dbo].[users] ([iduser])
GO
ALTER TABLE [dbo].[basket] CHECK CONSTRAINT [FK_basket_users]
GO
ALTER TABLE [dbo].[goods]  WITH CHECK ADD  CONSTRAINT [FK_goods_category] FOREIGN KEY([idcategory])
REFERENCES [dbo].[category] ([idcategory])
GO
ALTER TABLE [dbo].[goods] CHECK CONSTRAINT [FK_goods_category]
GO
USE [master]
GO
ALTER DATABASE [flowershop] SET  READ_WRITE 
GO
