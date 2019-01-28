-- drop all tables under special schema
-- This will generate all the [DROP TABLE] statements for you and PRINT the SQL statement out.
---------------------------------------
/*
DECLARE @SqlStatement NVARCHAR(MAX);
SELECT @SqlStatement =
COALESCE(@SqlStatement, N'') + N'DROP TABLE [assadara_ssms_admin].' + QUOTENAME(TABLE_NAME) + N';' + CHAR(13)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = 'assadara_ssms_admin' and TABLE_TYPE = 'BASE TABLE';
PRINT @SqlStatement;
*/
Go
-- drop all constraints of all tables under special schema
-- This will generate all the [ALTER TABLE DROP CONSTRAINT] statements for you and PRINT the SQL statement out.
-------------------------------------------
/*
DECLARE @sql varchar(max);
SET @sql = N'';

SELECT @sql = @sql + N'
  ALTER TABLE ' + QUOTENAME(s.name) + N'.'
  + QUOTENAME(t.name) + N' DROP CONSTRAINT '
  + QUOTENAME(c.name) + ';'
FROM sys.objects AS c
INNER JOIN sys.tables AS t
ON c.parent_object_id = t.[object_id]
INNER JOIN sys.schemas AS s 
ON t.[schema_id] = s.[schema_id]
WHERE c.[type] IN ('D','C','F','PK','UQ')
AND s.name = 'assadara_ssms_admin'
ORDER BY c.[type];

PRINT @sql;
--EXEC sys.sp_executesql @sql;
*/
Go
-- drop temporal table Persons
------------------------------
/*
ALTER TABLE assadara_ssms_admin.Persons SET ( SYSTEM_VERSIONING = OFF )
DROP TABLE assadara_ssms_admin.Persons
DROP TABLE dbo.PersonsHistory
*/
GO