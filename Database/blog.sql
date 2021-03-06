USE [master]
GO
/****** Object:  Database [TufyDuckDB]    Script Date: 1.11.2018 17:44:18 ******/
CREATE DATABASE [TufyDuckDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TufyDuckDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER\MSSQL\DATA\TufyDuckDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TufyDuckDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSERVER\MSSQL\DATA\TufyDuckDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TufyDuckDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TufyDuckDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TufyDuckDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TufyDuckDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TufyDuckDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TufyDuckDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TufyDuckDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TufyDuckDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TufyDuckDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TufyDuckDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TufyDuckDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TufyDuckDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TufyDuckDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TufyDuckDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TufyDuckDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TufyDuckDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TufyDuckDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TufyDuckDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TufyDuckDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TufyDuckDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TufyDuckDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TufyDuckDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TufyDuckDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TufyDuckDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TufyDuckDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TufyDuckDB] SET  MULTI_USER 
GO
ALTER DATABASE [TufyDuckDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TufyDuckDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TufyDuckDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TufyDuckDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TufyDuckDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TufyDuckDB', N'ON'
GO
ALTER DATABASE [TufyDuckDB] SET QUERY_STORE = OFF
GO
USE [TufyDuckDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
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
USE [TufyDuckDB]
GO
/****** Object:  Table [dbo].[Etiket]    Script Date: 1.11.2018 17:44:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Etiket](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NULL,
 CONSTRAINT [PK_Etiket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 1.11.2018 17:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 1.11.2018 17:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](10) NOT NULL,
	[Parola] [nvarchar](20) NOT NULL,
	[Ad] [nvarchar](50) NULL,
	[Soyad] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Tarih] [datetime] NOT NULL,
	[YetkiID] [int] NOT NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Makale]    Script Date: 1.11.2018 17:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Makale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Baslik] [nvarchar](150) NOT NULL,
	[Icerik] [nvarchar](max) NOT NULL,
	[KullaniciID] [int] NOT NULL,
	[Tarih] [datetime] NULL,
	[KategoriID] [int] NOT NULL,
 CONSTRAINT [PK_Makale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MakaleEtiket]    Script Date: 1.11.2018 17:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MakaleEtiket](
	[MakaleID] [int] NOT NULL,
	[EtiketID] [int] NOT NULL,
 CONSTRAINT [PK_MakaleEtiket] PRIMARY KEY CLUSTERED 
(
	[MakaleID] ASC,
	[EtiketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yetki]    Script Date: 1.11.2018 17:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yetki](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adi] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Yetki] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yorum]    Script Date: 1.11.2018 17:44:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yorum](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Icerik] [nvarchar](max) NOT NULL,
	[KullaniciID] [int] NOT NULL,
	[MakaleID] [int] NOT NULL,
	[Tarih] [datetime] NULL,
 CONSTRAINT [PK_Yorum] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Etiket] ON 

INSERT [dbo].[Etiket] ([Id], [Ad]) VALUES (1, N'Bilim')
INSERT [dbo].[Etiket] ([Id], [Ad]) VALUES (2, N'asfsa')
INSERT [dbo].[Etiket] ([Id], [Ad]) VALUES (3, N'safasf')
INSERT [dbo].[Etiket] ([Id], [Ad]) VALUES (4, N'aaa')
SET IDENTITY_INSERT [dbo].[Etiket] OFF
SET IDENTITY_INSERT [dbo].[Kategori] ON 

INSERT [dbo].[Kategori] ([Id], [Ad]) VALUES (1, N'Bilim')
INSERT [dbo].[Kategori] ([Id], [Ad]) VALUES (2, N'Sanat')
INSERT [dbo].[Kategori] ([Id], [Ad]) VALUES (3, N'Oyun')
INSERT [dbo].[Kategori] ([Id], [Ad]) VALUES (4, N'Eğitim')
INSERT [dbo].[Kategori] ([Id], [Ad]) VALUES (5, N'Siyaset')
INSERT [dbo].[Kategori] ([Id], [Ad]) VALUES (6, N'Tarih')
SET IDENTITY_INSERT [dbo].[Kategori] OFF
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([Id], [KullaniciAdi], [Parola], [Ad], [Soyad], [Email], [Tarih], [YetkiID]) VALUES (3, N'baki', N'123', N'yqyqyqyq', N'qyyqy', N'geqqh', CAST(N'2018-07-23T03:16:51.603' AS DateTime), 4)
INSERT [dbo].[Kullanici] ([Id], [KullaniciAdi], [Parola], [Ad], [Soyad], [Email], [Tarih], [YetkiID]) VALUES (4, N'exe', N'1', N'ass', N'ss', N'ss', CAST(N'2018-07-23T21:22:18.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
SET IDENTITY_INSERT [dbo].[Makale] ON 

INSERT [dbo].[Makale] ([Id], [Baslik], [Icerik], [KullaniciID], [Tarih], [KategoriID]) VALUES (1, N'Doğal yollar ile', N'ASJGAJGJ', 3, CAST(N'2018-07-23T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Makale] ([Id], [Baslik], [Icerik], [KullaniciID], [Tarih], [KategoriID]) VALUES (3, N'AGKAKG aG', N'asşjgajgjak ', 3, CAST(N'2018-07-23T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Makale] ([Id], [Baslik], [Icerik], [KullaniciID], [Tarih], [KategoriID]) VALUES (1007, N'SELAM', N'SAFASF', 4, CAST(N'2018-07-25T19:49:45.040' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Makale] OFF
INSERT [dbo].[MakaleEtiket] ([MakaleID], [EtiketID]) VALUES (1007, 2)
INSERT [dbo].[MakaleEtiket] ([MakaleID], [EtiketID]) VALUES (1007, 3)
INSERT [dbo].[MakaleEtiket] ([MakaleID], [EtiketID]) VALUES (1007, 4)
SET IDENTITY_INSERT [dbo].[Yetki] ON 

INSERT [dbo].[Yetki] ([Id], [Adi]) VALUES (1, N'Uye')
INSERT [dbo].[Yetki] ([Id], [Adi]) VALUES (2, N'Moderator')
INSERT [dbo].[Yetki] ([Id], [Adi]) VALUES (3, N'Admin')
INSERT [dbo].[Yetki] ([Id], [Adi]) VALUES (4, N'Super Admin')
SET IDENTITY_INSERT [dbo].[Yetki] OFF
SET IDENTITY_INSERT [dbo].[Yorum] ON 

INSERT [dbo].[Yorum] ([Id], [Icerik], [KullaniciID], [MakaleID], [Tarih]) VALUES (1003, N'fsafsa', 4, 1, CAST(N'2018-07-25T18:50:44.627' AS DateTime))
SET IDENTITY_INSERT [dbo].[Yorum] OFF
ALTER TABLE [dbo].[Kullanici] ADD  CONSTRAINT [DF_Kullanici_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Makale] ADD  CONSTRAINT [DF_Makale_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Yorum] ADD  CONSTRAINT [DF_Yorum_Tarih]  DEFAULT (getdate()) FOR [Tarih]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Yetki] FOREIGN KEY([YetkiID])
REFERENCES [dbo].[Yetki] ([Id])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Yetki]
GO
ALTER TABLE [dbo].[Makale]  WITH CHECK ADD  CONSTRAINT [FK_Makale_Kategori] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategori] ([Id])
GO
ALTER TABLE [dbo].[Makale] CHECK CONSTRAINT [FK_Makale_Kategori]
GO
ALTER TABLE [dbo].[Makale]  WITH CHECK ADD  CONSTRAINT [FK_Makale_Kullanici] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanici] ([Id])
GO
ALTER TABLE [dbo].[Makale] CHECK CONSTRAINT [FK_Makale_Kullanici]
GO
ALTER TABLE [dbo].[MakaleEtiket]  WITH CHECK ADD  CONSTRAINT [FK_MakaleEtiket_Etiket] FOREIGN KEY([EtiketID])
REFERENCES [dbo].[Etiket] ([Id])
GO
ALTER TABLE [dbo].[MakaleEtiket] CHECK CONSTRAINT [FK_MakaleEtiket_Etiket]
GO
ALTER TABLE [dbo].[MakaleEtiket]  WITH CHECK ADD  CONSTRAINT [FK_MakaleEtiket_Makale] FOREIGN KEY([MakaleID])
REFERENCES [dbo].[Makale] ([Id])
GO
ALTER TABLE [dbo].[MakaleEtiket] CHECK CONSTRAINT [FK_MakaleEtiket_Makale]
GO
ALTER TABLE [dbo].[Yorum]  WITH CHECK ADD  CONSTRAINT [FK_Yorum_Kullanici] FOREIGN KEY([KullaniciID])
REFERENCES [dbo].[Kullanici] ([Id])
GO
ALTER TABLE [dbo].[Yorum] CHECK CONSTRAINT [FK_Yorum_Kullanici]
GO
ALTER TABLE [dbo].[Yorum]  WITH CHECK ADD  CONSTRAINT [FK_Yorum_Makale] FOREIGN KEY([MakaleID])
REFERENCES [dbo].[Makale] ([Id])
GO
ALTER TABLE [dbo].[Yorum] CHECK CONSTRAINT [FK_Yorum_Makale]
GO
USE [master]
GO
ALTER DATABASE [TufyDuckDB] SET  READ_WRITE 
GO
