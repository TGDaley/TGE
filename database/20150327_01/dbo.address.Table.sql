USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[address]    Script Date: 3/27/2015 12:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[address1] [nvarchar](255) NOT NULL,
	[address2] [nvarchar](255) NULL,
	[city] [nvarchar](255) NOT NULL,
	[state_code] [nvarchar](10) NULL,
	[state_text] [nvarchar](255) NULL,
	[country] [nvarchar](255) NOT NULL,
	[zip_postal] [nvarchar](255) NULL,
 CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
