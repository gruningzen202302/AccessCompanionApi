delete from dbo.PermissionTypes
SELECT TOP (1000) [Id]
      ,[Description]
  FROM [dbo].[PermissionTypes]

select * from dbo.Permissions

ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_PermissionTypes_PermissionTypeId] FOREIGN KEY([PermissionTypeId])
REFERENCES [dbo].[PermissionTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_PermissionTypes_PermissionTypeId]
GO
