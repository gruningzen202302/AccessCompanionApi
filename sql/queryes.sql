delete from dbo.PermissionTypes
SELECT TOP (1000) [Id]
      ,[Description]
  FROM [dbo].[PermissionTypes]

select * from dbo.Permissions