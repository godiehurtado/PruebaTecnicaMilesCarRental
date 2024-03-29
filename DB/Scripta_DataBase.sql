USE [MikeCarRental_Test]
GO
/****** Object:  User [usrrent]    Script Date: 16/02/2024 1:08:41 a. m. ******/
CREATE USER [usrrent] FOR LOGIN [usrrent] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [usrrent]
GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[customerId] [uniqueidentifier] NOT NULL,
	[document] [varchar](50) NULL,
	[name] [varchar](200) NULL,
	[licence] [varchar](50) NULL,
	[country] [varchar](50) NULL,
	[email] [varchar](100) NULL,
	[phone] [varchar](50) NULL,
	[address] [varchar](200) NULL,
 CONSTRAINT [PK_CUSTOMER] PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DROPOFF_LOCATION]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DROPOFF_LOCATION](
	[pickupLocationId] [int] NOT NULL,
	[dropoffLocationId] [int] NOT NULL,
 CONSTRAINT [PK_DROPOFF_LOCATION] PRIMARY KEY CLUSTERED 
(
	[pickupLocationId] ASC,
	[dropoffLocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOCATION]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOCATION](
	[locationId] [int] NOT NULL,
	[locationName] [varchar](50) NULL,
 CONSTRAINT [PK_LOCATION] PRIMARY KEY CLUSTERED 
(
	[locationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVATION]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVATION](
	[reservationId] [uniqueidentifier] NOT NULL,
	[customerId] [uniqueidentifier] NULL,
	[vehicleId] [uniqueidentifier] NULL,
	[startDate] [datetime] NULL,
	[endDate] [datetime] NULL,
	[statusId] [int] NULL,
	[totalRate] [money] NULL,
	[pickUpLocationId] [int] NULL,
	[dropOffLocationId] [int] NULL,
 CONSTRAINT [PK_RESERVATION] PRIMARY KEY CLUSTERED 
(
	[reservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RESERVATION_STATUS]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RESERVATION_STATUS](
	[statusId] [int] NOT NULL,
	[statusName] [varchar](50) NULL,
 CONSTRAINT [PK_RESERVATION_STATUS] PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VEHICLE]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VEHICLE](
	[vehicleId] [uniqueidentifier] NOT NULL,
	[brand] [varchar](50) NULL,
	[model] [varchar](50) NULL,
	[manufacturingYear] [int] NULL,
	[idCategory] [int] NULL,
	[mileage] [numeric](18, 0) NULL,
	[statusId] [int] NULL,
	[dailyPrice] [money] NULL,
	[locationId] [int] NULL,
 CONSTRAINT [PK_VEHICLE] PRIMARY KEY CLUSTERED 
(
	[vehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VEHICLE_CATEGORY]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VEHICLE_CATEGORY](
	[categoryId] [int] NOT NULL,
	[categoryName] [varchar](50) NULL,
	[typeId] [int] NOT NULL,
 CONSTRAINT [PK_VEHICLE_CATEGORY] PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VEHICLE_STATUS]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VEHICLE_STATUS](
	[statusId] [int] NOT NULL,
	[statusName] [varchar](50) NULL,
 CONSTRAINT [PK_VEHICLE_STATUS] PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VEHICLE_TYPE]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VEHICLE_TYPE](
	[typeId] [int] NOT NULL,
	[typeName] [varchar](50) NULL,
 CONSTRAINT [PK_VEHICLE_TYPE] PRIMARY KEY CLUSTERED 
(
	[typeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CUSTOMER] ([customerId], [document], [name], [licence], [country], [email], [phone], [address]) VALUES (N'1eaee261-56cc-4bcf-813b-018c721ba96e', N'789012345', N'NombreCliente4', N'Licencia012', N'País4', N'cliente4@email.com', N'789-012-3456', N'Dirección4')
INSERT [dbo].[CUSTOMER] ([customerId], [document], [name], [licence], [country], [email], [phone], [address]) VALUES (N'02ea82ff-b7eb-4be8-827e-34b68e7e4046', N'012345678', N'NombreCliente5', N'Licencia345', N'País5', N'cliente5@email.com', N'012-345-6789', N'Dirección5')
INSERT [dbo].[CUSTOMER] ([customerId], [document], [name], [licence], [country], [email], [phone], [address]) VALUES (N'b5c4b2c3-2b73-4611-8a5a-5a116106795e', N'123456789', N'NombreCliente1', N'Licencia123', N'País1', N'cliente1@email.com', N'123-456-7890', N'Dirección1')
INSERT [dbo].[CUSTOMER] ([customerId], [document], [name], [licence], [country], [email], [phone], [address]) VALUES (N'bf90777c-06a3-48e3-89f8-8e80023dbc18', N'987654321', N'NombreCliente2', N'Licencia456', N'País2', N'cliente2@email.com', N'987-654-3210', N'Dirección2')
INSERT [dbo].[CUSTOMER] ([customerId], [document], [name], [licence], [country], [email], [phone], [address]) VALUES (N'73d7f27f-3cbd-4dd2-a1b6-a1c41040014e', N'456789012', N'NombreCliente3', N'Licencia789', N'País3', N'cliente3@email.com', N'456-789-0123', N'Dirección3')
INSERT [dbo].[CUSTOMER] ([customerId], [document], [name], [licence], [country], [email], [phone], [address]) VALUES (N'46728081-f6cc-498a-b799-be82cefc6d83', N'123465', N'Diego Hurtado', N'123465', N'', N'', N'3003003333', N'')
GO
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (1, 1)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (1, 3)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (2, 2)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (2, 3)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (2, 4)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (3, 2)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (3, 3)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (3, 4)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (4, 1)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (4, 2)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (4, 3)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (4, 4)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (5, 2)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (5, 4)
INSERT [dbo].[DROPOFF_LOCATION] ([pickupLocationId], [dropoffLocationId]) VALUES (5, 5)
GO
INSERT [dbo].[LOCATION] ([locationId], [locationName]) VALUES (1, N'North')
INSERT [dbo].[LOCATION] ([locationId], [locationName]) VALUES (2, N'Center')
INSERT [dbo].[LOCATION] ([locationId], [locationName]) VALUES (3, N'South')
INSERT [dbo].[LOCATION] ([locationId], [locationName]) VALUES (4, N'East')
INSERT [dbo].[LOCATION] ([locationId], [locationName]) VALUES (5, N'West')
GO
INSERT [dbo].[RESERVATION] ([reservationId], [customerId], [vehicleId], [startDate], [endDate], [statusId], [totalRate], [pickUpLocationId], [dropOffLocationId]) VALUES (N'82a55119-566f-4430-8363-0fc1dbcd30a8', N'73d7f27f-3cbd-4dd2-a1b6-a1c41040014e', N'a30863a5-eb33-4113-b565-aab583deb09b', CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(N'2024-02-20T00:00:00.000' AS DateTime), 1, 500.0000, 1, 1)
INSERT [dbo].[RESERVATION] ([reservationId], [customerId], [vehicleId], [startDate], [endDate], [statusId], [totalRate], [pickUpLocationId], [dropOffLocationId]) VALUES (N'1c2b3936-7e83-44cb-8b4a-352560e8b407', N'02ea82ff-b7eb-4be8-827e-34b68e7e4046', N'4bfbd859-3a69-4af7-9e69-7db943acbe06', CAST(N'2024-03-15T00:00:00.000' AS DateTime), CAST(N'2024-03-20T00:00:00.000' AS DateTime), 1, 700.0000, 3, 3)
INSERT [dbo].[RESERVATION] ([reservationId], [customerId], [vehicleId], [startDate], [endDate], [statusId], [totalRate], [pickUpLocationId], [dropOffLocationId]) VALUES (N'9d51acc5-04f4-473d-a6a6-52adc2186a5f', N'bf90777c-06a3-48e3-89f8-8e80023dbc18', N'bb908293-4722-4542-b940-d8bd1247eb45', CAST(N'2024-03-01T00:00:00.000' AS DateTime), CAST(N'2024-03-10T00:00:00.000' AS DateTime), 1, 600.0000, 2, 2)
INSERT [dbo].[RESERVATION] ([reservationId], [customerId], [vehicleId], [startDate], [endDate], [statusId], [totalRate], [pickUpLocationId], [dropOffLocationId]) VALUES (N'0b389847-250d-4140-9d8d-b66e02fb7843', N'1eaee261-56cc-4bcf-813b-018c721ba96e', N'62b27b55-4461-4695-ae24-f9bca7b77466', CAST(N'2024-04-01T00:00:00.000' AS DateTime), CAST(N'2024-04-10T00:00:00.000' AS DateTime), 1, 800.0000, 4, 4)
INSERT [dbo].[RESERVATION] ([reservationId], [customerId], [vehicleId], [startDate], [endDate], [statusId], [totalRate], [pickUpLocationId], [dropOffLocationId]) VALUES (N'541ad525-ffb7-427b-8824-c9ec726db2ea', N'46728081-f6cc-498a-b799-be82cefc6d83', N'0bf03e92-f90f-41bb-9659-0ea8e777f15c', CAST(N'2024-02-15T00:00:00.000' AS DateTime), CAST(N'2024-02-28T00:00:00.000' AS DateTime), 1, 1170.0000, 4, 3)
INSERT [dbo].[RESERVATION] ([reservationId], [customerId], [vehicleId], [startDate], [endDate], [statusId], [totalRate], [pickUpLocationId], [dropOffLocationId]) VALUES (N'18765e24-313d-4d81-81a4-ee8d2d1ef633', N'b5c4b2c3-2b73-4611-8a5a-5a116106795e', N'504040c9-d809-46c0-b520-440729b61bfa', CAST(N'2024-04-15T00:00:00.000' AS DateTime), CAST(N'2024-04-20T00:00:00.000' AS DateTime), 1, 900.0000, 5, 5)
GO
INSERT [dbo].[RESERVATION_STATUS] ([statusId], [statusName]) VALUES (1, N'Reserved')
INSERT [dbo].[RESERVATION_STATUS] ([statusId], [statusName]) VALUES (2, N'In Progress')
INSERT [dbo].[RESERVATION_STATUS] ([statusId], [statusName]) VALUES (3, N'Completed')
INSERT [dbo].[RESERVATION_STATUS] ([statusId], [statusName]) VALUES (4, N'Canceled')
GO
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'0bf03e92-f90f-41bb-9659-0ea8e777f15c', N'Subaru', N'Outback', 2018, 15, CAST(13000 AS Numeric(18, 0)), 1, 90.0000, 4)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'7d978717-0c12-4a2f-8689-0f8dc3eabd47', N'Chevrolet', N'Malibu', 2021, 24, CAST(8000 AS Numeric(18, 0)), 1, 65.0000, 4)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'76d92842-a87f-4ddc-af3f-130e85930934', N'Kia', N'Sorento', 2019, 41, CAST(11000 AS Numeric(18, 0)), 1, 80.0000, 2)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'c4390681-92e9-401a-b252-1aba702f34bd', N'Ford', N'Escape', 2021, 24, CAST(7000 AS Numeric(18, 0)), 1, 60.0000, 3)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'9af1320d-7d60-4bec-9145-1b4172c21656', N'Ford', N'Fusion', 2018, 32, CAST(12000 AS Numeric(18, 0)), 1, 110.0000, 1)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'2de86a55-334a-4899-abc6-1eaaeb066f43', N'Chevrolet', N'Malibu', 2021, 12, CAST(8000 AS Numeric(18, 0)), 1, 65.0000, 4)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'b3144b97-d80d-4b36-abf5-2afd5ef5cd86', N'Nissan', N'Altima', 2020, 32, CAST(9000 AS Numeric(18, 0)), 1, 70.0000, 5)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'9e09cfcb-4c7d-4586-806b-357545ec6b92', N'Chevrolet', N'Cruze', 2019, 21, CAST(10500 AS Numeric(18, 0)), 1, 100.0000, 2)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'c5f523cf-27ad-49c4-beb7-382641bf062b', N'Volkswagen', N'Passat', 2018, 43, CAST(14000 AS Numeric(18, 0)), 1, 95.0000, 5)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'504040c9-d809-46c0-b520-440729b61bfa', N'Subaru', N'Impreza', 2021, 45, CAST(8500 AS Numeric(18, 0)), 1, 90.0000, 5)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'391d0a04-670b-41ee-a1e4-5c12b3813334', N'Mazda', N'Mazda3', 2020, 13, CAST(9500 AS Numeric(18, 0)), 1, 85.0000, 4)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'4bfbd859-3a69-4af7-9e69-7db943acbe06', N'Toyota', N'Camry', 2022, 13, CAST(5000 AS Numeric(18, 0)), 1, 50.0000, 1)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'c22ac6f6-64ac-4df8-8bc5-87b6ee78c02a', N'Hyundai', N'Elantra', 2020, 41, CAST(10000 AS Numeric(18, 0)), 1, 75.0000, 1)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'f5601e6f-c2c7-4218-a9a6-9384fc82d8dc', N'Honda', N'Civic', 2022, 12, CAST(6000 AS Numeric(18, 0)), 1, 55.0000, 2)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'a30863a5-eb33-4113-b565-aab583deb09b', N'Kia', N'Optima', 2019, 32, CAST(10000 AS Numeric(18, 0)), 1, 80.0000, 3)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'65a5c135-7d9f-4742-9603-ad3153d197ff', N'Mazda', N'CX-5', 2019, 25, CAST(12000 AS Numeric(18, 0)), 1, 85.0000, 3)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'8c904a27-eeb7-4696-9bd0-ae53e700e44a', N'Nissan', N'Altima', 2020, 15, CAST(9000 AS Numeric(18, 0)), 1, 70.0000, 2)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'b6d5bc92-9689-471d-9075-b0506e439c3e', N'Hyundai', N'Elantra', 2019, 45, CAST(11000 AS Numeric(18, 0)), 1, 75.0000, 1)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'b9ecebc5-3eed-4d3d-b7ba-b8877a37a8b4', N'Ford', N'Escape', 2021, 32, CAST(7000 AS Numeric(18, 0)), 1, 60.0000, 3)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'04e268c7-d961-4efc-87fb-c7a950684224', N'Honda', N'Accord', 2019, 11, CAST(11500 AS Numeric(18, 0)), 1, 105.0000, 5)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'bb908293-4722-4542-b940-d8bd1247eb45', N'Honda', N'Civic', 2022, 23, CAST(6000 AS Numeric(18, 0)), 1, 55.0000, 2)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'75e885f6-2028-4a77-b10d-df2d050dac3c', N'Volkswagen', N'Jetta', 2018, 22, CAST(13000 AS Numeric(18, 0)), 1, 120.0000, 3)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'c01559d7-82c5-4ef1-9a89-e60280654246', N'Volkswagen', N'Passat', 2018, 25, CAST(14000 AS Numeric(18, 0)), 1, 95.0000, 5)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'62b27b55-4461-4695-ae24-f9bca7b77466', N'Toyota', N'Corolla', 2020, 22, CAST(8800 AS Numeric(18, 0)), 1, 95.0000, 4)
INSERT [dbo].[VEHICLE] ([vehicleId], [brand], [model], [manufacturingYear], [idCategory], [mileage], [statusId], [dailyPrice], [locationId]) VALUES (N'4dd3957e-018c-4fe6-8077-fb54f34f2c5c', N'Toyota', N'Camry', 2022, 41, CAST(5000 AS Numeric(18, 0)), 1, 50.0000, 1)
GO
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (11, N'Economy', 1)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (12, N'Compact', 1)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (13, N'Midsize', 1)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (14, N'Standard', 1)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (15, N'Full Size', 1)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (21, N'Compact SUV', 2)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (22, N'Midsize SUV', 2)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (23, N'Standard SUV', 2)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (24, N'Full Size SUV', 2)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (25, N'Luxury SUV', 2)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (31, N'Standard Pickup', 3)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (32, N'1/2 Ton Pickup', 3)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (41, N'7 Passenger Minivan', 4)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (42, N'8 Passanger Minivan', 4)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (43, N'15 Passanger Van', 4)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (44, N'12 Passanger Van', 4)
INSERT [dbo].[VEHICLE_CATEGORY] ([categoryId], [categoryName], [typeId]) VALUES (45, N'Compact Cargo Van', 4)
GO
INSERT [dbo].[VEHICLE_STATUS] ([statusId], [statusName]) VALUES (1, N'Available')
INSERT [dbo].[VEHICLE_STATUS] ([statusId], [statusName]) VALUES (2, N'Rented')
INSERT [dbo].[VEHICLE_STATUS] ([statusId], [statusName]) VALUES (3, N'In Mantenaice')
INSERT [dbo].[VEHICLE_STATUS] ([statusId], [statusName]) VALUES (4, N'Out of Service')
INSERT [dbo].[VEHICLE_STATUS] ([statusId], [statusName]) VALUES (5, N'Reserved')
INSERT [dbo].[VEHICLE_STATUS] ([statusId], [statusName]) VALUES (6, N'En Route')
GO
INSERT [dbo].[VEHICLE_TYPE] ([typeId], [typeName]) VALUES (1, N'Cars')
INSERT [dbo].[VEHICLE_TYPE] ([typeId], [typeName]) VALUES (2, N'SUVs')
INSERT [dbo].[VEHICLE_TYPE] ([typeId], [typeName]) VALUES (3, N'Trucks')
INSERT [dbo].[VEHICLE_TYPE] ([typeId], [typeName]) VALUES (4, N'Vans')
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD  CONSTRAINT [FK_RESERVATION_CUSTOMER] FOREIGN KEY([customerId])
REFERENCES [dbo].[CUSTOMER] ([customerId])
GO
ALTER TABLE [dbo].[RESERVATION] CHECK CONSTRAINT [FK_RESERVATION_CUSTOMER]
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD  CONSTRAINT [FK_RESERVATION_DROPOFFLOCATION] FOREIGN KEY([dropOffLocationId])
REFERENCES [dbo].[LOCATION] ([locationId])
GO
ALTER TABLE [dbo].[RESERVATION] CHECK CONSTRAINT [FK_RESERVATION_DROPOFFLOCATION]
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD  CONSTRAINT [FK_RESERVATION_PICKUPLOCATION] FOREIGN KEY([pickUpLocationId])
REFERENCES [dbo].[LOCATION] ([locationId])
GO
ALTER TABLE [dbo].[RESERVATION] CHECK CONSTRAINT [FK_RESERVATION_PICKUPLOCATION]
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD  CONSTRAINT [FK_RESERVATION_RESERVATION_STATUS] FOREIGN KEY([statusId])
REFERENCES [dbo].[RESERVATION_STATUS] ([statusId])
GO
ALTER TABLE [dbo].[RESERVATION] CHECK CONSTRAINT [FK_RESERVATION_RESERVATION_STATUS]
GO
ALTER TABLE [dbo].[RESERVATION]  WITH CHECK ADD  CONSTRAINT [FK_RESERVATION_VEHICLE] FOREIGN KEY([vehicleId])
REFERENCES [dbo].[VEHICLE] ([vehicleId])
GO
ALTER TABLE [dbo].[RESERVATION] CHECK CONSTRAINT [FK_RESERVATION_VEHICLE]
GO
ALTER TABLE [dbo].[VEHICLE]  WITH CHECK ADD  CONSTRAINT [FK_VEHICLE_LOCATION] FOREIGN KEY([locationId])
REFERENCES [dbo].[LOCATION] ([locationId])
GO
ALTER TABLE [dbo].[VEHICLE] CHECK CONSTRAINT [FK_VEHICLE_LOCATION]
GO
ALTER TABLE [dbo].[VEHICLE]  WITH CHECK ADD  CONSTRAINT [FK_VEHICLE_VEHICLE_CATEGORY] FOREIGN KEY([idCategory])
REFERENCES [dbo].[VEHICLE_CATEGORY] ([categoryId])
GO
ALTER TABLE [dbo].[VEHICLE] CHECK CONSTRAINT [FK_VEHICLE_VEHICLE_CATEGORY]
GO
ALTER TABLE [dbo].[VEHICLE]  WITH CHECK ADD  CONSTRAINT [FK_VEHICLE_VEHICLE_STATUS] FOREIGN KEY([statusId])
REFERENCES [dbo].[VEHICLE_STATUS] ([statusId])
GO
ALTER TABLE [dbo].[VEHICLE] CHECK CONSTRAINT [FK_VEHICLE_VEHICLE_STATUS]
GO
ALTER TABLE [dbo].[VEHICLE_CATEGORY]  WITH CHECK ADD  CONSTRAINT [FK_VEHICLE_CATEGORY_VEHICLE_CATEGORY] FOREIGN KEY([typeId])
REFERENCES [dbo].[VEHICLE_TYPE] ([typeId])
GO
ALTER TABLE [dbo].[VEHICLE_CATEGORY] CHECK CONSTRAINT [FK_VEHICLE_CATEGORY_VEHICLE_CATEGORY]
GO
/****** Object:  StoredProcedure [dbo].[GET_ALL_LOCATION]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_ALL_LOCATION]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM LOCATION;
END
GO
/****** Object:  StoredProcedure [dbo].[GET_DROPOFF_LOCATION]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_DROPOFF_LOCATION]
	@LocationId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [locationId]
      ,[locationName] FROM LOCATION
	INNER JOIN DROPOFF_LOCATION ON LOCATION.locationId = DROPOFF_LOCATION.dropoffLocationId
	WHERE DROPOFF_LOCATION.pickupLocationId = @LocationId;
END
GO
/****** Object:  StoredProcedure [dbo].[GET_VEHICLE_ENABLE]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_VEHICLE_ENABLE] 
	@LocationId int = 0,
	@StartDate datetime = '',
	@EndDate datetime = '',
	@CategoryId int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT VEHICLE.[vehicleId]
      ,[brand]
      ,[model]
      ,[manufacturingYear]
      ,[idCategory]
      ,[mileage]
      ,VEHICLE.[statusId]
      ,[dailyPrice]
      ,[locationId]
	FROM VEHICLE 
	LEFT JOIN RESERVATION ON VEHICLE.vehicleId = RESERVATION.vehicleId
	WHERE VEHICLE.locationId = @LocationId
	AND VEHICLE.idCategory = @CategoryId
	AND (VEHICLE.statusId = 1
	OR (VEHICLE.statusId = 2 AND RESERVATION.statusId = 2 AND RESERVATION.endDate < @StartDate)
	OR (VEHICLE.statusId = 5 AND RESERVATION.statusId = 1 AND RESERVATION.startDate NOT BETWEEN @StartDate AND @EndDate AND RESERVATION.endDate NOT BETWEEN @StartDate AND @EndDate)
	)
END
GO
/****** Object:  StoredProcedure [dbo].[GET_VEHICLE_TYPE_ENABLE]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_VEHICLE_TYPE_ENABLE] 
	@LocationId int = 0,
	@StartDate datetime = '',
	@EndDate datetime = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT VEHICLE_TYPE.typeId, VEHICLE_TYPE.typeName, VEHICLE_CATEGORY.categoryId, VEHICLE_CATEGORY.categoryName 
	FROM VEHICLE 
	INNER JOIN VEHICLE_CATEGORY ON VEHICLE.idCategory = VEHICLE_CATEGORY.categoryId
	INNER JOIN VEHICLE_TYPE ON VEHICLE_CATEGORY.typeId = VEHICLE_TYPE.typeId
	LEFT JOIN RESERVATION ON VEHICLE.vehicleId = RESERVATION.vehicleId
	WHERE VEHICLE.locationId = @LocationId
	AND (VEHICLE.statusId = 1
	OR (VEHICLE.statusId = 2 AND RESERVATION.statusId = 2 AND RESERVATION.endDate < @StartDate)
	OR (VEHICLE.statusId = 5 AND RESERVATION.statusId = 1 AND RESERVATION.startDate NOT BETWEEN @StartDate AND @EndDate AND RESERVATION.endDate NOT BETWEEN @StartDate AND @EndDate)
	)
END
GO
/****** Object:  StoredProcedure [dbo].[GETALLLOCATION]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GETALLLOCATION]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM LOCATION;
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_CUSTOMER]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INSERT_CUSTOMER] 
	@Name varchar(200) = '',
	@Document varchar(50) = '',
	@Licence varchar(50) = '',
	@Phone varchar(50) = '',
	@CustomerId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
	SET @CustomerId = NEWID()

    INSERT INTO [CUSTOMER] ([customerId]
      ,[document]
      ,[name]
      ,[licence]
      ,[country]
      ,[email]
      ,[phone]
      ,[address])
	VALUES (@CustomerId,@Document,@Name,@Licence,'','',@Phone,'')
END
GO
/****** Object:  StoredProcedure [dbo].[INSERT_RESERVATION]    Script Date: 16/02/2024 1:08:41 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[INSERT_RESERVATION] 
	@CustomerId UNIQUEIDENTIFIER,
    @DropOffLocationId int,
    @EndDate DateTime,
    @PickUpLocationId int,
    @StartDate DateTime,
    @StatusId int,
    @TotalRate money,
    @VehicleId UNIQUEIDENTIFIER,
	@ReservationId UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
	SET @ReservationId = NEWID()

    INSERT INTO [RESERVATION] ([reservationId]
      ,[customerId]
      ,[vehicleId]
      ,[startDate]
      ,[endDate]
      ,[statusId]
      ,[totalRate]
	  ,[pickUpLocationId]
      ,[dropOffLocationId])
	VALUES (@ReservationId,@CustomerId,@VehicleId,@StartDate,@EndDate,@StatusId,@TotalRate,@PickUpLocationId,@DropOffLocationId)
END
GO
