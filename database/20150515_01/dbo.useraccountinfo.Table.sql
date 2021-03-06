USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[useraccountinfo]    Script Date: 5/15/2015 10:38:10 AM ******/
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
ALTER TABLE [dbo].[useraccountinfo]  WITH CHECK ADD  CONSTRAINT [FK_useraccountinfo_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[useraccountinfo] CHECK CONSTRAINT [FK_useraccountinfo_users]
GO
