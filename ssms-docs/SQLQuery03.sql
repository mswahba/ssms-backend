alter table verificationCodeTypes add isDeleted bit not null
----------
alter table verificationCodeTypes alter column isDeleted bit null
---------
select * from verificationCodeTypes
-----------------
alter table refreshTokens add isDeleted bit null
----------------
select * from refreshTokens