USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[channels]    Script Date: 3/27/2015 12:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[channels](
	[channel_id] [int] IDENTITY(1,1) NOT NULL,
	[channel_description] [nvarchar](255) NOT NULL,
	[producer_id] [int] NOT NULL,
	[channel_link] [nvarchar](255) NOT NULL,
	[channelstatus_id] [int] NOT NULL,
	[genre_id] [int] NULL,
	[author_id] [int] NULL,
	[rating] [int] NULL,
	[subscription_price] [decimal](2, 2) NOT NULL,
	[thumbnail] [image] NULL,
 CONSTRAINT [PK_channels] PRIMARY KEY CLUSTERED 
(
	[channel_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [IX_channels_genreid]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_channels_genreid] ON [dbo].[channels]
(
	[genre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[channels] ADD  CONSTRAINT [DF_channels_subscription_price]  DEFAULT ((0.00)) FOR [subscription_price]
GO
ALTER TABLE [dbo].[channels]  WITH CHECK ADD  CONSTRAINT [FK_channels_authors] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([author_id])
GO
ALTER TABLE [dbo].[channels] CHECK CONSTRAINT [FK_channels_authors]
GO
ALTER TABLE [dbo].[channels]  WITH CHECK ADD  CONSTRAINT [FK_channels_genres] FOREIGN KEY([genre_id])
REFERENCES [dbo].[genres] ([genre_id])
GO
ALTER TABLE [dbo].[channels] CHECK CONSTRAINT [FK_channels_genres]
GO
ALTER TABLE [dbo].[channels]  WITH CHECK ADD  CONSTRAINT [FK_channels_status] FOREIGN KEY([channelstatus_id])
REFERENCES [dbo].[status] ([status_id])
GO
ALTER TABLE [dbo].[channels] CHECK CONSTRAINT [FK_channels_status]
GO
ALTER TABLE [dbo].[channels]  WITH CHECK ADD  CONSTRAINT [FK_channels_users] FOREIGN KEY([producer_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[channels] CHECK CONSTRAINT [FK_channels_users]
GO
