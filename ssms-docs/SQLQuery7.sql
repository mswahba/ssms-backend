ALTER TABLE [dbo].[verificationCodes] DROP CONSTRAINT [FK_verificationCodeTypes_verificationCodes]
GO

ALTER TABLE [dbo].[verificationCodes] DROP CONSTRAINT [FK_users_verificationCodes]
GO

/****** Object:  Table [dbo].[verificationCodes]    Script Date: 16/11/2018 08:04:32 PM ******/
DROP TABLE [dbo].[verificationCodes]
GO
/****** Object:  Table [dbo].[verificationCodes]    Script Date: 16/11/2018 08:04:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[verificationCodes](
	[codeId] [int] identity(1,1) NOT NULL,
	[code] [varchar](10) NOT NULL,
	[sentTime] [smalldatetime] NOT NULL,
	[codeTypeId] [tinyint] NULL,
	[userId] [char](10) NULL,
 CONSTRAINT [PK_verificationCodes] PRIMARY KEY CLUSTERED 
(
	[codeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [verificationCodes] ALTER COLUMN userId CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS

ALTER TABLE [dbo].[verificationCodes] WITH CHECK
ADD  CONSTRAINT [FK_users_verificationCodes] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[verificationCodes] CHECK CONSTRAINT [FK_users_verificationCodes]
GO

ALTER TABLE [dbo].[verificationCodes]  WITH CHECK 
ADD  CONSTRAINT [FK_verificationCodeTypes_verificationCodes] FOREIGN KEY([codeTypeId])
REFERENCES [dbo].[verificationCodeTypes] ([codeTypeId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO

ALTER TABLE [dbo].[verificationCodes] CHECK CONSTRAINT [FK_verificationCodeTypes_verificationCodes]


select * from users

select * from users where userId = '1133557799'

select * from verificationCodes

select * from verificationCodeTypes

insert into verificationCodes values('123456', DATEADD(HOUR,3,GETUTCDATE()), 1, '1133557799')
update verificationCodes set sentTime = DATEADD(HOUR,3,GETUTCDATE())