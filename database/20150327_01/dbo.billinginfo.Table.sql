USE [TiltedGlobe_Test]
GO
/****** Object:  Table [dbo].[billinginfo]    Script Date: 3/27/2015 12:49:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[billinginfo](
	[billing_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[ccnum_enc] [nvarchar](255) NULL,
	[cvv_enc] [nvarchar](255) NULL,
	[expiry_enc] [nvarchar](255) NULL,
	[cardholder_enc] [nvarchar](255) NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_billinginfo] PRIMARY KEY CLUSTERED 
(
	[billing_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[billinginfo]  WITH CHECK ADD  CONSTRAINT [FK_billinginfo_address] FOREIGN KEY([address_id])
REFERENCES [dbo].[address] ([address_id])
GO
ALTER TABLE [dbo].[billinginfo] CHECK CONSTRAINT [FK_billinginfo_address]
GO
ALTER TABLE [dbo].[billinginfo]  WITH CHECK ADD  CONSTRAINT [FK_billinginfo_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([user_id])
GO
ALTER TABLE [dbo].[billinginfo] CHECK CONSTRAINT [FK_billinginfo_users]
GO
