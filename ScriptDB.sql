USE [master]
GO
/****** Object:  Database [PruebaTecnica]    Script Date: 10/10/2024 12:50:37 p. m. ******/
CREATE DATABASE [PruebaTecnica]

USE [PruebaTecnica]

CREATE TABLE [dbo].[Personas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[NumIdentificacion] [varchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[TipoIdentificacion] [varchar](3) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/10/2024 12:50:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Pass] [varchar](50) NOT NULL,
	[HashKey] [binary](32) NULL,
	[HashIV] [binary](16) NULL,
	[FechaCreacion] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([Id], [Usuario], [Pass], [HashKey], [HashIV], [FechaCreacion]) VALUES (3, N'aechavezguardo@gmail.com', N'PqtOwblimDtEnSI2XZ6iAw==', 0x91C28594A36B5A1F30840E3A20F931B797A4C82026975553131F7FD344CB9F95, 0x2194DBAC10A57415F16327C98F34EACD, CAST(N'2024-10-10T12:07:56.097' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
USE [master]
GO
ALTER DATABASE [PruebaTecnica] SET  READ_WRITE 
GO
