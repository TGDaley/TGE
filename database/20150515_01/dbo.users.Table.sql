USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[users]    Script Date: 5/15/2015 10:38:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[usertype_id] [int] NOT NULL,
	[firstname] [nvarchar](255) NULL,
	[lastname] [nvarchar](255) NOT NULL,
	[password] [nvarchar](500) NOT NULL,
	[lastlogin] [datetime] NULL,
	[badlogincount] [int] NOT NULL CONSTRAINT [DF_users_badlogincount]  DEFAULT ((0)),
	[email] [nvarchar](255) NOT NULL,
	[companyname] [nvarchar](255) NULL,
	[position] [nvarchar](255) NULL,
	[phone] [nvarchar](255) NULL,
	[ein] [nvarchar](100) NULL,
	[facebookurl] [nvarchar](255) NULL,
	[twitterurl] [nvarchar](255) NULL,
	[address_id] [int] NULL,
	[status_id] [int] NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([address_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_address]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_status] FOREIGN KEY([status_id])
REFERENCES [dbo].[status] ([status_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_status]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_usertype] FOREIGN KEY([usertype_id])
REFERENCES [dbo].[usertype] ([usertype_id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_usertype]
GO
