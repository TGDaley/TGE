USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[usertype]    Script Date: 3/27/2015 12:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usertype](
	[usertype_id] [int] IDENTITY(1,1) NOT NULL,
	[usertype_desc] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_usertype] PRIMARY KEY CLUSTERED 
(
	[usertype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_usertype]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_usertype] ON [dbo].[usertype]
(
	[usertype_desc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
