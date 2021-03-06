USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[pagesecurity]    Script Date: 5/15/2015 10:38:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pagesecurity](
	[page_id] [int] NOT NULL,
	[usertype_id] [int] NOT NULL,
	[allowaccess] [bit] NOT NULL,
 CONSTRAINT [PK_pagesecurity] PRIMARY KEY CLUSTERED 
(
	[page_id] ASC,
	[usertype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[pagesecurity] ADD  CONSTRAINT [DF_pagesecurity_allowaccess]  DEFAULT ((0)) FOR [allowaccess]
GO
ALTER TABLE [dbo].[pagesecurity]  WITH CHECK ADD  CONSTRAINT [FK_pagesecurity_pages] FOREIGN KEY([page_id])
REFERENCES [dbo].[pages] ([page_id])
GO
ALTER TABLE [dbo].[pagesecurity] CHECK CONSTRAINT [FK_pagesecurity_pages]
GO
ALTER TABLE [dbo].[pagesecurity]  WITH CHECK ADD  CONSTRAINT [FK_pagesecurity_usertype] FOREIGN KEY([usertype_id])
REFERENCES [dbo].[usertype] ([usertype_id])
GO
ALTER TABLE [dbo].[pagesecurity] CHECK CONSTRAINT [FK_pagesecurity_usertype]
GO
