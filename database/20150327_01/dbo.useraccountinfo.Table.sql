USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[useraccountinfo]    Script Date: 3/27/2015 12:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[useraccountinfo](
	[useraccountinfo_id] [int] IDENTITY(1,1) NOT NULL,
	[paypal_email] [nvarchar](255) NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_useraccountinfo] PRIMARY KEY CLUSTERED 
(
	[useraccountinfo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_useraccountinfo_paypalemail]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE NONCLUSTERED INDEX [IX_useraccountinfo_paypalemail] ON [dbo].[useraccountinfo]
(
	[paypal_email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[useraccountinfo]  WITH CHECK ADD  CONSTRAINT [FK_useraccountinfo_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[useraccountinfo] CHECK CONSTRAINT [FK_useraccountinfo_users]
GO
