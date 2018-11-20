/*--------------------------------------------------------------
CREATE TABLE [dbo].[verificationCodeTypes](
	[codeTypeId] [tinyint] NOT NULL,
	[codeType] [varchar](25) NOT NULL,
	[description] [varchar](max) NULL
 CONSTRAINT [PK_verificationCodeTypes] PRIMARY KEY CLUSTERED 
(
	[codeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-----------------------------------------------------------------*/
alter table [verificationCodes]
add constraint FK_verificationCodeTypes_verificationCodes 
FOREIGN KEY (codeTypeId) 
references verificationCodeTypes(codeTypeId)
on update cascade
on delete set null
------------------------------------------------------------------
select * from users
------------------------------------------------------------------
exec sp_rename 'dbo.users.lastLogin', 'lastActive'
------------------------------------------------------------------
----------------------------------------------------------------
CREATE TABLE [dbo].[refreshTokens](
	[tokenId] [int] NOT NULL,
	[token] [char](32) NOT NULL,
	[deviceInfo] [varchar](max) NOT NULL,
	[userId] [char](10)
 CONSTRAINT [PK_refreshTokens] PRIMARY KEY CLUSTERED 
(
	[tokenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
-----------------------------------------------------------------
ALTER TABLE [refreshTokens] ALTER COLUMN userId CHAR(10) COLLATE SQL_Latin1_General_CP1_CI_AS
-----------------------------------------------------------------
alter table [refreshTokens]
add constraint FK_users_refreshTokens 
FOREIGN KEY (userId) 
references users(userId)
on update cascade
on delete set null