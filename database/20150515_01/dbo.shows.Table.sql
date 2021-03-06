USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[shows]    Script Date: 5/15/2015 10:38:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shows](
	[show_id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[genre_id] [int] NOT NULL,
	[thumbnail] [image] NULL,
	[air_datetime_utc] [datetime] NOT NULL,
	[tickets_available] [int] NOT NULL,
	[ticket_price] [decimal](2, 2) NOT NULL,
	[channel_id] [int] NOT NULL,
	[status_id] [int] NOT NULL,
	[stream_link] [nvarchar](255) NULL,
	[author_id] [int] NOT NULL,
 CONSTRAINT [PK_shows] PRIMARY KEY CLUSTERED 
(
	[show_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[shows] ADD  CONSTRAINT [DF_shows_tickets_available]  DEFAULT ((0)) FOR [tickets_available]
GO
ALTER TABLE [dbo].[shows] ADD  CONSTRAINT [DF_shows_ticket_price]  DEFAULT ((0.00)) FOR [ticket_price]
GO
ALTER TABLE [dbo].[shows]  WITH CHECK ADD  CONSTRAINT [FK_shows_authors] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([author_id])
GO
ALTER TABLE [dbo].[shows] CHECK CONSTRAINT [FK_shows_authors]
GO
ALTER TABLE [dbo].[shows]  WITH CHECK ADD  CONSTRAINT [FK_shows_channels] FOREIGN KEY([channel_id])
REFERENCES [dbo].[channels] ([channel_id])
GO
ALTER TABLE [dbo].[shows] CHECK CONSTRAINT [FK_shows_channels]
GO
ALTER TABLE [dbo].[shows]  WITH CHECK ADD  CONSTRAINT [FK_shows_genres] FOREIGN KEY([genre_id])
REFERENCES [dbo].[genres] ([genre_id])
GO
ALTER TABLE [dbo].[shows] CHECK CONSTRAINT [FK_shows_genres]
GO
ALTER TABLE [dbo].[shows]  WITH CHECK ADD  CONSTRAINT [FK_shows_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([status_id])
GO
ALTER TABLE [dbo].[shows] CHECK CONSTRAINT [FK_shows_status]
GO
