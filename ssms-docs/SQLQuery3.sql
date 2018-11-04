USE [assadara_ssms]
GO

/****** Object:  Table [assadara_ssms_admin].[verificationCodes]    Script Date: 03/11/2018 09:34:55 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[verificationCodes](
	[codeId] [int] NOT NULL,
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

alter table [verificationCodes]
drop constraint FK_users_verificationCodes

alter table [verificationCodes]
add constraint FK_users_verificationCodes 
FOREIGN KEY (userId) 
references users(userId)
on update cascade
on delete set null

ALTER TABLE [verificationCodes] ALTER COLUMN userId CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS

SELECT c.name, 
       c.collation_name
  FROM SYS.COLUMNS c
  JOIN SYS.TABLES t ON t.object_id = c.object_id
 WHERE t.name = 'users'

 select * from verificationCodes