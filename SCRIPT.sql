USE [DBHosteria_Tesoro]
GO
/****** Object:  Table [dbo].[Tarifa]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tarifa](
	[IdTarifa] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NULL,
	[Nombre] [varchar](100) NULL,
	[Valor] [float] NULL,
 CONSTRAINT [PK_Tarifa] PRIMARY KEY CLUSTERED 
(
	[IdTarifa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Servicio](
	[IdServicio] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[IdServicio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Implementos]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Implementos](
	[IdImplementos] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](300) NULL,
	[Nombre] [varchar](100) NULL,
	[Cantidad] [int] NULL,
 CONSTRAINT [PK_Implementos] PRIMARY KEY CLUSTERED 
(
	[IdImplementos] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Empleado](
	[strDocumento_EMPL] [int] NOT NULL,
	[strNombre_EMPL] [varchar](50) NOT NULL,
	[strPrimerApellido_EMPL] [varchar](50) NOT NULL,
	[strSegundoApellido_EMPL] [varchar](50) NULL,
	[strDireccion_EMPL] [varchar](200) NOT NULL,
	[strTelefono_EMPL] [varchar](20) NOT NULL,
 CONSTRAINT [PK_tblEMPLeado] PRIMARY KEY CLUSTERED 
(
	[strDocumento_EMPL] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[strDocumento_CLIE] [int] NOT NULL,
	[strNombre_CLIE] [varchar](50) NOT NULL,
	[strPrimerApellido_CLIE] [varchar](50) NOT NULL,
	[strSegundoApellido_CLIE] [varchar](50) NULL,
	[strDireccion_CLIE] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[strDocumento_CLIE] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cabaña]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cabaña](
	[IdCabaña] [int] IDENTITY(1,1) NOT NULL,
	[IdServicio] [int] NULL,
	[IdTarifa] [int] NULL,
	[IdImplementos] [int] NULL,
	[Descripcion] [varchar](300) NULL,
	[Nombre] [varchar](100) NULL,
 CONSTRAINT [PK_Cabaña] PRIMARY KEY CLUSTERED 
(
	[IdCabaña] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmpleadoCargo]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadoCargo](
	[intCodigo_EMCA] [int] IDENTITY(1,1) NOT NULL,
	[strDocumento_EMPL] [int] NOT NULL,
	[intCodigo_CARG] [int] NOT NULL,
	[dtmFechaInicio_EMCA] [datetime] NOT NULL,
	[dtmFechaFin_EMCA] [datetime] NULL,
	[intCodigo_SUCU] [int] NOT NULL,
 CONSTRAINT [PK_tblEMpleadoCArgo] PRIMARY KEY CLUSTERED 
(
	[intCodigo_EMCA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservas]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Reservas](
	[IdReservas] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdCabaña] [int] NULL,
	[IdEmpleado] [int] NULL,
	[Descripcion] [varchar](300) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaSalida] [datetime] NULL,
	[Hora] [varchar](100) NULL,
 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED 
(
	[IdReservas] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Promocion]    Script Date: 05/29/2013 23:09:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Promocion](
	[IdPromocion] [int] IDENTITY(1,1) NOT NULL,
	[IdServicio] [int] NULL,
	[IdCabaña] [int] NULL,
	[Descripcion] [varchar](300) NULL,
	[Nombre] [varchar](100) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Cabaña_Implementos]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[Cabaña]  WITH CHECK ADD  CONSTRAINT [FK_Cabaña_Implementos] FOREIGN KEY([IdImplementos])
REFERENCES [dbo].[Implementos] ([IdImplementos])
GO
ALTER TABLE [dbo].[Cabaña] CHECK CONSTRAINT [FK_Cabaña_Implementos]
GO
/****** Object:  ForeignKey [FK_Cabaña_Servicio]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[Cabaña]  WITH CHECK ADD  CONSTRAINT [FK_Cabaña_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([IdServicio])
GO
ALTER TABLE [dbo].[Cabaña] CHECK CONSTRAINT [FK_Cabaña_Servicio]
GO
/****** Object:  ForeignKey [FK_Cabaña_Tarifa]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[Cabaña]  WITH CHECK ADD  CONSTRAINT [FK_Cabaña_Tarifa] FOREIGN KEY([IdTarifa])
REFERENCES [dbo].[Tarifa] ([IdTarifa])
GO
ALTER TABLE [dbo].[Cabaña] CHECK CONSTRAINT [FK_Cabaña_Tarifa]
GO
/****** Object:  ForeignKey [FK_EmpleadoCargo_Empleado]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[EmpleadoCargo]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoCargo_Empleado] FOREIGN KEY([strDocumento_EMPL])
REFERENCES [dbo].[Empleado] ([strDocumento_EMPL])
GO
ALTER TABLE [dbo].[EmpleadoCargo] CHECK CONSTRAINT [FK_EmpleadoCargo_Empleado]
GO
/****** Object:  ForeignKey [FK_Promocion_Cabaña]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[Promocion]  WITH CHECK ADD  CONSTRAINT [FK_Promocion_Cabaña] FOREIGN KEY([IdCabaña])
REFERENCES [dbo].[Cabaña] ([IdCabaña])
GO
ALTER TABLE [dbo].[Promocion] CHECK CONSTRAINT [FK_Promocion_Cabaña]
GO
/****** Object:  ForeignKey [FK_Promocion_Servicio]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[Promocion]  WITH CHECK ADD  CONSTRAINT [FK_Promocion_Servicio] FOREIGN KEY([IdServicio])
REFERENCES [dbo].[Servicio] ([IdServicio])
GO
ALTER TABLE [dbo].[Promocion] CHECK CONSTRAINT [FK_Promocion_Servicio]
GO
/****** Object:  ForeignKey [FK_Reservas_Cabaña]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Cabaña] FOREIGN KEY([IdCabaña])
REFERENCES [dbo].[Cabaña] ([IdCabaña])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Cabaña]
GO
/****** Object:  ForeignKey [FK_Reservas_Cliente]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([strDocumento_CLIE])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Cliente]
GO
/****** Object:  ForeignKey [FK_Reservas_Empleado]    Script Date: 05/29/2013 23:09:49 ******/
ALTER TABLE [dbo].[Reservas]  WITH CHECK ADD  CONSTRAINT [FK_Reservas_Empleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([strDocumento_EMPL])
GO
ALTER TABLE [dbo].[Reservas] CHECK CONSTRAINT [FK_Reservas_Empleado]
GO
