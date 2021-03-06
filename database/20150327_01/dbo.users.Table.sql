USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[users]    Script Date: 3/27/2015 12:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[usertype_id] [int] NOT NULL,
	[firstname] [nvarchar](255) NULL,
	[lastname] [nvarchar](255) NOT NULL,
	[username] [nvarchar](255) NOT NULL,
	[password] [nvarchar](500) NOT NULL,
	[lastlogin] [datetime] NULL,
	[badlogincount] [int] NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[companyname] [nvarchar](255) NULL,
	[position] [nvarchar](255) NULL,
	[phone] [nvarchar](255) NULL,
	[ein] [nvarchar](100) NULL,
	[isactive] [bit] NOT NULL,
	[facebookurl] [nvarchar](255) NULL,
	[twitterurl] [nvarchar](255) NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [ix_users_firstname]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE NONCLUSTERED INDEX [ix_users_firstname] ON [dbo].[users]
(
	[firstname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [ix_users_lastname]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE NONCLUSTERED INDEX [ix_users_lastname] ON [dbo].[users]
(
	[lastname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [ix_users_uq_email]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE NONCLUSTERED INDEX [ix_users_uq_email] ON [dbo].[users]
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [ix_users_uq_username]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [ix_users_uq_username] ON [dbo].[users]
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [ix_users_usertype_id]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE NONCLUSTERED INDEX [ix_users_usertype_id] ON [dbo].[users]
(
	[usertype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_badlogincount]  DEFAULT ((0)) FOR [badlogincount]
GO
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [DF_users_isactive]  DEFAULT ((1)) FOR [isactive]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([address_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_address]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_usertype] FOREIGN KEY([usertype_id])
REFERENCES [dbo].[usertype] ([usertype_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_usertype]
GO
