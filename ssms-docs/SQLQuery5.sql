alter table verificationCodeTypes add isDeleted bit not null
----------
alter table verificationCodeTypes alter column isDeleted bit null
---------
select * from verificationCodeTypes