USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 3/27/2015 12:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authors](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[author_name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_authors] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
