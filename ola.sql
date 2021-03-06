USE [master]
GO
/****** Object:  Database [Cytaty]    Script Date: 06.01.2019 19:33:30 ******/
CREATE DATABASE [Cytaty]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cytaty', FILENAME = N'C:\Users\PrzemysławJeżewski\Desktop\OLA\Cytaty.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cytaty_log', FILENAME = N'C:\Users\PrzemysławJeżewski\Desktop\OLA\Cytaty_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Cytaty] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cytaty].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cytaty] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cytaty] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cytaty] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cytaty] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cytaty] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cytaty] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cytaty] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cytaty] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cytaty] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cytaty] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cytaty] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cytaty] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cytaty] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cytaty] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cytaty] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cytaty] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cytaty] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cytaty] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cytaty] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cytaty] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cytaty] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cytaty] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cytaty] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cytaty] SET  MULTI_USER 
GO
ALTER DATABASE [Cytaty] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cytaty] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cytaty] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cytaty] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cytaty] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cytaty] SET QUERY_STORE = OFF
GO
USE [Cytaty]
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
USE [Cytaty]
GO
/****** Object:  Table [dbo].[Cytaty]    Script Date: 06.01.2019 19:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cytaty](
	[ID_Cytat] [int] IDENTITY(1,1) NOT NULL,
	[Cytat] [nvarchar](max) NOT NULL,
	[ID_Mysliciel] [int] NULL,
	[ID_SlowoKlucz] [int] NULL,
	[DataDodania] [datetime2](7) NULL,
	[DataEdycji] [datetime2](7) NULL,
 CONSTRAINT [PK_Cytaty] PRIMARY KEY CLUSTERED 
(
	[ID_Cytat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mysliciele]    Script Date: 06.01.2019 19:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mysliciele](
	[ID_Mysliciel] [int] IDENTITY(1,1) NOT NULL,
	[Mysliciel] [nvarchar](max) NOT NULL,
	[Lata_życia] [nvarchar](50) NULL,
	[Biogram] [nvarchar](max) NULL,
	[DataDodania] [datetime2](7) NULL,
	[DataEdycji] [datetime2](7) NULL,
 CONSTRAINT [PK_Mysliciele] PRIMARY KEY CLUSTERED 
(
	[ID_Mysliciel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SłowaKluczowe]    Script Date: 06.01.2019 19:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SłowaKluczowe](
	[ID_SlowoKlucz] [int] IDENTITY(1,1) NOT NULL,
	[Tag] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SłowaKluczowe] PRIMARY KEY CLUSTERED 
(
	[ID_SlowoKlucz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SlowaKluczoweWCytatach]    Script Date: 06.01.2019 19:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SlowaKluczoweWCytatach](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cytat] [int] NOT NULL,
	[ID_SlowoKlucz] [int] NOT NULL,
 CONSTRAINT [PK_SlowaKluczoweWCytatach] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utwory]    Script Date: 06.01.2019 19:33:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utwory](
	[ID_Utwor] [int] IDENTITY(1,1) NOT NULL,
	[Tytuł] [nvarchar](max) NOT NULL,
	[RokWydania] [int] NULL,
	[ID_Mysliciel] [int] NULL,
 CONSTRAINT [PK_Utwory] PRIMARY KEY CLUSTERED 
(
	[ID_Utwor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cytaty] ON 

INSERT [dbo].[Cytaty] ([ID_Cytat], [Cytat], [ID_Mysliciel], [ID_SlowoKlucz], [DataDodania], [DataEdycji]) VALUES (3, N'Jesteśmy tym, co w swoim życiu powtarzamy. Doskonałość nie jest jednorazowym aktem, lecz nawykiem.', 3, 1, CAST(N'2019-01-06T16:54:09.1733333' AS DateTime2), CAST(N'2019-01-06T16:54:09.1733333' AS DateTime2))
INSERT [dbo].[Cytaty] ([ID_Cytat], [Cytat], [ID_Mysliciel], [ID_SlowoKlucz], [DataDodania], [DataEdycji]) VALUES (4, N'Ludzie są dokładnie tak szczęśliwi, jak myślą, że są. ', 4, NULL, CAST(N'2019-01-06T16:54:09.1733333' AS DateTime2), CAST(N'2019-01-06T16:54:09.1733333' AS DateTime2))
INSERT [dbo].[Cytaty] ([ID_Cytat], [Cytat], [ID_Mysliciel], [ID_SlowoKlucz], [DataDodania], [DataEdycji]) VALUES (5, N'Potykając się, można zajść daleko; nie wolno tylko upaść i nie podnieść się.', 5, NULL, CAST(N'2019-01-06T16:54:09.1733333' AS DateTime2), CAST(N'2019-01-06T16:54:09.1733333' AS DateTime2))
INSERT [dbo].[Cytaty] ([ID_Cytat], [Cytat], [ID_Mysliciel], [ID_SlowoKlucz], [DataDodania], [DataEdycji]) VALUES (6, N'Kochaj wszystkich, ufaj niewielu, nie czyń krzywdy nikomu.', 6, 1, CAST(N'2019-01-06T16:54:47.3787436' AS DateTime2), CAST(N'2019-01-06T16:54:47.3787436' AS DateTime2))
INSERT [dbo].[Cytaty] ([ID_Cytat], [Cytat], [ID_Mysliciel], [ID_SlowoKlucz], [DataDodania], [DataEdycji]) VALUES (7, N'Puste naczynia robią najwięcej hałasu.', 6, 1, CAST(N'2019-01-06T16:54:54.3134505' AS DateTime2), CAST(N'2019-01-06T16:54:54.3134505' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Cytaty] OFF
SET IDENTITY_INSERT [dbo].[Mysliciele] ON 

INSERT [dbo].[Mysliciele] ([ID_Mysliciel], [Mysliciel], [Lata_życia], [Biogram], [DataDodania], [DataEdycji]) VALUES (3, N'Arystoteles', NULL, NULL, NULL, NULL)
INSERT [dbo].[Mysliciele] ([ID_Mysliciel], [Mysliciel], [Lata_życia], [Biogram], [DataDodania], [DataEdycji]) VALUES (4, N'Abraham Lincoln', NULL, NULL, NULL, NULL)
INSERT [dbo].[Mysliciele] ([ID_Mysliciel], [Mysliciel], [Lata_życia], [Biogram], [DataDodania], [DataEdycji]) VALUES (5, N'Goethe', NULL, NULL, NULL, NULL)
INSERT [dbo].[Mysliciele] ([ID_Mysliciel], [Mysliciel], [Lata_życia], [Biogram], [DataDodania], [DataEdycji]) VALUES (6, N'William Shakespeare', N'1564–1616', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Mysliciele] OFF
SET IDENTITY_INSERT [dbo].[SłowaKluczowe] ON 

INSERT [dbo].[SłowaKluczowe] ([ID_SlowoKlucz], [Tag]) VALUES (1, N'pusty')
INSERT [dbo].[SłowaKluczowe] ([ID_SlowoKlucz], [Tag]) VALUES (2, N'hałas')
SET IDENTITY_INSERT [dbo].[SłowaKluczowe] OFF
ALTER TABLE [dbo].[Cytaty]  WITH CHECK ADD  CONSTRAINT [FK_Cytaty_Mysliciele] FOREIGN KEY([ID_Mysliciel])
REFERENCES [dbo].[Mysliciele] ([ID_Mysliciel])
GO
ALTER TABLE [dbo].[Cytaty] CHECK CONSTRAINT [FK_Cytaty_Mysliciele]
GO
ALTER TABLE [dbo].[SlowaKluczoweWCytatach]  WITH CHECK ADD  CONSTRAINT [FK_SlowaKluczoweWCytatach_Cytaty] FOREIGN KEY([ID_Cytat])
REFERENCES [dbo].[Cytaty] ([ID_Cytat])
GO
ALTER TABLE [dbo].[SlowaKluczoweWCytatach] CHECK CONSTRAINT [FK_SlowaKluczoweWCytatach_Cytaty]
GO
ALTER TABLE [dbo].[SlowaKluczoweWCytatach]  WITH CHECK ADD  CONSTRAINT [FK_SlowaKluczoweWCytatach_SłowaKluczowe] FOREIGN KEY([ID_SlowoKlucz])
REFERENCES [dbo].[SłowaKluczowe] ([ID_SlowoKlucz])
GO
ALTER TABLE [dbo].[SlowaKluczoweWCytatach] CHECK CONSTRAINT [FK_SlowaKluczoweWCytatach_SłowaKluczowe]
GO
ALTER TABLE [dbo].[Utwory]  WITH CHECK ADD  CONSTRAINT [FK_Utwory_Mysliciele] FOREIGN KEY([ID_Mysliciel])
REFERENCES [dbo].[Mysliciele] ([ID_Mysliciel])
GO
ALTER TABLE [dbo].[Utwory] CHECK CONSTRAINT [FK_Utwory_Mysliciele]
GO
USE [master]
GO
ALTER DATABASE [Cytaty] SET  READ_WRITE 
GO
