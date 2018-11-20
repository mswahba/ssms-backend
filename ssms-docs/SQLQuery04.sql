select * from users

update users set accountStatusId = 2 where userId = '1122112211'
update users set accountStatusId = 2 where userId = 2233223322

delete from users

delete from students

delete from parents

select * from accountStatus

select * from userTypes

exec sp_help refreshTokens

ALTER TABLE [dbo].[refreshTokens] DROP CONSTRAINT [FK_users_refreshTokens]
GO

/****** Object:  Table [dbo].[refreshTokens]    Script Date: 09/11/2018 08:03:14 PM ******/
DROP TABLE [dbo].[refreshTokens]
GO

/****** Object:  Table [dbo].[refreshTokens]    Script Date: 09/11/2018 08:03:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[refreshTokens](
	[tokenId] [int] identity(1,1) NOT NULL,
	[token] [char](32) NOT NULL,
	[deviceInfo] [varchar](max) NOT NULL,
	[userId] [char](10) NULL,
	[isDeleted] [bit] NULL,
 CONSTRAINT [PK_refreshTokens] PRIMARY KEY CLUSTERED 
(
	[tokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [refreshTokens] ALTER COLUMN userId CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS

ALTER TABLE [dbo].[refreshTokens]
ADD CONSTRAINT [FK_users_refreshTokens] FOREIGN KEY([userId])
REFERENCES [dbo].[users] ([userId])
ON UPDATE CASCADE
ON DELETE SET NULL
GO


alter table [refreshTokens]
alter column token char(44)

select * from users
select * from [refreshTokens]
select * from parents

-- test login
select * from refreshTokens
select * from users where userId = 5566556655 
--old -- SfxKDCSpkxin9r+ynRV2QMqCDiOhOqK+lMafN8P98WU=
--new -- CoorVgb7JnwFetxkYFjLFlYo285nlV76Wdu00U4vDzw=