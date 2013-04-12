/****** Object:  Table [dbo].[EnumFakeServiceResponseType]    Script Date: 04/12/2013 14:34:04 ******/
CREATE TABLE [dbo].[EnumFakeServiceResponseType](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EnumFakeServiceResponseType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
INSERT [dbo].[EnumFakeServiceResponseType] ([ID], [Name], [Description]) VALUES (0, N'Passthrough', N'Passthrough')
INSERT [dbo].[EnumFakeServiceResponseType] ([ID], [Name], [Description]) VALUES (1, N'PassthroughAndCache', N'Passthrough and Cache recognized methods')
INSERT [dbo].[EnumFakeServiceResponseType] ([ID], [Name], [Description]) VALUES (2, N'Unavailable', N'Simulate server unavailable')
INSERT [dbo].[EnumFakeServiceResponseType] ([ID], [Name], [Description]) VALUES (3, N'InternalServerError500', N'Simulate Internal Server Error (500)')
INSERT [dbo].[EnumFakeServiceResponseType] ([ID], [Name], [Description]) VALUES (4, N'NotFound404', N'Simulate Not Found (404)')

/****** Object:  Table [dbo].[FakeService]    Script Date: 04/12/2013 14:34:04 ******/
CREATE TABLE [dbo].[FakeService](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [nvarchar](50) NOT NULL,
	[RealEndpointRootUrl] [nvarchar](1000) NOT NULL,
	[RelativeFakeRootUrl] [nvarchar](50) NOT NULL,
	[EnumFakeServiceResponseTypeID] [int] NOT NULL,
 CONSTRAINT [PK_FakeService] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO

SET IDENTITY_INSERT [dbo].[FakeService] ON
INSERT [dbo].[FakeService] ([ID], [ServiceName], [RealEndpointRootUrl], [RelativeFakeRootUrl], [EnumFakeServiceResponseTypeID]) VALUES (1, N'Google', N'http://www.google.com/', N'fake_google', 0)
SET IDENTITY_INSERT [dbo].[FakeService] OFF

ALTER TABLE [dbo].[FakeService] ADD  CONSTRAINT [DF_FakeService_EnumFakeServiceResponseTypeID]  DEFAULT ((0)) FOR [EnumFakeServiceResponseTypeID]
GO

ALTER TABLE dbo.EnumFakeServiceResponseType SET (LOCK_ESCALATION = TABLE)
GO