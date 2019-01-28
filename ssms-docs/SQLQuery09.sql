/* table creation
CREATE TABLE Persons
(
  [PersonID] int NOT NULL PRIMARY KEY CLUSTERED,
  [Name] nvarchar(100) NOT NULL,
  [Position] varchar(100) NOT NULL,
  [Department] varchar(100) NOT NULL,
  [AnnualSalary] decimal (10,2) NOT NULL,
  [ValidFrom] datetime2 (2) GENERATED ALWAYS AS ROW START,
  [ValidTo] datetime2 (2) GENERATED ALWAYS AS ROW END,
  PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.PersonsHistory) );
*/
GO
/* insert rows
insert into Persons ([PersonID],[Name],[Position],[Department],[AnnualSalary])
values (1,'ahmady','dev','IT',75000);

insert into Persons ([PersonID],[Name],[Position],[Department],[AnnualSalary])
values (2,'Mohamdy','Ins','Edu',60000);

insert into Persons ([PersonID],[Name],[Position],[Department],[AnnualSalary])
values (3,'Wahba','Doc','Health',120000);
*/
GO
/* select
select * from Persons
select * from PersonsHistory
*/
GO
/* update and/or delete
update Persons set Department = 'R&D' where PersonID = 1
update Persons set Department = 'SMS' where PersonID = 2
update Persons set Department = 'DDT' where PersonID = 3
delete from Persons where PersonID = 1
*/
GO
/* select deleted row(s)
select top (1) * from PersonsHistory
where PersonID not in (select PersonID from Persons)
order by ValidTo desc
*/
GO