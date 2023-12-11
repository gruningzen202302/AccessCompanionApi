using AccessCompanionApi.Domain;
using System.Linq;

namespace AccessCompanionApi.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (context.PermissionTypes.ToList().Count == 0)
            {
                var permissionTypes = new PermissionType[]
                {
                    new()
                    {
                        Description = "Permission used by default when no other type is specified",
                        Permissions = new List<Permission>()
                    },
                    new()
                    {
                        Description = "Permission used to access the coworking area",
                        Permissions = new List<Permission>()
                    }
                };

                foreach (PermissionType p in permissionTypes)
                {
                    context.PermissionTypes.ToList().Add(p);
                }
                context.SaveChanges();
            }
        }
    }
}