USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[usertype]    Script Date: 5/15/2015 10:38:10 AM ******/
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
