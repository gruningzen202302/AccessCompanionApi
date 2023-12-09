-- delete from dbo.PermissionTypes
use [sqldb-calendar-gps]
GO

SELECT *
from [dbo].[PermissionTypes]

insert into dbo.Permissions
  (PermissionTypeId,EmployeeForename,EmployeeSurname,PermissionDay)
--values (3, 'John', 'Doe', '2020-12-24')
values
  --(3, 'Susan', 'Smith', '2020-12-31')
--values 
(1, 'John', 'Doe', '2020-10-10')
,
(3, 'Susan', 'Smith', '2020-10-10')

select * from dbo.Permissions


-- ALTER TABLE [dbo].[Permissions]  WITH CHECK ADD  CONSTRAINT [FK_Permissions_PermissionTypes_PermissionTypeId] FOREIGN KEY([PermissionTypeId])
-- REFERENCES [dbo].[PermissionTypes] ([Id])
-- ON DELETE CASCADE
-- GO
-- ALTER TABLE [dbo].[Permissions] CHECK CONSTRAINT [FK_Permissions_PermissionTypes_PermissionTypeId]
-- GO

