USE [TiltedGlobe_Test]
GO
/****** Object:  User [TiltedGlobe_User]    Script Date: 3/27/2015 12:49:16 PM ******/
CREATE USER [TiltedGlobe_User] FOR LOGIN [TiltedGlobe_User] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [TiltedGlobe_User]
GO
ALTER ROLE [db_datareader] ADD MEMBER [TiltedGlobe_User]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [TiltedGlobe_User]
GO
