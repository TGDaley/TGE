USE [TiltedGlobe_Test]
GO
SET IDENTITY_INSERT [dbo].[status] ON 

INSERT [dbo].[status] ([status_id], [status_description]) VALUES (1, N'Active')
INSERT [dbo].[status] ([status_id], [status_description]) VALUES (2, N'Inactive')
INSERT [dbo].[status] ([status_id], [status_description]) VALUES (3, N'Pending Review')
SET IDENTITY_INSERT [dbo].[status] OFF
