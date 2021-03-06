USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[subscriber_shows]    Script Date: 3/27/2015 12:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subscriber_shows](
	[user_id] [int] NOT NULL,
	[show_id] [int] NOT NULL,
 CONSTRAINT [PK_subscriber_shows] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[subscriber_shows]  WITH CHECK ADD  CONSTRAINT [FK_subscriber_shows_shows] FOREIGN KEY([show_id])
REFERENCES [dbo].[shows] ([show_id])
GO
ALTER TABLE [dbo].[subscriber_shows] CHECK CONSTRAINT [FK_subscriber_shows_shows]
GO
ALTER TABLE [dbo].[subscriber_shows]  WITH CHECK ADD  CONSTRAINT [FK_subscriber_shows_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[subscriber_shows] CHECK CONSTRAINT [FK_subscriber_shows_users]
GO
