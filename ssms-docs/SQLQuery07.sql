SELECT *
FROM users
ORDER BY CURRENT_TIMESTAMP
OFFSET     6 ROWS      -- skip
FETCH NEXT 3 ROWS ONLY -- take

SELECT * FROM users ORDER BY CURRENT_TIMESTAMP OFFSET 6 ROWS FETCH NEXT 3 ROWS ONLY

update users set userTypeId = 2 where userId = '7788778877'

ALTER DATABASE assadara_ssms SET ENABLE_BROKER with rollback immediate

-- ================================
select * from countries
--=================================
insert into countries values (1 , 'السعودية' , 'Saudi Arabia',0)
insert into countries values (2 , 'مصر' , 'Egypt',0)
insert into countries values (3 , 'سوريا' , 'Syria',0)
insert into countries values (4 , 'الأردن', 'Jordan',0)
--===============================
delete from countries
--===============================
select * from schools
--===============================
insert into schools values (1 , 'نور الدين محمود' , 'Noor Eldeen Mahmoud',GETUTCDATE(),'this is the address.',0,0,0)
insert into schools values (2 , 'الصدارة' , 'assadara',GETUTCDATE(),'this is the address.',0,0,0)
--===============================

ALTER AUTHORIZATION ON DATABASE:: assadara_ssms TO sa